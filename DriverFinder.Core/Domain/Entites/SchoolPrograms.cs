using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace DriverFinder.Core.Domain.Entites
{
    public class SchoolPrograms
    {
        [Key]
        public Guid SchoolProgramID { get; set; }
        
        [Required(ErrorMessage = "School ID is required")]
        public Guid SchoolID { get; set; }

        [ForeignKey(nameof(SchoolID))]
        public DrivingSchool school { get; set; }

        [Required(ErrorMessage = "Program ID is required")]
        public Guid ProgramID { get; set; }
        [ForeignKey(nameof(ProgramID))]
        public Programs Program { get; set; }

        public Guid? ProgramTypeID { get; set; }
        [ForeignKey(nameof(ProgramTypeID))]
        public ProgramTypes ProgramType { get; set; } 
        [Required(ErrorMessage = "Vehical ID is required")]
        public Guid? VehicleID { get; set; }
        [ForeignKey(nameof(VehicleID))]
        public SchoolsVehicles? Vehicle { get; set; }
       
         
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public short DurationInWeeks { get; set; }
        [Required]
        public short NumberOfSessions { get; set; }
        [Required]
        public short NumberOfSessionsPerWeek { get; set; }
        [Required]
        public short SessionDuration { get; set; }
        [Required]
        public bool IsActive { get; set; }


        public ICollection<Reservation> Reservations { get; set; }
    }
}
