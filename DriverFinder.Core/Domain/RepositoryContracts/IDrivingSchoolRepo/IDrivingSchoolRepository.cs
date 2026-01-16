using DriverFinder.Core.Domain.Entites;
using System;

namespace DriverFinder.Core.Domain.RepositoryContracts.IDrivingSchoolRepo
{
    public interface IDrivingSchoolRepository
    {
        public  Task<DrivingSchool> AddDrivingSchool(DrivingSchool drivingSchool);

        public Task<IEnumerable<DrivingSchool>> GetDrivingSchools();
        public  Task<DrivingSchool?> GetDrivingSchoolByID(Guid id);
        public  Task<DrivingSchool> UpdateDrivingSchool( DrivingSchool drivingSchool);
        public Task<bool> DeleteDrivingSchool(DrivingSchool School);
        public Task<bool> isSchoolNameExists(string schoolName);
    }
}
