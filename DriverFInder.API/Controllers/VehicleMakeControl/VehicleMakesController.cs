using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.DTO.VehicalDTO.VehicleMakeDTO;
using DriverFinder.Core.ServicesContracts.IVehicleMakeServices;
using DriverFinder.Core.Validation.VehiclesValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.UI.Controllers.VehicleMakeControl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakesController : ControllerBase
    {
        private readonly IVehicleMakeServices _VehicleMakesService;
        private readonly VehicleMakeRequestValidation _RequestValidator;

        public VehicleMakesController(IVehicleMakeServices VehicleMakesService, VehicleMakeRequestValidation RequestValidator)
        {
            _VehicleMakesService = VehicleMakesService;
            _RequestValidator = RequestValidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> GetVehicleMake()
        {
            var VehicleMakes= await _VehicleMakesService.GetAllVehicleMakes();
            if (!VehicleMakes.IsSuccess)
            {
                return Problem(VehicleMakes.ErrorMessage);
            }
            return Ok(VehicleMakes.Data);
        }

        [HttpGet("{Category}")]
        public async Task<ActionResult<IEnumerable<VehicleMake>>> GetVehicleMakeByCategory(string Category)
        {
            var VehicleMakes = await _VehicleMakesService.GetAllVehicleMakesByCategory(Category);
            if (!VehicleMakes.IsSuccess)
            {
                return Problem(VehicleMakes.ErrorMessage);
            }
            return Ok(VehicleMakes.Data);
        }


        [HttpPost]
        public async Task<ActionResult<VehicleMakeResponse>> PostVehicleMake(VehicleMakeRequest vehicleMake)
        {
            var Validationresult = await _RequestValidator.ValidateAsync(vehicleMake);
            if (!Validationresult.IsValid)
            {
                var errors = string.Join("\n", Validationresult.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            var NewMake = await _VehicleMakesService.AddMake(vehicleMake);
            
            if (!NewMake.IsSuccess)
            {
                return Problem(NewMake.ErrorMessage);
            }

            return Ok(NewMake.Data);
        }

    }
}
