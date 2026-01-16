using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolProgramsViewRepo;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace DriverFinder.Infrastructure.Repository.SchoolProgramsViewRepo
{
    public class SchoolProgramsViewRepoisotry : ISchoolProgramsViewRepository
    {
        private readonly ApplicationDBContext _context;
        public SchoolProgramsViewRepoisotry(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SchoolProgramsView>> GetAllSchoolProgramsView(Guid SchoolID)
        {
            return await _context.SchoolProgramsView.AsNoTracking()
                .Where(spv => spv.SchoolID == SchoolID)
                .ToListAsync();
        }

        public  async Task<IEnumerable<SchoolProgramsView>> GetAllSchoolsProgramsView()
        {
            return await _context.SchoolProgramsView.AsNoTracking().ToListAsync();
        }
        public async Task<SchoolProgramsView?> GetSchoolProgramsDetailsByID(Guid ProgramID)
        {
            return await _context.SchoolProgramsView.AsNoTracking().FirstOrDefaultAsync(sp => sp.SchoolProgramID == ProgramID);
        }

    }
}
