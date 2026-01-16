using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.ProgramTypesRepo;
using DriverFinder.Core.ServicesContracts.IProgramTypesServices;
using System;

namespace DriverFinder.Core.Services.ProgramTypesServices
{
    public class ProgramTypesService : IProgramTypesService
    {
        private readonly IProgramTypesRepository _ProgramTypesRepo;
        public ProgramTypesService(IProgramTypesRepository programTypesRepo)
        {
            _ProgramTypesRepo = programTypesRepo;
        }

        public async Task<Result<ProgramTypes?>> AddProgramType(ProgramTypes? programType)
        {
            ProgramTypes? Results = await _ProgramTypesRepo.AddProgramType(programType);
            if (Results == null)
            {
                return Result<ProgramTypes?>.Failure("Failed To Add Program Type");
            }
            return Result<ProgramTypes?>.Success(Results);
        }

        public async Task<Result<IEnumerable<ProgramTypes>>> GetProgramTypes()
        {
            IEnumerable<ProgramTypes> ProgramTypes = await _ProgramTypesRepo.GetProgramTypes();
            if (ProgramTypes.Count() == 0)
            {
                return Result<IEnumerable<ProgramTypes>>.Failure("No Program Types Found");
            }
            return Result<IEnumerable<ProgramTypes>>.Success(ProgramTypes);
        }

        public async Task<Result<ProgramTypes?>> GetProgramTypes(Guid id)
        {
            ProgramTypes? ProgramType = await _ProgramTypesRepo.GetProgramTypes(id);
            if (ProgramType == null)
            {
                return Result<ProgramTypes?>.Failure("Program Type not found");
            }
            return Result<ProgramTypes?>.Success(ProgramType);
        }
    }
}
