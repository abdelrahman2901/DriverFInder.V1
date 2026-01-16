using DriverFinder.Core.DTO.SchoolDTO.UpdateSchoolDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.SchoolValidation
{
    public class SchoolUpdateRequestValidation : AbstractValidator<UpdateSchoolRequest>
    {
        public SchoolUpdateRequestValidation()
        {
            RuleFor(p => p.SchoolID).NotEmpty().WithMessage("SchoolID Cant Be Blank");
            RuleFor(p => p.SubscriptionType).IsInEnum().WithMessage("Subscription Must be Valid (Basic , Standard,Premium)");

        }
    }
}
