using DriverFinder.Core.DTO.VehicalDTO.VehicleMakeDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.VehiclesValidation
{
    public class VehicleMakeRequestValidation : AbstractValidator<VehicleMakeRequest>
    {
        public VehicleMakeRequestValidation()
        {
            RuleFor(p => p.Category).NotEmpty().WithMessage("Category Cant Be Blank");
            RuleFor(p => p.Make).NotEmpty().WithMessage("Make Name Cant Be Blank");
        }
    }
}
