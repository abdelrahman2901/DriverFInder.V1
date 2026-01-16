
namespace DriverFinder.Core.DTO.SchoolProgramsDTO
{
    public class UpdateProgramRequest
    {
        public Guid SchoolProgramID { get; set; }
        public Guid SchoolID { get; set; }
        public Guid ProgramID { get; set; }
        public Guid? ProgramTypeID { get; set; }
        public Guid VehicleID { get; set; }
       
        public string? vehicleImgUrl { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public short DurationInWeeks { get; set; }
        public short NumberOfSessions { get; set; }
        public short NumberOfSessionsPerWeek { get; set; }
        public short SessionDuration { get; set; }
        public bool IsActive { get; set; }
    }
}
