using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobsBodyMetrics_BE.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRoleStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0889778b-0916-4e90-8bfa-8c3493fb3104");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1f628c4-a94f-4d0f-9166-379b775ce54d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7054f83d-edac-4754-8fee-a075509165eb", null, "Admin", "ADMIN" },
                    { "e21dc2fb-0376-4599-bb67-d68ed728ea43", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7054f83d-edac-4754-8fee-a075509165eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e21dc2fb-0376-4599-bb67-d68ed728ea43");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0889778b-0916-4e90-8bfa-8c3493fb3104", null, "Admin", "ADMIN" },
                    { "e1f628c4-a94f-4d0f-9166-379b775ce54d", null, "User", "USER" }
                });
        }
    }
}
