using DriverFinder.Core.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriverFinder.Core.Domain.Entites
{
    public class Notifications
    {
        [Key]
        public Guid NotificationID { get; set; }
        public Guid UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public ApplicationUser User { get; set; }
        public string Description { get; set; }
        public string icon { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool HasBeenRead { get; set; }
    }
}
