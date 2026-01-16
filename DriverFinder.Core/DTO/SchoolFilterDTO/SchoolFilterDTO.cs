using System;

namespace DriverFinder.Core.DTO.SchoolFilterDTO
{
    public class SchoolFilterDTO
    {
        public string? schoolName { get; set; }
        public string? City { get; set; }
        public string? Area{ get; set; }
        //public string? location { get; set; }
        public string? program { get; set; }
        public string? programType { get; set; }
        public bool Verified { get; set; }
        public bool hasFemaleInstructor { get; set; }

    }
}
