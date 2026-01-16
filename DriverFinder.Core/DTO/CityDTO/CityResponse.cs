using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.DTO.CityDTO
{
    public class CityResponse
    {
        public Guid CityID { get; set; }
        public string CityName { get; set; }

    }

    public static class CityResponseExtensions
    {
        public static CityResponse ToCityResponse(this City city)
        {
            return new CityResponse
            {
                CityID = city.CityID,
                CityName = city.CityName
            };
        }
    }

}
