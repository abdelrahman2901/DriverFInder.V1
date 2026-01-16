using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsNVehTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vehicleModel",
                table: "SchoolPrograms");

            migrationBuilder.DropColumn(
                name: "vehicleType",
                table: "SchoolPrograms");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleID",
                table: "SchoolPrograms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DrivingInstructorsInstructorID",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstructorID",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "DrivingSchools",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DrivingInstructors",
                columns: table => new
                {
                    InstructorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntsturctorImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingInstructors", x => x.InstructorID);
                    table.ForeignKey(
                        name: "FK_DrivingInstructors_DrivingSchools_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "DrivingSchools",
                        principalColumn: "SchoolID");
                });

            migrationBuilder.CreateTable(
                name: "SchoolsVehicals",
                columns: table => new
                {
                    VehicalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicalBodyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicalMake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicalModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicalTransmision = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolsVehicals", x => x.VehicalId);
                    table.ForeignKey(
                        name: "FK_SchoolsVehicals_DrivingSchools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "DrivingSchools",
                        principalColumn: "SchoolID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPrograms_VehicleID",
                table: "SchoolPrograms",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DrivingInstructorsInstructorID",
                table: "Reservations",
                column: "DrivingInstructorsInstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_InstructorID",
                table: "Reservations",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_DrivingInstructors_SchoolID",
                table: "DrivingInstructors",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolsVehicals_SchoolId",
                table: "SchoolsVehicals",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_DrivingInstructors_DrivingInstructorsInstructorID",
                table: "Reservations",
                column: "DrivingInstructorsInstructorID",
                principalTable: "DrivingInstructors",
                principalColumn: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_DrivingInstructors_InstructorID",
                table: "Reservations",
                column: "InstructorID",
                principalTable: "DrivingInstructors",
                principalColumn: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolPrograms_SchoolsVehicals_VehicleID",
                table: "SchoolPrograms",
                column: "VehicleID",
                principalTable: "SchoolsVehicals",
                principalColumn: "VehicalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_DrivingInstructors_DrivingInstructorsInstructorID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_DrivingInstructors_InstructorID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolPrograms_SchoolsVehicals_VehicleID",
                table: "SchoolPrograms");

            migrationBuilder.DropTable(
                name: "DrivingInstructors");

            migrationBuilder.DropTable(
                name: "SchoolsVehicals");

            migrationBuilder.DropIndex(
                name: "IX_SchoolPrograms_VehicleID",
                table: "SchoolPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DrivingInstructorsInstructorID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_InstructorID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "VehicleID",
                table: "SchoolPrograms");

            migrationBuilder.DropColumn(
                name: "DrivingInstructorsInstructorID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "DrivingSchools");

            migrationBuilder.AddColumn<string>(
                name: "vehicleModel",
                table: "SchoolPrograms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vehicleType",
                table: "SchoolPrograms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
