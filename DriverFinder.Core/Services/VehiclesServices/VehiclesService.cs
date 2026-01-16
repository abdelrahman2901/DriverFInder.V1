using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.RepositoryContracts.IVehiclesRepo;
using DriverFinder.Core.DTO.VehicalDTO;
using DriverFinder.Core.ServicesContracts.IVehiclesServices;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace DriverFinder.Core.Services.VehiclesServices
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IVehiclesRepository _repository;

        public VehiclesService(IVehiclesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<VehicleResponse>>> GetAllSchoolsVehicles()
        {
            IEnumerable<SchoolsVehicles> vehicles = await _repository.GetAllAsync();
            if (vehicles.Count() == 0)
            {
                return Result<IEnumerable<VehicleResponse>>.Failure("No vehicles found.");
            }
            return Result<IEnumerable<VehicleResponse>>.Success(vehicles.Select(v => v.ToVehicalResponse()));
        }

        public async Task<Result<VehicleResponse>> GetVehicleById(Guid vehicleId)
        {
            SchoolsVehicles? vehicle = await _repository.GetByIdAsync(vehicleId);
            if (vehicle == null)
            {
                return Result<VehicleResponse>.Failure("No vehicles found.");
            }
            return Result<VehicleResponse>.Success(vehicle.ToVehicalResponse());
        }

        public async Task<Result<IEnumerable<VehicleResponse>>> GetAllSchoolVehicles(Guid schoolId)
        {
            IEnumerable<SchoolsVehicles> Schoolvehicles = await _repository.GetBySchoolIdAsync(schoolId);
            if (Schoolvehicles.Count() == 0)
            {
                return Result<IEnumerable<VehicleResponse>>.Failure("No vehicles found.");
            }
            return Result<IEnumerable<VehicleResponse>>.Success(Schoolvehicles.Select(v => v.ToVehicalResponse()));
        }

        public async Task<Result<VehicleResponse>> AddNewVehicle(VehicleRequests request, IFormFile VehicleImg)
        {

            var NewVehicle = request.ToSchoolVehical();
            if (VehicleImg != null)
            {
                bool ImgExists = await CheckImgExistance(VehicleImg);
                if (ImgExists)
                {
                    return Result<VehicleResponse>.Failure("Image Already Exists.");
                }
                string? ImgUrl = await UploadVehicleImage(VehicleImg);
                if (ImgUrl == null)
                {
                    return Result<VehicleResponse>.Failure("Failed Uploading Image.");
                }
                NewVehicle.VehicleImageUrl = ImgUrl;
                NewVehicle.VehicleImageHash = HashImgString(VehicleImg);
            }
            SchoolsVehicles? Result = await _repository.AddAsync(NewVehicle);
            if (Result == null)
            {
                return Result<VehicleResponse>.Failure("Failed Adding New Vehicle.");
            }
            return Result<VehicleResponse>.Success(NewVehicle.ToVehicalResponse());
        }

        public async Task<Result<VehicleResponse>> UpdateVehicle(UpdateVehicleRequest request, IFormFile? NewVehicleImage)
        {
            SchoolsVehicles? OldVehicleData = await _repository.GetByIdAsync(request.VehicleID);
            if (OldVehicleData == null)
            {
                return Result<VehicleResponse>.Failure("No Vehicle Found to Update.");
            }
            SchoolsVehicles? UpdateVehicle = CheckUpdatedProperties(request, OldVehicleData);
            string? path;
            string? hashImg;
            if (NewVehicleImage != null)
            {
                path = await UpdatingVehicleImg(NewVehicleImage, request.VehicleImageUrl);
                if (path == null)
                {
                    return Result<VehicleResponse>.Failure("Failed Updating Vehicle Image.");
                }
                UpdateVehicle.VehicleImageUrl = path;
                UpdateVehicle.VehicleImageHash = HashImgString(NewVehicleImage);
            }

            SchoolsVehicles? UpdatedVehicle = await _repository.UpdateAsync(UpdateVehicle);

            if (UpdatedVehicle == null)
            {
                return Result<VehicleResponse>.Failure("Failed Updating Vehicle.");
            }
            return Result<VehicleResponse>.Success(UpdatedVehicle.ToVehicalResponse());
        }

        public async Task<Result<bool>> DeleteVehicle(Guid vehicleId)
        {
            SchoolsVehicles? Vehicle = await _repository.GetByIdAsync(vehicleId);
            if (Vehicle == null)
            {
                return Result<bool>.Failure("No Vehicle Found to Update.");
            }
            bool Result = await _repository.DeleteAsync(Vehicle);
            if (Result == false)
            {
                return Result<bool>.Failure("Failed Deleteing Vehicle.");
            }
            if (!string.IsNullOrEmpty(Vehicle.VehicleImageUrl))
            {

                Result = DeleteVehicleImage(Vehicle.VehicleImageUrl);
                if (Result == false)
                {
                    return Result<bool>.Failure("Failed Deleting Vehicle Image.");
                }
            }
            return Result<bool>.Success(true);
        }

        private async Task<bool> CheckImgExistance(IFormFile img)
        {
            return await _repository.CheckImgExistance(HashImgString(img));
        }

        private async Task<string?> UploadVehicleImage(IFormFile vehicleImg)
        {
            if (vehicleImg == null) return string.Empty;
            string Dir =
            @"D:\NEw_laptop_Boda\FullStack_Projects\DriveFinder_Project\DriverFinder\wwwroot\VehicalImgs";

            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }

            var filePath = Guid.NewGuid().ToString() + Path.GetExtension(vehicleImg.FileName);
            var fullPath = Path.Combine(Dir, filePath);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                await vehicleImg.CopyToAsync(stream);
            }

            return filePath;
        }

        private bool DeleteVehicleImage(string imgUrl)
        {

            string Dir =
           @"D:\NEw_laptop_Boda\FullStack_Projects\DriveFinder_Project\DriverFinder\wwwroot\VehicalImgs";

            var path = Path.Combine(Dir, imgUrl);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        private async Task<string?> UpdatingVehicleImg(IFormFile newImg, string existingImage)
        {
            bool deletingImage = DeleteVehicleImage(existingImage);
            if (!deletingImage)
            {
                return null;
            }
            string? ImgUrl = await UploadVehicleImage(newImg);
            return ImgUrl;
        }

        private SchoolsVehicles CheckUpdatedProperties(
            UpdateVehicleRequest request,
            SchoolsVehicles existing)
        {
            existing.MakeID = (request.vehicleMakeID != default
             || request.vehicleMakeID != existing.MakeID) ?
             request.vehicleMakeID : existing.MakeID;

            existing.ModelID = (request.vehicleModelID != default
                || request.vehicleModelID != existing.ModelID) ?
                request.vehicleModelID : existing.ModelID;

            existing.BodyTypeID = (request.vehicleBodyTypeID != default
                || request.vehicleBodyTypeID != existing.BodyTypeID) ?
                request.vehicleBodyTypeID : existing.BodyTypeID;

            existing.TransmissionID = (request.vehicleTransmissionID != default
                || request.vehicleTransmissionID != existing.TransmissionID) ?
                request.vehicleTransmissionID : existing.TransmissionID;

            return existing;
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
