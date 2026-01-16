using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.VehicalDTO.VehicleTransmissionDTO;

namespace DriverFinder.Core.ServicesContracts.IVehicleTransmissionServices
{
    public interface IVehicleTransmissionServices
    {
        public Task<Result<IEnumerable<VehicleTransmissionResponse>>> GetAllVehicleTransmissions();
    }
}
