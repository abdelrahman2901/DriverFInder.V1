using DriverFinder.Core.Domain.Entites;
using System;

namespace DriverFinder.Core.DTO.SchoolProgramsDTO
{
    public class SchoolProgramResponse
    {
        public Guid SchoolProgramID { get; set; }
        public Guid SchoolID { get; set; }
        public Guid ProgramID { get; set; }
        public Guid? ProgramTypeID { get; set; }
        public Guid? VehicalID { get; set; }
        
        public string? vehicleImgUrl { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public short DurationInWeeks { get; set; }
        public short NumberOfSessions { get; set; }
        public short NumberOfSessionsPerWeek { get; set; }
        public short SessionDuration { get; set; }
        public bool IsActive { get; set; }



    }
      public static class SchoolProgramResponseExtensions
    {
        public static SchoolProgramResponse ToSchoolProgramResponse(this SchoolPrograms schoolProgram)
        {
            return new SchoolProgramResponse
            {
                SchoolProgramID = schoolProgram.SchoolProgramID,
                SchoolID = schoolProgram.SchoolID,
                ProgramID = schoolProgram.ProgramID,
                ProgramTypeID = schoolProgram.ProgramTypeID,
                VehicalID= schoolProgram.VehicleID,
                Description=schoolProgram.Description,
                Price = schoolProgram.Price,
                DurationInWeeks = schoolProgram.DurationInWeeks,
                NumberOfSessions = schoolProgram.NumberOfSessions,
                NumberOfSessionsPerWeek = schoolProgram.NumberOfSessionsPerWeek,
                SessionDuration = schoolProgram.SessionDuration,
                IsActive = schoolProgram.IsActive
            };
        }
    }
 }

