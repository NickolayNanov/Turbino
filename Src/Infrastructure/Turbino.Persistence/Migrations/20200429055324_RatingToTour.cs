using Microsoft.EntityFrameworkCore.Migrations;

namespace Turbino.Persistence.Migrations
{
    public partial class RatingToTour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Tours",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Tours");
        }
    }
}
