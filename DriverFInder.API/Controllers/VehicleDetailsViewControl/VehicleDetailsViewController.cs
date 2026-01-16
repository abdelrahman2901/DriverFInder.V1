using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.ServicesContracts.IVehicleDetailsViewServices;
using Microsoft.AspNetCore.Mvc;

namespace DriverFinder.UI.Controllers.VehicleDetailsViewControl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDetailsViewController : ControllerBase
    {
        private readonly IVehicleDetailsViewService _vehicleDetailsViewService;
        public VehicleDetailsViewController(IVehicleDetailsViewService vehicleDetailsViewService)
        {
            _vehicleDetailsViewService = vehicleDetailsViewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDetailsView>>> GetAllVehicleDetails()
        {
            var Vehicles = await _vehicleDetailsViewService.GetVehiclesDetails();
            if (!Vehicles.IsSuccess)
            {
                return Problem(Vehicles.ErrorMessage);
            }
            return Ok(Vehicles.Data);
        }

        [HttpGet("{SchoolID}")]
        public async Task<ActionResult<IEnumerable<VehicleDetailsView>>> GetAllVehicleDetails(Guid SchoolID)
        {
            var Vehicles = await _vehicleDetailsViewService.GetVehiclesDetailsBySchoolID(SchoolID);
            if (!Vehicles.IsSuccess)
            {
                return Problem(Vehicles.ErrorMessage);
            }
            return Ok(Vehicles.Data);
        }
        [HttpGet("GetVehicleDetailsByID/{VehicleID}")]
        public async Task<ActionResult<VehicleDetailsView>> GetVehicleDetailsByID(Guid VehicleID)
        {
            var Vehicle = await _vehicleDetailsViewService.GetVehicleDetailsByID(VehicleID);
            if (!Vehicle.IsSuccess)
            {
                return Problem(Vehicle.ErrorMessage);
            }
            return Ok(Vehicle.Data);
        }
    }
}
