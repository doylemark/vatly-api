using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vatly.Api.Migrations
{
    public partial class AddLogonTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogonTime",
                table: "Flights",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogonTime",
                table: "Flights");
        }
    }
}
