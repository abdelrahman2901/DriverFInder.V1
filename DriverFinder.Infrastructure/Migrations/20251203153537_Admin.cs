using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonName", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpirationDateTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"), 0, "2ca3d817-3452-4c26-9fac-739f7b9b9658", "Admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", null, "AQAAAAIAAYagAAAAEJp7OyBKEW8TTc+vsExyXFcG9HNqWEhjapi1LEAGpsxxz/za5dFQU3LsTj2aQPZ8Rw==", "Admin", null, false, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("476169a5-07fa-4b3d-b198-915d27c653bc"), new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("476169a5-07fa-4b3d-b198-915d27c653bc"), new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"));
        }
    }
}
