using DriverFinder.Core.DTO.AuthDTO;
using DriverFinder.Core.Identity;
using System.Security.Claims;
using DriverFinder.Core.Domain.Common;
using System;

namespace DriverFinder.Core.ServicesContracts.IJwtService
{
    public interface IJwtToken
    {
        Task<Result<AuthTokenResponse>> CreateJwtToken(ApplicationUser user);
        Result<ClaimsPrincipal?> GetPrincipalFromJwtToken(string? token);
    }
}
