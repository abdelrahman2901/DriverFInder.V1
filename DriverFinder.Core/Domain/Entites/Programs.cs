using DriverFinder.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DriverFinder.Core.Domain.Entites
{
    public class Programs
    {
        [Key]
        public Guid ProgramID { get; set; }
        [Required]
        public DrivingProgramEnum Program { get; set; }

    }
}
