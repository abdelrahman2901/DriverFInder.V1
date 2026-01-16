using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsNVehTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolsVehicals_DrivingSchools_SchoolId",
                table: "SchoolsVehicals");

            migrationBuilder.RenameColumn(
                name: "SchoolId",
                table: "SchoolsVehicals",
                newName: "SchoolID");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolsVehicals_SchoolId",
                table: "SchoolsVehicals",
                newName: "IX_SchoolsVehicals_SchoolID");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolsVehicals_DrivingSchools_SchoolID",
                table: "SchoolsVehicals",
                column: "SchoolID",
                principalTable: "DrivingSchools",
                principalColumn: "SchoolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolsVehicals_DrivingSchools_SchoolID",
                table: "SchoolsVehicals");

            migrationBuilder.RenameColumn(
                name: "SchoolID",
                table: "SchoolsVehicals",
                newName: "SchoolId");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolsVehicals_SchoolID",
                table: "SchoolsVehicals",
                newName: "IX_SchoolsVehicals_SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolsVehicals_DrivingSchools_SchoolId",
                table: "SchoolsVehicals",
                column: "SchoolId",
                principalTable: "DrivingSchools",
                principalColumn: "SchoolID");
        }
    }
}
