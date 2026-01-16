using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.DTO.SchoolFilterDTO;
using System;

namespace DriverFinder.Core.Domain.RepositoryContracts.ISchoolDetailsViewRepo
{
    public interface ISchoolDetailsViewRepository
    {
        public Task<IEnumerable<SchoolDetailsView>> FilterSchool(SchoolFilterDTO filter);
        public Task<IEnumerable<SchoolDetailsView>> GetAllSchoolsDetails();
        public Task<SchoolDetailsView?> GetSchoolsDetailsByID(Guid ID);
        public Task<SchoolDetailsView?> GetSchoolsDetailsByOwnerID(Guid OwnerID);

    }
}
