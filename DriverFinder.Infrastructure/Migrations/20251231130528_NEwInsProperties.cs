using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NEwInsProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntsturctorImgUrl",
                table: "DrivingInstructors",
                newName: "InsturctorImgUrl");

            migrationBuilder.AddColumn<string>(
                name: "ImageHash",
                table: "DrivingInstructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageHash",
                table: "DrivingInstructors");

            migrationBuilder.RenameColumn(
                name: "InsturctorImgUrl",
                table: "DrivingInstructors",
                newName: "IntsturctorImgUrl");
        }
    }
}
