using DriverFinder.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriverFinder.Core.Domain.Entites
{
    public class DrivingInstructors
    {
        [Key]
        public Guid InstructorID { get; set; }
        
        [Required(ErrorMessage = "Driving School ID is required")]
        public Guid SchoolID { get; set; }
        
        [ForeignKey(nameof(SchoolID))]
        public DrivingSchool? School { get; set; }
        
        [Required(ErrorMessage = "Instructor Name is required")]
        public string InstructorName { get; set; }

        [Required(ErrorMessage = "Instructor Phone Number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Experience is required")]
        public int Experience { get; set; }

        public InstructorGender Gender { get; set; }
        public string? InsturctorImgUrl { get; set; }
        public string? ImageHash { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Reviews> Reviews { get; set; }

    }
}
