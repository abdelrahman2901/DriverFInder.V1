using DriverFinder.Core.DTO.RegisterDTO;
using DriverFinder.Core.ServicesContracts.IAuthServices;
using FluentValidation;
 
namespace DriverFinder.Core.Validation.AuthValidation
{
    public class RegisterRequestValidation :AbstractValidator<UserRegisterRequest>
    {
        public RegisterRequestValidation(IAuthService authservice) 
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email Cant Be Blank").EmailAddress().WithMessage("Add Valid Email Format");
            RuleFor(p=>p.Password).NotEmpty().WithMessage("Password Cant Be Blank");
            RuleFor(p=>p.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword Cant Be Blank").Equal(o=>o.Password).WithMessage("Passowrd doesnt Match");
            RuleFor(p=>p.PhoneNumber).NotEmpty().WithMessage("PhoneNumber Cant Be Blank").Matches("[0-9]").WithMessage("Phone number should contain digits only");
            RuleFor(p=>p.PersonName).NotEmpty().WithMessage("PersonName Cant Be Blank");
        }
    }
}
