using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IDrivingSchoolRepo;
using DriverFinder.Core.DTO.SchoolDTO;
using DriverFinder.Core.DTO.SchoolDTO.SchoolRegisterDTO;
using DriverFinder.Core.DTO.SchoolDTO.UpdateSchoolDTO;
using DriverFinder.Core.Enums;
using DriverFinder.Core.ServicesContracts.IReviewServices;
using DriverFinder.Core.ServicesContracts.ISchoolOwnerServices;
using DriverFinder.Core.ServicesContracts.ISchoolServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;

namespace DriverFinder.Core.Services.SchoolServices
{
    public class SchoolService : ISchoolService
    {
        private readonly IDrivingSchoolRepository _schoolRepo;
        private readonly ISchoolOwnerService _SchoolownerService;
        private readonly IReviewService _ReviewService;

        private readonly ILogger<SchoolService> _logger;
        public SchoolService(IDrivingSchoolRepository schoolRepo, ILogger<SchoolService> logger,
            ISchoolOwnerService ownerService, IReviewService reviewService)
        {
            _schoolRepo = schoolRepo;
            _SchoolownerService = ownerService;
            _logger = logger;
            _ReviewService = reviewService;
            //_http = http.CreateClient();
        }
        public async Task<Result<SchoolResponse?>> GetDrivingSchoolByID(Guid id)
        {
            DrivingSchool? school = await _schoolRepo.GetDrivingSchoolByID(id);
            if (school == null)
            {
                return Result<SchoolResponse?>.Failure("School doesnt exists");
            }
            return Result<SchoolResponse?>.Success(school.ToSchoolResponse());
        }
        public async Task<Result<DrivingSchool?>> GetDrivingSchoolEntityByID(Guid id)
        {
            DrivingSchool? school = await _schoolRepo.GetDrivingSchoolByID(id);
            if (school == null)
            {
                return Result<DrivingSchool?>.Failure("School doesnt exists");
            }
            return Result<DrivingSchool?>.Success(school);
        }
        public async Task<Result<IEnumerable<SchoolResponse>>> GetDrivingSchools()
        {
            var schools = await _schoolRepo.GetDrivingSchools();
            if (schools == null || !schools.Any() || schools.Count() == 0)
            {
                return Result<IEnumerable<SchoolResponse>>.Failure("No Schools found");
            }
            return Result<IEnumerable<SchoolResponse>>.Success(schools.Select(s => s.ToSchoolResponse()).ToList());
        }

        public async Task<Result<SchoolResponse?>> AddDrivingSchool(SchoolRegisterRequest drivingSchoolRequest, IFormFile img)
        {
            if (await isSchoolNameUsedByName(drivingSchoolRequest.schoolName))
            {
                return Result<SchoolResponse?>.Failure("Duplicated School Name");
            }
            var isexists = await _SchoolownerService.GetSchoolOwner(drivingSchoolRequest.OwnerID);
            if (isexists == null)
            {
                return Result<SchoolResponse?>.Failure("school owner doesnt exists");
            }

            string? path = null;
            string? hashImg = null;
            if (img != null)
            {
                path = await UploadImg(img);

                if (path == null)
                {
                    _logger.LogError("Failed to Upload the image");
                    return Result<SchoolResponse?>.Failure("Failed to upload image");
                }
                hashImg = HashImg(img);
            }


            DrivingSchool school = drivingSchoolRequest.ToDrivingSchool();

            school.SchoolID = Guid.NewGuid();
            school.status = SchoolStatusEnum.Pending;
            school.imgURl = path;
            school.ImageHash = hashImg;

            DrivingSchool result = await _schoolRepo.AddDrivingSchool(school);
            if (result == null)
            {
                return Result<SchoolResponse?>.Failure("Failed to add school");
            }

            return Result<SchoolResponse?>.Success(school?.ToSchoolResponse());
        }

        public async Task<Result<bool>> DeleteDrivingSchool(Guid Schoolid)
        {
            Result<DrivingSchool?> drivingSchool = await GetDrivingSchoolEntityByID(Schoolid);
            if (!drivingSchool.IsSuccess)
            {
                return Result<bool>.Failure("School Doesnt Exists");
            }
            return Result<bool>.Success(await _schoolRepo.DeleteDrivingSchool(drivingSchool.Data));
        }

