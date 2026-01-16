using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateReseravation8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SchoolID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolProgramID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_DrivingInstructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "DrivingInstructors",
                        principalColumn: "InstructorID");
                    table.ForeignKey(
                        name: "FK_Reservations_DrivingSchools_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "DrivingSchools",
                        principalColumn: "SchoolID");
                    table.ForeignKey(
                        name: "FK_Reservations_SchoolPrograms_SchoolProgramID",
                        column: x => x.SchoolProgramID,
                        principalTable: "SchoolPrograms",
                        principalColumn: "SchoolProgramID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_InstructorID",
                table: "Reservations",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SchoolID",
                table: "Reservations",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SchoolProgramID",
                table: "Reservations",
                column: "SchoolProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserID",
                table: "Reservations",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
