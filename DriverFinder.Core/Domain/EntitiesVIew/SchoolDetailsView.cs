namespace DriverFinder.Core.Domain.EntitiesVIew
{
    public class SchoolDetailsView
    {
        public Guid SchoolID { get; set; }
        public Guid OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string? SchoolName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? Location { get; set; }
        public string? LocationUrl { get; set; }
        public string? SchoolEmail { get; set; }
        public string Program { get; set; }
        public string? ProgramType { get; set; }
        public int? experience { get; set; }
        public string? imgURl { get; set; }
        public string? status { get; set; }
        public double Rating { get; set; }

        public bool HasFemaleInstructor { get; set; }
        public string? drivingSchoolLicense { get; set; }
        public bool isblocked { get; set; }
    }
}
