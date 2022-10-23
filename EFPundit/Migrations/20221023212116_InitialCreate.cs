using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFPundit.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClubColours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrimaryHex = table.Column<string>(type: "text", nullable: true),
                    SecondaryHex = table.Column<string>(type: "text", nullable: true),
                    TertiaryHex = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubColours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    CountryKey = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryKey = table.Column<int>(type: "integer", nullable: true),
                    LeagueKey = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leagues_Country_CountryKey",
                        column: x => x.CountryKey,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LeagueKey = table.Column<int>(type: "integer", nullable: true),
                    GameTypes = table.Column<int>(type: "integer", nullable: false),
                    ClubKey = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_ClubColours_Id",
                        column: x => x.Id,
                        principalTable: "ClubColours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Clubs_Leagues_LeagueKey",
                        column: x => x.LeagueKey,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryKey = table.Column<int>(type: "integer", nullable: true),
                    Dob = table.Column<string>(type: "text", nullable: true),
                    ClubKey = table.Column<int>(type: "integer", nullable: true),
                    Foot = table.Column<string>(type: "text", nullable: true),
                    PlayerKey = table.Column<Guid>(type: "uuid", nullable: false),
                    SeasonKey = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Clubs_ClubKey",
                        column: x => x.ClubKey,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Players_Country_CountryKey",
                        column: x => x.CountryKey,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerKey = table.Column<int>(type: "integer", nullable: true),
                    ClubKey = table.Column<int>(type: "integer", nullable: true),
                    GameTypes = table.Column<int>(type: "integer", nullable: false),
                    Goals = table.Column<int>(type: "integer", nullable: true),
                    Assists = table.Column<int>(type: "integer", nullable: true),
                    YellowCards = table.Column<int>(type: "integer", nullable: true),
                    RedCards = table.Column<int>(type: "integer", nullable: true),
                    Cleansheets = table.Column<int>(type: "integer", nullable: true),
                    MinutesPlayed = table.Column<int>(type: "integer", nullable: true),
                    Appearances = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Clubs_ClubKey",
                        column: x => x.ClubKey,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Players_PlayerKey",
                        column: x => x.PlayerKey,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Current = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_PlayerStats_Id",
                        column: x => x.Id,
                        principalTable: "PlayerStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_LeagueKey",
                table: "Clubs",
                column: "LeagueKey");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_CountryKey",
                table: "Leagues",
                column: "CountryKey");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ClubKey",
                table: "Players",
                column: "ClubKey");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CountryKey",
                table: "Players",
                column: "CountryKey");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_ClubKey",
                table: "PlayerStats",
                column: "ClubKey");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_PlayerKey",
                table: "PlayerStats",
                column: "PlayerKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "PlayerStats");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "ClubColours");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
