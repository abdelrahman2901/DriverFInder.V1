using DriverFinder.Core.DTO.SchoolDTO.SchoolRegisterDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.SchoolValidation
{
    public class SchoolRequestValidation : AbstractValidator<SchoolRegisterRequest>
    {
        public SchoolRequestValidation()
        {
            RuleFor(p => p.schoolEmail).NotEmpty().WithMessage("schoolEmail Cant Be Blank").EmailAddress().WithMessage("Add Valid Email Format");
            RuleFor(p => p.phoneNumber).NotEmpty().WithMessage("phoneNumber Cant Be Blank").Matches("[0-9]").WithMessage("Phone Number must be digits only");
            RuleFor(p => p.OwnerID).NotEmpty().WithMessage("OwnerID Cant Be Blank");
            RuleFor(p => p.location).NotEmpty().WithMessage("location Cant Be Blank");
            RuleFor(p => p.ProgramID).NotEmpty().WithMessage("ProgramID Cant Be Blank");
            RuleFor(p => p.ProgramTypeID).NotEmpty().WithMessage("ProgramTypeID Cant Be Blank");
            RuleFor(p => p.schoolName).NotEmpty().WithMessage("schoolName Cant Be Blank");
            RuleFor(p => p.SubscriptionType).IsInEnum().WithMessage("Subscription Must be Valid (Basic , Standard,Premium)");
        }
    }
}
