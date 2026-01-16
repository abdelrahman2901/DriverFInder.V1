using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.InstructorDTO;
using Microsoft.AspNetCore.Http;

namespace DriverFinder.Core.ServicesContracts.IInstructorServices
{
    public interface IInstructorService
    {
        public Task<Result<IEnumerable<InstructorResponse>>> GetDrivingInstructors();
        public Task<Result<InstructorResponse>> GetInstructor(Guid InstructorID);
        public Task<Result<IEnumerable<InstructorResponse>>> GetSchoolInstructors(Guid SchoolID);
        public Task<Result<InstructorResponse>> UpdateDrivingInstructor(UpdateInstructorRequest UpdateInstructors, IFormFile? UpdateImg);
        public Task<Result<InstructorResponse>> AddDrivingInstructor(InstructorRequest drivingInstructors,IFormFile? InstructorImg);
        public Task<Result<bool>> DeleteInstructor(Guid InstructorID);
    }
}
