using DriverFinder.Core.DTO.InstructorDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.InstructorsValidation
{
    public class InstructorRequestValidation : AbstractValidator<InstructorRequest>
    {
        public InstructorRequestValidation() 
        {
            RuleFor(p => p.SchoolID).NotEmpty().WithMessage("SchoolID Cant Be Blank");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("PhoneNumber Cant Be Blank").Matches("[0-9]").WithMessage("phone number must be digits only");
            RuleFor(p => p.Experience).NotEmpty().WithMessage("Experience Cant Be Blank").InclusiveBetween(0,int.MaxValue).WithMessage("Experience Cant Be negative number");
            RuleFor(p => p.Gender).IsInEnum().WithMessage("Gender is not in the correct format");
            RuleFor(p => p.InstructorName).NotEmpty().WithMessage("InstructorName Cant Be Blank");

        }
    }
}
