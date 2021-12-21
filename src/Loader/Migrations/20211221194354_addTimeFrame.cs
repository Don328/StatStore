using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatStore.Loader.Migrations
{
    public partial class addTimeFrame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentTimeFrame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SeasonType = table.Column<int>(type: "int", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Week = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FirstGameStart = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FirstGameEnd = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastGameEnd = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    HasGames = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    HasStarted = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    HasEnded = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    HasFirstGameStarted = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    HasFirstGameEnded = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    HasLastGameEnded = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ApiSeason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApiWeek = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTimeFrame", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentTimeFrame");
        }
    }
}
