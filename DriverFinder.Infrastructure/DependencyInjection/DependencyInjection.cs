using DriverFinder.Core.Domain.RepositoryContracts.IAreaRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IAuthRepo;
using DriverFinder.Core.Domain.RepositoryContracts.ICityRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IDrivingSchoolRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IInstructorRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IProgramRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IReservationRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IReviewRepo;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolDetailsViewRepo;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolDocuementRepo;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolOwnerRepo;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolProgramsRepo;
using DriverFinder.Core.Domain.RepositoryContracts.ISchoolProgramsViewRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IUserActivityRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IUserDetailsViewRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleBodyTypeRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleDetailsViewRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleMakeRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleModelRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IVehiclesRepo;
using DriverFinder.Core.Domain.RepositoryContracts.IVehicleTransmissionRepo;
using DriverFinder.Core.Domain.RepositoryContracts.ProgramTypesRepo;
using DriverFinder.Core.Identity;
using DriverFinder.Infrastructure.ApplicationContext;
using DriverFinder.Infrastructure.Repository.AreaRepo;
using DriverFinder.Infrastructure.Repository.AuthRepo;
using DriverFinder.Infrastructure.Repository.CityRepo;
using DriverFinder.Infrastructure.Repository.DrivingSchoolRepo;
using DriverFinder.Infrastructure.Repository.InstructorRepo;
using DriverFinder.Infrastructure.Repository.ProgramRepo;
using DriverFinder.Infrastructure.Repository.ProgramTypesRepo;
using DriverFinder.Infrastructure.Repository.ReservationRepo;
using DriverFinder.Infrastructure.Repository.ReviewRepo;
using DriverFinder.Infrastructure.Repository.SchoolDetailsViewRepo;
using DriverFinder.Infrastructure.Repository.SchoolDocumentsRepository;
using DriverFinder.Infrastructure.Repository.SchoolOwnerRepo;
using DriverFinder.Infrastructure.Repository.SchoolProgramsRepo;
using DriverFinder.Infrastructure.Repository.SchoolProgramsViewRepo;
using DriverFinder.Infrastructure.Repository.SchoolVehiclesRepo;
using DriverFinder.Infrastructure.Repository.UserActivityRepo;
using DriverFinder.Infrastructure.Repository.UserDetailsViewRepo;
using DriverFinder.Infrastructure.Repository.VehicleBodyTypeRepo;
using DriverFinder.Infrastructure.Repository.VehicleDetailsViewRepo;
using DriverFinder.Infrastructure.Repository.VehicleMakeRepo;
using DriverFinder.Infrastructure.Repository.VehicleModelRepo;
using DriverFinder.Infrastructure.Repository.VehicleTransmissionRepo;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DriverFinder.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection Services,IConfiguration configuration)
        {
            Services.AddScoped<IProgramRepository, ProgramRepository>();
            Services.AddScoped<IProgramTypesRepository, ProgramTypesRepository>();
            Services.AddScoped<ISchoolOwnerRepository, SchoolOwnerRepository>();
            Services.AddScoped<IReservationRepository, ReservationRepository>();
            Services.AddScoped<IDrivingSchoolRepository, DrivingSchoolRepository>();
            Services.AddScoped<ISchoolDetailsViewRepository, SchoolDetailsViewRepository>();
            Services.AddScoped<IUserDetailsViewRepository, UserDetailsViewRepository>();
            Services.AddScoped<IUserActivityRepository, UserActivityRepository>();
            Services.AddScoped<ISchoolDocuementRepository, SchoolDocumentsRepository>();
            Services.AddScoped<ISchoolProgramsRepository, SchoolProgramsRepository>();
            Services.AddScoped<ISchoolProgramsViewRepository, SchoolProgramsViewRepoisotry>();
            Services.AddScoped<IAuthRepository, AuthRepository>();
            Services.AddScoped<IInsturctorRepository, InstructorRepository>();
            Services.AddScoped<IVehiclesRepository, VehiclesRepository>();
            Services.AddScoped<IAreaRepository, AreaRepository>();
            Services.AddScoped<ICityRepository, CityRepository>();
            Services.AddScoped<IVehicleTransmissionRepository, VehicleTransmissionRepository>();
            Services.AddScoped<IVehicleBodyTypeRepository, VehicleBodyTypeRepository>();
            Services.AddScoped<IVehicleMakeRepository, VehicleMakeRepository>();
            Services.AddScoped<IVehicleModelRepository, VehicleModeRepository>();
            Services.AddScoped<IVehicleDetailsViewRepository, VehicleDetailsViewRepository>();
            Services.AddScoped<IReviewRepository, ReviewRepository>();

            Services.AddDbContext<ApplicationDBContext>(options =>
             {
                 options.UseSqlServer(configuration.GetConnectionString("Default"));
             });

           
            return Services;
        }
    }
}
