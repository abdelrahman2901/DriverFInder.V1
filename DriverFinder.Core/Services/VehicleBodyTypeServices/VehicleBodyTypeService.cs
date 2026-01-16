using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleBodyTypeRepo;
using DriverFinder.Core.DTO.VehicalDTO.VehicleBodyTypeDTO;
using DriverFinder.Core.ServicesContracts.IVehicleBodyTypeServices;

namespace DriverFinder.Core.Services.VehicleBodyTypeServices
{
    public class VehicleBodyTypeService : IVehicleBodyTypeServices
    {

        private readonly IVehicleBodyTypeRepository _VehicleBodyTypeRepo;

        public VehicleBodyTypeService(IVehicleBodyTypeRepository VehicleBodyTypeRepo)
        {
            _VehicleBodyTypeRepo = VehicleBodyTypeRepo;
        }

        public async Task<Result<IEnumerable<VehicleBodyTypeResponse>>> GetAllVehicleBodyTypes()
        {
            var bodytypes = await _VehicleBodyTypeRepo.GetAllVehicleBodyTypes();

            if (bodytypes.Count() == 0)
            {
                return Result<IEnumerable<VehicleBodyTypeResponse>>.Failure("no BodyTypes was found");
            }
            return Result<IEnumerable<VehicleBodyTypeResponse>>.Success(bodytypes.Select(s=>s.ToBodyTypeResponse()).ToList());
        }
        public async Task<Result<IEnumerable<VehicleBodyTypeResponse>>> GetAllVehicleBodyTypesByCategory(string Category)
        {
            var bodytypes = await _VehicleBodyTypeRepo.GetAllVehicleBodyTypesByCategory(Category);

            if (bodytypes.Count() == 0)
            {
                return Result<IEnumerable<VehicleBodyTypeResponse>>.Failure($"no BodyTypes For {Category} was found");
            }
            return Result<IEnumerable<VehicleBodyTypeResponse>>.Success(bodytypes.Select(s => s.ToBodyTypeResponse()).ToList());
        }
    }
}
