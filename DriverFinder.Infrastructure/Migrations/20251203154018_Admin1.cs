using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Admin1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshTokenExpirationDateTime" },
                values: new object[] { "3ecc9ca1-169a-4c51-a9f6-b94856f49205", "AQAAAAIAAYagAAAAENLc8u7cnRu8SALgkrFRGyIcJzTvC24gfUA1Mdo1LpqjNXrm/qRhS1rjiXaCFTRR8w==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshTokenExpirationDateTime" },
                values: new object[] { "2ca3d817-3452-4c26-9fac-739f7b9b9658", "AQAAAAIAAYagAAAAEJp7OyBKEW8TTc+vsExyXFcG9HNqWEhjapi1LEAGpsxxz/za5dFQU3LsTj2aQPZ8Rw==", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
