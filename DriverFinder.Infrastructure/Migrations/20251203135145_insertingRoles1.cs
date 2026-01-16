using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class insertingRoles1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("476169a5-07fa-4b3d-b198-915d27c653bc"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "164BA083-FF58-4773-B3F4-571FAC01D282", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("504792c3-25e4-43e2-83f1-c675ac03157a"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "273C9409-150E-49FC-BB58-2252A0E43E3A", "SCHOOLOWNER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("67269ba7-333e-4c1d-babc-321f4faff837"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "0B34AF6C-0D1D-49B6-BA72-2B78B68DCB2F", "MODERATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c426fc74-b893-4e75-bbc9-2a4ffe7cb236"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "AA09F9AC-354A-492E-AE38-5DFB794EA027", "USER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("476169a5-07fa-4b3d-b198-915d27c653bc"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "17c87a44-c66b-4e08-b1b1-6fba89f5796e", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("504792c3-25e4-43e2-83f1-c675ac03157a"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "76c64fc6-b63a-401d-b32f-e0802244a2a4", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("67269ba7-333e-4c1d-babc-321f4faff837"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "fda88a67-9054-4628-8a49-8f70097c4b7b", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c426fc74-b893-4e75-bbc9-2a4ffe7cb236"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "655015eb-f1a3-4e30-926c-aa1b7cde2a8f", null });
        }
    }
}
