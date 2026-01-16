using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.DTO.SchoolDTO.SchoolDocumentDTO;
using Microsoft.AspNetCore.Http;
using System;


namespace DriverFinder.Core.ServicesContracts.ISchoolDocuemntServices
{
    public interface ISchoolDocumentsService
    {
        public Task<Result<SchoolDocumentResponse?>> UploadDocuments(SchoolDocumentRequest docRequest, IFormFile docImg);
    }
}
