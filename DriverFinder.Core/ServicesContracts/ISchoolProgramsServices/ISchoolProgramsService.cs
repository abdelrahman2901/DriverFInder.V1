using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.SchoolProgramsDTO;
 


namespace DriverFinder.Core.ServicesContracts.ISchoolProgramsServices
{
    public interface ISchoolProgramsService
    {
        public Task< Result<IEnumerable<SchoolProgramResponse>>> GetAllSchoolsPrograms();
        public Task<Result<IEnumerable<SchoolProgramResponse>>> GetAllSchoolPrograms(Guid SchoolID);
        public Task<Result<SchoolProgramResponse>> GetSchoolProgramByID(Guid SchoolID);
        public Task<Result<SchoolProgramResponse>> AddSchoolProgram(SchoolProgramRequest schoolProgram);
        public Task<Result<SchoolProgramResponse>> UpdateSchoolProgram(UpdateProgramRequest UpdateSchoolProgram);
        public Task<Result<bool>> ChangeProgramActiveStatus(Guid ProgramID); 
        public Task<Result<bool>> DeleteSchoolProgram(Guid SchoolProgramID);
    }
}
