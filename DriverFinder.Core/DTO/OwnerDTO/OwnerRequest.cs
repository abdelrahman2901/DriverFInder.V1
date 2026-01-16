using DriverFinder.Core.Domain.Entites;


namespace DriverFinder.Core.DTO.OwnerDTO
{
    public class OwnerRequest
    {
        public Guid UserID { get; set; }
        public string? OwnerName { get; set; }

        public SchoolOwner toSchoolOnwer()
        {
            return new SchoolOwner() { UserID = UserID, OwnerName = OwnerName };
        }
      
    }
}
