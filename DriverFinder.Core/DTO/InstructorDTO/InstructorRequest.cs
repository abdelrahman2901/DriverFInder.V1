using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Enums;


namespace DriverFinder.Core.DTO.InstructorDTO
{
    public class InstructorRequest
    {
        public Guid SchoolID { get; set; }
        public string InstructorName { get; set; }
        public string PhoneNumber { get; set; }
        public int Experience { get; set; }
        public InstructorGender Gender { get; set; }
        public DrivingInstructors ToDrivingInstructor()
        {
            return new DrivingInstructors
            {
                InstructorID = Guid.NewGuid(),
                SchoolID = this.SchoolID,
                InstructorName = this.InstructorName,
                PhoneNumber = this.PhoneNumber,
                Experience = this.Experience,
                Gender = this.Gender
            };
        }

    }
}
