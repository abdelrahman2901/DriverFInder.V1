using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Admin4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e1d583a-18d4-492b-8aa9-077257c0a3e9", "AQAAAAIAAYagAAAAEP83XiF3ctBglNCgAAqwiP+aYWJH10PbNU5WiVk9tB+EzGuTCImIAJR37F8Cg4tLjA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3672901-3296-4bf2-a652-e367bfe28c9f", "AQAAAAIAAYagAAAAEBO6R+cO5Hbi9Y93DmYvgHRzS90tlK9HLC0Vdk4K4tPyk9Eo4jlFIKttvcpAu3pxzA==" });
        }
    }
}
