

namespace DriverFinder.Core.Domain.EntitiesVIew
{
    public class SchoolProgramsView
    {
        public Guid SchoolProgramID { get; set; }
        public Guid SchoolID { get; set; }
        public Guid VehicleID { get; set; }
        public string? Program { get; set; }
        public string? ProgramType { get; set; }
        public string? VehicleMake { get; set; }
        public string? VehicleModel { get; set; }
        public string? vehicleImgUrl { get; set; }
        public string? description { get; set; }
        public decimal Price { get; set; }
        public short DurationInWeeks { get; set; }
        public short NumberOfSessions { get; set; }
        public short NumberOfSessionsPerWeek { get; set; }
        public short SessionDuration { get; set; }
        public bool IsActive { get; set; }

    }
}
