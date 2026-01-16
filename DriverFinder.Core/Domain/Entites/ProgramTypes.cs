using DriverFinder.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DriverFinder.Core.Domain.Entites
{
    public class ProgramTypes
    {
        [Key]
        public Guid ProgramTypeID { get; set; }
        [Required]
        public ProgramTypesEnum ProgramType { get; set; }
    }
}
