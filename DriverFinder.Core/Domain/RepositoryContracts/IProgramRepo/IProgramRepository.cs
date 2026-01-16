using DriverFinder.Core.Domain.Entites;
using System;

namespace DriverFinder.Core.Domain.RepositoryContracts.IProgramRepo
{
    public interface IProgramRepository
    {
        public Task<IEnumerable<Programs>> GetDrivingPrograms();


        public Task<Programs> AddDrivingProgram(Programs newprogram);
        public Task<Programs?> GetDrivingProgram(Guid id);
    }
}
