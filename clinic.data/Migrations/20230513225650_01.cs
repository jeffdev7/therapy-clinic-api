using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace clinic.data.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentTime", "DocumentNumber", "Email", "PatientName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "23112312332", "joe@outlook.com", "Joe", "13123123123" },
                    { 2, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "6969696332", "light@gmail.com", "Light", "16799843" },
                    { 3, new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "317762332", "cleo@live.com", "Cleo", "5567677676" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
