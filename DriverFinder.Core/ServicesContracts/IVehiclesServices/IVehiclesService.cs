using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.VehicalDTO;
using Microsoft.AspNetCore.Http;

namespace DriverFinder.Core.ServicesContracts.IVehiclesServices
{
    public interface IVehiclesService
    {
        Task<Result<IEnumerable<VehicleResponse>>> GetAllSchoolsVehicles();
        Task<Result<VehicleResponse>> GetVehicleById(Guid vehicleId);
        Task<Result<IEnumerable<VehicleResponse>>> GetAllSchoolVehicles(Guid schoolId);
        Task<Result<VehicleResponse>> AddNewVehicle(VehicleRequests request,IFormFile VehicleImage);
        Task<Result<VehicleResponse>> UpdateVehicle(UpdateVehicleRequest request,IFormFile NewVehicleImage);
        Task<Result<bool>> DeleteVehicle(Guid vehicleId);
    }
}
