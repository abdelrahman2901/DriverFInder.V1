using DriverFinder.Core.DTO.LoginDTO;
using FluentValidation;

namespace DriverFinder.Core.Validation.AuthValidation
{
    public class LoginRequestValidation : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidation()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email Cant Be Blank").EmailAddress().WithMessage("Add Valid Email Address");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password Cant Be Blank");
        }
    }
}
