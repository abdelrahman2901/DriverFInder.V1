using DriverFinder.Core.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace DriverFinder.Core.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? PersonName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationDateTime { get; set; }
        public bool? isblocked { get; set; } = false;


        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<Notifications> Notifications { get; set; }
    }
}
