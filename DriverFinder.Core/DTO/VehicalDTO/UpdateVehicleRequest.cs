using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.DTO.VehicalDTO
{
    public class UpdateVehicleRequest
    {
        public Guid VehicleID { get; set; }
        public Guid SchoolID { get; set; }
        public Guid? vehicleMakeID { get; set; }
        public Guid? vehicleModelID { get; set; }
        public Guid vehicleBodyTypeID { get; set; }
        public Guid vehicleTransmissionID { get; set; }
        public string? VehicleTransmision { get; set; }
        public string? VehicleImageUrl { get; set; }
       
        public SchoolsVehicles ToSchoolVehical()
        {
            return new SchoolsVehicles
            {
                VehicleID = this.VehicleID,
                SchoolID = this.SchoolID,
                MakeID = this.vehicleMakeID,
                ModelID = this.vehicleModelID,
                BodyTypeID = this.vehicleBodyTypeID,
                TransmissionID = this.vehicleTransmissionID,
                
            };
        }
    }
}
