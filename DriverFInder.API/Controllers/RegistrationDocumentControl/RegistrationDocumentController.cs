using DriverFinder.Core.DTO.SchoolDTO.SchoolDocumentDTO;
using DriverFinder.Core.ServicesContracts.ISchoolDocuemntServices;
using DriverFinder.Core.Validation.SchoolValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DriverFinder.UI.Controllers.RegistrationDocumentControl
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationDocumentController : ControllerBase
    {
        private readonly ISchoolDocumentsService _schoolDocService;
        private readonly SchoolDocumentRequestValidation _RequestValidator;
        public RegistrationDocumentController(ISchoolDocumentsService schoolDocService, SchoolDocumentRequestValidation RequestValidator)
        {
            _schoolDocService = schoolDocService;
            _RequestValidator = RequestValidator;
        }
        [HttpPost]
        public async Task<ActionResult<SchoolDocumentResponse>> AddDocument([FromForm]SchoolDocumentRequest request,IFormFile docImg)
        {
            var Validationresult = await _RequestValidator.ValidateAsync(request);
            if (!Validationresult.IsValid)
            {
                var errors = string.Join("\n", Validationresult.Errors.Select(err => err.ErrorMessage));
                return Problem(errors);
            }


            var response = await _schoolDocService.UploadDocuments(request,docImg);

            if (response == null)
            {
                return Problem("faild to upload docuemnts");
            }

            return Ok(response);
        }
    }
}
