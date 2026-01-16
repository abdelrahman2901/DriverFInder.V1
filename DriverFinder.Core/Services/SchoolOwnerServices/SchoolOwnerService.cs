using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolOwnerRepo;
using DriverFinder.Core.DTO.OwnerDTO;
using DriverFinder.Core.Identity;
using DriverFinder.Core.ServicesContracts.ISchoolOwnerServices;
using Microsoft.AspNetCore.Identity;
using System;
 

namespace DriverFinder.Core.Services.SchoolOwnerServices
{
    public class SchoolOwnerService : ISchoolOwnerService
    {
        private readonly ISchoolOwnerRepository _OwnerRepo;


        public SchoolOwnerService(ISchoolOwnerRepository ownerRepo)
        {
            _OwnerRepo = ownerRepo;
        }
        public async Task<Result<OwnerResponse?>> AddSchoolOwner(OwnerRequest ownerRequest)
        {
            var schoolowner = await _OwnerRepo.GetSchoolOwnerByUserID(ownerRequest.UserID);
            if (schoolowner ==null)
            {
                return Result<OwnerResponse?>.Failure("User Doesnt Exists");
            }

            SchoolOwner ownerReq = ownerRequest.toSchoolOnwer();
            ownerReq.OwnerID = Guid.NewGuid();
            SchoolOwner? owner=  await  _OwnerRepo.AddSchoolOwner(ownerReq);
            if(owner == null)
            {
                return Result<OwnerResponse?>.Failure("Failed to add School Owner");
            }
            OwnerResponse ownerResponse = owner.ToOwnerResponse();

            bool isRoleCHanged = await _OwnerRepo.ChangeRoles(ownerResponse, "User", "SchoolOwner");
            if (!isRoleCHanged)
            {
                await DeleteOwner(ownerResponse.OwnerID);
                return Result<OwnerResponse?>.Failure("couldnt change the role");
            }


            return Result<OwnerResponse?>.Success(ownerResponse);
        }

        public async Task<Result<bool>> DeleteOwner(Guid OwnerID)
        {
            SchoolOwner? SchoolOwner = await _OwnerRepo.GetSchoolOwner(OwnerID);
            if (SchoolOwner == null)
            {
                return Result<bool>.Failure("Owner doesnt Exists");
            }

            var DeleteResults = await _OwnerRepo.DeleteOwner(SchoolOwner);
            if(!DeleteResults)
            {
                return Result<bool>.Failure("Failed to delete School Owner");
            }
            var roleResult = await _OwnerRepo.ChangeRoles(SchoolOwner.ToOwnerResponse(), "SchoolOwner", "User");
            if (!roleResult)
            {
                return Result<bool>.Failure("failed to change roles");
            }
            return Result<bool>.Success(true);
        }

        public async Task<Result<OwnerResponse?>> GetSchoolOwner(Guid id)
        {
            SchoolOwner? owner = await _OwnerRepo.GetSchoolOwner(id);
            if(owner == null)
            {
                return Result<OwnerResponse?>.Failure("School Owner not found");
            }
            return Result<OwnerResponse?>.Success(owner.ToOwnerResponse());
        }

        public async Task<Result<OwnerResponse?>> GetSchoolOwnerByUserID(Guid Userid)
        {
            SchoolOwner? owner = await _OwnerRepo.GetSchoolOwnerByUserID(Userid);
            if (owner == null)
            {
                return Result<OwnerResponse?>.Failure("School Owner not found");
            }

            return Result<OwnerResponse?>.Success(owner?.ToOwnerResponse());
        }

        public async Task<Result<IEnumerable<OwnerResponse>>> GetSchoolOwners()
        {
            var OwnersResponse = await _OwnerRepo.GetSchoolOwners();
            if(OwnersResponse.Count()==0)
            {
                return Result<IEnumerable<OwnerResponse>>.Failure("No School Owners found");
            }
            return Result<IEnumerable<OwnerResponse>>.Success(OwnersResponse.Select(o => o.ToOwnerResponse()).ToList());
        }

      
    }
}
