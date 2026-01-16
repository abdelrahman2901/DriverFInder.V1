using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.DTO.VehicalDTO
{
    public class VehicleRequests
    {
        public Guid SchoolID { get; set; }
        public Guid? VehicleMakeID { get; set; }
        public Guid? VehicleModelID { get; set; }
        public Guid VehicleBodyTypeID { get; set; }
        public Guid VehicleTransmissionID { get; set; }


        public SchoolsVehicles ToSchoolVehical()
        {
            return new SchoolsVehicles
            {
                VehicleID = Guid.NewGuid(),
                SchoolID = this.SchoolID,
                MakeID = this.VehicleMakeID,
                ModelID = this.VehicleModelID,
                BodyTypeID = this.VehicleBodyTypeID,
                TransmissionID = this.VehicleTransmissionID
                ,
                IsActive = true
            };
        }
    }
}
