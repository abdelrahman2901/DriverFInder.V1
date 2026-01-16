using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.DTO.InstructorDTO;

namespace DriverFinder.Core.Domain.RepositoryContracts.IInstructorRepo
{
    public interface IInsturctorRepository
    {
        public Task<IEnumerable<DrivingInstructors>> GetDrivingInstructors();
        public Task<DrivingInstructors?> GetInstructor(Guid InstructorID);
        public Task<IEnumerable<DrivingInstructors>> GetDrivingInstructorsForSchool(Guid SchoolID);
        public Task<DrivingInstructors?> UpdateDrivingInstructors(DrivingInstructors drivingInstructors);
        public Task<DrivingInstructors?> AddDrivingInstructors(DrivingInstructors drivingInstructors);
        public Task<bool> DeleteInstructors(DrivingInstructors drivingInstructors);
        public Task<bool> CheckUserDataExistance(InstructorRequest request);
        public Task<bool> CheckImgExistance(string ImageHash);
    }
}
