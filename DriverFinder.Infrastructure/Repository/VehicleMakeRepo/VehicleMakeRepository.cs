using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleMakeRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DriverFinder.Infrastructure.Repository.VehicleMakeRepo
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<VehicleMakeRepository> _logger;
        public VehicleMakeRepository(ApplicationDBContext context, ILogger<VehicleMakeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<VehicleMake>> GetAllVehicleMakes()
        {
            return await _context.VehicleMake.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<VehicleMake>> GetAllVehicleMakesByCategory(string Category)
        {
            return await _context.VehicleMake.AsNoTracking().Where(vm=>vm.Category.ToLower()==Category.ToLower()).ToListAsync();
        }

        public async Task<VehicleMake?> AddMake(VehicleMake NewMake)
        {
            try
            {
                await _context.VehicleMake.AddAsync(NewMake);
                await _context.SaveChangesAsync();
                return NewMake;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in {nameof(VehicleMake)}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsMakeExists(string MakesName)
        {
            return await _context.VehicleMake.AnyAsync(vm => vm.Make == MakesName);
        }
    }
}
