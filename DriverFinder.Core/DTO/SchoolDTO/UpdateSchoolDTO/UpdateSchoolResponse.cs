using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Enums;
using System;


namespace DriverFinder.Core.DTO.SchoolDTO.UpdateSchoolDTO
{
    public class UpdateSchoolResponse
    {
        public Guid SchoolID { get; set; }
        public string? SchoolName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
        public string? LocationURl { get; set; }
        public int? Experience { get; set; }
        public string? SchoolEmail { get; set; }
        public Guid ProgramID { get; set; }
        public Guid? ProgramTypeID { get; set; }
        public Subscriptions SubscriptionType { get; set; }

    }

    public static class UpdateSChoolEXtension
    {
        public static UpdateSchoolResponse ToUpdateSchoolResponse(this DrivingSchool school)
        {
            return new UpdateSchoolResponse()
            {
                SchoolID = school.SchoolID,
                SchoolName = school.SchoolName,
                SchoolEmail = school.SchoolEmail,
                PhoneNumber = school.PhoneNumber,
                Location = school.Location,
                LocationURl = school.LocationURl,
                ProgramID = school.ProgramID,
                ProgramTypeID = school.ProgramTypeID,Experience=school.Experience,
                SubscriptionType = school.SubscriptionType,
            };
        }
    }
}
