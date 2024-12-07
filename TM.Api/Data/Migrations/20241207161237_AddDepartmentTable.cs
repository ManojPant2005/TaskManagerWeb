using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKeJWRlpOkv4jRIdVW84j3Hkc1uWdF7kWVLaihou5J4BiG4yZSbfjEG3Qt8UW2oODg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA9zqMZ3BdQLzL0iJm6OsnWF7mXiTGg245GPIG5WvIcYdhMqJpax2u2s2hh6LaqI3Q==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEFF2wkkfSaH2oJTG5X6bmrXZjqGnNI8wBpi+ka6/VfQBpfNNoieu+MTX1+RWRoIyA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEF0QXFy+JV1ZlBXeNB6/8m/Dd4xf3NOPZBmIhMSNC1v9V+vsiPztqJ4mxQOuE2HE6A==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEDYOoVvwf45HR/H+C85nXNfBlQdsqtY0MQf52HXr1YUkoeJu611VPKELzHipmBkqg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENDV/KgoRm25OQWZejYtOithYs4f47xV1PSXmCXrNvNrUrxPx47rec3SL6Bpmj0vGw==");
        }
    }
}
