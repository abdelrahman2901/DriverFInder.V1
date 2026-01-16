using DriverFinder.Core.Enums;
using DriverFinder.Core.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriverFinder.Core.Domain.Entites
{
    public class Reservation
    {
        [Key]
        public Guid ReservationID { get; set; }
        public Guid? UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public ApplicationUser User { get; set; }
        [Required(ErrorMessage = "SchoolID Is Required")]
        public Guid SchoolID { get; set; }
        [ForeignKey(nameof(SchoolID))]
        public DrivingSchool School { get; set; }

        [Required(ErrorMessage = "schoolProgram ID Is Required")]
        public Guid SchoolProgramID { get; set; }
        [ForeignKey(nameof(SchoolProgramID))]
        public SchoolPrograms SchoolProgram { get; set; }

        [Required(ErrorMessage = "Instructor ID is required")]
        public Guid? InstructorID { get; set; }
        [ForeignKey(nameof(InstructorID))]
        public DrivingInstructors? Instructor { get; set; }

        [Required(ErrorMessage = "Start Date Is Required")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "End Date Is Required")]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Reservation Status Is Required")]
        public ReservationStatus Status { get; set; }


    }
}
