using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.DTO.VehicalDTO.VehicleMakeDTO
{
    public class VehicleMakeResponse
    {
        public Guid MakeID { get; set; }
        public string Make { get; set; }
        public string Category { get; set; }
    }
    public static class VehilceMakeExtensions
    {
        public static VehicleMakeResponse ToVehicleResponse(this VehicleMake vehicleMake)
        {
            return new VehicleMakeResponse() { MakeID = vehicleMake.MakeID, Make = vehicleMake.Make, Category = vehicleMake.Category };
        }
    }
}
