using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleDetailsViewRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.Infrastructure.Repository.VehicleDetailsViewRepo
{
    public class VehicleDetailsViewRepository : IVehicleDetailsViewRepository
    {
        private readonly ApplicationDBContext _context;
        public VehicleDetailsViewRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VehicleDetailsView>> GetVehiclesDetails()
        {
            return await _context.VehicleDetailsVew.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<VehicleDetailsView>> GetVehiclesDetailsBySchoolID(Guid SchoolID)
        {
            return await _context.VehicleDetailsVew.AsNoTracking().Where(vdw=>vdw.SchoolID==SchoolID).ToListAsync();
        }
        public async Task<VehicleDetailsView?> GetVehicleDetailsByID(Guid VehicleID)
        {
            return await _context.VehicleDetailsVew.AsNoTracking().FirstOrDefaultAsync(vdw => vdw.VehicleID == VehicleID);
        }
    }
}
