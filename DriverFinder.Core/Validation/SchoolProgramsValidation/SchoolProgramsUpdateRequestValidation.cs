using DriverFinder.Core.DTO.SchoolProgramsDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.SchoolProgramsValidation
{
    public class SchoolProgramsUpdateRequestValidation : AbstractValidator<UpdateProgramRequest>
    {
        public SchoolProgramsUpdateRequestValidation()
        {
            RuleFor(p => p.SchoolID).NotEmpty().WithMessage("SchoolID Cant Be Blank");
            RuleFor(p => p.VehicleID).NotEmpty().WithMessage("VehicleID Cant Be Blank");
        
        }
    }
}
