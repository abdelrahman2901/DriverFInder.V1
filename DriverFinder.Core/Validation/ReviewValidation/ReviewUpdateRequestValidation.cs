using DriverFinder.Core.DTO.ReviewDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.ReviewValidation
{
    public class ReviewUpdateRequestValidation : AbstractValidator<ReviewUpdateRequest>
    {
        public ReviewUpdateRequestValidation()
        {
            RuleFor(p => p.SchoolID).NotEmpty().WithMessage("SchoolID Cant Be Blank");
            RuleFor(p => p.InstructorID).NotEmpty().WithMessage("InstructorID Cant Be Blank");
            RuleFor(p => p.UserID).NotEmpty().WithMessage("UserID Cant Be Blank");
            RuleFor(p => p.UserName).NotEmpty().WithMessage("UserName Cant Be Blank");
        }
    }
}
