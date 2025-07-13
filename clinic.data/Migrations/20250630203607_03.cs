using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace clinic.data.Migrations
{
    /// <inheritdoc />
    public partial class _03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppointmentsVacancies",
                keyColumn: "Id",
                keyValue: new Guid("e10a4b7e-f9ce-40f4-904c-6945b9e8e3b3"));

            migrationBuilder.DeleteData(
                table: "RequestedAppointments",
                keyColumn: "Id",
                keyValue: new Guid("cc81cd5f-6dfd-441d-be98-eec440f733f8"));

            migrationBuilder.DeleteData(
                table: "RequestedAppointments",
                keyColumn: "Id",
                keyValue: new Guid("ddfc1c8a-b2cb-4d4d-897c-d3ee19b57799"));

            migrationBuilder.DropColumn(
                name: "RequestedTime",
                table: "RequestedAppointments");

            migrationBuilder.AddColumn<Guid>(
                name: "RequestedTimeId",
                table: "RequestedAppointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                table: "RequestedAppointments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlots_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestedAppointments_RequestedTimeId",
                table: "RequestedAppointments",
                column: "RequestedTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedAppointments_ScheduleId",
                table: "RequestedAppointments",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_ScheduleId",
                table: "TimeSlots",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestedAppointments_Schedules_ScheduleId",
                table: "RequestedAppointments",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestedAppointments_TimeSlots_RequestedTimeId",
                table: "RequestedAppointments",
                column: "RequestedTimeId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestedAppointments_Schedules_ScheduleId",
                table: "RequestedAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestedAppointments_TimeSlots_RequestedTimeId",
                table: "RequestedAppointments");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_RequestedAppointments_RequestedTimeId",
                table: "RequestedAppointments");

            migrationBuilder.DropIndex(
                name: "IX_RequestedAppointments_ScheduleId",
                table: "RequestedAppointments");

            migrationBuilder.DropColumn(
                name: "RequestedTimeId",
                table: "RequestedAppointments");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "RequestedAppointments");

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedTime",
                table: "RequestedAppointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AppointmentsVacancies",
                columns: new[] { "Id", "AppointmentTime", "CreatedAt", "UpdatedAt" },
                values: new object[] { new Guid("e10a4b7e-f9ce-40f4-904c-6945b9e8e3b3"), "[\"2023-05-06T12:30:00\",\"2023-05-05T15:00:00\",\"2023-05-10T15:45:00\"]", new DateTime(2025, 6, 27, 1, 16, 53, 176, DateTimeKind.Utc).AddTicks(9168), new DateTime(2025, 6, 27, 1, 16, 53, 176, DateTimeKind.Utc).AddTicks(9168) });

            migrationBuilder.InsertData(
                table: "RequestedAppointments",
                columns: new[] { "Id", "ClientName", "CreatedAt", "DocumentNumber", "Email", "Phone", "RequestedTime", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("cc81cd5f-6dfd-441d-be98-eec440f733f8"), "Cleo", new DateTime(2025, 6, 27, 1, 16, 53, 176, DateTimeKind.Utc).AddTicks(9144), "317762332", "cleo@live.com", "5567677676", new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 27, 1, 16, 53, 176, DateTimeKind.Utc).AddTicks(9144) },
                    { new Guid("ddfc1c8a-b2cb-4d4d-897c-d3ee19b57799"), "Joe", new DateTime(2025, 6, 27, 1, 16, 53, 176, DateTimeKind.Utc).AddTicks(9100), "23112312332", "joe@outlook.com", "13123123123", new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 27, 1, 16, 53, 176, DateTimeKind.Utc).AddTicks(9102) }
                });
        }
    }
}
