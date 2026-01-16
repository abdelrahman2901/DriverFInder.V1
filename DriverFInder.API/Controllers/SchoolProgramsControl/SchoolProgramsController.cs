using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.DTO.SchoolProgramsDTO;
using DriverFinder.Core.ServicesContracts.ISchoolProgramsServices;
using DriverFinder.Core.ServicesContracts.ISchoolProgramsViewServices;
using DriverFinder.Core.Validation.SchoolProgramsValidation;
using DriverFinder.Infrastructure.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.UI.Controllers.SchoolProgramsControl.SchoolProgramsControl
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolProgramsController : ControllerBase
    {
        private readonly ISchoolProgramsService _schoolProgramsService;
        private readonly ISchoolProgramsViewServices _SchoolProgramsViewService;

        private readonly SchoolProgramsRequestValidation _RequestValidator;
        private readonly SchoolProgramsUpdateRequestValidation _UpdateRequestValidator;

        public SchoolProgramsController(ISchoolProgramsService schoolProgramsService, ISchoolProgramsViewServices schoolProgramsViewService,
            SchoolProgramsRequestValidation RequestValidator, SchoolProgramsUpdateRequestValidation UpdateRequestValidator)
        {
            _schoolProgramsService = schoolProgramsService;
            _SchoolProgramsViewService = schoolProgramsViewService;
            _RequestValidator = RequestValidator;
            _UpdateRequestValidator = UpdateRequestValidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolProgramsView>>> GetAllSchoolsPrograms()
        {
            Result<IEnumerable<SchoolProgramsView>> schoolsPrograms = await _SchoolProgramsViewService.GetAllSchoolsProgramsView();
            if (!schoolsPrograms.IsSuccess)
            {
                return Problem(schoolsPrograms.ErrorMessage);
            }
            return Ok(schoolsPrograms.Data);
        }

        [HttpGet("{SchoolID}")]
        public async Task<ActionResult<IEnumerable<SchoolProgramsView>>> GetAllSchoolsPrograms(Guid SchoolID)
        {
            Result<IEnumerable<SchoolProgramsView>> schoolPrograms = await _SchoolProgramsViewService.GetAllSchoolProgramsView(SchoolID);

            if (!schoolPrograms.IsSuccess)
            {
                return Problem(schoolPrograms.ErrorMessage);
            }

            return Ok(schoolPrograms.Data);
        }

        [HttpPost]
        public async Task<ActionResult<schoolprogramsView>> PostSchoolProgram( SchoolProgramRequest schoolProgramsRequest)
        {

            var Validationresult = await _RequestValidator.ValidateAsync(schoolProgramsRequest);
            if (!Validationresult.IsValid)
            {
                var errors = string.Join("\n", Validationresult.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            var result = await _schoolProgramsService.AddSchoolProgram(schoolProgramsRequest);

            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            var schoolProgramdetails = await _SchoolProgramsViewService.GetSchoolProgramsDetailsByID(result.Data.SchoolProgramID);
            return Ok(schoolProgramdetails.Data);
        }
        [HttpPut]
        public async Task<ActionResult<schoolprogramsView>> PutSchoolProgram(UpdateProgramRequest UpdateschoolPrograms)
        {
            var Validationresult = await _UpdateRequestValidator.ValidateAsync(UpdateschoolPrograms);
            if (!Validationresult.IsValid)
            {
                var errors = string.Join("\n", Validationresult.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            var result = await _schoolProgramsService.UpdateSchoolProgram(UpdateschoolPrograms);

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            var schoolProgramdetails = await _SchoolProgramsViewService.GetSchoolProgramsDetailsByID(result.Data.SchoolProgramID);
            return Ok(schoolProgramdetails.Data);
        }

        [HttpPut("EditProgramActiveStatus/{ProgramID}")]
        public async Task<IActionResult> ChangeProgramActiveStatus(Guid ProgramID)
        {
            var result = await _schoolProgramsService.ChangeProgramActiveStatus(ProgramID);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(result.Data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolProgram(Guid id)
        {
            var result = await _schoolProgramsService.DeleteSchoolProgram(id);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }

            return Ok(result.Data);
        }


    }
}
