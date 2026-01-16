using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleModelRepo;
using DriverFinder.Core.DTO.VehicalDTO.VehicleModelDTO;
using DriverFinder.Core.ServicesContracts.IVehicleModelServices;

namespace DriverFinder.Core.Services.VehicleModelServices
{
    public class VehicleModelService : IVehicleModelServices
    {

        private readonly IVehicleModelRepository _VehicleModelRepo;

        public VehicleModelService(IVehicleModelRepository VehicleTransmissionRepo)
        {
            _VehicleModelRepo = VehicleTransmissionRepo;
        }

        public async Task<Result<VehicleModelResponse>> AddModel(VehicleModelRequest NewModel)
        {
            if (await _VehicleModelRepo.IsModelExists(NewModel.Model))
            {
                return Result<VehicleModelResponse>.Failure("model Already Exists");
            }
            VehicleModel? addedModel = await _VehicleModelRepo.AddModel(NewModel.ToVehicleModel());
            if (addedModel != null)
            {
                return Result<VehicleModelResponse>.Failure("Failed to Add The Model");
            }

            return Result<VehicleModelResponse>.Success(addedModel.ToVehicleModelResponse());
        }

        public async Task<Result<IEnumerable<VehicleModelResponse>>> GetAllVehicleModels()
        {
            var VEhiclemodels = await _VehicleModelRepo.GetAllVehicleModels();
            if (VEhiclemodels.Count() == 0)
            {
                return Result<IEnumerable<VehicleModelResponse>>.Failure("No Models was Found.");
            }
            return Result<IEnumerable<VehicleModelResponse>>.Success(VEhiclemodels.Select(vm=>vm.ToVehicleModelResponse()).ToList());
        }

    }
}
