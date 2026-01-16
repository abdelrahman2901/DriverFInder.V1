using DriverFinder.Core.DTO.SchoolProgramsDTO;
using FluentValidation;
 
namespace DriverFinder.Core.Validation.SchoolProgramsValidation
{
    public class SchoolProgramsRequestValidation : AbstractValidator<SchoolProgramRequest>
    {
        public SchoolProgramsRequestValidation()
        {
            RuleFor(p => p.SchoolID).NotEmpty().WithMessage("SchoolID Cant Be Blank");
            RuleFor(p => p.VehicleID).NotEmpty().WithMessage("VehicleID Cant Be Blank");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Description Cant Be Blank");

            RuleFor(p => p.Price).NotEmpty().WithMessage("Price Cant Be Blank")
                .InclusiveBetween(decimal.MinValue, decimal.MaxValue).WithMessage("Price Cant be Negative Number");

            RuleFor(p => p.SessionDuration).NotEmpty().WithMessage("SessionDuration Cant Be Blank")
                .InclusiveBetween(short.MinValue, short.MaxValue).WithMessage("SessionDuration Cant be Negative Number");

            RuleFor(p => p.DurationInWeeks).NotEmpty().WithMessage("DurationInWeeks Cant Be Blank")
                .InclusiveBetween(short.MinValue, short.MaxValue).WithMessage("DurationInWeeks Cant be Negative Number");

            RuleFor(p => p.NumberOfSessions).NotEmpty().WithMessage("NumberOfSessions Cant Be Blank")
                .InclusiveBetween(short.MinValue,short.MaxValue).WithMessage("NumberOfSessions Cant be Negative Number");

            RuleFor(p => p.NumberOfSessionsPerWeek).NotEmpty().WithMessage("NumberOfSessionsPerWeek Cant Be Blank")
                .InclusiveBetween(short.MinValue, short.MaxValue).WithMessage("NumberOfSessionsPerWeek Cant be Negative Number");
           
            RuleFor(p => p.ProgramID).NotEmpty().WithMessage("ProgramID Cant Be Blank");
            RuleFor(p => p.ProgramTypeID).NotEmpty().WithMessage("ProgramTypeID Cant Be Blank");
        }
    }
}
