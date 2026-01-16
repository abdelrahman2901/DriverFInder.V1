using System.ComponentModel.DataAnnotations;

namespace DriverFinder.Core.Domain.Entites
{
    public class VehicleTransmission
    {
        [Key]
        public Guid TransmissionID { get; set; }
        [Required(ErrorMessage = "Transmission is required")]
        public string Transmission { get; set; }
    }
}
