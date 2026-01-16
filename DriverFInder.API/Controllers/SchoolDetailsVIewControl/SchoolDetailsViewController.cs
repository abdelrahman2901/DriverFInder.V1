using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.DTO.SchoolFilterDTO;
using DriverFinder.Core.ServicesContracts.ISchoolDetailsViewServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace DriverFinder.UI.Controllers.SchoolDetailsVIewControl
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolDetailsViewController : ControllerBase
    {
        private readonly ISchoolDetailsViewService _SchoolDetailsService;
        public SchoolDetailsViewController(ISchoolDetailsViewService schoolDetailsService,ILogger<SchoolDetailsViewController> logger)
        {
            _SchoolDetailsService = schoolDetailsService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolDetailsView>>> GetSchoolDetails()
        {
            Result<IEnumerable<SchoolDetailsView>> Schools = await _SchoolDetailsService.GetSchoolsDetails();
            if (!Schools.IsSuccess)
            {
                return Problem(Schools.ErrorMessage);
            }

            return Ok(Schools.Data);
        }

        [HttpGet("GetSchoolDetailsByID/{schoolID}")]
        public async Task<ActionResult<SchoolDetailsView>> GetSchoolDetailsByID(Guid schoolID)
        {
            Result<SchoolDetailsView?> School = await _SchoolDetailsService.GetSchoolDetailsByID(schoolID);
            if (!School.IsSuccess)
            {
                return Problem(School.ErrorMessage);
            }

            return Ok(School.Data);
        }
         
        [HttpGet("GetSchoolDetailsByOwnerID/{OwnerID}")]
        public async Task<ActionResult<SchoolDetailsView>> GetSchoolDetailsByOwnerID(Guid OwnerID)
        {
            Result<SchoolDetailsView?> School = await _SchoolDetailsService.GetSchoolDetailsByOwnerID(OwnerID);
            if (!School.IsSuccess)
            {
                return Problem(School.ErrorMessage);
            }   

            return Ok(School.Data);
        }

        [HttpPost("GetSchoolFilter")]
        public async Task<ActionResult<IEnumerable<SchoolDetailsView>>> GetSchoolFilter(SchoolFilterDTO filterDTO)
        {
            Result<IEnumerable<SchoolDetailsView>> filter = await _SchoolDetailsService.FilterSchool(filterDTO);
            if (!filter.IsSuccess)
            {
                return Problem(filter.ErrorMessage);
            }

            return Ok(filter.Data);
        }
    }
}
