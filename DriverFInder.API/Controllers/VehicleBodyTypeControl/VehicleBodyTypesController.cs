using DriverFinder.Core.DTO.VehicalDTO.VehicleBodyTypeDTO;
using DriverFinder.Core.ServicesContracts.IVehicleBodyTypeServices;
using Microsoft.AspNetCore.Mvc;

namespace DriverFinder.UI.Controllers.VehicleBodyTypeControl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleBodyTypesController : ControllerBase
    {
        private readonly IVehicleBodyTypeServices _vehicleBodyTypeService;

        public VehicleBodyTypesController(IVehicleBodyTypeServices vehicleBodyTypeService)
        {
            _vehicleBodyTypeService = vehicleBodyTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleBodyTypeResponse>>> GetVehicleBodyType()
        {
            var VehicleBodyTypes = await _vehicleBodyTypeService.GetAllVehicleBodyTypes();
            if (!VehicleBodyTypes.IsSuccess)
            {
                return Problem(VehicleBodyTypes.ErrorMessage);
            }
            return Ok(VehicleBodyTypes.Data);
        }

        [HttpGet("{Category}")]
        public async Task<ActionResult<IEnumerable<VehicleBodyTypeResponse>>> GetVehicleBodyType(string Category)
        {
            var VehicleBodyTypes = await _vehicleBodyTypeService.GetAllVehicleBodyTypesByCategory(Category);
            if (!VehicleBodyTypes.IsSuccess)
            {
                return Problem(VehicleBodyTypes.ErrorMessage);
            }
            return Ok(VehicleBodyTypes.Data);
        }


    }
}
