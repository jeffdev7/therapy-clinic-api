using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinic.data.Migrations
{
    /// <inheritdoc />
    public partial class _04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestedAppointments_Schedules_ScheduleId",
                table: "RequestedAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Schedules_ScheduleId",
                table: "TimeSlots");

            migrationBuilder.DropTable(
                name: "AppointmentsVacancies");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_ScheduleId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_RequestedAppointments_ScheduleId",
                table: "RequestedAppointments");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "RequestedAppointments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "RequestedAppointments");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "RequestedAppointments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                table: "TimeSlots",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "RequestedAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "RequestedAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                table: "RequestedAppointments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppointmentsVacancies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentsVacancies", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_ScheduleId",
                table: "TimeSlots",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedAppointments_ScheduleId",
                table: "RequestedAppointments",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestedAppointments_Schedules_ScheduleId",
                table: "RequestedAppointments",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Schedules_ScheduleId",
                table: "TimeSlots",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");
        }
    }
}
