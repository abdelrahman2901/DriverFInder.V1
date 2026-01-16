using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Enums;

namespace DriverFinder.Core.DTO.SchoolDTO.UpdateSchoolDTO
{
    public class UpdateSchoolRequest
    {
        public Guid SchoolID { get; set; }
        public string? SchoolName { get; set; }
        public string? ActualSchoolName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
        public string? LocationURl { get; set; }
        public int? Experience { get; set; }
        public string? SchoolEmail { get; set; }
        public string? imgUrl { get; set; }
        public Guid ProgramID { get; set; }
        public Guid? ProgramTypeID { get; set; }
        public Subscriptions SubscriptionType { get; set; }

        public DrivingSchool ToDriverSchool()
        {
            return new DrivingSchool() {SchoolID=SchoolID,SchoolName=SchoolName,SchoolEmail=SchoolEmail,
                Location=Location,ProgramID=ProgramID,ProgramTypeID=ProgramTypeID,PhoneNumber=PhoneNumber ,
                imgURl=imgUrl,Experience=Experience,SubscriptionType=SubscriptionType
             };

        }
    }
}
