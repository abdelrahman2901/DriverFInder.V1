using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.DTO.SchoolFilterDTO;
using System;
    
namespace DriverFinder.Core.ServicesContracts.ISchoolDetailsViewServices
{
    public interface ISchoolDetailsViewService
    {
        Task<Result<IEnumerable<SchoolDetailsView>>> FilterSchool(SchoolFilterDTO filter);
        Task<Result<IEnumerable<SchoolDetailsView>>> GetSchoolsDetails();
        Task<Result<SchoolDetailsView?>> GetSchoolDetailsByID(Guid ID);
        Task<Result<SchoolDetailsView?>> GetSchoolDetailsByOwnerID(Guid OwnerID);

    }
}
