using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolDocuementRepo;
using DriverFinder.Core.DTO.SchoolDTO.SchoolDocumentDTO;
using DriverFinder.Infrastructure.ApplicationContext;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace DriverFinder.Infrastructure.Repository.SchoolDocumentsRepository
{
    public class SchoolDocumentsRepository :ISchoolDocuementRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<SchoolDocumentsRepository> _logger;
        public SchoolDocumentsRepository(ApplicationDBContext context,ILogger<SchoolDocumentsRepository>logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<RegistrationDocuemnts?> UploadDocuments(RegistrationDocuemnts documents)
        {
            try
            {
              await  _context.RegistrationDocuemnts.AddAsync(documents);
                await _context.SaveChangesAsync();
                return documents;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<string?> UploadDocImg(IFormFile DocImage)
        {

            if (DocImage == null || DocImage.Length == 0)
            {
                _logger.LogError("error from (SchoolDocumentsRepository:uploeadDocimg) : file img empty");

                return null;
            }
            string dir = @"D:\FullStack_Projects\DriveFinder_Project\DriverFinder\wwwroot\Documentation";
            string FileName = Guid.NewGuid().ToString() + Path.GetExtension(DocImage.FileName);
            string path = Path.Combine(dir, FileName);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await DocImage.CopyToAsync(stream);
                }

                return FileName;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error from (DrivingSchoolRepository:UploadImg) :{ex.Message}");
                return null;
            }

        }
    }
}
