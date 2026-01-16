using DriverFinder.Core.Identity;
using System;


namespace DriverFinder.Core.DTO.AuthDTO
{
    public class AuthUserDetailsDTO
    {

        public Guid userID { get; set; }
          public string?  userEmail { get; set; }
          public string?  userName { get; set; }
          public string?  personName { get; set; }
          public string? role { get; set; }

        

        }
    public static class AuthUserDetailsDTOExtensions
    {
        public static AuthUserDetailsDTO ToAuthUserDetailsDTO(this ApplicationUser user, string role)
        {
            return new AuthUserDetailsDTO
            {
                userID = user.Id,
                userEmail = user.Email,
                userName = user.UserName,
                personName=user.PersonName,
                role = role,

            };
        }
    }
}
