using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vatly.Api.Migrations
{
    public partial class CreateMetarsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RawText = table.Column<string>(type: "text", nullable: false),
                    Icao = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    DewPoint = table.Column<double>(type: "double precision", nullable: false),
                    WindDirection = table.Column<int>(type: "integer", nullable: false),
                    WindSpeed = table.Column<int>(type: "integer", nullable: false),
                    Pressure = table.Column<double>(type: "double precision", nullable: false),
                    WindGust = table.Column<double>(type: "double precision", nullable: true),
                    Visibility = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metars");
        }
    }
}
