using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;

namespace DriverFinder.Core.ServicesContracts.IVehicleDetailsViewServices
{
    public interface IVehicleDetailsViewService
    {
        public Task<Result<IEnumerable<VehicleDetailsView>>> GetVehiclesDetails();
        public Task<Result<IEnumerable<VehicleDetailsView>>> GetVehiclesDetailsBySchoolID(Guid SchoolID);

        public Task<Result<VehicleDetailsView>> GetVehicleDetailsByID(Guid VehicleID);

    }
}
