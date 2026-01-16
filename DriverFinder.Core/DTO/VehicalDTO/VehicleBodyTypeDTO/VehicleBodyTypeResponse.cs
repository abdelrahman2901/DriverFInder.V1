using DriverFinder.Core.Domain.Entites;
using System.ComponentModel.DataAnnotations;

namespace DriverFinder.Core.DTO.VehicalDTO.VehicleBodyTypeDTO
{
    public class VehicleBodyTypeResponse
    {
        public Guid BodyTypeID { get; set; }
        public string BodyType { get; set; }

        
    }
    public static class VehicleBodyTypeExtensions
    {
        public static VehicleBodyTypeResponse ToBodyTypeResponse(this VehicleBodyType bodytype)
        {
            return new VehicleBodyTypeResponse() {BodyTypeID=bodytype.BodyTypeID,BodyType=bodytype.BodyType };
        }
    }
}
