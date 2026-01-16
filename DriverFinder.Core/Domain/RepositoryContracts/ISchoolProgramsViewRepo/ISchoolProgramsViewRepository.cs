using DriverFinder.Core.Domain.EntitiesVIew;

namespace DriverFinder.Core.Domain.RepositoryContracts.ISchoolProgramsViewRepo
{
    public interface ISchoolProgramsViewRepository
    {
        public Task<IEnumerable<SchoolProgramsView>> GetAllSchoolsProgramsView();
        public Task<IEnumerable<SchoolProgramsView>> GetAllSchoolProgramsView(Guid SchoolID);
        public Task<SchoolProgramsView> GetSchoolProgramsDetailsByID(Guid ProgramID);

    }
}
