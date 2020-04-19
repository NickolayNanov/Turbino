using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turbino.Persistence.Migrations
{
    public partial class Tour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Tours");

            migrationBuilder.AlterColumn<string>(
                name: "Included",
                table: "Tours",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Accommodation",
                table: "Tours",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dates",
                table: "Tours",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Departure",
                table: "Tours",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tours",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Tours",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tours",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NextDeparture",
                table: "Tours",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotIncluded",
                table: "Tours",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerPerson",
                table: "Tours",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accommodation",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Departure",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "NextDeparture",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "NotIncluded",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "PricePerPerson",
                table: "Tours");

            migrationBuilder.AlterColumn<int>(
                name: "Included",
                table: "Tours",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Tours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tours",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "Tours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
