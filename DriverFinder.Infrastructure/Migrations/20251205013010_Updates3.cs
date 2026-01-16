using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updates3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "DrivingSchools");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "DrivingSchools",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "DrivingSchools");

            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "DrivingSchools",
                type: "bit",
                nullable: true);
        }
    }
}
