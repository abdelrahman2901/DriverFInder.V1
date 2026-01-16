using DriverFinder.Core.Domain.Entites;
using System;

namespace DriverFinder.Core.DTO.SchoolDTO.SchoolDocumentDTO
{
    public class SchoolDocumentResponse
    {
        public Guid RegistrationID { get; set; }
        public Guid schoolID { get; set; }
        public string drivingSchoolLicense { get; set; }
    }

    public static class SchoolDocuemntResponseExtentions
    {
        public static SchoolDocumentResponse toSchoolDocResponnse(this RegistrationDocuemnts registerObj)
        {
            return new SchoolDocumentResponse() { RegistrationID = registerObj.RegistrationID, schoolID = registerObj.SchoolID, drivingSchoolLicense = registerObj.drivingSchoolLicense };
        }
    }
}
