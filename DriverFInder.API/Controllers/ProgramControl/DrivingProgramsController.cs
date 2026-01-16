using System;
using Microsoft.AspNetCore.Mvc;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.ServicesContracts.IProgramServices;
using Microsoft.AspNetCore.Authorization;
using DriverFinder.Core.Domain.Common;
namespace DriverFinder.UI.Controllers.ProgramControl
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DrivingProgramsController : ControllerBase
    {
        private readonly IProgramService _ProgramService;

        public DrivingProgramsController(IProgramService ProgramService)
        { 
            _ProgramService = ProgramService;
        }

        /// <summary>
        /// Retrieves all driving programs.
        /// </summary>
        /// <returns>An asynchronous operation that returns an <see cref="ActionResult{T}"/> containing a collection of <see
        /// cref="Programs"/> objects. The collection is empty if no driving programs are found.</returns>
        // GET: api/DrivingPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programs>>> GetDrivingPrograms()
        {
            Result<IEnumerable<Programs>> Programs = await _ProgramService.GetDrivingPrograms();

            if (!Programs.IsSuccess)
            {
                return Problem(Programs.ErrorMessage);
            }
            return Ok(Programs.Data);
        }

        /// <summary>
        /// Retrieves the driving program with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the driving program to retrieve.</param>
        /// <returns>An <see cref="ActionResult{T}"/> containing the driving program if found; otherwise, a 404 Not Found
        /// response.</returns>
        // GET: api/DrivingPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Programs>> GetDrivingProgram(Guid id)
        {
            Result<Programs> drivingProgram = await _ProgramService.GetDrivingProgram(id);

            if (!drivingProgram.IsSuccess )
            {
                return Problem(drivingProgram.ErrorMessage);
            }

            return Ok(drivingProgram.Data);
        }

    }
}
