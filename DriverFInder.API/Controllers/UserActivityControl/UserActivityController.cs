using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.UserActivityDTO;
using DriverFinder.Core.ServicesContracts.IUserActivityServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DriverFinder.UI.Controllers.UserActivityControl
{
    [Authorize(Roles = "Admin,Moderator")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserActivityController : ControllerBase
    {
        private readonly IUserActivityService _userActivityService;

        public UserActivityController(IUserActivityService userActivity) 
        {
            _userActivityService = userActivity;
        }

        [HttpGet]
        public ActionResult<UserActivityCountDTO> GetUserActivityCount()
        {
            Result<UserActivityCountDTO> ActivityCount = _userActivityService.GetUserActiviyCounts();
            if(!ActivityCount.IsSuccess)
            {
                return BadRequest(ActivityCount.ErrorMessage);
            }

            return Ok(ActivityCount.Data);
        }
    }
}
