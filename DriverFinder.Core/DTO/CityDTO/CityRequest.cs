using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.DTO.CityDTO
{
    public class CityRequest
    {
        public string CityName { get; set; }
        public City ToCityEntity()
        {
            return new City
            {
                CityID = Guid.NewGuid(),
                CityName = this.CityName
            };
        }
    }
}
