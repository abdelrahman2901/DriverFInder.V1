using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriverFinder.Core.Domain.Entites
{
    public class Area
    {
        [Key]
        public Guid AreaID { get; set; }
        [Required(ErrorMessage = "City ID is required")]
        public Guid CityID { get; set; }
        [ForeignKey(nameof(CityID))]
        public City City { get; set; }
        [Required(ErrorMessage = "Area Name is required")]
        public string AreaName { get; set; }
        

    }
}
