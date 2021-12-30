using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vatly.Api.Migrations
{
    public partial class RemovePlanAirports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlans_Airports_ArrivalId",
                table: "FlightPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPlans_Airports_OriginId",
                table: "FlightPlans");

            migrationBuilder.DropIndex(
                name: "IX_FlightPlans_ArrivalId",
                table: "FlightPlans");

            migrationBuilder.DropIndex(
                name: "IX_FlightPlans_OriginId",
                table: "FlightPlans");

            migrationBuilder.DropColumn(
                name: "ArrivalId",
                table: "FlightPlans");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "FlightPlans");

            migrationBuilder.AddColumn<string>(
                name: "Arrival",
                table: "FlightPlans",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "FlightPlans",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arrival",
                table: "FlightPlans");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "FlightPlans");

            migrationBuilder.AddColumn<Guid>(
                name: "ArrivalId",
                table: "FlightPlans",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OriginId",
                table: "FlightPlans",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlans_ArrivalId",
                table: "FlightPlans",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlans_OriginId",
                table: "FlightPlans",
                column: "OriginId");

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
        }
    }
}
