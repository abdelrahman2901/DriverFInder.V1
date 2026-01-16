using DriverFinder.Core.DTO.OwnerDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.OwnerValidation
{
    public class OwnerRequestValidation : AbstractValidator<OwnerRequest>
    {
        public OwnerRequestValidation()
        {
            RuleFor(p => p.OwnerName).NotEmpty().WithMessage("Owner Name Cant Be Empty");
            RuleFor(p => p.UserID).NotEmpty().WithMessage("UserID Cant Be Empty");
        }
    }
}
