

using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.Domain.RepositoryContracts.IAreaRepo
{
    public interface IAreaRepository
    {
        public Task<IEnumerable<Area>> GetAllAreas();
        public Task<Area?> GetArea(Guid id);
        public Task<Area?> UpdateArea(Area area);
        public Task<Area?> AddArea(Area area);
        public Task<bool> DeleteArea(Area area);
        public Task<bool> IsAreaExistsByName(string AreaName);
        public Task<bool> IsAreaExistsByID(Guid AreaID);
    }
}
