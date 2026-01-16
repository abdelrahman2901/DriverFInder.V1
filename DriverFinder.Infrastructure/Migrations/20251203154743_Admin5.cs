using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Admin5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshTokenExpirationDateTime" },
                values: new object[] { "e0ef9ad0-5ef6-42c8-a5e9-2153b525ef37", "AQAAAAIAAYagAAAAEMCqSUiSGTnpUBrHdiroV0lNRuIy5LC5lepMYefDKvhLBRVqiYce1dvmYc+QUfHjtQ==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshTokenExpirationDateTime" },
                values: new object[] { "4e1d583a-18d4-492b-8aa9-077257c0a3e9", "AQAAAAIAAYagAAAAEP83XiF3ctBglNCgAAqwiP+aYWJH10PbNU5WiVk9tB+EzGuTCImIAJR37F8Cg4tLjA==", new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
