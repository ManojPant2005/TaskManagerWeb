using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TM.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddClassTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Quantum Mechanics" },
                    { 2, 1, "Thermodynamics" },
                    { 3, 2, "World History" },
                    { 4, 3, "Linear Algebra" },
                    { 5, 3, "Calculus" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBud0pL7zbxiEio8WcEgTfNiLbL/eOlTybiFAQI1zH0V9P7Vn4PXaTFX9QoEgnLZ8w==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMEThdurJXWclfBW0stGBYs8QDcFj1pkDlltphucVhu5W1meGqnp8y3VYoEp4gB2Qw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENX+JeU0G86rNyl0vK984fFWgMLjBEyjjcg4RKQoIIRC1hY5VyZNMOm7+/0+y2nsVg==");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_DepartmentId",
                table: "Classes",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

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
    }
}
