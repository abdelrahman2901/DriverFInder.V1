using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.Domain.RepositoryContracts.IVehiclesRepo
{
    public interface IVehiclesRepository
    {
        Task<IEnumerable<SchoolsVehicles>> GetAllAsync();
        Task<SchoolsVehicles?> GetByIdAsync(Guid vehicleId);
        Task<IEnumerable<SchoolsVehicles>> GetBySchoolIdAsync(Guid schoolId);
        Task<SchoolsVehicles> AddAsync(SchoolsVehicles vehicle);
        Task<SchoolsVehicles> UpdateAsync(SchoolsVehicles vehicle);
        Task<bool> DeleteAsync(SchoolsVehicles vehicle);
        Task<bool> CheckImgExistance(string HashImg);

    }
}
