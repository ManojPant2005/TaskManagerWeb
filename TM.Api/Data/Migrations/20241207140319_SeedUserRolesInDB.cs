using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TM.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRolesInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEF0QXFy+JV1ZlBXeNB6/8m/Dd4xf3NOPZBmIhMSNC1v9V+vsiPztqJ4mxQOuE2HE6A==");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsApproved", "Name", "PasswordHash", "Phone", "Role" },
                values: new object[,]
                {
                    { 2, "manager@email.com", true, "University Manager", "AQAAAAIAAYagAAAAEEDYOoVvwf45HR/H+C85nXNfBlQdsqtY0MQf52HXr1YUkoeJu611VPKELzHipmBkqg==", "0987654321", "Manager" },
                    { 3, "department@email.com", true, "Department Head", "AQAAAAIAAYagAAAAENDV/KgoRm25OQWZejYtOithYs4f47xV1PSXmCXrNvNrUrxPx47rec3SL6Bpmj0vGw==", "1122334455", "Department" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGPUeBbYOlptU284wGVp77AmCM6cuB5hgyLSKBLFQBmM8HOrSOok+ThOXKkxhi36iw==");
        }
    }
}
