using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.AuthDTO;
using DriverFinder.Core.DTO.LoginDTO;
using DriverFinder.Core.DTO.RegisterDTO;
using DriverFinder.Core.DTO.TokenDTO;
using DriverFinder.Core.Identity;
using System;

namespace DriverFinder.Core.ServicesContracts.IAuthServices
{
    public interface IAuthService
    {
        public  Task<Result<IEnumerable<ApplicationUser>>> GetAllUsers();
        public  Task<Result<AuthUserDetailsDTO>> GetUserDetailsByID(string userid);
        public  Task<Result<AuthUserDetailsDTO>> GetUserDetailsByEmail(string email);
        public  Task<Result<AuthTokenResponse>> RegisterUser(UserRegisterRequest Register);
        public  Task<Result<AuthTokenResponse>> Login(LoginRequest Login);
        public  Task<Result<bool>> SignOut();
        public  Task<Result<AuthTokenResponse>> RefreshToken( TokenModelDTO tokenModel);
        public Task<bool> IsEmailAlreadyRegister(string Email);

    }
}
