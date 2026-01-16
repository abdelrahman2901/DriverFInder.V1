using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class schoolprogramsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SchoolPrograms",
                keyColumn: "SchoolProgramID",
                keyValue: new Guid("6c7b0bfb-9629-4225-af93-f0f0da1a9f5a"));

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SchoolPrograms",
                columns: new[] { "SchoolProgramID", "DurationInWeeks", "IsActive", "NumberOfSessions", "NumberOfSessionsPerWeek", "Price", "ProgramID", "ProgramTypeID", "SchoolID", "SessionDuration", "vehicleModel", "vehicleType" },
                values: new object[] { new Guid("6c7b0bfb-9629-4225-af93-f0f0da1a9f5a"), (short)4, true, (short)12, (short)3, 3500m, new Guid("08c869a0-8d74-4693-ad0a-9a8197bd3643"), null, new Guid("0796e164-0a6c-4493-8f52-9d6fc2200322"), (short)60, "S1000 RR", "BMW" });

            
        }
    }
}
