using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _235fwedsf1fwe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
