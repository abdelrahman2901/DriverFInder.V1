using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolDetailsViewRepo;
using DriverFinder.Core.DTO.SchoolFilterDTO;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DriverFinder.Infrastructure.Repository.SchoolDetailsViewRepo
{
    public class SchoolDetailsViewRepository : ISchoolDetailsViewRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<SchoolDetailsViewRepository> _logger;
        public SchoolDetailsViewRepository(ApplicationDBContext context, ILogger<SchoolDetailsViewRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<SchoolDetailsView>> GetAllSchoolsDetails()
        {
            try
            {

                var schoolsDetails = await _context.SchoolDetailsView.AsNoTracking().ToListAsync();
                return schoolsDetails;
            }
            catch (Exception ex)
            {
               _logger.LogError(ex.Message);
                if (ex.InnerException!=null)
                {
                    _logger.LogError(ex.InnerException.Message);
                }
                return new List<SchoolDetailsView>();
            }
        }

        public async Task<SchoolDetailsView?> GetSchoolsDetailsByID(Guid ID)
        {
            try
            {

                var schoolsDetail = await _context.SchoolDetailsView.AsNoTracking().Where(t => t.SchoolID == ID).FirstOrDefaultAsync();
                return schoolsDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException.Message);
                }
                return null;
            }
        }

        public async Task<SchoolDetailsView?> GetSchoolsDetailsByOwnerID(Guid OwnerID)
        {
            try
            {

                var schoolsDetail = await _context.SchoolDetailsView.AsNoTracking().Where(t => t.OwnerID == OwnerID).FirstOrDefaultAsync();
                return schoolsDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException.Message);
                }
                return null;
            }
        }

        public async Task<IEnumerable<SchoolDetailsView>> FilterSchool(SchoolFilterDTO filter)
        {
            try
            {

                var query = _context.SchoolDetailsView.AsNoTracking();


                if (filter.Verified)
                {
                    query = query.Where(s => s.status == "Approved");
                }

                if (filter.program.ToLower() == "both")
                {
                    return query;
                }


                if (!string.IsNullOrEmpty(filter.schoolName))
                {
                    return _context.SchoolDetailsView.Where(s => s.SchoolName.Contains(filter.schoolName));
                }

                if (!string.IsNullOrEmpty(filter.City) && filter.City.ToLower() != "any")
                {
                    query = query.Where(s => s.City.ToLower().Equals(filter.City.ToLower()));
                }

                if (!string.IsNullOrEmpty(filter.Area) && filter.Area.ToLower() != "any")
                {
                    query = query.Where(s => s.Area.ToLower().Contains(filter.Area.ToLower()));
                }

                if (!string.IsNullOrEmpty(filter.program))
                {
                    query = query.Where(s => s.Program.ToLower() == filter.program.ToLower() || s.Program.ToLower() == "both");
                }

                if (!string.IsNullOrEmpty(filter.programType))
                {
                    query = query.Where(s => s.ProgramType.ToLower() == filter.programType.ToLower() || s.ProgramType.ToLower() == "both");
                }
                if (filter.hasFemaleInstructor)
                {
                    query = query.Where(s => s.HasFemaleInstructor);
                }


                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException.Message);
                }
                return new List<SchoolDetailsView>();
            }
        }

    }
}
