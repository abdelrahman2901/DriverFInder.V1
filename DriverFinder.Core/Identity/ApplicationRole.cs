using Microsoft.AspNetCore.Identity;
using System;


namespace DriverFinder.Core.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
      public  string? Description { get; set; }
    }
}