        public async Task<Result<UpdateSchoolResponse?>> UpdateDrivingSchool(UpdateSchoolRequest UpdateSchoolRequest, IFormFile img)
        {

            if (!await DrivingSchoolExists(UpdateSchoolRequest.SchoolID))
            {
                return Result<UpdateSchoolResponse?>.Failure("School Doesnt Exists");
            }
            if (await isSchoolNameUsedByName(UpdateSchoolRequest.SchoolName) && UpdateSchoolRequest.SchoolName != UpdateSchoolRequest.ActualSchoolName)
            {
                return Result<UpdateSchoolResponse?>.Failure("School Name is Used");
            }
            Result<DrivingSchool> UpdateSchool = await CheckDefaultValues(UpdateSchoolRequest);
            UpdateSchool = img == null ? Result<DrivingSchool>.Success(UpdateSchool.Data) : await UpdateImageIfNeeded(UpdateSchool.Data, img);

            if (!UpdateSchool.IsSuccess)
            {
                return Result<UpdateSchoolResponse?>.Failure(UpdateSchool.ErrorMessage);
            }

            DrivingSchool? school = await _schoolRepo.UpdateDrivingSchool(UpdateSchool.Data);
            if (school == null)
            {
                return Result<UpdateSchoolResponse?>.Failure("Failed To Update School");

            }
            return Result<UpdateSchoolResponse?>.Success(school?.ToUpdateSchoolResponse());
        }

        public async Task<Result<UpdateSchoolResponse?>> ChangeFemaleInstructorStatus(Guid SchoolID)
        {

            if (!await DrivingSchoolExists(SchoolID))
            {
                return Result<UpdateSchoolResponse?>.Failure("School Doesnt Exists");
            }
            var Updateschool = await _schoolRepo.GetDrivingSchoolByID(SchoolID);
            Updateschool.HasFemaleInstructor = true;

            DrivingSchool? school = await _schoolRepo.UpdateDrivingSchool(Updateschool);
            if (school == null)
            {
                return Result<UpdateSchoolResponse?>.Failure("Failed To Update School");

            }
            return Result<UpdateSchoolResponse?>.Success(school?.ToUpdateSchoolResponse());
        }

        public async Task<Result<SchoolResponse?>> UpdateRating(Guid SchoolID)
        {
            DrivingSchool? School = await _schoolRepo.GetDrivingSchoolByID(SchoolID);
            if (School == null)
            {
                return Result<SchoolResponse?>.Failure("School Doesnt Exists");
            }

            //var response = await _http.GetAsync($"https://localhost:7182/api/Reviews/GetSchoolReviews/{SchoolID}");

            //if (!response.IsSuccessStatusCode)
            //{
            //    return Result<SchoolResponse?>.Failure("Failed to Get Reviwes for that school");
            //}

            //var json = await response.Content.ReadAsStringAsync();


            //var Reviews = JsonSerializer.Deserialize<IEnumerable<ReviewResponse?>>(json);
            var Reviews = (await _ReviewService.GetSchoolReviews(SchoolID)).Data;

            //if (Reviews.Count() == 0)
            //{
            //    return Result<SchoolResponse?>.Failure("No Reviwes Was Found for that school");
            //}


            School.Rating = Reviews.Count() != 0 ? CalcuateTheRating(Reviews.Count(), Reviews.Average(i => i.SchoolRating)) : 0;

            var Result = await _schoolRepo.UpdateDrivingSchool(School);

            if (Result == null)
            {
                return Result<SchoolResponse?>.Failure("Failed To Update School ");
            }
            return Result<SchoolResponse?>.Success(School.ToSchoolResponse());
        }
        public async Task<Result<SchoolResponse?>> EditSchoolStatus(Guid Schoolid, SchoolStatusEnum status)
        {
            var school = await _schoolRepo.GetDrivingSchoolByID(Schoolid);
            if (school == null)
            {
                return Result<SchoolResponse?>.Failure("School Doesnt Exists");
            }

            school.status = status;
            DrivingSchool? Updatedschool = await _schoolRepo.UpdateDrivingSchool(school);
            if (Updatedschool == null)
            {
                return Result<SchoolResponse?>.Failure("Failed To Update School");
            }
            return Result<SchoolResponse?>.Success(Updatedschool?.ToSchoolResponse());
        }

        public async Task<Result<SchoolResponse?>> BlockSchool(Guid Schoolid, bool block)
        {
            var school = await _schoolRepo.GetDrivingSchoolByID(Schoolid);
            if (school == null)
            {
                return Result<SchoolResponse?>.Failure("school Doesnt exists");
            }
            school.isblocked = block;
            DrivingSchool? Updatedschool = await _schoolRepo.UpdateDrivingSchool(school);
            if (Updatedschool == null)
            {
                return Result<SchoolResponse?>.Failure("Failed to update school");
            }
            return Result<SchoolResponse?>.Success(Updatedschool?.ToSchoolResponse());
        }


