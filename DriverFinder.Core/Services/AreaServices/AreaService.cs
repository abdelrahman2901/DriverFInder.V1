using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IAreaRepo;
using DriverFinder.Core.DTO.AreaDTO;
using DriverFinder.Core.ServicesContracts.IAreaServices;

namespace DriverFinder.Core.Services.AreaServices
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        public AreaService(IAreaRepository _areaRepository)
        {
            this._areaRepository = _areaRepository;
        }

        public async Task<Result<AreaResponse>> AddArea(AreaRequest area)
        {
            if (await _areaRepository.IsAreaExistsByName(area.AreaName))
            {
                return Result<AreaResponse>.Failure("Area with the same name already exists.");
            }
            Area? addedArea = await _areaRepository.AddArea(area.ToAreaEntity());
            if (addedArea == null)
            {
                return Result<AreaResponse>.Failure("Failed to add Area.");
            }
            return Result<AreaResponse>.Success(addedArea.ToAreaResponse());
        }

        public async Task<Result<bool>> DeleteArea(Guid id)
        {
            Area? Area = await _areaRepository.GetArea(id);
            if (Area == null)
            {
                return Result<bool>.Failure("Area with the given id does not exist.");
            }
            bool isDeleted = await _areaRepository.DeleteArea(Area);
            if (!isDeleted)
            {
                return Result<bool>.Failure("Failed to delete Area.");
            }
            return Result<bool>.Success(true);
        }

        public async Task<Result<IEnumerable<AreaResponse>>> GetAllAreas()
        {
            IEnumerable<Area> Areas = await _areaRepository.GetAllAreas();
            if (Areas.Count() == 0)
            {
                return Result<IEnumerable<AreaResponse>>.Failure("No cities found.");
            }
            return Result<IEnumerable<AreaResponse>>.Success(Areas.Select(c => c.ToAreaResponse()));
        }

        public async Task<Result<AreaResponse>> GetArea(Guid id)
        {
            Area? Area = await _areaRepository.GetArea(id);
            if (Area == null)
            {
                return Result<AreaResponse>.Failure("Area with the given id does not exist.");
            }
            return Result<AreaResponse>.Success(Area.ToAreaResponse());
        }

        public async Task<Result<AreaResponse>> UpdateArea(AreaUpdateRequest Area)
        {
            if (!(await _areaRepository.IsAreaExistsByID(Area.AreaID)))
            {
                return Result<AreaResponse>.Failure("Area with the given id does not exist.");
            }
            Area? updatedArea = await _areaRepository.UpdateArea(Area.ToAreaEntity());
            if (updatedArea == null)
            {
                return Result<AreaResponse>.Failure("Failed to update Area.");
            }
            return Result<AreaResponse>.Success(updatedArea.ToAreaResponse());
        }
    }
}
