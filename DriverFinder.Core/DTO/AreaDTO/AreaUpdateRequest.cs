using DriverFinder.Core.Domain.Entites;
using System.ComponentModel.DataAnnotations;

namespace DriverFinder.Core.DTO.AreaDTO
{
    public class AreaUpdateRequest
    {
        [Required(ErrorMessage = "Area ID is required")]
        public Guid AreaID { get; set; }
        [Required(ErrorMessage = "City ID is required")]
        public Guid CityID { get; set; }

        [Required(ErrorMessage = "Area Name is required")]
        public string AreaName { get; set; }

        public Area ToAreaEntity()
        {
            return new Area
            {
                AreaID = this.AreaID,
                CityID = this.CityID,
                AreaName = this.AreaName
            };
        }
    }
}
