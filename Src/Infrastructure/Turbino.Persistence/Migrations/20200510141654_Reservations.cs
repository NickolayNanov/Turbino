using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turbino.Persistence.Migrations
{
    public partial class Reservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfLeaving",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Reservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfLeaving",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Reservations");
        }
    }
}
