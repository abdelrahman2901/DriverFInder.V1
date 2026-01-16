using DriverFinder.Core.Domain.Entites;
using Microsoft.AspNetCore.Http;
using System;


namespace DriverFinder.Core.Domain.RepositoryContracts.ISchoolDocuementRepo
{
    public interface ISchoolDocuementRepository
    {
        public Task<RegistrationDocuemnts?> UploadDocuments(RegistrationDocuemnts documents);
        public Task<string?> UploadDocImg(IFormFile DocImage);
    }
}
