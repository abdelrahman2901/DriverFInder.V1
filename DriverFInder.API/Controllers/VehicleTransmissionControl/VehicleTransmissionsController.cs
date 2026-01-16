using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.DTO.VehicalDTO.VehicleTransmissionDTO;
using DriverFinder.Core.ServicesContracts.IVehicleTransmissionServices;
using Microsoft.AspNetCore.Mvc;

namespace DriverFinder.UI.Controllers.VehicleTransmissionControl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTransmissionsController : ControllerBase
    {
        private readonly IVehicleTransmissionServices _VehicleTransmissionService;

        public VehicleTransmissionsController(IVehicleTransmissionServices VehicleTransmissionService)
        { 
            _VehicleTransmissionService = VehicleTransmissionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleTransmissionResponse>>> GetVehicleTransmission()
        {
            var VehicleTransmission = await _VehicleTransmissionService.GetAllVehicleTransmissions();
            if (!VehicleTransmission.IsSuccess)
            {
                return Problem(VehicleTransmission.ErrorMessage);
            }
            return Ok(VehicleTransmission.Data);
        }

    }
}
