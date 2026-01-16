using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolProgramsRepo;
using DriverFinder.Core.DTO.SchoolProgramsDTO;
using DriverFinder.Core.ServicesContracts.ISchoolProgramsServices;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace DriverFinder.Core.Services.SchoolProgramsServices
{
    public class SchoolProgramsService : ISchoolProgramsService
    {
        private readonly ISchoolProgramsRepository _schoolProgramsRepo;
        public SchoolProgramsService(ISchoolProgramsRepository schoolProgramsRepo)
        {
            _schoolProgramsRepo = schoolProgramsRepo;
        }


        public async Task<Result<IEnumerable<SchoolProgramResponse>>> GetAllSchoolPrograms(Guid SchoolID)
        {
            IEnumerable<SchoolPrograms> schoolPrograms = await _schoolProgramsRepo.GetAllSchoolPrograms(SchoolID);
            if (schoolPrograms.Count() == 0)
            {
                return Result<IEnumerable<SchoolProgramResponse>>.Failure("No School Programs found for the given School ID");
            }
            return Result<IEnumerable<SchoolProgramResponse>>.Success(schoolPrograms.Select(sp => sp.ToSchoolProgramResponse()));
        }

        public async Task<Result<IEnumerable<SchoolProgramResponse>>> GetAllSchoolsPrograms()
        {
            IEnumerable<SchoolPrograms> schoolsPrograms = await _schoolProgramsRepo.GetAllSchoolsPrograms();
            if (schoolsPrograms.Count() == 0)
            {
                return Result<IEnumerable<SchoolProgramResponse>>.Failure("No School Programs found for the given School ID");
            }
            return Result<IEnumerable<SchoolProgramResponse>>.Success(schoolsPrograms.Select(sp => sp.ToSchoolProgramResponse()));
        }

        public async Task<Result<SchoolProgramResponse>> GetSchoolProgramByID(Guid SchoolID)
        {
            SchoolPrograms? schoolPrograms = await _schoolProgramsRepo.GetSchoolProgramByID(SchoolID);
            if (schoolPrograms == null)
            {
                return Result<SchoolProgramResponse>.Failure("School Program not found");
            }
            return Result<SchoolProgramResponse>.Success(schoolPrograms.ToSchoolProgramResponse());
        }

        public async Task<Result<SchoolProgramResponse>> AddSchoolProgram(SchoolProgramRequest schoolProgramRequest)
        {

            if (await IsProgramExists(schoolProgramRequest))
            {
                return Result<SchoolProgramResponse>.Failure("School Program Already Exists");
            }

            SchoolPrograms NewSchoolProgram = schoolProgramRequest.ToSchoolProgram();
           
            SchoolPrograms? results = await _schoolProgramsRepo.AddSchoolProgram(NewSchoolProgram);

            if (results == null)
            {
                return Result<SchoolProgramResponse>.Failure("Failed To Add School Program");
            }
            return Result<SchoolProgramResponse>.Success(results.ToSchoolProgramResponse());
        }

        public async Task<Result<bool>> DeleteSchoolProgram(Guid SchoolProgramID)
        {
            SchoolPrograms? schoolProgram = await _schoolProgramsRepo.GetSchoolProgramByID(SchoolProgramID);
            if (schoolProgram == null)
            {
                return Result<bool>.Failure("School Program not found");
            }
          
            return Result<bool>.Success(await _schoolProgramsRepo.DeleteSchoolProgram(schoolProgram));
        }
        public async Task<Result<SchoolProgramResponse>> UpdateSchoolProgram(UpdateProgramRequest UpdateSchoolProgramRequest)
        {
            SchoolPrograms? schoolProgram = await _schoolProgramsRepo.GetSchoolProgramByID(UpdateSchoolProgramRequest.SchoolProgramID);
            if (schoolProgram == null)
            {
                return Result<SchoolProgramResponse>.Failure("School Program not found");
            }

            SchoolPrograms UpdatedProgram = CheckUpdatedProperties(UpdateSchoolProgramRequest, schoolProgram);

            SchoolPrograms? updatedSchoolProgram = await _schoolProgramsRepo.UpdateSchoolProgram(UpdatedProgram);
            if (schoolProgram == null)
            {
                return Result<SchoolProgramResponse>.Failure("Failed To Update School Program");
            }

            return Result<SchoolProgramResponse>.Success(updatedSchoolProgram.ToSchoolProgramResponse());
        }
        public async Task<Result<bool>> ChangeProgramActiveStatus(Guid ProgramID)
        {
            SchoolPrograms? updatedschoolProgram = await _schoolProgramsRepo.GetSchoolProgramByID(ProgramID);
            if (updatedschoolProgram == null)
            {
                return Result<bool>.Failure("School Program not found");
            }
            updatedschoolProgram.IsActive = !(updatedschoolProgram.IsActive);

            SchoolPrograms? updatedSchoolProgram = await _schoolProgramsRepo.UpdateSchoolProgram(updatedschoolProgram);
            if (updatedschoolProgram == null)
            {
                return Result<bool>.Failure("Failed To Update School Program");
            }

            return Result<bool>.Success(updatedschoolProgram.IsActive);
        }

         private SchoolPrograms CheckUpdatedProperties(UpdateProgramRequest UpdateSchoolProgramRequest, SchoolPrograms existingProgram)
        {
            existingProgram.Price = (UpdateSchoolProgramRequest.Price != default || UpdateSchoolProgramRequest.Price != existingProgram.Price) ? UpdateSchoolProgramRequest.Price : existingProgram.Price;
            existingProgram.DurationInWeeks = (UpdateSchoolProgramRequest.DurationInWeeks != default || UpdateSchoolProgramRequest.DurationInWeeks != existingProgram.DurationInWeeks) ? UpdateSchoolProgramRequest.DurationInWeeks : existingProgram.DurationInWeeks;
            existingProgram.NumberOfSessions = (UpdateSchoolProgramRequest.NumberOfSessions != default || UpdateSchoolProgramRequest.NumberOfSessions != existingProgram.NumberOfSessions) ? UpdateSchoolProgramRequest.NumberOfSessions : existingProgram.NumberOfSessions;
            existingProgram.NumberOfSessionsPerWeek = (UpdateSchoolProgramRequest.NumberOfSessionsPerWeek != default || UpdateSchoolProgramRequest.NumberOfSessionsPerWeek != existingProgram.NumberOfSessionsPerWeek) ? UpdateSchoolProgramRequest.NumberOfSessionsPerWeek : existingProgram.NumberOfSessionsPerWeek;
            existingProgram.SessionDuration = (UpdateSchoolProgramRequest.SessionDuration != default || UpdateSchoolProgramRequest.SessionDuration != existingProgram.SessionDuration) ? UpdateSchoolProgramRequest.SessionDuration : existingProgram.SessionDuration;
            existingProgram.VehicleID = (UpdateSchoolProgramRequest.VehicleID != default || UpdateSchoolProgramRequest.VehicleID != existingProgram.VehicleID) ? UpdateSchoolProgramRequest.VehicleID : existingProgram.VehicleID;
            existingProgram.Description = (UpdateSchoolProgramRequest.Description != default || UpdateSchoolProgramRequest.Description != existingProgram.Description) ? UpdateSchoolProgramRequest.Description : existingProgram.Description;
            existingProgram.IsActive = UpdateSchoolProgramRequest.IsActive != existingProgram.IsActive ? UpdateSchoolProgramRequest.IsActive : existingProgram.IsActive;
            return existingProgram;
        }
        private async Task<bool> IsProgramExists(SchoolProgramRequest schoolProgramRequest)
        {
            var existingPrograms = await _schoolProgramsRepo.GetAllSchoolPrograms(schoolProgramRequest.SchoolID);
            return existingPrograms.Any(sp => sp.Price.Equals(schoolProgramRequest.Price)
            && (sp.NumberOfSessions.Equals(schoolProgramRequest.NumberOfSessions))
            && (sp.NumberOfSessionsPerWeek.Equals(schoolProgramRequest.NumberOfSessionsPerWeek))
            && (sp.ProgramID.Equals(schoolProgramRequest.ProgramID))
            && (sp.ProgramTypeID.Equals(schoolProgramRequest.ProgramTypeID))
            && (sp.VehicleID.Equals(schoolProgramRequest.VehicleID)));

        }
      

      
    
    }
}
