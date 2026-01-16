using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.ServicesContracts.IProgramTypesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace DriverFinder.UI.Controllers.ProgramTypesControl
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramTypesController : ControllerBase
    {

        private readonly IProgramTypesService _ProgramTypesService;
        public ProgramTypesController(IProgramTypesService ProgramTypesService)
        {
            _ProgramTypesService = ProgramTypesService;
        }

        /// <summary>
        /// Retrieves all available program types.
        /// </summary>
        /// <returns>An <see cref="ActionResult{T}"/> containing a collection of <see cref="ProgramTypes"/> objects. Returns an
        /// empty collection if no program types are found.</returns>
        // GET: api/ProgramTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramTypes>>> GetProgramTypes()
        {
            Result<IEnumerable<ProgramTypes>> ProgramTypes = await _ProgramTypesService.GetProgramTypes();
            if (!ProgramTypes.IsSuccess)
            {
                return Problem(ProgramTypes.ErrorMessage);
            }
            return Ok(ProgramTypes.Data);
        }

        /// <summary>
        /// Retrieves the program type with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the program type to retrieve.</param>
        /// <returns>An <see cref="ActionResult{ProgramTypes}"/> containing the program type if found; otherwise, a 404 Not Found
        /// response.</returns>
        // GET: api/ProgramTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramTypes>> GetProgramType(Guid id)
        {
            Result<ProgramTypes?> programTypes =await _ProgramTypesService.GetProgramTypes(id);

            if (!programTypes.IsSuccess)
            {
                return Problem(programTypes.ErrorMessage);
            }

            return Ok(programTypes.Data);
        }

       
    }
}
