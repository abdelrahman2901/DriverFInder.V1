using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;

namespace DriverFinder.Core.ServicesContracts.ISchoolProgramsViewServices
{
    public interface ISchoolProgramsViewServices
    {
        public Task<Result<IEnumerable<SchoolProgramsView>>> GetAllSchoolsProgramsView();
        public Task<Result<IEnumerable<SchoolProgramsView>>> GetAllSchoolProgramsView(Guid SchoolID);
        public Task<Result<SchoolProgramsView>> GetSchoolProgramsDetailsByID(Guid ProgramID);
    }
}
