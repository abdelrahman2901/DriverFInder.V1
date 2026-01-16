using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Enums;
using System;

namespace DriverFinder.Core.DTO.SchoolDTO
{
    public class SchoolResponse
    {
        public Guid SchoolID { get; set; }
        public Guid OwnerID { get; set; }

        public string? schoolName { get; set; }
        public string? schoolEmail { get; set; }
        public string? phoneNumber { get; set; }
        public string? location { get; set; }
        public string? locationUrl { get; set; }
        public int? Experience { get; set; }
        public Guid ProgramID { get; set; }
        public Guid? ProgramTypeID { get; set; }
        public string? imgUrl { get; set; }
        public bool? isBlocked { get; set; }
        public double? Rating { get; set; }
        public SchoolStatusEnum? status { get; set; }
        public Subscriptions SubscriptionType { get; set; }


    }

    public static class SchoolExtensions{

        public static SchoolResponse ToSchoolResponse(this DrivingSchool school)
        {
            return new SchoolResponse() {OwnerID=school.OwnerID,
                locationUrl= school.LocationURl,
                imgUrl=school.imgURl,
                phoneNumber=school.PhoneNumber,
                SchoolID=school.SchoolID
                ,schoolEmail=school.SchoolEmail,
                schoolName=school.SchoolName, 
                location = school.Location ,
                ProgramID= school.ProgramID,
                ProgramTypeID= school.ProgramTypeID,
                isBlocked=school.isblocked,
                status=school.status,
                Experience=school.Experience,
                Rating=school.Rating
            
            };
        }
        }
}
