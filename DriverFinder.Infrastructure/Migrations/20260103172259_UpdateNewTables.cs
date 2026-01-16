using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "SchoolsVehicals");

            migrationBuilder.DropColumn(
                name: "VehicleBodyType",
                table: "SchoolsVehicals");

            migrationBuilder.DropColumn(
                name: "VehicleMake",
                table: "SchoolsVehicals");

            migrationBuilder.DropColumn(
                name: "VehicleModel",
                table: "SchoolsVehicals");

            migrationBuilder.DropColumn(
                name: "VehicleTransmision",
                table: "SchoolsVehicals");

            migrationBuilder.AddColumn<Guid>(
                name: "BodyTypeID",
                table: "SchoolsVehicals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MakeID",
                table: "SchoolsVehicals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModelID",
                table: "SchoolsVehicals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TransmissionID",
                table: "SchoolsVehicals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "VehicleBodyType",
                columns: table => new
                {
                    BodyTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBodyType", x => x.BodyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMake",
                columns: table => new
                {
                    MakeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMake", x => x.MakeID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    ModelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.ModelID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTransmission",
                columns: table => new
                {
                    TransmissionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTransmission", x => x.TransmissionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolsVehicals_BodyTypeID",
                table: "SchoolsVehicals",
                column: "BodyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolsVehicals_MakeID",
                table: "SchoolsVehicals",
                column: "MakeID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolsVehicals_ModelID",
                table: "SchoolsVehicals",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolsVehicals_TransmissionID",
                table: "SchoolsVehicals",
                column: "TransmissionID");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolsVehicals_VehicleBodyType_BodyTypeID",
                table: "SchoolsVehicals",
                column: "BodyTypeID",
                principalTable: "VehicleBodyType",
                principalColumn: "BodyTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolsVehicals_VehicleMake_MakeID",
                table: "SchoolsVehicals",
                column: "MakeID",
                principalTable: "VehicleMake",
                principalColumn: "MakeID");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolsVehicals_VehicleModel_ModelID",
                table: "SchoolsVehicals",
                column: "ModelID",
                principalTable: "VehicleModel",
                principalColumn: "ModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolsVehicals_VehicleTransmission_TransmissionID",
                table: "SchoolsVehicals",
                column: "TransmissionID",
                principalTable: "VehicleTransmission",
                principalColumn: "TransmissionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolsVehicals_VehicleBodyType_BodyTypeID",
                table: "SchoolsVehicals");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolsVehicals_VehicleMake_MakeID",
                table: "SchoolsVehicals");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolsVehicals_VehicleModel_ModelID",
                table: "SchoolsVehicals");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolsVehicals_VehicleTransmission_TransmissionID",
                table: "SchoolsVehicals");

            migrationBuilder.DropTable(
                name: "VehicleBodyType");

            migrationBuilder.DropTable(
                name: "VehicleMake");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleTransmission");

            migrationBuilder.DropIndex(
                name: "IX_SchoolsVehicals_BodyTypeID",
                table: "SchoolsVehicals");

            migrationBuilder.DropIndex(
                name: "IX_SchoolsVehicals_MakeID",
                table: "SchoolsVehicals");

            migrationBuilder.DropIndex(
                name: "IX_SchoolsVehicals_ModelID",
                table: "SchoolsVehicals");

            migrationBuilder.DropIndex(
                name: "IX_SchoolsVehicals_TransmissionID",
                table: "SchoolsVehicals");

            migrationBuilder.DropColumn(
                name: "BodyTypeID",
                table: "SchoolsVehicals");

            migrationBuilder.DropColumn(
                name: "MakeID",
                table: "SchoolsVehicals");

            migrationBuilder.DropColumn(
                name: "ModelID",
                table: "SchoolsVehicals");

            migrationBuilder.DropColumn(
                name: "TransmissionID",
                table: "SchoolsVehicals");

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "SchoolsVehicals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleBodyType",
                table: "SchoolsVehicals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleMake",
                table: "SchoolsVehicals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleModel",
                table: "SchoolsVehicals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleTransmision",
                table: "SchoolsVehicals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
