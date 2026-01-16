using System;
using System.ComponentModel.DataAnnotations;

namespace DriverFinder.Core.Domain.Entites
{
    public class RegistrationDocuemnts
    {
        [Key]
        public Guid RegistrationID{get;set;}
        [Required]
        public Guid SchoolID { get; set; }
        [Required]
        public string drivingSchoolLicense { get; set; }
    }
}
