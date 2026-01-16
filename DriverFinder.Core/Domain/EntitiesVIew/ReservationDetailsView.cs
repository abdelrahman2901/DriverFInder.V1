namespace DriverFinder.Core.Domain.EntitiesVIew
{
    public class ReservationDetailsView
    {
        public Guid? ReservationID { get; set; }
        public string? PersonName { get; set; }
        public string? User_PhoneNumber { get; set; }
        public string? InstructorName { get; set; }
        public string? Instructor_PhoneNumber { get; set; }
        //public string?  Program                  {get;set;}
        //public string?  ProgramType              {get;set;}
        public string? DateOfAttendance { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }
    }
}
