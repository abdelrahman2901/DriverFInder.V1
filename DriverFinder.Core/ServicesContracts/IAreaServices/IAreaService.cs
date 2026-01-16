
using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.AreaDTO;

namespace DriverFinder.Core.ServicesContracts.IAreaServices
{
    public interface IAreaService
    {
        public Task<Result<IEnumerable<AreaResponse>>> GetAllAreas();
        public Task<Result<AreaResponse>> GetArea(Guid id);
        public Task<Result<AreaResponse>> UpdateArea(AreaUpdateRequest AreaRequest);
        public Task<Result<AreaResponse>> AddArea(AreaRequest AreaRequest);
        public Task<Result<bool>> DeleteArea(Guid id);
    }
}
