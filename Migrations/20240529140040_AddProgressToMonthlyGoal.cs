using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobsBodyMetrics_BE.Migrations
{
    /// <inheritdoc />
    public partial class AddProgressToMonthlyGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b56d337-48c5-4b77-94ec-8764a2bf1a1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4bf8ffe-e2af-4751-a6d3-f8ce0b4accd1");

            migrationBuilder.AddColumn<double>(
                name: "Progress",
                table: "MonthlyGoals",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c55b945-12fe-472c-af63-d202cb508cee", null, "Admin", "ADMIN" },
                    { "c5b700a8-7a7b-4878-b6bb-4185d590a760", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c55b945-12fe-472c-af63-d202cb508cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5b700a8-7a7b-4878-b6bb-4185d590a760");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "MonthlyGoals");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b56d337-48c5-4b77-94ec-8764a2bf1a1d", null, "User", "USER" },
                    { "f4bf8ffe-e2af-4751-a6d3-f8ce0b4accd1", null, "Admin", "ADMIN" }
                });
        }
    }
}
