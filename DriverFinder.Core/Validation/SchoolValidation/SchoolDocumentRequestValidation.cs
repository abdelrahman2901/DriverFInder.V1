using DriverFinder.Core.DTO.SchoolDTO.SchoolDocumentDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriverFinder.Core.Validation.SchoolValidation
{
    public class SchoolDocumentRequestValidation : AbstractValidator<SchoolDocumentRequest>
    {
        public SchoolDocumentRequestValidation()
        {
            RuleFor(p => p.schoolID).NotEmpty().WithMessage("schoolID Cant Be Blank");
        }
    }
}
