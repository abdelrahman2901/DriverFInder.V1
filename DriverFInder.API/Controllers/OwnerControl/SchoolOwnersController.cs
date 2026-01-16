using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.OwnerDTO;
using DriverFinder.Core.Identity;
using DriverFinder.Core.ServicesContracts.ISchoolOwnerServices;
using DriverFinder.Core.Validation.OwnerValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace DriverFinder.UI.Controllers.OwnerControl
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolOwnersController : ControllerBase
    {
        private readonly ISchoolOwnerService _OwnerService;
        private readonly OwnerRequestValidation _RequestValidator;

        public SchoolOwnersController(ISchoolOwnerService OwnerService, OwnerRequestValidation RequestValidator)
        {
            _OwnerService = OwnerService;
            _RequestValidator = RequestValidator;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerResponse>>> GetSchoolOwners()
        {
            Result<IEnumerable<OwnerResponse>> SchoolOwners = await _OwnerService.GetSchoolOwners();
            if (!SchoolOwners.IsSuccess)
            {
                return Problem(SchoolOwners.ErrorMessage);
            }

            return Ok(SchoolOwners.Data);
        }

        [HttpGet("GetOwnerByUserID")]
        public async Task<ActionResult<OwnerResponse>> GetOwnerByUserID(Guid id)
        {
            Result<OwnerResponse?> schoolOwnerResponse = await _OwnerService.GetSchoolOwnerByUserID(id);

            if (!schoolOwnerResponse.IsSuccess)
            {
                return Problem(schoolOwnerResponse.ErrorMessage);
            }

            return Ok(schoolOwnerResponse.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerResponse>> GetSchoolOwner(Guid id)
        {
            Result<OwnerResponse> schoolOwnerResponse = await _OwnerService.GetSchoolOwner(id);
            if (!schoolOwnerResponse.IsSuccess)
            {
                return Problem(schoolOwnerResponse.ErrorMessage);
            }

            return Ok(schoolOwnerResponse.Data);
        }


        [HttpPost]
        public async Task<ActionResult<OwnerResponse>> PostSchoolOwner(OwnerRequest OwnerDTO)
        {
            var Validationresult = await _RequestValidator.ValidateAsync(OwnerDTO);
            if (!Validationresult.IsValid)
            {
                var errors = string.Join("\n", Validationresult.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            Result<OwnerResponse?> ownerResponse = await _OwnerService.AddSchoolOwner(OwnerDTO);
            if (ownerResponse == null)
            {
                return Problem(ownerResponse.ErrorMessage);
            }
             
            return Ok(ownerResponse);
       
        }

        // DELETE: api/SchoolOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolOwner(Guid id)
        {
            Result<bool> isDeleted = await _OwnerService.DeleteOwner(id);
            
            if (!isDeleted.IsSuccess)
            {
                return Problem(isDeleted.ErrorMessage);
            }

            //return Ok(JsonConvert.SerializeObject("owner Deleted Successfuly"));
            return Ok("owner Deleted Successfuly"); //need fix
        }

       
    }
}
