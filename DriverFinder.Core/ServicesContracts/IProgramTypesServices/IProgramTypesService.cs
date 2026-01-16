using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using System;

namespace DriverFinder.Core.ServicesContracts.IProgramTypesServices
{
    public interface IProgramTypesService
    {
          Task<Result<IEnumerable<ProgramTypes>>> GetProgramTypes();
          Task<Result<ProgramTypes?>> GetProgramTypes(Guid id);
          Task<Result<ProgramTypes?>> AddProgramType(ProgramTypes programType);
    }   
}
