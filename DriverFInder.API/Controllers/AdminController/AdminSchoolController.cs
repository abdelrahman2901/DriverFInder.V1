using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.SchoolDTO;
using DriverFinder.Core.Enums;
using DriverFinder.Core.ServicesContracts.ISchoolServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DriverFinder.UI.Controllers.AdminController
{
    [Authorize(Roles ="Admin")]
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class AdminSchoolController : ControllerBase
    {
        private readonly ISchoolService _SchoolService;
        public AdminSchoolController(ISchoolService SchoolService)
        {
            _SchoolService = SchoolService;
        }

        [HttpPut("EditSchoolStatus/{SchoolID}")]
        public async Task<ActionResult<SchoolResponse>> SchoolStatus(Guid SchoolID ,[FromQuery] SchoolStatusEnum Status)
        {
            Result<SchoolResponse?> schoolResponse = await _SchoolService.EditSchoolStatus(SchoolID, Status);
            if (!schoolResponse.IsSuccess)
            {
                return Problem(schoolResponse.ErrorMessage);
            }
            return Ok(schoolResponse.Data);
        } 

        [HttpPut("BlockSchool/{SchoolID}")]
        public async Task<ActionResult<SchoolResponse>> BlockSchool(Guid SchoolID,bool block)
        {
                Result<SchoolResponse?> schoolResponse = await _SchoolService.BlockSchool(SchoolID,block);
            if (!schoolResponse.IsSuccess)
            {
                return Problem(schoolResponse.ErrorMessage);
            }

            return Ok(schoolResponse.Data);
        }
    }
}
