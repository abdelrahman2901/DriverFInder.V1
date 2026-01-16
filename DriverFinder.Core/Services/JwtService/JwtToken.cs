using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.AuthDTO;
using DriverFinder.Core.Identity;
using DriverFinder.Core.ServicesContracts.IJwtService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace DriverFinder.Core.Services.JwtService
{
    public class JwtToken : IJwtToken
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<JwtToken> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public JwtToken(IConfiguration configuration,ILogger<JwtToken> logger,UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<Result<AuthTokenResponse>> CreateJwtToken(ApplicationUser user)
        {
            double tokenexpireMinutes = Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]);


             DateTime expiration = DateTime.UtcNow.AddMinutes(tokenexpireMinutes);
            _logger.LogInformation($"expiration of the token after : {tokenexpireMinutes}  date: : {expiration}");
            var Roles = await _userManager.GetRolesAsync(user);
            var userRole = Roles.FirstOrDefault();
            

            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Email),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.PersonName),
                new Claim(ClaimTypes.Role,userRole),
            };
          

            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            SigningCredentials credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken tokenGen = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],claims
                ,expires:expiration,signingCredentials:credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
           string token=  handler.WriteToken(tokenGen);

            double RefreshTokenexpireDays = Convert.ToDouble(_configuration["RefreshToken:EXPIRATION_DAYS"]);
            DateTime RefreshTokenExpiration = DateTime.UtcNow.AddDays(RefreshTokenexpireDays);
            _logger.LogInformation($"expiration of the Refreshtoken after : {RefreshTokenexpireDays} date : {RefreshTokenExpiration}");

            return Result<AuthTokenResponse>.Success(new AuthTokenResponse()
            {
                PersonName = user.PersonName,
                Email = user.Email,
                Token = token,
                Expiration = expiration,
                RefreshToken = GenerateRefreshToken(),
                RefreshTokenExpirationDateTime = RefreshTokenExpiration
            });
        }

        public Result<ClaimsPrincipal?> GetPrincipalFromJwtToken(string? token)
        {
            TokenValidationParameters validators = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])) ,
                ValidateLifetime =false,
                RoleClaimType=ClaimTypes.Role,
               
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = handler.ValidateToken(token, validators, out SecurityToken securityToken);

            if (securityToken is  not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("invalid token");
            }

            return Result<ClaimsPrincipal?>.Success(principal);
        }

private string GenerateRefreshToken()
        {
            byte[] bytes = new byte[64];
            var randomNumber =  RandomNumberGenerator.Create();
            randomNumber.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
