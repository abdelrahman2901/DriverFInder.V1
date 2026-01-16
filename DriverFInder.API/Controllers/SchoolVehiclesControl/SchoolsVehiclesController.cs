using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.DTO.VehicalDTO;
using DriverFinder.Core.ServicesContracts.IVehicleDetailsViewServices;
using DriverFinder.Core.ServicesContracts.IVehiclesServices;
using DriverFinder.Core.Validation.VehiclesValidation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.UI.Controllers.SchoolVehiclesControl
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsVehiclesController : ControllerBase
    {
        private readonly IVehiclesService _VehicleService;
        private readonly IVehicleDetailsViewService _VehicleDetailsService;

        private readonly VehicleRequestValidation _RequestValidator;
        private readonly VehicleUpdateRequestValidation _UpdateRequestValidator;
        public SchoolsVehiclesController(IVehiclesService VehicleService,IVehicleDetailsViewService VehicleDetailsService, 
            VehicleRequestValidation RequestValidator, VehicleUpdateRequestValidation UpdateRequestValidator)
        {
            _VehicleService = VehicleService;
            _VehicleDetailsService = VehicleDetailsService;
            _RequestValidator = RequestValidator;
            _UpdateRequestValidator = UpdateRequestValidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleResponse>>> GetSchoolsVehicles()
        {
            Result<IEnumerable<VehicleResponse>> Vehicles = await _VehicleService.GetAllSchoolsVehicles();
            if (!Vehicles.IsSuccess)
            {
                return Problem(Vehicles.ErrorMessage);
            }
            return Ok(Vehicles.Data);
        }

        [HttpGet("GetVehicle/{VehicleID}")]
        public async Task<ActionResult<VehicleResponse>> GetVehicle(Guid VehicleID)
        {
            var Vehicle = await _VehicleService.GetVehicleById(VehicleID);
            if (!Vehicle.IsSuccess)
            {
                return Problem(Vehicle.ErrorMessage);
            }
            return Ok(Vehicle.Data);
        }

        [HttpGet("GetSchoolVehicles/{SchoolID}")]
        public async Task<ActionResult<IEnumerable<VehicleResponse>>> GetSchoolVehicle(Guid SchoolID)
        {
            Result<IEnumerable<VehicleResponse>> Vehicles = await _VehicleService.GetAllSchoolVehicles(SchoolID);
            if (!Vehicles.IsSuccess)
            {
                return Problem(Vehicles.ErrorMessage);
            }
            return Ok(Vehicles.Data);
        }


        [HttpPost]
        public async Task<ActionResult<VehicleDetailsView>> AddVehicle([FromForm] VehicleRequests AddVehicleRequest, IFormFile? VehicleImg)
        {
            var Validationresult = await _RequestValidator.ValidateAsync(AddVehicleRequest);
            if (!Validationresult.IsValid)
            {
                var errors = string.Join("\n", Validationresult.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            Result<VehicleResponse> result = await _VehicleService.AddNewVehicle(AddVehicleRequest, VehicleImg);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            var VehicleDetails = await _VehicleDetailsService.GetVehicleDetailsByID(result.Data.VehicleID);
            return Ok(VehicleDetails.Data);
        }

        [HttpPut]
        public async Task<ActionResult<VehicleDetailsView>> UpdateVehicle([FromForm] UpdateVehicleRequest UpdateVehicleRequest, IFormFile? newVehicleImage)
        {
            var Validationresult = await _UpdateRequestValidator.ValidateAsync(UpdateVehicleRequest);
            if (!Validationresult.IsValid)
            {
                var errors = string.Join("\n", Validationresult.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            Result<VehicleResponse> result = await _VehicleService.UpdateVehicle(UpdateVehicleRequest, newVehicleImage);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            var VehicleDetails = await _VehicleDetailsService.GetVehicleDetailsByID(result.Data.VehicleID);
            return Ok(VehicleDetails.Data);
        }

        [HttpDelete("{VehicleID}")]
        public async Task<IActionResult> DeleteVehicle(Guid VehicleID)
        {
            Result<bool> result = await _VehicleService.DeleteVehicle(VehicleID);
            if (!result.IsSuccess)
            {
                return Problem(result.ErrorMessage);
            }
            return Ok(new { messege = "Vehicle Deleted Successfully" });
        }
    }
}
