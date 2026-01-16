using DriverFinder.Core.DTO.AuthDTO;
using DriverFinder.Core.DTO.LoginDTO;
using DriverFinder.Core.DTO.RegisterDTO;
using DriverFinder.Core.DTO.TokenDTO;
using DriverFinder.Core.Identity;
using DriverFinder.Core.ServicesContracts.IAuthServices;
using DriverFinder.Core.Validation.AuthValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DriverFinder.UI.Controllers.AuthControl
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly LoginRequestValidation _LoginRequestValidator;
        private readonly RegisterRequestValidation _RegisterRequestValidator;

        public AuthController(IAuthService authService, LoginRequestValidation LoginRequestValidator, RegisterRequestValidation RegisterRequestValidator)
        {
            _authService = authService;
            _LoginRequestValidator = LoginRequestValidator;
            _RegisterRequestValidator = RegisterRequestValidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllUsers()
        {

            var users = await _authService.GetAllUsers();
            if (!users.IsSuccess)
            {
                return Problem(users.ErrorMessage);
            }
            return Ok(users.Data);
        }

        [HttpGet("GetUserDetailsByID")]
        public async Task<ActionResult<AuthUserDetailsDTO>> GetUserDetailsByID(string userid)
        {

            var UserDetails = await _authService.GetUserDetailsByID(userid);
            if (!UserDetails.IsSuccess)
            {
                return Problem(UserDetails.ErrorMessage);
            }
            return Ok(UserDetails.Data);
        }

        [HttpGet("GetUserDetailsByEmail")]
        public async Task<ActionResult> GetUserDetailsByEmail(string email)
        {

            var UserDetails = await _authService.GetUserDetailsByEmail(email);
            if (!UserDetails.IsSuccess)
            {
                return Problem(UserDetails.ErrorMessage);
            }
            return Ok(UserDetails.Data);

        }


        /// <summary>
        /// Registers a new user account using the specified registration details.
        /// </summary>
        /// <remarks>The registration request must provide valid user details. If the registration is
        /// successful, the user is automatically signed in. Validation errors or registration failures will result in
        /// an error response.</remarks>
        /// <param name="Register">An object containing the user's registration information, including email, name, and phone number. Cannot be
        /// null.</param>
        /// <returns>An <see cref="IActionResult"/> that represents the result of the registration operation. Returns <see
        /// cref="OkObjectResult"/> with the created user on success, or a problem response if registration fails.</returns>
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(UserRegisterRequest Register)
        {
            var result = await _RegisterRequestValidator.ValidateAsync(Register);
            if (!result.IsValid)
            {
                var errors = string.Join("\n", result.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            var Response = await _authService.RegisterUser(Register);
            if (!Response.IsSuccess)
            {
                return Problem(Response.ErrorMessage);
            }
            return Ok(Response.Data);
        }

        /// <summary>
        /// Attempts to authenticate a user with the provided login credentials.
        /// </summary>
        /// <param name="Login">An object containing the user's email address and password used for authentication. Must not be null and
        /// must contain valid values.</param>
        /// <returns>An <see cref="IActionResult"/> that represents the result of the login attempt. Returns <see
        /// cref="OkObjectResult"/> with the authenticated user if successful; otherwise, returns a problem response
        /// describing the error.</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest Login)
        {
            var result = await _LoginRequestValidator.ValidateAsync(Login);
            if (!result.IsValid)
            {
                var errors = string.Join("\n", result.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            var authresponse = await _authService.Login(Login);
            if (!authresponse.IsSuccess)
            {
                return Problem(authresponse.ErrorMessage);
            }

            return Ok(authresponse.Data);
        }

        /// <summary>
        /// Signs out the currently authenticated user and ends their session.
        /// </summary>
        /// <returns>A result indicating that the sign-out operation completed successfully. Returns a 204 No Content response.</returns>
        [HttpGet("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            var signoutResult = await _authService.SignOut();
            if (!signoutResult.IsSuccess)
            {
                return Problem(signoutResult.ErrorMessage);
            }
            return Ok(JsonSerializer.Serialize("user LogedOut Successfully"));
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenModelDTO tokenModel)
        {
            if (tokenModel == null || tokenModel.token == null || tokenModel.refreshToken == null)
            {
                return BadRequest("Invalid client request");
            }

            var RefreshResponse = await _authService.RefreshToken(tokenModel);
            if (!RefreshResponse.IsSuccess)
            {
                return Problem(RefreshResponse.ErrorMessage);
            }

            return Ok(RefreshResponse.Data);
           
        }
 
    }
}
