using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vatly.Api.Migrations
{
    public partial class AddControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AircraftType",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Alternate",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "CruiseSpeed",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DestinationIcao",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "OriginIcao",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PlannedAltitude",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Route",
                table: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "Cid",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Server",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Transponder",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Controllers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cid = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Callsign = table.Column<string>(type: "text", nullable: false),
                    Frequency = table.Column<string>(type: "text", nullable: false),
                    Facility = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Server = table.Column<string>(type: "text", nullable: false),
                    VisualRange = table.Column<int>(type: "integer", nullable: false),
                    LogonTime = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controllers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FlightId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rules = table.Column<string>(type: "text", nullable: false),
                    Aircraft = table.Column<string>(type: "text", nullable: false),
                    OriginId = table.Column<Guid>(type: "uuid", nullable: true),
                    ArrivalId = table.Column<Guid>(type: "uuid", nullable: true),
                    Speed = table.Column<double>(type: "double precision", nullable: false),
                    Altitude = table.Column<double>(type: "double precision", nullable: false),
                    DepartureTime = table.Column<string>(type: "text", nullable: false),
                    EnrouteTime = table.Column<string>(type: "text", nullable: false),
                    FuelTime = table.Column<string>(type: "text", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    Route = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightPlan_Airports_ArrivalId",
                        column: x => x.ArrivalId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightPlan_Airports_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightPlan_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_ArrivalId",
                table: "FlightPlan",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_FlightId",
                table: "FlightPlan",
                column: "FlightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_OriginId",
                table: "FlightPlan",
                column: "OriginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Controllers");

            migrationBuilder.DropTable(
                name: "FlightPlan");

            migrationBuilder.DropColumn(
                name: "Cid",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Server",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Transponder",
                table: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "AircraftType",
                table: "Flights",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alternate",
                table: "Flights",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CruiseSpeed",
                table: "Flights",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DestinationIcao",
                table: "Flights",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginIcao",
                table: "Flights",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PlannedAltitude",
                table: "Flights",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Route",
                table: "Flights",
                type: "text",
                nullable: true);
        }
    }
}
