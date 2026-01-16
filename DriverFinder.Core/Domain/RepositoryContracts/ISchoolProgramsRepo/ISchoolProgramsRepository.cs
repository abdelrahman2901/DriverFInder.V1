using DriverFinder.Core.Domain.Entites;
using System;


namespace DriverFinder.Core.Domain.RepositoryContracts.ISchoolProgramsRepo
{
    public interface ISchoolProgramsRepository
    {
        public Task<IEnumerable<SchoolPrograms>> GetAllSchoolsPrograms();
        public Task<IEnumerable<SchoolPrograms>> GetAllSchoolPrograms(Guid SchoolID);
        public Task<SchoolPrograms?> GetSchoolProgramByID(Guid SchoolID);
        public Task<SchoolPrograms?>  AddSchoolProgram(SchoolPrograms schoolProgram);
        public   Task<SchoolPrograms?> UpdateSchoolProgram(SchoolPrograms UpdateschoolProgram);
        public Task<bool> DeleteSchoolProgram(SchoolPrograms SchoolProgram);
        
       
    }
}
