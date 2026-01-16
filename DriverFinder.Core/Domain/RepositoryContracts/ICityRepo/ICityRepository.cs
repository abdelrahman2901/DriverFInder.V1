
using DriverFinder.Core.Domain.Entites;
 

namespace DriverFinder.Core.Domain.RepositoryContracts.ICityRepo
{
    public interface ICityRepository
    {
        public Task<IEnumerable<City>> GetAllCities();
        public Task<City?> GetCity(Guid id);
        public Task<City?> UpdateCity(City City);
        public Task<City?> AddCity(City City); 
        public Task<bool> DeleteCity(City City);
        public Task<bool> IsCityExistsByName(string CityName);
        public Task<bool> IsCityExistsByID(Guid CityID  );
    }
}
