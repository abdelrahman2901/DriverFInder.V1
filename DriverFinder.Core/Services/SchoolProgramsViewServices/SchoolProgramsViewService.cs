using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolProgramsViewRepo;
using DriverFinder.Core.ServicesContracts.ISchoolProgramsViewServices;
using System;

namespace DriverFinder.Core.Services.SchoolProgramsViewServices
{
    public class SchoolProgramsViewService : ISchoolProgramsViewServices
    {
        private readonly ISchoolProgramsViewRepository _schoolProgramsViewRepo;
        public SchoolProgramsViewService(ISchoolProgramsViewRepository schoolProgramsViewRepo)
        {
            _schoolProgramsViewRepo = schoolProgramsViewRepo;
        }

        public async Task<Result<IEnumerable<SchoolProgramsView>>> GetAllSchoolProgramsView(Guid SchoolID)
        {
            var schoolProgramsView = await _schoolProgramsViewRepo.GetAllSchoolProgramsView(SchoolID);
            if(schoolProgramsView.Count()==0)
            {
                return Result<IEnumerable<SchoolProgramsView>>.Failure("No programs found for the specified school.");
            }
            return Result<IEnumerable<SchoolProgramsView>>.Success(schoolProgramsView);  
        }

        public async Task<Result<IEnumerable<SchoolProgramsView>>> GetAllSchoolsProgramsView()
        {
            var schoolsProgramsView = await _schoolProgramsViewRepo.GetAllSchoolsProgramsView();

            if (schoolsProgramsView.Count() == 0)
            {
                return Result<IEnumerable<SchoolProgramsView>>.Failure("No programs found for the specified school.");
            }
            return Result<IEnumerable<SchoolProgramsView>>.Success(schoolsProgramsView);
        }

        public async Task<Result<SchoolProgramsView>> GetSchoolProgramsDetailsByID(Guid ProgramID)
        {
            var schoolsProgramsView = await _schoolProgramsViewRepo.GetSchoolProgramsDetailsByID(ProgramID);

            if (schoolsProgramsView == null)
            {
                return Result<SchoolProgramsView>.Failure("No program found for the specified school.");
            }
            return Result<SchoolProgramsView>.Success(schoolsProgramsView);
        }

    }
}
