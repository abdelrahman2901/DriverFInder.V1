using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ewgr132 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashImg",
                table: "SchoolPrograms");

            migrationBuilder.DropColumn(
                name: "vehicleImgUrl",
                table: "SchoolPrograms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashImg",
                table: "SchoolPrograms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vehicleImgUrl",
                table: "SchoolPrograms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
