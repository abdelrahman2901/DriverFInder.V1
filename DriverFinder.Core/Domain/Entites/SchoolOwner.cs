using DriverFinder.Core.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace DriverFinder.Core.Domain.Entites
{
    public class SchoolOwner
    {
        [Key]
        public Guid OwnerID { get; set; }
        [Required()]
        public Guid UserID { get; set; }
        [Required(ErrorMessage ="Name Cant Be Empty")]
        public string? OwnerName { get; set; }
        [ForeignKey(nameof(UserID))]
        public ApplicationUser User { get; set; }
        

    }
}
