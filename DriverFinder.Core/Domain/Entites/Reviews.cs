using DriverFinder.Core.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriverFinder.Core.Domain.Entites
{
    public class Reviews
    {
        [Key]
        public Guid ReviewID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public ApplicationUser User { get; set; }
       
        [Required]
        public Guid SchoolID { get; set; }
        [ForeignKey(nameof(SchoolID))]
        public DrivingSchool School { get; set; }

        [Required]
        public Guid InstructorID { get; set; }
        [ForeignKey(nameof(InstructorID))]
        public DrivingInstructors Instructor { get; set; }
        [Required]
        public short SchoolRating { get; set; }
        [Required]
        public short InstructorRating { get; set; }
        public string? SchoolReviewDescription { get; set; }
        public string? InstructorReviewDescription { get; set; }
        public string UserName { get; set; }
        public int helpFullReviewCount { get; set; }
        public DateTime ReviewDate { get; set; }

    }
}
