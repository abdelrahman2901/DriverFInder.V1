using DriverFinder.Core.Domain.EntitiesVIew;

namespace DriverFinder.Core.Domain.RepositoryContracts.IVehicleDetailsViewRepo
{
    public interface IVehicleDetailsViewRepository
    {
        Task<IEnumerable<VehicleDetailsView>> GetVehiclesDetails();
        Task<IEnumerable<VehicleDetailsView>> GetVehiclesDetailsBySchoolID(Guid SchoolID);
        Task<VehicleDetailsView?> GetVehicleDetailsByID(Guid VehicleID);

    }
}
