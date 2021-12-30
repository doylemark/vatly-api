using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vatly.Api.Migrations
{
    public partial class FixFlightPlanKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Arrival",
                table: "FlightPlans",
                newName: "Destination");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "FlightPlans",
                newName: "Arrival");
        }
    }
}
