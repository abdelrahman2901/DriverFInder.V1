using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleTransmissionRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.Infrastructure.Repository.VehicleTransmissionRepo
{
    public class VehicleTransmissionRepository:IVehicleTransmissionRepository
    {
        private readonly ApplicationDBContext _context;
        public VehicleTransmissionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VehicleTransmission>> GetAllVehicleTransmissions()
        {
            return await _context.VehicleTransmission.AsNoTracking().ToListAsync();
        }
    }
}
