using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSchoolProgramsUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "SchoolPrograms",
                columns: table => new
                {
                    SchoolProgramID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    vehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DurationInWeeks = table.Column<short>(type: "smallint", nullable: false),
                    NumberOfSessions = table.Column<short>(type: "smallint", nullable: false),
                    NumberOfSessionsPerWeek = table.Column<short>(type: "smallint", nullable: false),
                    DurationOfSessionInMin = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolPrograms", x => x.SchoolProgramID);
                    table.ForeignKey(
                        name: "FK_SchoolPrograms_DrivingProgram_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "DrivingProgram",
                        principalColumn: "ProgramID");
                    table.ForeignKey(
                        name: "FK_SchoolPrograms_DrivingSchools_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "DrivingSchools",
                        principalColumn: "SchoolID");
                    table.ForeignKey(
                        name: "FK_SchoolPrograms_ProgramTypes_ProgramTypeID",
                        column: x => x.ProgramTypeID,
                        principalTable: "ProgramTypes",
                        principalColumn: "ProgramTypeID");
                });

            migrationBuilder.CreateTable(
                name: "testentity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testentity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SchoolPrograms",
                columns: new[] { "SchoolProgramID", "DurationInWeeks", "DurationOfSessionInMin", "IsActive", "NumberOfSessions", "NumberOfSessionsPerWeek", "Price", "ProgramID", "ProgramTypeID", "SchoolID", "vehicleModel", "vehicleType" },
                values: new object[] { new Guid("6c7b0bfb-9629-4225-af93-f0f0da1a9f5a"), (short)4, (short)60, true, (short)12, (short)3, 3500m, new Guid("08c869a0-8d74-4693-ad0a-9a8197bd3643"), null, new Guid("0796e164-0a6c-4493-8f52-9d6fc2200322"), "S1000 RR", "BMW" });

            migrationBuilder.InsertData(
                table: "testentity",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d2f3a2b4-5c6d-4e8f-9a0b-1c2d3e4f5a6b"), "Test Name" });

           
            migrationBuilder.CreateIndex(
                name: "IX_SchoolPrograms_ProgramID",
                table: "SchoolPrograms",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPrograms_ProgramTypeID",
                table: "SchoolPrograms",
                column: "ProgramTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPrograms_SchoolID",
                table: "SchoolPrograms",
                column: "SchoolID");

        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_SchoolPrograms_SchoolProgramID",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "SchoolPrograms");

            migrationBuilder.DropTable(
                name: "testentity");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Reservations",
                newName: "SubPeriod");

            migrationBuilder.RenameColumn(
                name: "SchoolProgramID",
                table: "Reservations",
                newName: "ProgramTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_SchoolProgramID",
                table: "Reservations",
                newName: "IX_Reservations_ProgramTypeID");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "DateOfAttendance",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProgramID",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("476169a5-07fa-4b3d-b198-915d27c653bc"), "164BA083-FF58-4773-B3F4-571FAC01D282", "Has full system access, manages all users, roles, permissions, and platform-wide settings.", "Admin", "ADMIN" },
                    { new Guid("504792c3-25e4-43e2-83f1-c675ac03157a"), "273C9409-150E-49FC-BB58-2252A0E43E3A", "Manages their own driving school profile, updates school details, programs, pricing, schedules, and responds to student registrations.", "SchoolOwner", "SCHOOLOWNER" },
                    { new Guid("67269ba7-333e-4c1d-babc-321f4faff837"), "0B34AF6C-0D1D-49B6-BA72-2B78B68DCB2F", "Manages content and user activity, approves schools, reviews reports, and enforces platform rules.", "Moderator", "MODERATOR" },
                    { new Guid("c426fc74-b893-4e75-bbc9-2a4ffe7cb236"), "AA09F9AC-354A-492E-AE38-5DFB794EA027", "Regular user who can search for schools, view details, register for programs, and manage personal profile.", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "DrivingProgram",
                columns: new[] { "ProgramID", "Program" },
                values: new object[,]
                {
                    { new Guid("08c869a0-8d74-4693-ad0a-9a8197bd3643"), "motorcycle" },
                    { new Guid("2e8bd5e0-7c5a-42a3-b633-b50fa96ada1e"), "both" },
                    { new Guid("a3ef3534-390f-4b6e-8de9-27c120194c11"), "Cars" }
                });

            migrationBuilder.InsertData(
                table: "ProgramTypes",
                columns: new[] { "ProgramTypeID", "ProgramType" },
                values: new object[,]
                {
                    { new Guid("42110cf6-17d9-42dd-9ce3-c96dff7c38fa"), "Manual" },
                    { new Guid("e2444b3f-dfc3-4b32-a05f-c10bc6ab54a3"), "Automatic" },
                    { new Guid("eff9f038-a0ca-4da5-9da4-5fd6ca28ac3f"), "both" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ProgramID",
                table: "Reservations",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserID_ProgramID",
                table: "Reservations",
                columns: new[] { "UserID", "ProgramID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_DrivingProgram_ProgramID",
                table: "Reservations",
                column: "ProgramID",
                principalTable: "DrivingProgram",
                principalColumn: "ProgramID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ProgramTypes_ProgramTypeID",
                table: "Reservations",
                column: "ProgramTypeID",
                principalTable: "ProgramTypes",
                principalColumn: "ProgramTypeID");
        }
    }
}
