using DriverFinder.Core.DTO.ReviewDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.ReviewValidation
{
    public class ReviewRequestValidation : AbstractValidator<ReviewRequest>
    {
        public ReviewRequestValidation() 
        {
            RuleFor(p => p.SchoolID).NotEmpty().WithMessage("SchoolID Cant Be Blank");
            RuleFor(p => p.SchoolReviewDescription).NotEmpty().WithMessage("Schoo lReview Description Cant Be Blank");
            RuleFor(p => p.SchoolRating).NotEmpty().WithMessage("Schoo lRating Cant Be Blank");
            RuleFor(p => p.InstructorID).NotEmpty().WithMessage("InstructorID Cant Be Blank");
            RuleFor(p => p.InstructorRating).NotEmpty().WithMessage("Instructor Rating Cant Be Blank");
            RuleFor(p => p.InstructorReviewDescription).NotEmpty().WithMessage("Instructor Review Description Cant Be Blank");
            RuleFor(p => p.UserID).NotEmpty().WithMessage("UserID Cant Be Blank");
            RuleFor(p => p.UserName).NotEmpty().WithMessage("UserName Cant Be Blank");
        }
    }
}
