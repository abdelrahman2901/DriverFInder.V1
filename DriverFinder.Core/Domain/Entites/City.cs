
using System.ComponentModel.DataAnnotations;

namespace DriverFinder.Core.Domain.Entites
{
    public class City
    {
        [Key]
        public Guid CityID { get; set; }
        [Required(ErrorMessage = "City Name is required")]
        public string CityName { get; set; }
        public ICollection<Area> Areas { get; set; }

  
    }
}
