using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.VehicalDTO.VehicleBodyTypeDTO;

namespace DriverFinder.Core.ServicesContracts.IVehicleBodyTypeServices
{
    public interface IVehicleBodyTypeServices
    {
        public Task<Result<IEnumerable<VehicleBodyTypeResponse>>> GetAllVehicleBodyTypes();
        public Task<Result<IEnumerable<VehicleBodyTypeResponse>>> GetAllVehicleBodyTypesByCategory(string Category);

    }
}
