using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.AreaDTO;
using DriverFinder.Core.ServicesContracts.IAreaServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.UI.Controllers.AreaControl
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IAreaService _AreaService;

        public AreasController(IAreaService AreaService)
        {
            _AreaService = AreaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaResponse>>> GetAllAreas()
        {
            Result<IEnumerable<AreaResponse>> Areas = await _AreaService.GetAllAreas();
            if (!Areas.IsSuccess)
            {
                return Problem(Areas.ErrorMessage);
            }
            return Ok(Areas.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AreaResponse>> GetArea(Guid id)
        {
            Result<AreaResponse> Area = await _AreaService.GetArea(id);
            if (!Area.IsSuccess)
            {
                return Problem(Area.ErrorMessage);
            }
            return Ok(Area.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(Guid id, AreaUpdateRequest areaRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(string.Join('\n', errors));
            }
            Result<AreaResponse> UpdatedArea = await _AreaService.UpdateArea(areaRequest);
            if (!UpdatedArea.IsSuccess)
            {
                return Problem(UpdatedArea.ErrorMessage);
            }
            return Ok(UpdatedArea.Data);
        }

        [HttpPost]
        public async Task<ActionResult<AreaResponse>> PostArea(AreaRequest areaRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(string.Join('\n', errors));
            }
            Result<AreaResponse> AddedArea = await _AreaService.AddArea(areaRequest);
            if (!AddedArea.IsSuccess)
            {
                return Problem(AddedArea.ErrorMessage);
            }
            return Ok(AddedArea.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(Guid id)
        {
            Result<bool> isRemoved = await _AreaService.DeleteArea(id);
            if (!isRemoved.IsSuccess)
            {
                return Problem(isRemoved.ErrorMessage);
            }
            return Ok(isRemoved.Data);
        }

    }
}
