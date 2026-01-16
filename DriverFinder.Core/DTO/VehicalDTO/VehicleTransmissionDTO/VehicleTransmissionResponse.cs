using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.DTO.VehicalDTO.VehicleTransmissionDTO
{
    public class VehicleTransmissionResponse
    {
        public Guid TransmissionID { get; set; }
        public string Transmission { get; set; }
    }
    public static class TransmissionExtensions
    {
        public static VehicleTransmissionResponse ToTransmissionResponse(this VehicleTransmission transmission)
        {
            return new VehicleTransmissionResponse() { TransmissionID = transmission.TransmissionID, Transmission = transmission.Transmission };
        }
    }
}
