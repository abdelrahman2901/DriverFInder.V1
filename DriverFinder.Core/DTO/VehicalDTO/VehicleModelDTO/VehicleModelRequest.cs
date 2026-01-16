using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.DTO.VehicalDTO.VehicleModelDTO
{
    public class VehicleModelRequest
    {
     
        public Guid MakeID { get; set; }
        public string Model { get; set; }

        public VehicleModel ToVehicleModel()
        {
            return new VehicleModel()
            {
                ModelID = Guid.NewGuid(),
                MakeID = this.MakeID,
                Model = this.Model
            };
        }
    }
}
