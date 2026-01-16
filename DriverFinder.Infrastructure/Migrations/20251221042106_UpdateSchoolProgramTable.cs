using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchoolProgramTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DurationOfSessionInMin",
                table: "SchoolPrograms",
                newName: "SessionDuration");

            migrationBuilder.AlterColumn<string>(
                name: "vehicleModel",
                table: "SchoolPrograms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionDuration",
                table: "SchoolPrograms",
                newName: "DurationOfSessionInMin");

            migrationBuilder.AlterColumn<string>(
                name: "vehicleModel",
                table: "SchoolPrograms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
