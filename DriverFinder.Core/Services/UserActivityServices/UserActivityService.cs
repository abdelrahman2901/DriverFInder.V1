using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IUserActivityRepo;
using DriverFinder.Core.DTO.UserActivityDTO;
using DriverFinder.Core.ServicesContracts.IUserActivityServices;
using System;


namespace DriverFinder.Core.Services.UserActivityServices
{
    public class UserActivityService : IUserActivityService
    {

        private readonly IUserActivityRepository _UserActivityRepo;

        public UserActivityService(IUserActivityRepository UserActivity)
        {
            _UserActivityRepo = UserActivity;
        }

        public Result<UserActivityCountDTO> GetUserActiviyCounts()
        {
            var userActivityCounts = _UserActivityRepo.GetUserActiviyCounts();
            if(userActivityCounts == null)
            {
                return Result<UserActivityCountDTO>.Failure("Failed to retrieve user activity counts.");
            }
            return Result<UserActivityCountDTO>.Success(userActivityCounts);
        }

        public async Task<Result<bool>> LogUserActivity(Guid Userid,string LogType)
        {
            UserActivity activity = new UserActivity()
            {
                Id = Guid.NewGuid(),
                UserId = Userid,
                Timestamp = DateTime.Now
                ,LogType=LogType
            };
            var Results = await _UserActivityRepo.LogUserActivity(activity);
            if (!Results)
            {
                return Result<bool>.Failure("Failed to log user activity.");
            }
            return Result<bool>.Success(Results);
        }
    }
}
