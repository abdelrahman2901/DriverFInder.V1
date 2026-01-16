using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Identity;
using System;


namespace DriverFinder.Core.Domain.RepositoryContracts.IUserDetailsViewRepo
{
    public interface IUserDetailsViewRepository
    {
        public Task<IEnumerable<UsersDetailsView>> GetAllUsers();
        public Task<bool> EditUserBlockStatus(ApplicationUser user);
        public Task<bool> EditUserRole(ApplicationUser user, string UpdateRole);
        public Task<UsersDetailsView?> GetUserByID(Guid UserID);
        public Task<ApplicationUser?> GetUserEntityByID(Guid UserID);

    }
}
