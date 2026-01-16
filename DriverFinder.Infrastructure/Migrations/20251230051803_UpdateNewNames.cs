using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicalTransmision",
                table: "SchoolsVehicals",
                newName: "VehicleTransmision");

            migrationBuilder.RenameColumn(
                name: "VehicalModel",
                table: "SchoolsVehicals",
                newName: "VehicleModel");

            migrationBuilder.RenameColumn(
                name: "VehicalMake",
                table: "SchoolsVehicals",
                newName: "VehicleMake");

            migrationBuilder.RenameColumn(
                name: "VehicalBodyType",
                table: "SchoolsVehicals",
                newName: "VehicleBodyType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleTransmision",
                table: "SchoolsVehicals",
                newName: "VehicalTransmision");

            migrationBuilder.RenameColumn(
                name: "VehicleModel",
                table: "SchoolsVehicals",
                newName: "VehicalModel");

            migrationBuilder.RenameColumn(
                name: "VehicleMake",
                table: "SchoolsVehicals",
                newName: "VehicalMake");

            migrationBuilder.RenameColumn(
                name: "VehicleBodyType",
                table: "SchoolsVehicals",
                newName: "VehicalBodyType");
        }
    }
}
