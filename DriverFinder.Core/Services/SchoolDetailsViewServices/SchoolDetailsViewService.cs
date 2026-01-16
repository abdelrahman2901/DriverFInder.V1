using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolDetailsViewRepo;
using DriverFinder.Core.DTO.SchoolFilterDTO;
using DriverFinder.Core.ServicesContracts.ISchoolDetailsViewServices;
using System;

namespace DriverFinder.Core.Services.SchoolDetailsViewServices
{
    public class SchoolDetailsViewService : ISchoolDetailsViewService
    {
        private readonly ISchoolDetailsViewRepository _schoolRepo;
        public SchoolDetailsViewService(ISchoolDetailsViewRepository SchoolRepo)
        {
            _schoolRepo = SchoolRepo; 
        }
        public async Task<Result<SchoolDetailsView?>> GetSchoolDetailsByID(Guid ID)
        {
            var schoolDetails = await _schoolRepo.GetSchoolsDetailsByID(ID);
            if (schoolDetails == null)
            {
                return Result<SchoolDetailsView?>.Failure("School not found for the given ID.");
            }
            return Result<SchoolDetailsView?>.Success(schoolDetails);
        } 

        public async Task<Result<IEnumerable<SchoolDetailsView>>> GetSchoolsDetails()
        {
            var schoolsDetails = await _schoolRepo.GetAllSchoolsDetails();
            if(schoolsDetails.Count()== 0)
            {
                return Result<IEnumerable<SchoolDetailsView>>.Failure("No schools found.");
            }
            return Result<IEnumerable<SchoolDetailsView>>.Success(schoolsDetails); 
        }
        public async Task<Result<SchoolDetailsView?>> GetSchoolDetailsByOwnerID(Guid OwnerID)
        {
            var SchoolDetails = await _schoolRepo.GetSchoolsDetailsByOwnerID(OwnerID);
            if (SchoolDetails == null)
            {
                return Result<SchoolDetailsView?>.Failure("School not found for the given Owner ID.");
            }

            return Result<SchoolDetailsView?>.Success(SchoolDetails);
        }
        public async Task<Result<IEnumerable<SchoolDetailsView>>> FilterSchool(SchoolFilterDTO filter)
        {
            IEnumerable<SchoolDetailsView> filteredSchools = await _schoolRepo.FilterSchool(filter);
            if(filteredSchools.Count() == 0)
            {
                return Result<IEnumerable<SchoolDetailsView>>.Failure("No schools found matching the filter criteria.");
            }
            return Result<IEnumerable<SchoolDetailsView>>.Success(filteredSchools);
        }
     }
}
