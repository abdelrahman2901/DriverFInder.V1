using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.OwnerDTO;
using System;

namespace DriverFinder.Core.ServicesContracts.ISchoolOwnerServices
{
    public interface ISchoolOwnerService
    {
          Task<Result<IEnumerable<OwnerResponse>>> GetSchoolOwners();
          Task<Result<OwnerResponse?>> GetSchoolOwner(Guid id);
          Task<Result<OwnerResponse?>> GetSchoolOwnerByUserID(Guid Userid);
        Task<Result<OwnerResponse?>> AddSchoolOwner(OwnerRequest ownerRequest); 
        Task<Result<bool>> DeleteOwner(Guid OwnerID);
    }
}
