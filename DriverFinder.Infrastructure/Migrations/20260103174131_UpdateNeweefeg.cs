using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNeweefeg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MakeID",
                table: "VehicleModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_MakeID",
                table: "VehicleModel",
                column: "MakeID");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModel_VehicleMake_MakeID",
                table: "VehicleModel",
                column: "MakeID",
                principalTable: "VehicleMake",
                principalColumn: "MakeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModel_VehicleMake_MakeID",
                table: "VehicleModel");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModel_MakeID",
                table: "VehicleModel");

            migrationBuilder.DropColumn(
                name: "MakeID",
                table: "VehicleModel");
        }
    }
}
