using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.RepositoryContracts.IAuthRepo;
using DriverFinder.Core.DTO.AuthDTO;
using DriverFinder.Core.DTO.LoginDTO;
using DriverFinder.Core.DTO.RegisterDTO;
using DriverFinder.Core.DTO.TokenDTO;
using DriverFinder.Core.Identity;
using DriverFinder.Core.ServicesContracts.IJwtService;
using DriverFinder.Core.ServicesContracts.IUserActivityServices;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DriverFinder.Infrastructure.Repository.AuthRepo
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _RoleManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly ApplicationDBContext _context;
        private readonly IUserActivityService _userActivityService;
        private readonly IJwtToken _JwtService;
        public AuthRepository(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDBContext context, IJwtToken JwtService

            , IUserActivityService userActivity)
        {
            _userManager = userManager;
            _RoleManager = roleManager;
            _SignInManager = signInManager;
            _context = context;
            _JwtService = JwtService;

            _userActivityService = userActivity;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<AuthUserDetailsDTO?> GetUserDetailsByEmail(string email)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);

            return user.ToAuthUserDetailsDTO(roles.FirstOrDefault() ?? "");
        }

        public async Task<AuthUserDetailsDTO?> GetUserDetailsByID(string userid)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);
            AuthUserDetailsDTO userDetailsDTO = user.ToAuthUserDetailsDTO(roles.FirstOrDefault() ?? "");
            return userDetailsDTO;
        }

        public async Task<Result<AuthTokenResponse>> Login(LoginRequest Login)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(Login.Email);

            if (user == null)
            {
                return Result<AuthTokenResponse>.Failure("Email Doesnt Exists , Create New Account");
            }

            var result = await _SignInManager.PasswordSignInAsync(Login.Email, Login.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Result<AuthTokenResponse>.Failure($"invalid Email or Password");
            }

            await _SignInManager.SignInAsync(user, isPersistent: false);
            await _userActivityService.LogUserActivity(user.Id, "Login");

            Result<AuthTokenResponse> authresponse = await _JwtService.CreateJwtToken(user);
            user.RefreshToken = authresponse.Data.RefreshToken;
            user.RefreshTokenExpirationDateTime = authresponse.Data.RefreshTokenExpirationDateTime;

            var roles = await _userManager.GetRolesAsync(user);
            authresponse.Data.role = roles.FirstOrDefault();

            await _userManager.UpdateAsync(user);

            return Result<AuthTokenResponse>.Success(authresponse.Data);
        }

        public async Task<Result<AuthTokenResponse>> RefreshToken(TokenModelDTO tokenModel)
        {
            Result<ClaimsPrincipal?> principal = _JwtService.GetPrincipalFromJwtToken(tokenModel.token);
            if (principal == null)
            {
                return Result<AuthTokenResponse>.Failure("Invalid jwt access token");
            }

            string? email = principal.Data?.FindFirstValue(ClaimTypes.Email);

            ApplicationUser? user = await _userManager.FindByEmailAsync(email);

            if (user == null || user.RefreshToken != tokenModel.refreshToken || user.RefreshTokenExpirationDateTime <= DateTime.UtcNow)
            {
                return Result<AuthTokenResponse>.Failure("Invalid refresh token");
            }

            Result<AuthTokenResponse> authenticationResponse = await _JwtService.CreateJwtToken(user);
            var refreshUser = await _context.Users.FindAsync(user.Id);
            refreshUser.RefreshToken = authenticationResponse.Data?.RefreshToken;
            refreshUser.RefreshTokenExpirationDateTime = authenticationResponse.Data.RefreshTokenExpirationDateTime;


            try
            {
                _context.Users.Update(refreshUser);
                var result = await _context.SaveChangesAsync();
                return Result<AuthTokenResponse>.Success(authenticationResponse.Data);
            }
            catch (Exception ex)
            {
                return Result<AuthTokenResponse>.Failure(ex.Message);
            }
        }

        public async Task<Result<AuthTokenResponse>> RegisterUser(UserRegisterRequest Register)
        {
            ApplicationUser user = Register.ToApplicationUser();

            var result = await _userManager.CreateAsync(user, Register.Password);

            if (!result.Succeeded)
            {
                return Result<AuthTokenResponse>.Failure("Failed To Create User");
            }

            await _SignInManager.SignInAsync(user, isPersistent: false);

            var roleresult = await _userManager.AddToRoleAsync(user, "User");

            if (!roleresult.Succeeded)
            {
                return Result<AuthTokenResponse>.Failure("Failed To Add Role To The User");
            }

            Result<AuthTokenResponse> authresponse = await _JwtService.CreateJwtToken(user);
            user.RefreshToken = authresponse.Data.RefreshToken;
            user.RefreshTokenExpirationDateTime = authresponse.Data.RefreshTokenExpirationDateTime;
            await _userManager.UpdateAsync(user);
            authresponse.Data.role = "User";
            await _userActivityService.LogUserActivity(user.Id, "Register");

            return Result<AuthTokenResponse>.Success(authresponse.Data);
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await _SignInManager.SignOutAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> IsEmailAlreadyRegister(string Email)
        {
            return await _userManager.FindByEmailAsync(Email) != null;
        }

    }
}
