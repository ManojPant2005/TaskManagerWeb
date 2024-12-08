using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TM.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class RecreateDepartment : Migration
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccessCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "AccessCode", "Name", "Subject" },
                values: new object[,]
                {
                    { 1, "PHY123", "Physics Dept", "Physics" },
                    { 2, "HIS123", "History Dept", "History" },
                    { 3, "MTH123", "Maths Dept", "Maths" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKhLuoL79I/4lQIz+W3Jx+wepB/poTxihlOcD9MFg0d5uf+wqPsbUlrN8UPJC8Fyvg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIaTBKjdxH//H2aJNoPubiECMc2qml3Q3uEhl/gn9xiXb16k7EFWYcwmioqrNZLEpA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIKQ7SXZXEYFiJbOAFb+Jma6nh7TyoFOj0ZG6FxYsLcCvA5Z4bWRs9kB0sGSs5mPVw==");
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
