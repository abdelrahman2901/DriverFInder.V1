using DriverFinder.Core.Domain.Entites;

namespace DriverFinder.Core.DTO.AreaDTO
{
    public class AreaResponse
    {

        public Guid AreaID { get; set; }
        public Guid CityID { get; set; }
        public string AreaName { get; set; }
    
    }
    public static class AreaResponseMapper
    {
        public static AreaResponse ToAreaResponse(this Area area)
        {
            
            return new AreaResponse
            {
                AreaID = area.AreaID,
                CityID = area.CityID,
                AreaName = area.AreaName
            };
        }
    }
}
