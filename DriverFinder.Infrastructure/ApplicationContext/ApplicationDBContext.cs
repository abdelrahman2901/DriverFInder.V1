using DriverFinder.Core.Domain.Entites;
using DriverFinder.Core.Domain.EntitiesVIew;
using DriverFinder.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DriverFinder.Infrastructure.ApplicationContext
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<SchoolOwner> SchoolOwners { get; set; }
        public virtual DbSet<DrivingSchool> DrivingSchools { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<SchoolPrograms> SchoolPrograms { get; set; }
        public virtual DbSet<ProgramTypes> ProgramTypes { get; set; }
        public virtual DbSet<Programs> DrivingProgram { get; set; }
        public virtual DbSet<UserActivity> UserActivity { get; set; }
        public virtual DbSet<RegistrationDocuemnts> RegistrationDocuemnts { get; set; }
        public virtual DbSet<SchoolDetailsView> SchoolDetailsView { get; set; }
        public virtual DbSet<UsersDetailsView> UsersDetailsView { get; set; }
        public virtual DbSet<SchoolProgramsView> SchoolProgramsView { get; set; }
        public virtual DbSet<SchoolsVehicles> SchoolsVehicals { get; set; }

        public virtual DbSet<DrivingInstructors> DrivingInstructors { get; set; }
        public virtual DbSet<VehicleTransmission> VehicleTransmission { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }
        public virtual DbSet<VehicleMake> VehicleMake { get; set; }
        public virtual DbSet<VehicleBodyType> VehicleBodyType { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<VehicleDetailsView> VehicleDetailsVew { get; set; }
        public virtual DbSet<Reviews> Review { get; set; }
        public virtual DbSet<Notifications> SchoolActivity { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var ForeignKeys = builder.Model.GetEntityTypes()
       .SelectMany(e => e.GetForeignKeys()).ToList();
            foreach (var relationship in ForeignKeys)
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            builder.Entity<Notifications>()
                .HasOne(u => u.User)
                .WithMany(a => a.Notifications)
                .HasForeignKey(u => u.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DrivingSchool>().Property(i => i.SubscriptionType).HasConversion<string>();

            #region old
            builder.Entity<Reviews>()
                   .HasOne(i => i.User)
                   .WithMany(m => m.Reviews)
                   .HasForeignKey(i => i.UserID)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Reviews>()
                   .HasOne(i => i.Instructor)
                   .WithMany(m=>m.Reviews)
                   .HasForeignKey(i => i.InstructorID)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reviews>()
                   .HasOne(i => i.School)
                   .WithMany(m => m.Reviews)
                   .HasForeignKey(i => i.SchoolID)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<DrivingInstructors>().Property(i => i.Gender).HasConversion<string>();
            builder.Entity<DrivingSchool>().HasOne(c => c.City).WithMany().HasForeignKey(c => c.CityID).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<DrivingSchool>().HasOne(c => c.Area).WithMany().HasForeignKey(c => c.AreaID).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<VehicleDetailsView>().HasNoKey().ToView("VehicleDetails_vw");

            builder.Entity<Area>().HasOne(p => p.City)
                .WithMany()
                .HasForeignKey(p => p.CityID)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<VehicleModel>().HasOne(p => p.make)
                .WithMany()
                .HasForeignKey(p => p.MakeID)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<SchoolsVehicles>().HasOne(p => p.VehicleMake)
                .WithMany()
                .HasForeignKey(p => p.MakeID)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<SchoolsVehicles>().HasOne(p => p.VehicleModel).WithMany()
                .HasForeignKey(p => p.ModelID)
                .OnDelete(DeleteBehavior.NoAction);
           
            builder.Entity<SchoolsVehicles>().HasOne(p => p.VehicleBodyType).WithMany()
                .HasForeignKey(p => p.BodyTypeID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SchoolsVehicles>().HasOne(p => p.VehicleTransmision)
                .WithMany()
                .HasForeignKey(p => p.TransmissionID)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<SchoolsVehicles>().HasOne(p => p.School)
                .WithMany()
                .HasForeignKey(p => p.SchoolID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DrivingInstructors>().HasOne(p => p.School)
                .WithMany()
                .HasForeignKey(p => p.SchoolID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>().HasOne(p => p.Instructor)
                .WithMany()
                .HasForeignKey(p => p.InstructorID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SchoolPrograms>().HasOne(p => p.Vehicle)
                .WithMany()
                .HasForeignKey(p => p.VehicleID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SchoolPrograms>().HasOne(p => p.ProgramType)
                .WithMany()
                .HasForeignKey(p => p.ProgramTypeID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SchoolPrograms>().HasOne(p => p.Program)
                .WithMany()
                .HasForeignKey(p => p.ProgramID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SchoolPrograms>().HasOne(p => p.school)
                .WithMany()
                .HasForeignKey(p => p.SchoolID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ProgramTypes>().Property(p => p.ProgramType).HasConversion<string>();
            builder.Entity<Programs>().Property(p => p.Program).HasConversion<string>();

            builder.Entity<DrivingSchool>().Property(p => p.status).HasConversion<string>();
            builder.Entity<DrivingSchool>().Property(p => p.isblocked).HasConversion<bool>();
            builder.Entity<SchoolPrograms>().Property(p => p.IsActive).HasConversion<bool>();
            builder.Entity<Reservation>().Property(p => p.Status).HasConversion<string>();

            builder.Entity<UsersDetailsView>().HasNoKey().ToView("GetAllUsers_vw");
            builder.Entity<SchoolDetailsView>().HasNoKey().ToView("SchoolDetails_vw");
            builder.Entity<ReservationDetailsView>().HasNoKey().ToView("ReservationDetails_vw");
            builder.Entity<SchoolProgramsView>().HasNoKey().ToView("SchoolPrograms_vw");
            



            builder.Entity<Reservation>().HasOne(u => u.User)
                .WithMany(r => r.Reservations)
          .HasForeignKey(r => r.UserID)
          .IsRequired(false)
          .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Reservation>()
                .HasOne(s => s.School)
        .WithMany(r => r.Reservations)
        .HasForeignKey(r => r.SchoolID)
        .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>()
                .HasOne(s => s.SchoolProgram)
                .WithMany(r => r.Reservations)
                .HasForeignKey(s => s.SchoolProgramID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>()
               .HasOne(s => s.Instructor)
               .WithMany(r => r.Reservations)
               .HasForeignKey(s => s.InstructorID)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DrivingSchool>()
                .HasOne(o => o.Owner)
                .WithMany()
                .HasForeignKey(o => o.OwnerID)
                .OnDelete(DeleteBehavior.NoAction);


            #endregion
        }


    }
}
