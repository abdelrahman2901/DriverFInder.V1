using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.DTO.VehicalDTO.VehicleMakeDTO
{
    public class VehicleMakeRequest
    {
        public string Make { get; set; }
        public string Category { get; set; }
        public VehicleMake toVehicleMake()
        {
            return new VehicleMake() {MakeID=Guid.NewGuid(),Make=this.Make ,Category=this.Category};
        }
    }
}
