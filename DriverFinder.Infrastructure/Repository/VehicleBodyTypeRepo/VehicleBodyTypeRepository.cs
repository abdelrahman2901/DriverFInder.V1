using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleBodyTypeRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.Infrastructure.Repository.VehicleBodyTypeRepo
{
    public class VehicleBodyTypeRepository : IVehicleBodyTypeRepository
    {
        private readonly ApplicationDBContext _context;
        public VehicleBodyTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleBodyType>> GetAllVehicleBodyTypes()
        {
            return await _context.VehicleBodyType.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<VehicleBodyType>> GetAllVehicleBodyTypesByCategory(string Category)
        {
            return await _context.VehicleBodyType.AsNoTracking().Where(vb=>vb.Category.ToLower()==Category.ToLower()).ToListAsync();

        }
    }
}
