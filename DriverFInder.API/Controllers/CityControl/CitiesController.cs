using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.CityDTO;
using DriverFinder.Core.ServicesContracts.ICityServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.UI.Controllers.CityControl
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _CityService;

        public CitiesController(ICityService CityService)
        {
            _CityService = CityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityResponse>>> GetAllCities()
        {
            Result<IEnumerable<CityResponse>> Cities = await _CityService.GetAllCities();
            if (!Cities.IsSuccess)
            {
                return Problem(Cities.ErrorMessage);
            }
            return Ok(Cities.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityResponse>> GetCity(Guid id)
        {
            Result<CityResponse> City = await _CityService.GetCity(id);
            if (!City.IsSuccess)
            {
                return Problem(City.ErrorMessage);
            }
            return Ok(City.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(Guid id, CityUpdateRequest CityRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(string.Join('\n', errors));
            }
            Result<CityResponse> UpdatedCity = await _CityService.UpdateCity(CityRequest);
            if (!UpdatedCity.IsSuccess)
            {
                return Problem(UpdatedCity.ErrorMessage);
            }
            return Ok(UpdatedCity.Data);
        }

        [HttpPost]
        public async Task<ActionResult<CityResponse>> PostCity(CityRequest CityRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(string.Join('\n', errors));
            }
            Result<CityResponse> AddedCity = await _CityService.AddCity(CityRequest);
            if (!AddedCity.IsSuccess)
            {
                return Problem(AddedCity.ErrorMessage);
            }
            return Ok(AddedCity.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            Result<bool> isRemoved = await _CityService.DeleteCity(id);
            if (!isRemoved.IsSuccess)
            {
                return Problem(isRemoved.ErrorMessage);
            }
            return Ok(isRemoved.Data);
        }


    }
}
