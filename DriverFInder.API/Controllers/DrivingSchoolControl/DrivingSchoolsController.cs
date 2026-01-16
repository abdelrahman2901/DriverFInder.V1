using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.DTO.SchoolDTO;
using DriverFinder.Core.DTO.SchoolDTO.SchoolRegisterDTO;
using DriverFinder.Core.DTO.SchoolDTO.UpdateSchoolDTO;
using DriverFinder.Core.ServicesContracts.ISchoolDetailsViewServices;
using DriverFinder.Core.ServicesContracts.ISchoolServices;
using DriverFinder.Core.Validation.SchoolValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.UI.Controllers.DrivingSchoolControl
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DrivingSchoolsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly ISchoolDetailsViewService _schoolServicevw;
        private readonly SchoolRequestValidation _RequestValidaiton;
        private readonly SchoolUpdateRequestValidation _UpdateRequestValidaiton;

        public DrivingSchoolsController(ISchoolService schoolService, ISchoolDetailsViewService schoolDetailsView,
            SchoolRequestValidation RequestValidaiton, SchoolUpdateRequestValidation UpdateRequestValidaiton)
        {
            _schoolService = schoolService;
            _schoolServicevw = schoolDetailsView;
            _RequestValidaiton = RequestValidaiton;
            _UpdateRequestValidaiton = UpdateRequestValidaiton;
        }

        /// <summary>
        /// Retrieves a list of all available driving schools.
        /// </summary>
        /// <returns>An <see cref="ActionResult{T}"/> containing a collection of <see cref="DrivingSchool"/> objects. Returns an
        /// empty collection if no driving schools are found.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolResponse>>> GetDrivingSchools()
        {
            var Schools = await _schoolService.GetDrivingSchools();
            if (!Schools.IsSuccess)
            {
                return Problem(Schools.ErrorMessage);
            }

            return Ok(Schools.Data);
        }

        /// <summary>
        /// Retrieves the driving school with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the driving school to retrieve.</param>
        /// <returns>An <see cref="ActionResult{DrivingSchool}"/> containing the driving school if found; otherwise, a 404 Not
        /// Found response.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolResponse>> GetDrivingSchool(Guid id)
        {

            Result<SchoolResponse?> drivingSchool = await _schoolService.GetDrivingSchoolByID(id);

            if (!drivingSchool.IsSuccess)
            {
                return Problem(drivingSchool.ErrorMessage);
            }

            return Ok(drivingSchool.Data);
        }

        /// <summary>
        /// Updates the details of an existing driving school with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the driving school to update.</param>
        /// <param name="UpdateSchool">An object containing the updated details of the driving school. The <see cref="DrivingSchool.SchoolID"/>
        /// property must match the <paramref name="id"/> parameter.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation. Returns <see cref="NoContentResult"/> if
        /// the update is successful; <see cref="BadRequestResult"/> if the identifiers do not match; <see
        /// cref="NotFoundObjectResult"/> if the driving school does not exist; or a problem result if the update fails or
        /// the model state is invalid.</returns>
        [HttpPut]
        public async Task<IActionResult> PutDrivingSchool([FromForm] UpdateSchoolRequest UpdateSchool, IFormFile? img)
        {
            var result = await _UpdateRequestValidaiton.ValidateAsync(UpdateSchool);
            if (!result.IsValid)
            {
                var errors = string.Join("\n", result.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            var UpdatedSchool = await _schoolService.UpdateDrivingSchool(UpdateSchool, img);

            if (!UpdatedSchool.IsSuccess)
            {
                return Problem(UpdatedSchool.ErrorMessage);
            }
            var UpdatedschoolDetails = await _schoolServicevw.GetSchoolDetailsByID(UpdateSchool.SchoolID);
            return Ok(UpdatedschoolDetails.Data);
        }

        /// <summary>
        /// Creates a new driving school or updates an existing one based on the provided information.
        /// </summary>
        /// <remarks>If the model state is invalid, the method returns a problem response with validation
        /// error messages. If the operation fails to add or update the driving school, a problem response is returned.
        /// On success, an HTTP 200 OK response is returned with a confirmation message.</remarks>
        /// <param name="SchoolDTO">The driving school entity to create or update. Must contain valid data; otherwise, the request will fail
        /// validation.</param>
        /// <returns>An ActionResult containing the created or updated DrivingSchool entity if successful; otherwise, a problem
        /// response describing the error.</returns>

        [HttpPut("ChangeFemaleInsStatus/{SchoolID}")]
        public async Task<ActionResult<SchoolResponse>> ChangeFemaleInsStatus(Guid SchoolID)
        {
            var result = await _schoolService.ChangeFemaleInstructorStatus(SchoolID);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(result);
        }
        [HttpPost("AddNewSchool")]
        public async Task<ActionResult<SchoolResponse>> PostDrivingSchool([FromForm] SchoolRegisterRequest SchoolDTO, IFormFile? img)
        {
            var Validationresult = await _RequestValidaiton.ValidateAsync(SchoolDTO);
            if (!Validationresult.IsValid)
            {
                var errors = string.Join("\n", Validationresult.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            Result<SchoolResponse?> results = await _schoolService.AddDrivingSchool(SchoolDTO, img);
            if (!results.IsSuccess)
            {
                return Problem(results.ErrorMessage);
            }

            return Ok(results.Data);
        }

        [HttpPut("UpdateRating/{SchoolID}")]
        public async Task<IActionResult> UpdateRating(Guid SchoolID)
        {
            var updatedSchool = await _schoolService.UpdateRating(SchoolID);
            if (!updatedSchool.IsSuccess)
            {
                return Problem(updatedSchool.ErrorMessage);
            }
            return Ok(updatedSchool.Data);
        }

        /// <summary>
        /// Applies a JSON Patch document to an existing driving school resource.
        /// </summary>
        /// <param name="id">The unique identifier of the driving school to update.</param>
        /// <param name="PatchTo">The JSON Patch document containing the set of operations to apply to the driving school.</param>
        /// <returns>An <see cref="IActionResult"/> that represents the result of the operation. Returns <see
        /// cref="OkObjectResult"/> with the updated driving school if successful; otherwise, returns a problem response
        /// if the school does not exist or if the patch results in validation errors.</returns>


        /// <summary>
        /// Deletes the driving school with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the driving school to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the delete operation. Returns <see
        /// cref="NotFoundResult"/> if the driving school does not exist; <see cref="OkObjectResult"/> if the deletion
        /// is successful; or <see cref="ObjectResult"/> with an error if the deletion fails.</returns>
        [HttpDelete("{SchoolID}")]
        public async Task<IActionResult> DeleteDrivingSchool(Guid SchoolID)
        {
            Result<bool> results = await _schoolService.DeleteDrivingSchool(SchoolID);

            if (!results.IsSuccess)
            {
                return Problem(results.ErrorMessage);
            }

            return Ok(new { Message = "School Deleted Successfully" });
        }
    }
}
