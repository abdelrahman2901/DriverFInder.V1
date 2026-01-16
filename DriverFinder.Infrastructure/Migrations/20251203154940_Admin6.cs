using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Admin6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "25eca292-d333-4f89-8ea2-33fcc78ef46d", "AQAAAAIAAYagAAAAEMQZac9oNP26RhKbjajhqTAjCGwj1BUZp97HUk8LLqyrqkyDMDP7oFCOCxPUV+CjJw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e0ef9ad0-5ef6-42c8-a5e9-2153b525ef37", "AQAAAAIAAYagAAAAEMCqSUiSGTnpUBrHdiroV0lNRuIy5LC5lepMYefDKvhLBRVqiYce1dvmYc+QUfHjtQ==" });
        }
    }
}
