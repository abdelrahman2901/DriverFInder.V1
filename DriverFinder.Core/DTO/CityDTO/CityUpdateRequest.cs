using DriverFinder.Core.Domain.Entites;
using System.ComponentModel.DataAnnotations;

namespace DriverFinder.Core.DTO.CityDTO
{
    public class CityUpdateRequest
    {
        [Required(ErrorMessage = "CityID is Required")]
        public Guid CityID { get; set; }
        [Required(ErrorMessage = "CityName is Required")]
        public string CityName { get; set; }

        public City ToCityEntity()
        {
            return new City
            {
                CityID = CityID,
                CityName = this.CityName
            };
        }
    }

}
