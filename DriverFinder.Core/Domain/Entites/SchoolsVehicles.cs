using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriverFinder.Core.Domain.Entites
{
    public class SchoolsVehicles
    {
        [Key]
        public Guid VehicleID { get; set; }

        [Required(ErrorMessage = "Driving School ID is required")]
        public Guid SchoolID { get; set; }
        [ForeignKey(nameof(SchoolID))]
        public DrivingSchool? School { get; set; }

        [Required(ErrorMessage = "Vehicle Make is required")]
        public Guid? MakeID { get; set; }
        [ForeignKey(nameof(MakeID))]
        public VehicleMake VehicleMake { get; set; }

        public Guid? ModelID { get; set; }
        [ForeignKey(nameof(ModelID))]
        public VehicleModel? VehicleModel { get; set; }

        [Required(ErrorMessage = "Vehical BodyTypeID is required")]
        public Guid BodyTypeID { get; set; }
        [ForeignKey(nameof(BodyTypeID))]
        public VehicleBodyType VehicleBodyType { get; set; }

        [Required(ErrorMessage = "Vehical TransmisionID is required")]
        public Guid TransmissionID { get; set; }
        [ForeignKey(nameof(TransmissionID))]
        public VehicleTransmission? VehicleTransmision { get; set; }

        public string? VehicleImageUrl { get; set; }
        public string? VehicleImageHash { get; set; }
        public bool IsActive { get; set; }
    }
}
