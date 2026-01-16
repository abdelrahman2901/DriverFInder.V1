using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.DTO.UserActivityDTO;
using System;


namespace DriverFinder.Core.Domain.RepositoryContracts.IUserActivityRepo
{
    public interface IUserActivityRepository
    {
        public UserActivityCountDTO GetUserActiviyCounts();
        public Task<bool> LogUserActivity(UserActivity activity);
    }
}
