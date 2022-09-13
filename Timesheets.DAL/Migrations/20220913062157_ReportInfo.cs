using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheets.DAL.Migrations
{
    public partial class ReportInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportsInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDawnloaded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartOfWorkDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfWorkDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReportInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportDto_ReportsInfo_ReportInfoId",
                        column: x => x.ReportInfoId,
                        principalTable: "ReportsInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportDto_ReportInfoId",
                table: "ReportDto",
                column: "ReportInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportDto");

            migrationBuilder.DropTable(
                name: "ReportsInfo");
        }
    }
}
