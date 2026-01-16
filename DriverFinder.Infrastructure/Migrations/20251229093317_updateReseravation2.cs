using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateReseravation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_DrivingInstructors_DrivingInstructorsInstructorID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DrivingInstructorsInstructorID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DrivingInstructorsInstructorID",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DrivingInstructorsInstructorID",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DrivingInstructorsInstructorID",
                table: "Reservations",
                column: "DrivingInstructorsInstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_DrivingInstructors_DrivingInstructorsInstructorID",
                table: "Reservations",
                column: "DrivingInstructorsInstructorID",
                principalTable: "DrivingInstructors",
                principalColumn: "InstructorID");
        }
    }
}
