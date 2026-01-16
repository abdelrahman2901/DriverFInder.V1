using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.RepositoryContracts.IAuthRepo;
using DriverFinder.Core.DTO.AuthDTO;
using DriverFinder.Core.DTO.LoginDTO;
using DriverFinder.Core.DTO.RegisterDTO;
using DriverFinder.Core.DTO.TokenDTO;
using DriverFinder.Core.Identity;
using DriverFinder.Core.ServicesContracts.IAuthServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;


namespace DriverFinder.Core.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _AuthRepo;
        public AuthService( IAuthRepository AuthRepo)
        {
            _AuthRepo = AuthRepo;
        }
        public async Task<Result<IEnumerable<ApplicationUser>>> GetAllUsers()
        {
           IEnumerable<ApplicationUser> users = await  _AuthRepo.GetAllUsers();
            if (users.Count() == 0)
            {
                return Result<IEnumerable<ApplicationUser>>.Failure("No users found.");
            }
            return Result<IEnumerable<ApplicationUser>>.Success(users);
        }

        public async Task<Result<AuthUserDetailsDTO>> GetUserDetailsByEmail(string email)
        {
            var UserDetailsResult = await _AuthRepo.GetUserDetailsByEmail(email);
            if (UserDetailsResult == null)
            {
                return Result<AuthUserDetailsDTO>.Failure("User not found.");
            }
            return Result<AuthUserDetailsDTO>.Success(UserDetailsResult);
        }

        public async Task<Result<AuthUserDetailsDTO>> GetUserDetailsByID(string userid)
        {
           var userDetaulsResult= await _AuthRepo.GetUserDetailsByID(userid);
            if (userDetaulsResult == null)
            {
                return Result<AuthUserDetailsDTO>.Failure("User not found.");
            }
            return Result<AuthUserDetailsDTO>.Success(userDetaulsResult);
        }

        public async Task<bool> IsEmailAlreadyRegister(string Email)
        {
            return await _AuthRepo.IsEmailAlreadyRegister(Email);
        }

        public async Task<Result<AuthTokenResponse>> Login(LoginRequest Login)
        {
            return await _AuthRepo.Login(Login);
        }

        public async Task<Result<AuthTokenResponse>> RefreshToken([FromBody] TokenModelDTO tokenModel)
        {
            return await _AuthRepo.RefreshToken(tokenModel);
        }

        public async Task<Result<AuthTokenResponse>> RegisterUser(UserRegisterRequest Register)
        {

            if(await _AuthRepo.IsEmailAlreadyRegister(Register.Email))
            {
                return Result<AuthTokenResponse>.Failure("Email Already Registered");
            }
            return await _AuthRepo.RegisterUser(Register);
        }

        public async Task<Result<bool>> SignOut()
        {
          var result=await _AuthRepo.SignOut();
            if (!result)
            {
                return Result<bool>.Failure("Failed to SignOut User");
            }
            return Result<bool>.Success(result);
        }

        
    }
}
