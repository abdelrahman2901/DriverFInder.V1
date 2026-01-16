using DriverFinder.Core.DTO.VehicalDTO;
using FluentValidation;
 

namespace DriverFinder.Core.Validation.VehiclesValidation
{
    public class VehicleUpdateRequestValidation : AbstractValidator<UpdateVehicleRequest>
    {
        public VehicleUpdateRequestValidation() 
        {
            RuleFor(p=>p.VehicleID).NotEmpty().WithMessage("VehicleID Cant Be Blank");
            RuleFor(p=>p.SchoolID).NotEmpty().WithMessage("SchoolID Cant Be Blank");
        }
    }
}
