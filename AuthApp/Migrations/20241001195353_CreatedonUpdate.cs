using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuthApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedonUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c303275-3f88-4dab-b4dd-e39f2b53b61c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c970864-b4c3-45cf-9cd3-6905523bbe1f");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Enquiry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ba56b20a-4597-490c-b08d-c9fbff338a04", null, "User", "USER" },
                    { "dd456d7c-e10f-4ed5-b0d8-c6b5b0b85a37", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba56b20a-4597-490c-b08d-c9fbff338a04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd456d7c-e10f-4ed5-b0d8-c6b5b0b85a37");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Enquiry");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c303275-3f88-4dab-b4dd-e39f2b53b61c", null, "Admin", "ADMIN" },
                    { "9c970864-b4c3-45cf-9cd3-6905523bbe1f", null, "User", "USER" }
                });
        }
    }
}
