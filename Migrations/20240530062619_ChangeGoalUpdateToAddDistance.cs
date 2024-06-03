using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobsBodyMetrics_BE.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGoalUpdateToAddDistance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c55b945-12fe-472c-af63-d202cb508cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5b700a8-7a7b-4878-b6bb-4185d590a760");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c32b4dd5-eb98-42c4-a75e-d7e4357d3d93", null, "User", "USER" },
                    { "e2498069-b446-4b20-8f8c-b3b375c70687", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c32b4dd5-eb98-42c4-a75e-d7e4357d3d93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2498069-b446-4b20-8f8c-b3b375c70687");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c55b945-12fe-472c-af63-d202cb508cee", null, "Admin", "ADMIN" },
                    { "c5b700a8-7a7b-4878-b6bb-4185d590a760", null, "User", "USER" }
                });
        }
    }
}
