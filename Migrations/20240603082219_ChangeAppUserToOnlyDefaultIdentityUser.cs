using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobsBodyMetrics_BE.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAppUserToOnlyDefaultIdentityUser : Migration
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
                    { "51158288-cf58-4c29-92b0-8644cabe3e85", null, "User", "USER" },
                    { "a93a3937-b6c7-40ce-a28d-ea5c789fef12", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51158288-cf58-4c29-92b0-8644cabe3e85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a93a3937-b6c7-40ce-a28d-ea5c789fef12");

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
