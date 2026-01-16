using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.Domain.RepositoryContracts.IVehicleTransmissionRepo
{
    public interface IVehicleTransmissionRepository
    {
        public Task<IEnumerable<VehicleTransmission>> GetAllVehicleTransmissions();
    }
}
