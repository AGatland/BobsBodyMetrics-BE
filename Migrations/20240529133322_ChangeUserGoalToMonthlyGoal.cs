using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobsBodyMetrics_BE.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserGoalToMonthlyGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGoals");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bb54e2d-f058-47f6-b118-5a03038d28e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8292aed-f17f-4362-b538-66f15c92e99e");

            migrationBuilder.CreateTable(
                name: "MonthlyGoals",
                columns: table => new
                {
                    MonthlyGoalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ActivityType = table.Column<int>(type: "integer", nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyGoals", x => x.MonthlyGoalId);
                    table.ForeignKey(
                        name: "FK_MonthlyGoals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b56d337-48c5-4b77-94ec-8764a2bf1a1d", null, "User", "USER" },
                    { "f4bf8ffe-e2af-4751-a6d3-f8ce0b4accd1", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyGoals_UserId",
                table: "MonthlyGoals",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyGoals");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b56d337-48c5-4b77-94ec-8764a2bf1a1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4bf8ffe-e2af-4751-a6d3-f8ce0b4accd1");

            migrationBuilder.CreateTable(
                name: "UserGoals",
                columns: table => new
                {
                    UserGoalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActivityType = table.Column<int>(type: "integer", nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGoals", x => x.UserGoalId);
                    table.ForeignKey(
                        name: "FK_UserGoals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7bb54e2d-f058-47f6-b118-5a03038d28e7", null, "User", "USER" },
                    { "c8292aed-f17f-4362-b538-66f15c92e99e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGoals_UserId",
                table: "UserGoals",
                column: "UserId");
        }
    }
}
