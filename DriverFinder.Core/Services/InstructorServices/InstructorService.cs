using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IInstructorRepo;
using DriverFinder.Core.DTO.InstructorDTO;
using DriverFinder.Core.ServicesContracts.IInstructorServices;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace DriverFinder.Core.Services.InstructorServices
{
    public class InstructorService : IInstructorService
    {
        private readonly IInsturctorRepository _InsturctorRepo;
        public InstructorService(IInsturctorRepository insturctorRepository)
        {
            _InsturctorRepo = insturctorRepository;
        }

        public async Task<Result<IEnumerable<InstructorResponse>>> GetDrivingInstructors()
        {
            IEnumerable<DrivingInstructors> instructors = await _InsturctorRepo.GetDrivingInstructors();
            if (instructors.Count() == 0)
            {
                return Result<IEnumerable<InstructorResponse>>.Failure("No instructors found.");
            }
            return Result<IEnumerable<InstructorResponse>>.Success(instructors.Select(i => i.ToInstructorResponse()));
        }

        public async Task<Result<InstructorResponse>> GetInstructor(Guid InstructorID)
        {
            DrivingInstructors? instructor = await _InsturctorRepo.GetInstructor(InstructorID);
            if (instructor == null)
            {
                return Result<InstructorResponse>.Failure("No instructor found.");
            }
            return Result<InstructorResponse>.Success(instructor.ToInstructorResponse());
        }
        public async Task<Result<IEnumerable<InstructorResponse>>> GetSchoolInstructors(Guid SchoolID)
        {
            IEnumerable<DrivingInstructors> Schoolinstructors = await _InsturctorRepo.GetDrivingInstructorsForSchool(SchoolID);
            if (Schoolinstructors == null)
            {
                return Result<IEnumerable<InstructorResponse>>.Failure("No instructor found.");
            }
            return Result<IEnumerable<InstructorResponse>>.Success(Schoolinstructors.Select(i => i.ToInstructorResponse()));
        }
        public async Task<Result<InstructorResponse>> AddDrivingInstructor(InstructorRequest drivingInstructors, IFormFile? InstructorImg)
        {
            var NewInstructor = drivingInstructors.ToDrivingInstructor();
            if (await CheckUserDataExistance(drivingInstructors))
            {
                return Result<InstructorResponse>.Failure("Instructor Already Exists");
            }
            if (InstructorImg != null)
            {
                bool ImgExists = await CheckImgExistance(InstructorImg);
                if (ImgExists)
                {
                    return Result<InstructorResponse>.Failure("Image Already Exists.");
                }
                string? ImgUrl = await UploadinstructorImage(InstructorImg);
                if (ImgUrl == null)
                {
                    return Result<InstructorResponse>.Failure("Failed Uploading Image.");
                }
                NewInstructor.InsturctorImgUrl = ImgUrl;
                NewInstructor.ImageHash = HashImgString(InstructorImg);
            }
            DrivingInstructors? Result = await _InsturctorRepo.AddDrivingInstructors(NewInstructor);
            if (Result == null)
            {
                return Result<InstructorResponse>.Failure("Failed Adding New Instructor.");
            }
            return Result<InstructorResponse>.Success(NewInstructor.ToInstructorResponse());
        }

        public async Task<Result<InstructorResponse>> UpdateDrivingInstructor(UpdateInstructorRequest UpdateInstructorsRequest, IFormFile? UpdateImg)
        {
            DrivingInstructors? OldInstructorData = await _InsturctorRepo.GetInstructor(UpdateInstructorsRequest.InstructorID);
            if (OldInstructorData == null)
            {
                return Result<InstructorResponse>.Failure("No Instructor Found to Update.");
            }
            DrivingInstructors UpdateInstructor = CheckUpdatedProperties(UpdateInstructorsRequest, OldInstructorData);
            string? path;
            string? hashImg;
            if (UpdateImg != null)
            {
                path = await UpdatingInstructorImg(UpdateImg, UpdateInstructorsRequest.InsturctorImgUrl);
                if (path == null)
                {
                    return Result<InstructorResponse>.Failure("Failed Updating Instructor Image.");
                }
                hashImg = HashImgString(UpdateImg);
                UpdateInstructor.InsturctorImgUrl = path;
                UpdateInstructor.ImageHash = hashImg;
            }

            DrivingInstructors? UpdatedInstructor = await _InsturctorRepo.UpdateDrivingInstructors(UpdateInstructor);

            if (UpdatedInstructor == null)
            {
                return Result<InstructorResponse>.Failure("Failed Updating Instructor.");
            }
            return Result<InstructorResponse>.Success(UpdatedInstructor.ToInstructorResponse());
        }
        public async Task<Result<bool>> DeleteInstructor(Guid InstructorID)
        {
            DrivingInstructors? Instructor = await _InsturctorRepo.GetInstructor(InstructorID);
            if (Instructor == null)
            {
                return Result<bool>.Failure("No Instructor Found to Update.");
            }
            bool Result = await _InsturctorRepo.DeleteInstructors(Instructor);
            if (Result == false)
            {
                return Result<bool>.Failure("Failed Updating Instructor.");
            }
            if (Instructor.InsturctorImgUrl != null)
            {
                Result = DeleteInstructorImage(Instructor.InsturctorImgUrl);
            }
            if (Result == false)
            {
                return Result<bool>.Failure("Failed Deleting Instructor Image.");
            }
            return Result<bool>.Success(true);

        }

        private async Task<bool> CheckUserDataExistance(InstructorRequest request)
        {
            return await _InsturctorRepo.CheckUserDataExistance(request);
        }
        private async Task<string?> UpdatingInstructorImg(IFormFile? NewImg, string? existingImage)
        {
            if (existingImage != null)
            {
                bool deletingImage = DeleteInstructorImage(existingImage);
                if (!deletingImage)
                {
                    return null;
                }
            }
            string? ImgUrl = await UploadinstructorImage(NewImg);
            return ImgUrl;
        }
        private async Task<bool> CheckImgExistance(IFormFile Img)
        {
            return await _InsturctorRepo.CheckImgExistance(HashImgString(Img));
        }
        private bool DeleteInstructorImage(string ImgUrl)
        {
            string dir = @"D:\NEw_laptop_Boda\FullStack_Projects\DriveFinder_Project\DriverFinder\wwwroot\Instructors_Images";
            string path = Path.Combine(dir, ImgUrl);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
        private async Task<string?> UploadinstructorImage(IFormFile? InstructorImg)
        {
            if (InstructorImg== null)
            {
                return null;
            }
            string dir = @"D:\NEw_laptop_Boda\FullStack_Projects\DriveFinder_Project\DriverFinder\wwwroot\Instructors_Images";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string filePath = Guid.NewGuid().ToString() + Path.GetExtension(InstructorImg.FileName);
            string path = Path.Combine(dir, filePath);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await InstructorImg.CopyToAsync(stream);
            }
            return filePath;
        }
        private DrivingInstructors CheckUpdatedProperties(UpdateInstructorRequest UpdateInstructorRequest, DrivingInstructors existingInstructor)
        {

            existingInstructor.Experience = (UpdateInstructorRequest.Experience != default
                || UpdateInstructorRequest.Experience != existingInstructor.Experience) ?
                UpdateInstructorRequest.Experience : existingInstructor.Experience;

            existingInstructor.InstructorName = (UpdateInstructorRequest.InstructorName != default
                || UpdateInstructorRequest.InstructorName != existingInstructor.InstructorName) ?
                UpdateInstructorRequest.InstructorName : existingInstructor.InstructorName;

            existingInstructor.InsturctorImgUrl = (UpdateInstructorRequest.InsturctorImgUrl != default
                || UpdateInstructorRequest.InsturctorImgUrl != existingInstructor.InsturctorImgUrl) ?
                UpdateInstructorRequest.InsturctorImgUrl : existingInstructor.InsturctorImgUrl;

            existingInstructor.PhoneNumber = (UpdateInstructorRequest.PhoneNumber != default
                || UpdateInstructorRequest.PhoneNumber != existingInstructor.PhoneNumber) ?
                UpdateInstructorRequest.PhoneNumber : existingInstructor.PhoneNumber;


            return existingInstructor;
        }
        private string HashImgString(IFormFile file)
        {
            using (var sha256 = SHA256.Create())
            using (var stream = file.OpenReadStream())
            {
                byte[] hashBytes = sha256.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
