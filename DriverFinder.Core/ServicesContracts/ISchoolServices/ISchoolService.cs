using DriverFinder.Core.Domain.Common;
using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.DTO.SchoolDTO;
using DriverFinder.Core.DTO.SchoolDTO.SchoolRegisterDTO;
using DriverFinder.Core.DTO.SchoolDTO.UpdateSchoolDTO;
using DriverFinder.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace DriverFinder.Core.ServicesContracts.ISchoolServices
{
    public interface ISchoolService
    {
        Task<Result<IEnumerable<SchoolResponse>>> GetDrivingSchools();
        Task<Result<DrivingSchool?>> GetDrivingSchoolEntityByID(Guid id);
        Task<Result<SchoolResponse?>> GetDrivingSchoolByID(Guid id);
        Task<Result<SchoolResponse?>> AddDrivingSchool(SchoolRegisterRequest drivingSchool,IFormFile img);
        Task<Result<SchoolResponse?>> EditSchoolStatus(Guid SchoolID, SchoolStatusEnum status); 
        Task<Result<SchoolResponse?>> BlockSchool(Guid SchoolID, bool block);

        Task<Result<UpdateSchoolResponse?>> ChangeFemaleInstructorStatus(Guid SchoolID);
        Task<Result<SchoolResponse?>> UpdateRating(Guid SchoolID);


        Task<Result<UpdateSchoolResponse?>> UpdateDrivingSchool(UpdateSchoolRequest drivingSchool,IFormFile img);

        Task<Result<bool>> DeleteDrivingSchool(Guid Schoolid);
    }
}
