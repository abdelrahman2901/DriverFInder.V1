using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.Domain.RepositoryContracts.IVehicleBodyTypeRepo
{
    public interface IVehicleBodyTypeRepository
    {
        public Task<IEnumerable<VehicleBodyType>> GetAllVehicleBodyTypes();
        public Task<IEnumerable<VehicleBodyType>> GetAllVehicleBodyTypesByCategory(string Category);
    }
}
