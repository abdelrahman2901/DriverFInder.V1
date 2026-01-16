using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Admin2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "RefreshTokenExpirationDateTime", "SecurityStamp", "UserName" },
                values: new object[] { "042b98ec-c349-4aa9-8371-5b678a39ab9d", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBdVXh60KOP+sPm+EtsS49A0BPAwN71Yx/Z7Fei3PHduYKWZccvvjn6Jdk9ey54xDA==", new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4c486df1-005f-4eec-a8cc-98ed68db3425", "Admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a3659c40-1490-40b3-8ccf-7bdd354ffb50"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "RefreshTokenExpirationDateTime", "SecurityStamp", "UserName" },
                values: new object[] { "3ecc9ca1-169a-4c51-a9f6-b94856f49205", null, "AQAAAAIAAYagAAAAENLc8u7cnRu8SALgkrFRGyIcJzTvC24gfUA1Mdo1LpqjNXrm/qRhS1rjiXaCFTRR8w==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null });
        }
    }
}
