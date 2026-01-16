using DriverFinder.Core.Enums;
using System;


namespace DriverFinder.Core.DTO.InstructorDTO
{
    public class InstructorResponse
    {
        public Guid? InstructorID { get; set; }
        public Guid? SchoolID { get; set; }
        public string? InstructorName { get; set; }
        public string? PhoneNumber { get; set; }
        public int Experience { get; set; }
        public string? IntsturctorImgUrl { get; set; }
        public InstructorGender? Gender { get; set; }
    }
    public static class InstructorResponseExtensions
    {
        public static InstructorResponse ToInstructorResponse(this Domain.Entites.DrivingInstructors instructor)
        {
            return new InstructorResponse
            {
                InstructorID = instructor.InstructorID,
                SchoolID = instructor.SchoolID,
                InstructorName = instructor.InstructorName,
                PhoneNumber = instructor.PhoneNumber,
                Experience = instructor.Experience,
                IntsturctorImgUrl = instructor.InsturctorImgUrl
                ,Gender=instructor.Gender
            };
        }
    }
}
