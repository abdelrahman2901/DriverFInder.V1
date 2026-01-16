using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriverFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolRating = table.Column<short>(type: "smallint", nullable: false),
                    InstructorRating = table.Column<short>(type: "smallint", nullable: false),
                    SchoolReviewDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructorReviewDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    helpFullReviewCount = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Review_DrivingInstructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "DrivingInstructors",
                        principalColumn: "InstructorID");
                    table.ForeignKey(
                        name: "FK_Review_DrivingSchools_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "DrivingSchools",
                        principalColumn: "SchoolID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_InstructorID",
                table: "Review",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_SchoolID",
                table: "Review",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserID",
                table: "Review",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
