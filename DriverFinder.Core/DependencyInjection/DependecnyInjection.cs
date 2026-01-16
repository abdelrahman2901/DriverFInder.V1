using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Domain.RepositoryContracts.IReviewRepo;
using DriverFinder.Core.Services.AreaServices;
using DriverFinder.Core.Services.AuthServices;
using DriverFinder.Core.Services.CityServices;
using DriverFinder.Core.Services.InstructorServices;
using DriverFinder.Core.Services.ProgramServices;
using DriverFinder.Core.Services.ProgramTypesServices;
using DriverFinder.Core.Services.ReservationServices;
using DriverFinder.Core.Services.ReviewServices;
using DriverFinder.Core.Services.SchoolDetailsViewServices;
using DriverFinder.Core.Services.SchoolDocumentServices;
using DriverFinder.Core.Services.SchoolOwnerServices;
using DriverFinder.Core.Services.SchoolProgramsServices;
using DriverFinder.Core.Services.SchoolProgramsViewServices;
using DriverFinder.Core.Services.SchoolServices;
using DriverFinder.Core.Services.UserActivityServices;
using DriverFinder.Core.Services.UserDetailsServices;
using DriverFinder.Core.Services.VehicleBodyTypeServices;
using DriverFinder.Core.Services.VehicleDetailsViewServices;
using DriverFinder.Core.Services.VehicleMakeServices;
using DriverFinder.Core.Services.VehicleModelServices;
using DriverFinder.Core.Services.VehiclesServices;
using DriverFinder.Core.Services.VehicleTransmissionServices;
using DriverFinder.Core.ServicesContracts.IAreaServices;
using DriverFinder.Core.ServicesContracts.IAuthServices;
using DriverFinder.Core.ServicesContracts.ICityServices;
using DriverFinder.Core.ServicesContracts.IInstructorServices;
using DriverFinder.Core.ServicesContracts.IProgramServices;
using DriverFinder.Core.ServicesContracts.IProgramTypesServices;
using DriverFinder.Core.ServicesContracts.IReservationServices;
using DriverFinder.Core.ServicesContracts.IReviewServices;
using DriverFinder.Core.ServicesContracts.ISchoolDetailsViewServices;
using DriverFinder.Core.ServicesContracts.ISchoolDocuemntServices;
using DriverFinder.Core.ServicesContracts.ISchoolOwnerServices;
using DriverFinder.Core.ServicesContracts.ISchoolProgramsServices;
using DriverFinder.Core.ServicesContracts.ISchoolProgramsViewServices;
using DriverFinder.Core.ServicesContracts.ISchoolServices;
using DriverFinder.Core.ServicesContracts.IUserActivityServices;
using DriverFinder.Core.ServicesContracts.IUserDetailsServices;
using DriverFinder.Core.ServicesContracts.IVehicleBodyTypeServices;
using DriverFinder.Core.ServicesContracts.IVehicleDetailsViewServices;
using DriverFinder.Core.ServicesContracts.IVehicleMakeServices;
using DriverFinder.Core.ServicesContracts.IVehicleModelServices;
using DriverFinder.Core.ServicesContracts.IVehiclesServices;
using DriverFinder.Core.ServicesContracts.IVehicleTransmissionServices;
using DriverFinder.Core.Validation.AuthValidation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DriverFinder.Core.DependencyInjection
{
    public static class DependecnyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection Services)
        {
            Services.AddScoped<ISchoolService, SchoolService>();
            Services.AddScoped<ISchoolDetailsViewService, SchoolDetailsViewService>();
            Services.AddScoped<IProgramService, ProgramService>();
            Services.AddScoped<IProgramTypesService, ProgramTypesService>();
            Services.AddScoped<ISchoolOwnerService, SchoolOwnerService>();
            Services.AddScoped<IReservationService, ReservationService>();
            Services.AddScoped<IUserDetailsViewService, UserDetailsViewService>();
            Services.AddScoped<IUserActivityService, UserActivityService>();
            Services.AddScoped<ISchoolDocumentsService, SchoolDocumentsService>();
            Services.AddScoped<ISchoolProgramsService, SchoolProgramsService>();
            Services.AddScoped<ISchoolProgramsViewServices, SchoolProgramsViewService>();
            Services.AddScoped<IAuthService, AuthService>();
            Services.AddScoped<IInstructorService, InstructorService>();
            Services.AddScoped<IVehiclesService, VehiclesService>();
            Services.AddScoped<ICityService, CityService>();
            Services.AddScoped<IAreaService, AreaService>();
            Services.AddScoped<IVehicleTransmissionServices, VehicleTransmissionService>();
            Services.AddScoped<IVehicleBodyTypeServices, VehicleBodyTypeService>();
            Services.AddScoped<IVehicleMakeServices, VehicleMakeService>();
            Services.AddScoped<IVehicleModelServices, VehicleModelService>();
            Services.AddScoped<IVehicleDetailsViewService, VehicleDetailsViewService>();
            Services.AddScoped<IReviewService, ReviewService>();

            Services.AddValidatorsFromAssemblyContaining<LoginRequestValidation>();

            //Services.AddHttpClient();

            return Services;
        }

    }
}
