using DriverFinder.Core.Domain.Entites;
using System;

namespace DriverFinder.Core.DTO.OwnerDTO
{
    public class OwnerResponse
    {

        public Guid OwnerID { get; set; } 
        public Guid UserID { get; set; } 
        
        public string? OwnerName { get; set; }
    }
    public static class OwnerExtensions
    {
        public static OwnerResponse ToOwnerResponse(this SchoolOwner owner)
        {
            return new OwnerResponse() { OwnerID = owner.OwnerID,UserID=owner.UserID,OwnerName=owner.OwnerName };
        }
    }

}
