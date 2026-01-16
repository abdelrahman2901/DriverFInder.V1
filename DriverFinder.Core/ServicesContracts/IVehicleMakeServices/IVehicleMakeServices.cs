using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.DTO.VehicalDTO.VehicleMakeDTO;

namespace DriverFinder.Core.ServicesContracts.IVehicleMakeServices
{
    public interface IVehicleMakeServices
    {
        public Task<Result<IEnumerable<VehicleMakeResponse>>> GetAllVehicleMakes();
        public Task<Result<IEnumerable<VehicleMakeResponse>>> GetAllVehicleMakesByCategory(string Category);
        public Task<Result<VehicleMakeResponse>> AddMake(VehicleMakeRequest NewMake);
    }
}
