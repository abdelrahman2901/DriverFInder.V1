using System.ComponentModel.DataAnnotations;

namespace DriverFinder.Core.Domain.Entites
{
    public class VehicleMake
    {
        [Key]
        public Guid MakeID { get; set; }
        [Required(ErrorMessage = "Make is required")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Make Type is required")]
        public string Category { get; set; }
    }
}
