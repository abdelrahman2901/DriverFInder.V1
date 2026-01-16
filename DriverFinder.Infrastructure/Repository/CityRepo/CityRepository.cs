using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.ICityRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DriverFinder.Infrastructure.Repository.CityRepo
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<CityRepository> _logger;
        public CityRepository(ApplicationDBContext context, ILogger<CityRepository> logger)
        {
            _context = context;
            _logger = logger; 
        } 

        public async Task<City?> AddCity(City City)
        {
            try
            {
                await _context.City.AddAsync(City);
                await _context.SaveChangesAsync();
                return City;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(AddCity)}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteCity(City City)
        {
            try
            {
                _context.City.Remove(City);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteCity)}: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _context.City.AsNoTracking().ToListAsync();
        }

        public async Task<City?> GetCity(Guid id)
        {
            return await _context.City.AsNoTracking().FirstOrDefaultAsync(c => c.CityID == id);
        }

        public async Task<bool> IsCityExistsByName(string CityName)
        {
           return await _context.City.AnyAsync(c => c.CityName == CityName);    
        }
        public async Task<bool> IsCityExistsByID(Guid CityID)
        {
            return await _context.City.AnyAsync(c => c.CityID == CityID);
        }

        public async Task<City?> UpdateCity(City City)
        {
            try
            {
                _context.City.Update(City);
                await _context.SaveChangesAsync();
                return City;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(UpdateCity)}: {ex.Message}");
                return null;
            }
        }
    }
}
