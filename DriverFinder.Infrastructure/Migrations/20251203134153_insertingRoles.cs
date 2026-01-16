using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class insertingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("476169a5-07fa-4b3d-b198-915d27c653bc"), "17c87a44-c66b-4e08-b1b1-6fba89f5796e", "Has full system access, manages all users, roles, permissions, and platform-wide settings.", "Admin", null },
                    { new Guid("504792c3-25e4-43e2-83f1-c675ac03157a"), "76c64fc6-b63a-401d-b32f-e0802244a2a4", "Manages their own driving school profile, updates school details, programs, pricing, schedules, and responds to student registrations.", "SchoolOwner", null },
                    { new Guid("67269ba7-333e-4c1d-babc-321f4faff837"), "fda88a67-9054-4628-8a49-8f70097c4b7b", "Manages content and user activity, approves schools, reviews reports, and enforces platform rules.", "Moderator", null },
                    { new Guid("c426fc74-b893-4e75-bbc9-2a4ffe7cb236"), "655015eb-f1a3-4e30-926c-aa1b7cde2a8f", "Regular user who can search for schools, view details, register for programs, and manage personal profile.", "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("476169a5-07fa-4b3d-b198-915d27c653bc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("504792c3-25e4-43e2-83f1-c675ac03157a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("67269ba7-333e-4c1d-babc-321f4faff837"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c426fc74-b893-4e75-bbc9-2a4ffe7cb236"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");
        }
    }
}
