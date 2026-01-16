using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using System;

namespace DriverFinder.Core.ServicesContracts.IProgramServices
{
    public interface IProgramService
    {
          Task<Result<IEnumerable<Programs>>> GetDrivingPrograms();

          Task<Result<Programs?>> AddDrivingProgram(Programs program);

          Task<Result<Programs?>> GetDrivingProgram(Guid id);
    }
}
