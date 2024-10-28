using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class CustomReportInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtSavedCustomReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Schema = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Table = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtSavedCustomReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtReportsColumns",
                columns: table => new
                {
                    Column = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    JsType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNullable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtReportsColumns", x => new { x.ReportId, x.Column });
                    table.ForeignKey(
                        name: "FK_ArtReportsColumns_ArtSavedCustomReport_ReportId",
                        column: x => x.ReportId,
                        principalTable: "ArtSavedCustomReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtSavedReportsChart",
                columns: table => new
                {
                    Type = table.Column<int>(type: "int", nullable: false),
                    Column = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtSavedReportsChart", x => new { x.ReportId, x.Column, x.Type });
                    table.ForeignKey(
                        name: "FK_ArtSavedReportsChart_ArtSavedCustomReport_ReportId",
                        column: x => x.ReportId,
                        principalTable: "ArtSavedCustomReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtReportsColumns");

            migrationBuilder.DropTable(
                name: "ArtSavedReportsChart");

            migrationBuilder.DropTable(
                name: "ArtSavedCustomReport");
        }
    }
}
