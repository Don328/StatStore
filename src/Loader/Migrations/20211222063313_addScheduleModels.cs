using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatStore.Loader.Migrations
{
    public partial class addScheduleModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnnualRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DayOfMonth = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Tag = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExecuteAt = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Team = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    Week = table.Column<int>(type: "int", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Minutes = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualRequests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DailyRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tag = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExecuteAt = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Team = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    Week = table.Column<int>(type: "int", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Minutes = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyRequests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MonthlyRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DayOfMonth = table.Column<int>(type: "int", nullable: true),
                    Tag = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExecuteAt = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Team = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    Week = table.Column<int>(type: "int", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Minutes = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyRequests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OneoffRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DayOfMonth = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Frequency = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    Durration = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    Tag = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExecuteAt = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Team = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    Week = table.Column<int>(type: "int", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Minutes = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneoffRequests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QueuedRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ScheduledAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Tag = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExecuteAt = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Team = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    Week = table.Column<int>(type: "int", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Minutes = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueuedRequests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeeklyRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Frequency = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    Durration = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    Tag = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExecuteAt = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Team = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    Week = table.Column<int>(type: "int", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Minutes = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyRequests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AnnualRequests",
                columns: new[] { "Id", "Date", "DayOfMonth", "ExecuteAt", "Minutes", "Month", "Season", "Tag", "TargetId", "Team", "Week" },
                values: new object[] { 1, null, 1, new TimeSpan(0, 3, 0, 0, 0), null, 7, null, "Timeframes", null, null, null });

            migrationBuilder.InsertData(
                table: "DailyRequests",
                columns: new[] { "Id", "Date", "ExecuteAt", "Minutes", "Season", "Tag", "TargetId", "Team", "Week" },
                values: new object[] { 2, null, new TimeSpan(0, 2, 0, 1, 0), null, null, "Schedules", null, null, null });

            migrationBuilder.InsertData(
                table: "WeeklyRequests",
                columns: new[] { "Id", "Date", "Day", "Discriminator", "ExecuteAt", "Minutes", "Season", "Tag", "TargetId", "Team", "Week" },
                values: new object[,]
                {
                    { 1, null, 4, "Weekly", new TimeSpan(0, 22, 0, 0, 0), null, null, "ScoresByWeek", null, null, null },
                    { 2, null, 5, "Weekly", new TimeSpan(0, 8, 0, 0, 0), null, null, "ScoresByWeek", null, null, null },
                    { 3, null, 0, "Weekly", new TimeSpan(0, 14, 0, 0, 0), null, null, "ScoresByWeek", null, null, null },
                    { 4, null, 0, "Weekly", new TimeSpan(0, 17, 0, 0, 0), null, null, "ScoresByWeek", null, null, null },
                    { 5, null, 0, "Weekly", new TimeSpan(0, 22, 0, 0, 0), null, null, "ScoresByWeek", null, null, null },
                    { 6, null, 1, "Weekly", new TimeSpan(0, 8, 0, 0, 0), null, null, "ScoresByWeek", null, null, null },
                    { 7, null, 1, "Weekly", new TimeSpan(0, 22, 0, 0, 0), null, null, "ScoresByWeek", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "WeeklyRequests",
                columns: new[] { "Id", "Date", "Day", "Discriminator", "Durration", "ExecuteAt", "Frequency", "Minutes", "Season", "Tag", "TargetId", "Team", "Week" },
                values: new object[,]
                {
                    { 8, null, 4, "WeeklySpan", new TimeSpan(0, 3, 0, 0, 0), new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 0, 10, 0, 0), null, null, "ScoresByWeek", null, null, null },
                    { 9, null, 0, "WeeklySpan", new TimeSpan(0, 6, 30, 0, 0), new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 0, 10, 0, 0), null, null, "ScoresByWeek", null, null, null },
                    { 10, null, 0, "WeeklySpan", new TimeSpan(0, 3, 0, 0, 0), new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 0, 10, 0, 0), null, null, "ScoresByWeek", null, null, null },
                    { 11, null, 1, "WeeklySpan", new TimeSpan(0, 3, 0, 0, 0), new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 0, 10, 0, 0), null, null, "ScoresByWeek", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnualRequests_ExecuteAt",
                table: "AnnualRequests",
                column: "ExecuteAt");

            migrationBuilder.CreateIndex(
                name: "IX_DailyRequests_ExecuteAt",
                table: "DailyRequests",
                column: "ExecuteAt");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyRequests_DayOfMonth",
                table: "MonthlyRequests",
                column: "DayOfMonth");

            migrationBuilder.CreateIndex(
                name: "IX_QueuedRequests_ExecuteAt",
                table: "QueuedRequests",
                column: "ExecuteAt");

            migrationBuilder.CreateIndex(
                name: "IX_QueuedRequests_IsCompleted",
                table: "QueuedRequests",
                column: "IsCompleted");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyRequests_Day",
                table: "WeeklyRequests",
                column: "Day");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnualRequests");

            migrationBuilder.DropTable(
                name: "DailyRequests");

            migrationBuilder.DropTable(
                name: "MonthlyRequests");

            migrationBuilder.DropTable(
                name: "OneoffRequests");

            migrationBuilder.DropTable(
                name: "QueuedRequests");

            migrationBuilder.DropTable(
                name: "WeeklyRequests");
        }
    }
}
