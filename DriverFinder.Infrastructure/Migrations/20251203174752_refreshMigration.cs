using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refreshMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonName", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpirationDateTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"), 0, "25eca292-d333-4f89-8ea2-33fcc78ef46d", "Admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMQZac9oNP26RhKbjajhqTAjCGwj1BUZp97HUk8LLqyrqkyDMDP7oFCOCxPUV+CjJw==", "Admin", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12a9ffc5-580d-425e-a29e-0b1983480f10", false, "Admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("476169a5-07fa-4b3d-b198-915d27c653bc"), new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50") });
        }
    }
}
