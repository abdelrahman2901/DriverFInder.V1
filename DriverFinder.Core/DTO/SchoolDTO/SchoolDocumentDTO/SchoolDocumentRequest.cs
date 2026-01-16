using DriverFinder.Core.Domain.Entites;


namespace DriverFinder.Core.DTO.SchoolDTO.SchoolDocumentDTO
{
    public class SchoolDocumentRequest
    {
        public Guid schoolID { get; set; }
        public RegistrationDocuemnts toRegistrationDocuemnts()
        {

            return new RegistrationDocuemnts() { SchoolID = schoolID };
        }
    }
}
