using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.ICityRepo;
using DriverFinder.Core.DTO.CityDTO;
using DriverFinder.Core.ServicesContracts.ICityServices;
using System.Collections.Generic;

namespace DriverFinder.Core.Services.CityServices
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Result<CityResponse>> AddCity(CityRequest City)
        {
            if(await _cityRepository.IsCityExistsByName(City.CityName))
            {
                return Result<CityResponse>.Failure("City with the same name already exists.");
            }
            City? addedCity = await _cityRepository.AddCity(City.ToCityEntity());
            if(addedCity == null)
            {
                return Result<CityResponse>.Failure("Failed to add city.");
            }
            return Result<CityResponse>.Success(addedCity.ToCityResponse());
        }

        public async Task<Result<bool>> DeleteCity(Guid id)
        {
            City? city = await _cityRepository.GetCity(id);
            if (city==null)
            {
                return Result<bool>.Failure("City with the given id does not exist.");
            }
            bool isDeleted = await _cityRepository.DeleteCity(city);
            if(!isDeleted)
            {
                return Result<bool>.Failure("Failed to delete city.");
            }
            return Result<bool>.Success(true);
        }

        public async Task<Result<IEnumerable<CityResponse>>> GetAllCities()
        {
            IEnumerable<City> cities =await  _cityRepository.GetAllCities();
            if(cities.Count()== 0)
            {
                return Result<IEnumerable<CityResponse>>.Failure("No cities found.");
            }
            return Result<IEnumerable<CityResponse>>.Success(cities.Select(c => c.ToCityResponse()));
        }

        public async Task<Result<CityResponse>> GetCity(Guid id)
        {
           City? city = await _cityRepository.GetCity(id);
            if(city == null)
            {
                return Result<CityResponse>.Failure("City with the given id does not exist.");
            }
            return Result<CityResponse>.Success(city.ToCityResponse());
        }

        public async Task<Result<CityResponse>> UpdateCity(CityUpdateRequest City)
        {
            if(!(await _cityRepository.IsCityExistsByID(City.CityID)))
            {
                return Result<CityResponse>.Failure("City with the given id does not exist.");
            }
            City? updatedCity = await _cityRepository.UpdateCity(City.ToCityEntity());
            if(updatedCity == null)
            {
                return Result<CityResponse>.Failure("Failed to update city.");
            }
            return Result<CityResponse>.Success(updatedCity.ToCityResponse());
        }
    }
}
