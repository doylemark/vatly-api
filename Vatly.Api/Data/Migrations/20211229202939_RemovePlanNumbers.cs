using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vatly.Api.Migrations
{
    public partial class RemovePlanNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Speed",
                table: "FlightPlans",
                type: "text",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "Altitude",
                table: "FlightPlans",
                type: "text",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Speed",
                table: "FlightPlans",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<double>(
                name: "Altitude",
                table: "FlightPlans",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
