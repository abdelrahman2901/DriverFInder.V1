using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Admin3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3672901-3296-4bf2-a652-e367bfe28c9f", "AQAAAAIAAYagAAAAEBO6R+cO5Hbi9Y93DmYvgHRzS90tlK9HLC0Vdk4K4tPyk9Eo4jlFIKttvcpAu3pxzA==", "12a9ffc5-580d-425e-a29e-0b1983480f10" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "042b98ec-c349-4aa9-8371-5b678a39ab9d", "AQAAAAIAAYagAAAAEBdVXh60KOP+sPm+EtsS49A0BPAwN71Yx/Z7Fei3PHduYKWZccvvjn6Jdk9ey54xDA==", "4c486df1-005f-4eec-a8cc-98ed68db3425" });
        }
    }
}
