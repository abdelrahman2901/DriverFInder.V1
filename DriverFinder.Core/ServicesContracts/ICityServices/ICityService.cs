
using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.CityDTO;

namespace DriverFinder.Core.ServicesContracts.ICityServices
{
    public interface ICityService 
    {
        public Task<Result<IEnumerable<CityResponse>>> GetAllCities();
        public Task<Result<CityResponse>> GetCity(Guid id);
        public Task<Result<CityResponse>> UpdateCity(CityUpdateRequest City);
        public Task<Result<CityResponse>> AddCity(CityRequest City);
        public Task<Result<bool>> DeleteCity(Guid id);
    }
}
