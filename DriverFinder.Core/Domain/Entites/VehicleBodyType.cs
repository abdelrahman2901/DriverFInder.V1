using System.ComponentModel.DataAnnotations;

namespace DriverFinder.Core.Domain.Entites
{
    public class VehicleBodyType
    {
        [Key]
        public Guid BodyTypeID { get; set; }
        [Required(ErrorMessage = "BodyType is required")]
        public string BodyType { get; set; }
        [Required(ErrorMessage ="Category Is Required")]
        public string Category { get; set; }
    }
}
