using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleTransmissionRepo;
using DriverFinder.Core.DTO.VehicalDTO.VehicleTransmissionDTO;
using DriverFinder.Core.ServicesContracts.IVehicleTransmissionServices;

namespace DriverFinder.Core.Services.VehicleTransmissionServices
{
    public class VehicleTransmissionService : IVehicleTransmissionServices
    {
        private readonly IVehicleTransmissionRepository _VehicleTransmissionRepo;

        public VehicleTransmissionService(IVehicleTransmissionRepository vehicleTransmissionRepo)
        {
            _VehicleTransmissionRepo = vehicleTransmissionRepo;
        }

        public async Task<Result<IEnumerable<VehicleTransmissionResponse>>> GetAllVehicleTransmissions()
        {
            IEnumerable<VehicleTransmission> transmissions= await _VehicleTransmissionRepo.GetAllVehicleTransmissions();
            if (transmissions.Count() == 0)
            {
                return Result<IEnumerable<VehicleTransmissionResponse>>.Failure("no transmission was found.");
            }
            return Result<IEnumerable<VehicleTransmissionResponse>>.Success(transmissions.Select(t=>t.ToTransmissionResponse()).ToList());
        }
    }
}
