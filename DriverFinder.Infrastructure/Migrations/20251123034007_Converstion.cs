using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Converstion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProgramType",
                table: "ProgramTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "ProgramTypeID",
                keyValue: new Guid("42110cf6-17d9-42dd-9ce3-c96dff7c38fa"),
                column: "ProgramType",
                value: "Manual");

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "ProgramTypeID",
                keyValue: new Guid("e2444b3f-dfc3-4b32-a05f-c10bc6ab54a3"),
                column: "ProgramType",
                value: "Automatic");

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "ProgramTypeID",
                keyValue: new Guid("eff9f038-a0ca-4da5-9da4-5fd6ca28ac3f"),
                column: "ProgramType",
                value: "both");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProgramType",
                table: "ProgramTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "ProgramTypeID",
                keyValue: new Guid("42110cf6-17d9-42dd-9ce3-c96dff7c38fa"),
                column: "ProgramType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "ProgramTypeID",
                keyValue: new Guid("e2444b3f-dfc3-4b32-a05f-c10bc6ab54a3"),
                column: "ProgramType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProgramTypes",
                keyColumn: "ProgramTypeID",
                keyValue: new Guid("eff9f038-a0ca-4da5-9da4-5fd6ca28ac3f"),
                column: "ProgramType",
                value: 2);
        }
    }
}
