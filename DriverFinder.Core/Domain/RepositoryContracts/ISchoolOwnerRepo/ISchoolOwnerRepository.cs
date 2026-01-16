using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.DTO.OwnerDTO;
using System;

namespace DriverFinder.Core.Domain.RepositoryContracts.ISchoolOwnerRepo
{
    public interface ISchoolOwnerRepository
    {
        public  Task<IEnumerable<SchoolOwner>> GetSchoolOwners();
        public  Task<SchoolOwner?> GetSchoolOwner(Guid id);
        public Task<SchoolOwner?> GetSchoolOwnerByUserID(Guid Userid); 
        public Task<SchoolOwner?> AddSchoolOwner(SchoolOwner owner);
        public Task<bool> DeleteOwner(SchoolOwner owner);
        public Task<bool> ChangeRoles(OwnerResponse ownerResponse, string CurrentRole, string toRole);
    }
}
