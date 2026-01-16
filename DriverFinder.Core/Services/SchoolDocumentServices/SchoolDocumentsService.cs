using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IDrivingSchoolRepo;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolDocuementRepo;
using DriverFinder.Core.DTO.SchoolDTO.SchoolDocumentDTO;
using DriverFinder.Core.ServicesContracts.ISchoolDocuemntServices;
using Microsoft.AspNetCore.Http;
using System;

namespace DriverFinder.Core.Services.SchoolDocumentServices
{
    public class SchoolDocumentsService : ISchoolDocumentsService
    {
        private readonly ISchoolDocuementRepository _schoolDocRepo;
        private readonly IDrivingSchoolRepository _schoolRepo;
        public SchoolDocumentsService(ISchoolDocuementRepository SchoolDocRepo, IDrivingSchoolRepository SchoolRepo)
        {
            _schoolDocRepo = SchoolDocRepo;
            _schoolRepo = SchoolRepo;
        }

        public async Task<Result<SchoolDocumentResponse?>> UploadDocuments(SchoolDocumentRequest docRequest,IFormFile docImg)
        {
            if(await _schoolRepo.GetDrivingSchoolByID(docRequest.schoolID)==null)
            {
                return Result<SchoolDocumentResponse?>.Failure("School Doesnt Exists");
            }

            string? path = await _schoolDocRepo.UploadDocImg(docImg);

            if (path == null)
            {
                return Result<SchoolDocumentResponse?>.Failure("Failed To Upload The Document Image");
            }
            RegistrationDocuemnts RDoc = docRequest.toRegistrationDocuemnts();
            RDoc.drivingSchoolLicense = path;
            RDoc.RegistrationID = Guid.NewGuid();
            RegistrationDocuemnts? DocResponse = await _schoolDocRepo.UploadDocuments(RDoc);
            if(DocResponse==null)
            {
                return Result<SchoolDocumentResponse?>.Failure("Failed To Upload The Document Details");
            }
            return Result<SchoolDocumentResponse?>.Success(DocResponse?.toSchoolDocResponnse());
        }

        
    }
}
