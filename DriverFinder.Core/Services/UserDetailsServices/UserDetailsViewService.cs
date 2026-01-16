using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Domain.RepositoryContracts.IUserDetailsViewRepo;
using DriverFinder.Core.Identity;
using DriverFinder.Core.ServicesContracts.IUserDetailsServices;
using System;

namespace DriverFinder.Core.Services.UserDetailsServices
{
    public class UserDetailsViewService : IUserDetailsViewService
    {
        private readonly IUserDetailsViewRepository _UsersRepo;
        public UserDetailsViewService(IUserDetailsViewRepository UsersRepo)
        {
            _UsersRepo = UsersRepo;
        }
        public async Task<Result<IEnumerable<UsersDetailsView>>> GetAllUsers()
        {
            var Users = await _UsersRepo.GetAllUsers();

            if (Users.Count() == 0)
            {
                return Result<IEnumerable<UsersDetailsView>>.Failure("No Users Found");
            }

            return Result<IEnumerable<UsersDetailsView>>.Success(Users);
        }

        public async Task<Result<UsersDetailsView?>> GetUserByID(Guid UserID)
        {
            UsersDetailsView? user =await  _UsersRepo.GetUserByID(UserID);
            if (user == null)
            {
                return Result<UsersDetailsView?>.Failure("User not found");
            }
            return Result<UsersDetailsView?>.Success(user);
        }

        public async Task<Result<bool>> EditUserBlockStatus(Guid UserId,bool status)
        {
            ApplicationUser? user = await _UsersRepo.GetUserEntityByID(UserId);
            user.isblocked = status;

            var Results = await _UsersRepo.EditUserBlockStatus(user);
            if(!Results)
            {
                return Result<bool>.Failure("Failed To Block User");
            }
            return Result<bool>.Success(Results);
        }

        public async Task<Result<bool>> EditUserRole(Guid userId, string UpdateRole)
        {
            ApplicationUser? user = await _UsersRepo.GetUserEntityByID(userId);
            if (user == null)
            {
                return Result<bool>.Failure("User Doesnt Exists");
            }
            bool Results = await _UsersRepo.EditUserRole(user, UpdateRole);
            if (!Results)
            {
                return Result<bool>.Failure("Failed To Edit User Role");
            }
            return Result<bool>.Success(Results);
        }

    }
}
