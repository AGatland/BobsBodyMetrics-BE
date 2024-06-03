using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobsBodyMetrics_BE.Migrations
{
    /// <inheritdoc />
    public partial class AddBgImgToProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47e9341f-ab36-4cff-8614-78ca4a4d3532");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfe3a4d1-d254-4e39-8e9a-331da6c22ab2");

            migrationBuilder.AddColumn<string>(
                name: "BgImg",
                table: "Profiles",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0889778b-0916-4e90-8bfa-8c3493fb3104", null, "Admin", "ADMIN" },
                    { "e1f628c4-a94f-4d0f-9166-379b775ce54d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0889778b-0916-4e90-8bfa-8c3493fb3104");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1f628c4-a94f-4d0f-9166-379b775ce54d");

            migrationBuilder.DropColumn(
                name: "BgImg",
                table: "Profiles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47e9341f-ab36-4cff-8614-78ca4a4d3532", null, "Admin", "ADMIN" },
                    { "dfe3a4d1-d254-4e39-8e9a-331da6c22ab2", null, "User", "USER" }
                });
        }
    }
}