        private double CalcuateTheRating(int TotalReviews, double AvarageRating)
        {
            double R = AvarageRating;
            int V = TotalReviews;
            int M = 20;
            double C = 2.7;

            double NewRating = (((V * R) + (M * C)) / (V + M));
            return NewRating;
        }
        private async Task<bool> DrivingSchoolExists(Guid id)
        {
            return await _schoolRepo.GetDrivingSchoolByID(id) != null;
        }

        private async Task<Result<DrivingSchool>> CheckDefaultValues(UpdateSchoolRequest updateSchool)
        {
            DrivingSchool? ActualschoolData = await _schoolRepo.GetDrivingSchoolByID(updateSchool.SchoolID);
            ActualschoolData.PhoneNumber = updateSchool.PhoneNumber == ActualschoolData.PhoneNumber ?
                ActualschoolData.PhoneNumber : updateSchool.PhoneNumber;

            ActualschoolData.SchoolEmail = updateSchool.SchoolEmail == ActualschoolData.SchoolEmail ?
                ActualschoolData.SchoolEmail : updateSchool.SchoolEmail;

            ActualschoolData.SchoolName = updateSchool.SchoolName == ActualschoolData.SchoolName ?
                ActualschoolData.SchoolName : updateSchool.SchoolName;

            ActualschoolData.ProgramID = updateSchool.ProgramID == ActualschoolData.ProgramID ?
                ActualschoolData.ProgramID : updateSchool.ProgramID;

            ActualschoolData.ProgramTypeID = updateSchool.ProgramTypeID == ActualschoolData.ProgramTypeID ?
                ActualschoolData.ProgramTypeID : updateSchool.ProgramTypeID;

            ActualschoolData.Location = updateSchool.Location == ActualschoolData.Location ?
                ActualschoolData.Location : updateSchool.Location;

            ActualschoolData.LocationURl = updateSchool.LocationURl == ActualschoolData.LocationURl ?
                ActualschoolData.LocationURl : updateSchool.LocationURl;
            ActualschoolData.Experience = updateSchool.Experience == ActualschoolData.Experience ?
                ActualschoolData.Experience : updateSchool.Experience;


            return Result<DrivingSchool>.Success(ActualschoolData);
        }
        private async Task<Result<DrivingSchool>> UpdateImageIfNeeded(
    DrivingSchool school,
    IFormFile img)
        {

            string newHash = HashImg(img);

            if (newHash == school.ImageHash)
                return Result<DrivingSchool>.Failure("image already set");

            string? newPath = await UpdateImg(img, school.imgURl);

            if (newPath == null)
            {
                return Result<DrivingSchool>.Failure("Failed to upload image");
            }

            school.imgURl = newPath;
            school.ImageHash = newHash;

            return Result<DrivingSchool>.Success(school);
        }
        private string HashImg(IFormFile file)
        {
            using (var sha256 = SHA256.Create())
            using (var stream = file.OpenReadStream())
            {
                byte[] hashBytes = sha256.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        private async Task<string?> UploadImg(IFormFile? FileImage)
        {
            if (FileImage == null || FileImage.Length == 0)
            {
                _logger.LogError("error from (DrivingSchoolRepository:uploeadIMG) : file img empty");

                return null;
            }
            string dir = @"D:\NEw_laptop_Boda\FullStack_Projects\DriveFinder_Project\DriverFinder\wwwroot\Schools_Images";
            string FileName = Guid.NewGuid().ToString() + Path.GetExtension(FileImage.FileName);
            string path = Path.Combine(dir, FileName);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await FileImage.CopyToAsync(stream);
                }

                return FileName;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error from (DrivingSchoolRepository:UploadImg) :{ex.Message}");
                return null;
            }
        }
        private async Task<string?> UpdateImg(IFormFile? FileImage, string oldImgUrl)
        {
            string dir = @"D:\NEw_laptop_Boda\FullStack_Projects\DriveFinder_Project\DriverFinder\wwwroot\Schools_Images";

            string? newImgFileName = await UploadImg(FileImage);

            if (newImgFileName == null)
            {
                _logger.LogError("UpdateImg failed: new image upload failed.");
                return null;
            }
            if (oldImgUrl != null)
            {
                try
                {
                    string oldImgPath = Path.Combine(dir, oldImgUrl);

                    if (File.Exists(oldImgPath))
                    {
                        File.Delete(oldImgPath);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"UpdateImg: Failed to delete old image: {ex.Message}");
                    File.Delete(Path.Combine(dir, newImgFileName));
                    return null;
                }
            }

            return newImgFileName;
        }

        private async Task<bool> isSchoolNameUsedByName(string? name)
        {
            return await _schoolRepo.isSchoolNameExists(name);
        }


    }
}
