using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.Domain.RepositoryContracts.IVehicleModelRepo
{
    public interface IVehicleModelRepository
    {
        public Task<IEnumerable<VehicleModel>> GetAllVehicleModels();
        public Task<VehicleModel> AddModel(VehicleModel NewModel);
        public Task<bool> IsModelExists(string ModelName);

    }
}
