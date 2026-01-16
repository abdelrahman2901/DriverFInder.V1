using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.DTO.VehicalDTO
{
    public class VehicleResponse
    {
        public Guid VehicleID { get; set; }
        public Guid SchoolID { get; set; }
        public Guid? VehicleMakeID { get; set; }
        public Guid? VehicleModelID { get; set; }
        public Guid VehicleBodyTypeID { get; set; }
        public Guid VehicleTransmissionID { get; set; }
        public string? VehicleImageUrl { get; set; }

    }
    public static class VehicalResponseExtensions
    {
        public static VehicleResponse ToVehicalResponse(this SchoolsVehicles vehical)
        {
            return new VehicleResponse
            {
                VehicleID = vehical.VehicleID,
                SchoolID = vehical.SchoolID,
                VehicleMakeID = vehical.MakeID,
                VehicleModelID = vehical.ModelID,
                VehicleBodyTypeID = vehical.BodyTypeID,
                VehicleTransmissionID = vehical.TransmissionID,
                VehicleImageUrl = vehical.VehicleImageUrl
            };
        }
    }
}
