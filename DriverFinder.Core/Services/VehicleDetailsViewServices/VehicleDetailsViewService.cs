using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleDetailsViewRepo;
using DriverFinder.Core.ServicesContracts.IVehicleDetailsViewServices;

namespace DriverFinder.Core.Services.VehicleDetailsViewServices
{
    public class VehicleDetailsViewService : IVehicleDetailsViewService
    {
        private readonly IVehicleDetailsViewRepository _vehicleDetailsViewRepo;
        public VehicleDetailsViewService(IVehicleDetailsViewRepository vehicleDetailsViewRepo)
        {
            _vehicleDetailsViewRepo = vehicleDetailsViewRepo;
        }
       public async Task<Result<IEnumerable<VehicleDetailsView>>> GetVehiclesDetails()
        {
            var VehiclesDetails = await _vehicleDetailsViewRepo.GetVehiclesDetails();
            if (VehiclesDetails.Count() == 0)
            {
                return Result<IEnumerable<VehicleDetailsView>>.Failure("No Vehicles Was Found");
            }

            return Result<IEnumerable<VehicleDetailsView>>.Success(VehiclesDetails);
        }
        public async Task<Result<IEnumerable<VehicleDetailsView>>> GetVehiclesDetailsBySchoolID(Guid SchoolID)
        {
            var VehiclesDetails = await _vehicleDetailsViewRepo.GetVehiclesDetailsBySchoolID(SchoolID);
            if (VehiclesDetails.Count() == 0)
            {
                return Result<IEnumerable<VehicleDetailsView>>.Failure("No Vehicles For That SChool Was Found");
            }

            return Result<IEnumerable<VehicleDetailsView>>.Success(VehiclesDetails);
        }

        public async Task<Result<VehicleDetailsView>> GetVehicleDetailsByID(Guid VehicleID)
        {
            var VehiclesDetails = await _vehicleDetailsViewRepo.GetVehicleDetailsByID(VehicleID);
            if (VehiclesDetails == null)
            {
                return Result<VehicleDetailsView>.Failure("No Vehicles Was Found");
            }

            return Result<VehicleDetailsView>.Success(VehiclesDetails);
        }

    }
}
