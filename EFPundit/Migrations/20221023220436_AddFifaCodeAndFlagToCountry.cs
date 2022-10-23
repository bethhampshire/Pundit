using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFPundit.Migrations
{
    public partial class AddFifaCodeAndFlagToCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FifaCode",
                table: "Country",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlagImage",
                table: "Country",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FifaCode",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "FlagImage",
                table: "Country");
        }
    }
}
