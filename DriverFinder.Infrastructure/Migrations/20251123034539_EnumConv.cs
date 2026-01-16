using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnumConv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Program",
                table: "DrivingProgram",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "DrivingProgram",
                keyColumn: "ProgramID",
                keyValue: new Guid("08c869a0-8d74-4693-ad0a-9a8197bd3643"),
                column: "Program",
                value: "motorcycle");

            migrationBuilder.UpdateData(
                table: "DrivingProgram",
                keyColumn: "ProgramID",
                keyValue: new Guid("2e8bd5e0-7c5a-42a3-b633-b50fa96ada1e"),
                column: "Program",
                value: "both");

            migrationBuilder.UpdateData(
                table: "DrivingProgram",
                keyColumn: "ProgramID",
                keyValue: new Guid("a3ef3534-390f-4b6e-8de9-27c120194c11"),
                column: "Program",
                value: "Cars");

            migrationBuilder.Sql(@"
              CREATE VIEW SchoolDetails AS
            SELECT 
                s.SchoolID,
                s.SchoolName,
                s.PhoneNumber,
                s.Location,
                s.SchoolEmail,
                o.OwnerName,
                s.OwnerID,
                p.Program,
                pt.ProgramType
            FROM DrivingSchool s
            INNER JOIN SchoolOwner o ON s.OwnerID = o.OwnerID ,
           inner join DrivingProgram p ON p.ProgramID = s.ProgramID
           inner join ProgramTypes pt on pt.ProgramTypeID= s.ProgramTypeID
        
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Program",
                table: "DrivingProgram",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "DrivingProgram",
                keyColumn: "ProgramID",
                keyValue: new Guid("08c869a0-8d74-4693-ad0a-9a8197bd3643"),
                column: "Program",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DrivingProgram",
                keyColumn: "ProgramID",
                keyValue: new Guid("2e8bd5e0-7c5a-42a3-b633-b50fa96ada1e"),
                column: "Program",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DrivingProgram",
                keyColumn: "ProgramID",
                keyValue: new Guid("a3ef3534-390f-4b6e-8de9-27c120194c11"),
                column: "Program",
                value: 0);

            migrationBuilder.Sql("DROP VIEW SchoolDetails");
        }
    }
}
