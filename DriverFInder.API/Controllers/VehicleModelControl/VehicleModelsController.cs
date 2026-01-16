using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.DTO.VehicalDTO.VehicleModelDTO;
using DriverFinder.Core.ServicesContracts.IVehicleModelServices;
using DriverFinder.Core.Validation.VehiclesValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.UI.Controllers.VehicleModelControl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelsController : ControllerBase
    {
        private readonly IVehicleModelServices _VehicleModelService;
        private readonly VehicleModelRequestValidation _RequestValidator;

        public VehicleModelsController(IVehicleModelServices VehicleModelService, VehicleModelRequestValidation RequestValidator)
        {
            _VehicleModelService = VehicleModelService;
            _RequestValidator = RequestValidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleModelResponse>>> GetVehicleModel()
        {
            var VehicleModels = await _VehicleModelService.GetAllVehicleModels();
            if (!VehicleModels.IsSuccess)
            {
                return Problem(VehicleModels.ErrorMessage);
            }
            
            return Ok(VehicleModels.Data) ;
        }
        [HttpPost]
        public async Task<ActionResult<VehicleModelResponse>> PostModel(VehicleModelRequest ModelReqeust)
        {
            var Validationresult = await _RequestValidator.ValidateAsync(ModelReqeust);
            if (!Validationresult.IsValid)
            {
                var errors = string.Join("\n", Validationresult.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }

            var NewModel = await _VehicleModelService.AddModel(ModelReqeust);

            if (!NewModel.IsSuccess)
            {
                return Problem(NewModel.ErrorMessage);  
            }
            return Ok(NewModel.Data);
        }
    }
}
