using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Enums;

namespace DriverFinder.Core.DTO.SchoolDTO.SchoolRegisterDTO
{
    public class SchoolRegisterRequest
    {
        public Guid OwnerID { get; set; }
        public string? schoolName { get; set; }
        public string? schoolEmail { get; set; }
        public string? phoneNumber { get; set; }
        public string? location { get; set; }
        public string? locationUrl { get; set; }
        public Guid ProgramID { get; set; }
        public Guid? ProgramTypeID { get; set; }
        public Subscriptions SubscriptionType { get; set; }


        public DrivingSchool ToDrivingSchool()
        {
            return new DrivingSchool()
            {
                OwnerID = OwnerID,
                PhoneNumber = phoneNumber,
                SchoolEmail = schoolEmail,
                SchoolName = schoolName,
                Location = location,
                LocationURl = locationUrl,
                ProgramID = ProgramID,
                ProgramTypeID = ProgramTypeID,
                SubscriptionType = SubscriptionType

            };
        }
    }
}
