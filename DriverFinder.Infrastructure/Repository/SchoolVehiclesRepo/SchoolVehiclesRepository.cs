using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IVehiclesRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DriverFinder.Infrastructure.Repository.SchoolVehiclesRepo
{
    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<VehiclesRepository> _logger;
        

        public VehiclesRepository(ApplicationDBContext context, ILogger<VehiclesRepository>logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<SchoolsVehicles>> GetAllAsync()
        {
            return await _context.SchoolsVehicals.ToListAsync();
        }

        public async Task<SchoolsVehicles?> GetByIdAsync(Guid vehicleId)
        {
            return await _context.SchoolsVehicals
                .FirstOrDefaultAsync(v => v.VehicleID == vehicleId);
        }

        public async Task<IEnumerable<SchoolsVehicles>> GetBySchoolIdAsync(Guid schoolId)
        {
            return await _context.SchoolsVehicals
                .Where(v => v.SchoolID == schoolId)
                .ToListAsync();
        }

        public async Task<SchoolsVehicles?> AddAsync(SchoolsVehicles Newvehicle)
        {
            try
            {
                await _context.SchoolsVehicals.AddAsync(Newvehicle);
                await _context.SaveChangesAsync();
                return Newvehicle;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding new vehicle : {ex.Message}");
                return null;
            }
        }

        public async Task<SchoolsVehicles?> UpdateAsync(SchoolsVehicles Updatevehicle)
        {
            try
            {
                _context.SchoolsVehicals.Update(Updatevehicle);
                await _context.SaveChangesAsync();
                return Updatevehicle;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating vehicle : {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteAsync(SchoolsVehicles vehicle)
        {
            try
            {
                _context.SchoolsVehicals.Remove(vehicle);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting vehicle : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CheckImgExistance(string HashImg)
        {
            return await _context.SchoolsVehicals
                .AnyAsync(v => v.VehicleImageHash == HashImg);
        }
    }

}
