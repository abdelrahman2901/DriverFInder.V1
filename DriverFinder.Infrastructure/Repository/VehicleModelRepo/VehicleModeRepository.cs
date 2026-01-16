using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleModelRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DriverFinder.Infrastructure.Repository.VehicleModelRepo
{
    public class VehicleModeRepository : IVehicleModelRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<VehicleModeRepository> _logger;
        
        public VehicleModeRepository(ApplicationDBContext context,ILogger<VehicleModeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<VehicleModel>> GetAllVehicleModels()
        {
            return await _context.VehicleModel.AsNoTracking().ToListAsync();
        }
        public async Task<VehicleModel?> AddModel(VehicleModel NewModel)
        {
            try
            {
                await _context.VehicleModel.AddAsync(NewModel);
                await _context.SaveChangesAsync();
                return NewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in {nameof(VehicleModel)}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsModelExists(string ModelName)
        {
            return await _context.VehicleModel.AnyAsync(vm=>vm.Model==ModelName);
        }
    }
}
