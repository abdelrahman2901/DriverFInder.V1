using DriverFinder.Core.DTO.VehicalDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.VehiclesValidation
{
    public class VehicleRequestValidation : AbstractValidator<VehicleRequests>
    {
        public VehicleRequestValidation()
        {
            RuleFor(p => p.SchoolID).NotEmpty().WithMessage("SchoolID Cant Be Blank");
            RuleFor(p => p.VehicleMakeID).NotEmpty().WithMessage("VehicleMakeID Cant Be Blank");
            RuleFor(p => p.VehicleTransmissionID).NotEmpty().WithMessage("VehicleTransmissionID Cant Be Blank");
            RuleFor(p => p.VehicleBodyTypeID).NotEmpty().WithMessage("VehicleBodyTypeID Cant Be Blank");
            RuleFor(p => p.VehicleModelID).NotEmpty().WithMessage("VehicleModelID Cant Be Blank");
        }
    }
}
