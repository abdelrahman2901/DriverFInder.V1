using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.AuthDTO;
using DriverFinder.Core.DTO.LoginDTO;
using DriverFinder.Core.DTO.RegisterDTO;
using DriverFinder.Core.DTO.TokenDTO;
using DriverFinder.Core.Identity;
using System;


namespace DriverFinder.Core.Domain.RepositoryContracts.IAuthRepo
{
    public interface IAuthRepository
    {
        public Task<IEnumerable<ApplicationUser>> GetAllUsers();
        public Task<AuthUserDetailsDTO> GetUserDetailsByID(string userid);
        public Task<AuthUserDetailsDTO> GetUserDetailsByEmail(string email);
        public Task<Result<AuthTokenResponse>> RegisterUser(UserRegisterRequest Register);
        public Task<Result<AuthTokenResponse>> Login(LoginRequest Login);
        public Task<bool> SignOut();
        public Task<Result<AuthTokenResponse>> RefreshToken( TokenModelDTO tokenModel);
        public Task<bool> IsEmailAlreadyRegister(string Email);

    }
}
