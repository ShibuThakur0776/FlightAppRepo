using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightTicketApp.Migrations
{
    public partial class addColumnAirportType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Airport_Type",
                table: "Airports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Airport_Type",
                table: "Airports");
        }
    }
}
