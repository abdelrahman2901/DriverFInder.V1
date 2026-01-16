using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixing2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

          

            migrationBuilder.DropColumn(
                name: "CityID1",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "CityID2",
                table: "Area");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityID1",
                table: "Area",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CityID2",
                table: "Area",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Area_CityID1",
                table: "Area",
                column: "CityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Area_CityID2",
                table: "Area",
                column: "CityID2");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_City_CityID1",
                table: "Area",
                column: "CityID1",
                principalTable: "City",
                principalColumn: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_City_CityID2",
                table: "Area",
                column: "CityID2",
                principalTable: "City",
                principalColumn: "CityID");
        }
    }
}
