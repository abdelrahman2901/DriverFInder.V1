using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _235fwedsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AreaID",
                table: "DrivingSchools",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CityID",
                table: "DrivingSchools",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DrivingSchools_AreaID",
                table: "DrivingSchools",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_DrivingSchools_CityID",
                table: "DrivingSchools",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_DrivingSchools_Area_AreaID",
                table: "DrivingSchools",
                column: "AreaID",
                principalTable: "Area",
                principalColumn: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_DrivingSchools_City_CityID",
                table: "DrivingSchools",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrivingSchools_Area_AreaID",
                table: "DrivingSchools");

            migrationBuilder.DropForeignKey(
                name: "FK_DrivingSchools_City_CityID",
                table: "DrivingSchools");

            migrationBuilder.DropIndex(
                name: "IX_DrivingSchools_AreaID",
                table: "DrivingSchools");

            migrationBuilder.DropIndex(
                name: "IX_DrivingSchools_CityID",
                table: "DrivingSchools");

            migrationBuilder.DropColumn(
                name: "AreaID",
                table: "DrivingSchools");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "DrivingSchools");
        }
    }
}
