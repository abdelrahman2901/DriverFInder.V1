using DriverFinder.Core.Domain.Entites;
using System;

namespace DriverFinder.Core.Domain.RepositoryContracts.ProgramTypesRepo
{
    public interface IProgramTypesRepository
    {

          Task<IEnumerable<ProgramTypes>> GetProgramTypes();
         
          Task<ProgramTypes?> AddProgramType(ProgramTypes programType);

           Task<ProgramTypes?> GetProgramTypes(Guid id);


    }
}
