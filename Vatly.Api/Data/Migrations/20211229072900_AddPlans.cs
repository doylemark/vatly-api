using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vatly.Api.Migrations
{
    public partial class AddPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlan_Airports_ArrivalId",
                table: "FlightPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlan_Airports_OriginId",
                table: "FlightPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlan_Flights_FlightId",
                table: "FlightPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPlan",
                table: "FlightPlan");

            migrationBuilder.RenameTable(
                name: "FlightPlan",
                newName: "FlightPlans");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPlan_OriginId",
                table: "FlightPlans",
                newName: "IX_FlightPlans_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPlan_FlightId",
                table: "FlightPlans",
                newName: "IX_FlightPlans_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPlan_ArrivalId",
                table: "FlightPlans",
                newName: "IX_FlightPlans_ArrivalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPlans",
                table: "FlightPlans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPlans_Airports_ArrivalId",
                table: "FlightPlans",
                column: "ArrivalId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPlans_Airports_OriginId",
                table: "FlightPlans",
                column: "OriginId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPlans_Flights_FlightId",
                table: "FlightPlans",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlans_Airports_ArrivalId",
                table: "FlightPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlans_Airports_OriginId",
                table: "FlightPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlans_Flights_FlightId",
                table: "FlightPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPlans",
                table: "FlightPlans");

            migrationBuilder.RenameTable(
                name: "FlightPlans",
                newName: "FlightPlan");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPlans_OriginId",
                table: "FlightPlan",
                newName: "IX_FlightPlan_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPlans_FlightId",
                table: "FlightPlan",
                newName: "IX_FlightPlan_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPlans_ArrivalId",
                table: "FlightPlan",
                newName: "IX_FlightPlan_ArrivalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPlan",
                table: "FlightPlan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPlan_Airports_ArrivalId",
                table: "FlightPlan",
                column: "ArrivalId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPlan_Airports_OriginId",
                table: "FlightPlan",
                column: "OriginId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPlan_Flights_FlightId",
                table: "FlightPlan",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
