using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.DTO.VehicalDTO.VehicleModelDTO
{
    public class VehicleModelResponse
    {
        public Guid ModelID { get; set; }
        public Guid MakeID { get; set; }
        public string Model { get; set; }

    }
    public static class VehicleModelExtensions
    {
        public static VehicleModelResponse ToVehicleModelResponse(this VehicleModel Model)
        {
            return new VehicleModelResponse() { MakeID = Model.MakeID, ModelID = Model.ModelID, Model = Model.Model };
        }
    }
}
