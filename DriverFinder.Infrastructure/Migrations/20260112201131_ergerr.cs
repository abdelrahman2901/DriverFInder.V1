using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ergerr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isblocked",
                table: "DrivingSchools",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

    

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_City_CityID2",
                table: "Area");

            migrationBuilder.DropIndex(
                name: "IX_Area_CityID2",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "CityID2",
                table: "Area");

            migrationBuilder.AlterColumn<bool>(
                name: "isblocked",
                table: "DrivingSchools",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
