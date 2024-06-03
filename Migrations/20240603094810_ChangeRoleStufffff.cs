using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobsBodyMetrics_BE.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRoleStufffff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "4008736d-8f3a-4903-b052-61b8a45fe971", null, "Admin", "ADMIN" },
                    { "b8781acb-1abb-40d4-a0b2-fa210a308cff", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4008736d-8f3a-4903-b052-61b8a45fe971");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8781acb-1abb-40d4-a0b2-fa210a308cff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7054f83d-edac-4754-8fee-a075509165eb", null, "Admin", "ADMIN" },
                    { "e21dc2fb-0376-4599-bb67-d68ed728ea43", null, "User", "USER" }
                });
        }
    }
}
