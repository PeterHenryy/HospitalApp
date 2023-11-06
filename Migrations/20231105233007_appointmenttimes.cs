using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalApp.Migrations
{
    public partial class appointmenttimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "BookedTime",
                table: "Appointments",
                newName: "AppointmentStartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentEndTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentEndTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentStartTime",
                table: "Appointments",
                newName: "BookedTime");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
