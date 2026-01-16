using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IAreaRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DriverFinder.Infrastructure.Repository.AreaRepo
{
    public class AreaRepository : IAreaRepository
    {

        private readonly ApplicationDBContext _context;
        private readonly ILogger<AreaRepository> _logger;
        public AreaRepository(ApplicationDBContext context, ILogger<AreaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Area>> GetAllAreas()
        {
            return await _context.Area.AsNoTracking().ToListAsync();
        }

        public async Task<Area?> GetArea(Guid id)
        {
            return await _context.Area.AsNoTracking().FirstOrDefaultAsync(a => a.AreaID == id);
        }

        public async Task<bool> IsAreaExistsByName(string AreaName)
        {
            return await _context.Area.AnyAsync(c => c.AreaName == AreaName);
        }
        public async Task<bool> IsAreaExistsByID(Guid AreaID)
        {
            return await _context.Area.AnyAsync(c => c.AreaID == AreaID);

        }
        public async Task<Area?> AddArea(Area area)
        {
            try
            {
                await _context.Area.AddAsync(area);
                await _context.SaveChangesAsync();
                return area;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(AddArea)}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteArea(Area area)
        {

            try
            {
                _context.Area.Remove(area);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteArea)}: {ex.Message}");
                return false;
            }
        }



        public async Task<Area?> UpdateArea(Area area)
        {
            try
            {
                _context.Area.Update(area);
                await _context.SaveChangesAsync();
                return area;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(UpdateArea)}: {ex.Message}");
                return null;
            }
        }
    }
}
