using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.Domain.RepositoryContracts.IVehicleMakeRepo
{
    public interface IVehicleMakeRepository
    {
        public Task<IEnumerable<VehicleMake>> GetAllVehicleMakes();
        public Task<IEnumerable<VehicleMake>> GetAllVehicleMakesByCategory(string Category);

        public Task<VehicleMake> AddMake(VehicleMake NewMake);
        public Task<bool> IsMakeExists(string MakesName);
    }
}
