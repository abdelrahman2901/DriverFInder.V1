using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;
using System;

namespace DriverFinder.Core.ServicesContracts.IUserDetailsServices
{
    public interface IUserDetailsViewService
    {
        public Task<Result<IEnumerable<UsersDetailsView>>> GetAllUsers();
        public Task<Result<bool>> EditUserBlockStatus(Guid UserId, bool status);
        public Task<Result<bool>> EditUserRole(Guid userId, string UpdateRole);
        public Task<Result<UsersDetailsView?>> GetUserByID(Guid UserID);
    }
}
