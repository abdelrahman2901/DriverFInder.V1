using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DriverFinder.Core.Enums;

namespace DriverFinder.Core.Domain.Entites
{
    public class DrivingSchool
    {
        [Key]
        public Guid SchoolID { get; set; }
        
        [Required(ErrorMessage ="School must be associated with SchoolOwnerID")]
        public Guid OwnerID { get; set; }

        [ForeignKey(nameof(OwnerID))]
        public SchoolOwner Owner { get; set; }
        [Required(ErrorMessage ="City ID is Required")]
        public Guid CityID { get; set; }
        [ForeignKey(nameof(CityID))]
        public City City { get; set; }

        [Required(ErrorMessage = "Area ID is Required")]
        public Guid AreaID { get; set; }
        [ForeignKey(nameof(AreaID))]
        public Area Area { get; set; }

        [Required(ErrorMessage = "School Name Cant be Empty")]
        public string? SchoolName { get; set; }
        
        [Required(ErrorMessage = "phone NUmber Cant be Empty")]
        [RegularExpression("^[0-9]*$")]
        public string? PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "School Location Cant be Empty")]
        public string? Location { get; set; }
        public string? LocationURl { get; set; }
        
        [EmailAddress]
        public string? SchoolEmail { get; set; }

        [Required]
        public Guid ProgramID { get; set; }
        [ForeignKey(nameof(ProgramID))]
        public Programs Program { get; set; }
        
        public Guid? ProgramTypeID { get; set; }
        [ForeignKey(nameof(ProgramTypeID))]
        public ProgramTypes? ProgramType { get; set; }
        public string? imgURl { get; set; }
        public int? Experience { get; set; }
        public string? ImageHash { get; set; }
        public bool HasFemaleInstructor { get; set; }
        public bool isblocked { get; set; } = false;
      
        public SchoolStatusEnum? status { get; set; } 

        public double Rating { get; set; }

        public Subscriptions SubscriptionType { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Reviews> Reviews { get; set; }

    }
}
