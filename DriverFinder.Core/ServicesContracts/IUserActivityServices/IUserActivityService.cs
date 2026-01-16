using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.UserActivityDTO;
using System;


namespace DriverFinder.Core.ServicesContracts.IUserActivityServices
{
    public interface IUserActivityService
    {
        public Result<UserActivityCountDTO> GetUserActiviyCounts();
        public Task<Result<bool>> LogUserActivity(Guid Userid,string LogType);
    }
}
