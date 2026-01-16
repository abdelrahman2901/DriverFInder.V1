using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.InstructorDTO;
using DriverFinder.Core.ServicesContracts.IInstructorServices;
using DriverFinder.Core.Validation.InstructorsValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivingInstructorsController : ControllerBase
    {
        private readonly IInstructorService _InstructorService;
        private readonly InstructorRequestValidation _Requestvalidator;
        private readonly InstructorUpdateRequestValidation _UpdateRequestvalidator;
        public DrivingInstructorsController(IInstructorService InstructorService, InstructorRequestValidation Requestvalidator, InstructorUpdateRequestValidation UpdateRequestvalidator)
        {
            _InstructorService = InstructorService;
            _Requestvalidator = Requestvalidator;
            _UpdateRequestvalidator = UpdateRequestvalidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorResponse>>> GetDrivingInstructors()
        {
            Result<IEnumerable<InstructorResponse>> instructors = await _InstructorService.GetDrivingInstructors();
            if (!instructors.IsSuccess)
            {
                return Problem(instructors.ErrorMessage);
            }
            return Ok(instructors.Data);
        }

        [HttpGet("GetInstructor/{InstuctorID}")]
        public async Task<ActionResult<InstructorResponse>> GetDrivingInstructors(Guid InstuctorID)
        {
            var instructors = await _InstructorService.GetDrivingInstructors();
            if (!instructors.IsSuccess)
            {
                return Problem(instructors.ErrorMessage);
            }
            return Ok(instructors.Data);
        }

        [HttpGet("GetSchoolInstructors/{Schoolid}")]
        public async Task<ActionResult<IEnumerable<InstructorResponse>>> GetSchoolInstructors(Guid Schoolid)
        {
            Result<IEnumerable<InstructorResponse>> instructors = await _InstructorService.GetSchoolInstructors(Schoolid);
            if (!instructors.IsSuccess)
            {
                return Problem(instructors.ErrorMessage);
            }
            return Ok(instructors.Data);
        }

        [HttpPost]
        public async Task<ActionResult<InstructorResponse>> PostDrivingInstructors([FromForm] InstructorRequest AddInstructorRequest,IFormFile? InstructorImg)
        {
            var Validationresult = await _Requestvalidator.ValidateAsync(AddInstructorRequest);
            if (!Validationresult.IsValid)
            {
                var errors = string.Join("\n", Validationresult.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }
            Result<InstructorResponse> result = await _InstructorService.AddDrivingInstructor(AddInstructorRequest,InstructorImg);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpPut]
        public async Task<IActionResult> PutDrivingInstructors([FromForm]UpdateInstructorRequest UpdateInstructorRequest,IFormFile? newInstructorImage)
        {
            var Validationresult = await _UpdateRequestvalidator.ValidateAsync(UpdateInstructorRequest);
            if (!Validationresult.IsValid)
            {
                var errors = string.Join("\n", Validationresult.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            Result<InstructorResponse> result = await _InstructorService.UpdateDrivingInstructor(UpdateInstructorRequest, newInstructorImage);
           
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(result.Data);
        }

        [HttpDelete("{InstructorID}")]
        public async Task<IActionResult> DeleteDrivingInstructors(Guid InstructorID)
        {
            Result<bool> result = await _InstructorService.DeleteInstructor(InstructorID);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(new { messege = "Instructor Deleted Successfully" });
        }

    }
}
