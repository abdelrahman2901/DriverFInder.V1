using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.VehicalDTO.VehicleModelDTO;

namespace DriverFinder.Core.ServicesContracts.IVehicleModelServices
{
    public interface IVehicleModelServices
    {
        public Task<Result<IEnumerable<VehicleModelResponse>>> GetAllVehicleModels();
        public Task<Result<VehicleModelResponse>> AddModel(VehicleModelRequest NewModel);
    }
}
