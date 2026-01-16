using DriverFinder.Core.DTO.InstructorDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.InstructorsValidation
{
    public class InstructorUpdateRequestValidation : AbstractValidator<UpdateInstructorRequest>
    {
        public InstructorUpdateRequestValidation()
        {
            RuleFor(p => p.SchoolID).NotEmpty().WithMessage("SchoolID Cant Be Blank");
            RuleFor(p => p.InstructorID).NotEmpty().WithMessage("InstructorID Cant Be Blank");
        }
    }
}
