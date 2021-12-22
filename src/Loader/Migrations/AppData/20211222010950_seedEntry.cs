using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatStore.Loader.Migrations.AppData
{
    public partial class seedEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestModels");

            migrationBuilder.InsertData(
                table: "CurrentTimeFrame",
                columns: new[] { "Id", "ApiSeason", "ApiWeek", "EndDate", "FirstGameEnd", "FirstGameStart", "HasEnded", "HasFirstGameEnded", "HasFirstGameStarted", "HasGames", "HasLastGameEnded", "HasStarted", "LastGameEnd", "Name", "Season", "SeasonType", "ShortName", "StartDate", "Week" },
                values: new object[] { 1, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CurrentTimeFrame",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "TestModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TestModels",
                columns: new[] { "Id", "Name" },
                values: new object[] { -1, "Test Model" });
        }
    }
}
