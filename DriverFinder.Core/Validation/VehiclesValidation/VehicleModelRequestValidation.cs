using DriverFinder.Core.DTO.VehicalDTO.VehicleModelDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.VehiclesValidation
{
    public class VehicleModelRequestValidation : AbstractValidator<VehicleModelRequest>
    {
        public VehicleModelRequestValidation()
        {
            RuleFor(p=>p.MakeID).NotEmpty().WithMessage("Make ID Cant Be Blank");
            RuleFor(p => p.Model).NotEmpty().WithMessage("Model Name Cant be Blank");
        }
    }
}
