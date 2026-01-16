using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IProgramRepo;
using DriverFinder.Core.ServicesContracts.IProgramServices;
using System;

namespace DriverFinder.Core.Services.ProgramServices
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _ProgramRepo;
        public ProgramService(IProgramRepository programRepo)
        {
            _ProgramRepo = programRepo;
        }

        public async Task<Result<IEnumerable<Programs>>> GetDrivingPrograms()
        {
            var Programs =await _ProgramRepo.GetDrivingPrograms();
            if (Programs.Count() == 0)
            {
                return Result<IEnumerable<Programs>>.Failure("No Programs Exists");
            }
            return Result<IEnumerable<Programs>>.Success(Programs);
        }
        public async Task<Result<Programs?>> GetDrivingProgram(Guid id)
        {
            var Program = await _ProgramRepo.GetDrivingProgram(id);
            if (Program == null)
            {
                return Result<Programs?>.Failure("Program Doesnt Exists");
            }
            return Result<Programs?>.Success(Program);
        }


        public async Task<Result<Programs?>> AddDrivingProgram(Programs program)
        {
            var Results = await _ProgramRepo.AddDrivingProgram(program);
            if (Results == null)
            {
                return Result<Programs?>.Failure("Failed to add the driving program.");
            }
            return Result<Programs?>.Success(Results);
        }
    }
}
