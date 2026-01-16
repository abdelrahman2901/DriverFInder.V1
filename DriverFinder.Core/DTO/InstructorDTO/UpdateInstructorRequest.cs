using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace DriverFinder.Core.DTO.InstructorDTO
{
    public class UpdateInstructorRequest
    {
        [Required(ErrorMessage = "Instructor ID is required")]
        public Guid InstructorID { get; set; }
        [Required(ErrorMessage = "School ID is required")]
        public Guid SchoolID { get; set; }
        public string? InstructorName { get; set; }
        public string? PhoneNumber { get; set; }
        public int Experience { get; set; }
        public string? InsturctorImgUrl { get; set; }
        public InstructorGender Gender { get; set; }

        public DrivingInstructors ToDrivingInstructor()
        {
            return new DrivingInstructors
            {
                InstructorID = this.InstructorID,
                SchoolID = this.SchoolID,
                InstructorName = this.InstructorName,
                PhoneNumber = this.PhoneNumber,
                Experience = this.Experience,
                InsturctorImgUrl = this.InsturctorImgUrl
                ,Gender=this.Gender
            };
        }
    }

}
