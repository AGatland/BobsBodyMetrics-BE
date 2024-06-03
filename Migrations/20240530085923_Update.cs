using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobsBodyMetrics_BE.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "47e9341f-ab36-4cff-8614-78ca4a4d3532", null, "Admin", "ADMIN" },
                    { "dfe3a4d1-d254-4e39-8e9a-331da6c22ab2", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47e9341f-ab36-4cff-8614-78ca4a4d3532");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfe3a4d1-d254-4e39-8e9a-331da6c22ab2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c32b4dd5-eb98-42c4-a75e-d7e4357d3d93", null, "User", "USER" },
                    { "e2498069-b446-4b20-8f8c-b3b375c70687", null, "Admin", "ADMIN" }
                });
        }
    }
}
