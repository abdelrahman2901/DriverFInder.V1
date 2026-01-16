using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleMakeRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleModelRepo;
using DriverFinder.Core.DTO.VehicalDTO.VehicleMakeDTO;
using DriverFinder.Core.DTO.VehicalDTO.VehicleModelDTO;
using DriverFinder.Core.ServicesContracts.IVehicleMakeServices;

namespace DriverFinder.Core.Services.VehicleMakeServices
{
    public class VehicleMakeService : IVehicleMakeServices
    {
        private readonly IVehicleMakeRepository _VehicleMakeRepo;

        public VehicleMakeService(IVehicleMakeRepository VehicleMakeRepo)
        {
            _VehicleMakeRepo = VehicleMakeRepo;
        }

        public async Task<Result<VehicleMakeResponse>> AddMake(VehicleMakeRequest NewMake)
        {
            if (await _VehicleMakeRepo.IsMakeExists(NewMake.Make))
            {
                return Result<VehicleMakeResponse>.Failure("model Already Exists");
            }
            VehicleMake? addedMake = await _VehicleMakeRepo.AddMake(NewMake.toVehicleMake());
            if (addedMake != null)
            {
                return Result<VehicleMakeResponse>.Failure("Failed to Add The Make");
            }

            return Result<VehicleMakeResponse>.Success(addedMake.ToVehicleResponse());
        }

        public async Task<Result<IEnumerable<VehicleMakeResponse>>> GetAllVehicleMakes()
        {
            var VEhiclemakes = await _VehicleMakeRepo.GetAllVehicleMakes();
            if (VEhiclemakes.Count() == 0)
            {
                return Result<IEnumerable<VehicleMakeResponse>>.Failure("No Makes was Found.");
            }
            return Result<IEnumerable<VehicleMakeResponse>>.Success(VEhiclemakes.Select(vm => vm.ToVehicleResponse()).ToList());
        }

        public async Task<Result<IEnumerable<VehicleMakeResponse>>> GetAllVehicleMakesByCategory(string Category)
        {
            var VEhiclemakes = await _VehicleMakeRepo.GetAllVehicleMakesByCategory(Category);
            if (VEhiclemakes.Count() == 0)
            {
                return Result<IEnumerable<VehicleMakeResponse>>.Failure("No Makes was Found.");
            }
            return Result<IEnumerable<VehicleMakeResponse>>.Success(VEhiclemakes.Select(vm => vm.ToVehicleResponse()).ToList());

        }
    }
}
