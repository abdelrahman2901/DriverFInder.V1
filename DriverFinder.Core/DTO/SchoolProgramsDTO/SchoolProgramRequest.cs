using DriverFinder.Core.Domain.Entites;


namespace DriverFinder.Core.DTO.SchoolProgramsDTO
{
    public class SchoolProgramRequest
    {
        public Guid SchoolID { get; set; }
        public Guid ProgramID { get; set; }
        public Guid? ProgramTypeID { get; set; }
        public Guid? VehicleID { get; set; }
        public string? vehicleImgUrl { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public short DurationInWeeks { get; set; }
        public short NumberOfSessions { get; set; }
        public short NumberOfSessionsPerWeek { get; set; }
        public short SessionDuration { get; set; }
        public bool IsActive { get; set; } = true;

        public SchoolPrograms ToSchoolProgram()
        {
            return new SchoolPrograms
            {
                SchoolProgramID = Guid.NewGuid(),
                SchoolID = this.SchoolID,
                ProgramID = this.ProgramID,
                ProgramTypeID = this.ProgramTypeID,
                VehicleID = VehicleID,
                Description = this.Description,
                Price = this.Price,
                DurationInWeeks = this.DurationInWeeks,
                NumberOfSessions = this.NumberOfSessions,
                NumberOfSessionsPerWeek = this.NumberOfSessionsPerWeek,
                SessionDuration = this.SessionDuration,
                IsActive = this.IsActive
            };
        }
    }
}
