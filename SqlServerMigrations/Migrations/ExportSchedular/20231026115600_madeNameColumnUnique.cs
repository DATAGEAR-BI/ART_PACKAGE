﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations.ExportSchedular
{
    public partial class madeNameColumnUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExportsTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Never"),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Hour = table.Column<int>(type: "int", nullable: true),
                    Minute = table.Column<int>(type: "int", nullable: true),
                    IsMailed = table.Column<bool>(type: "bit", nullable: false),
                    IsSavedOnServer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportsTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskMails",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMails", x => new { x.TaskId, x.Mail });
                    table.ForeignKey(
                        name: "FK_TaskMails_ExportsTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "ExportsTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParameterValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskParameters_ExportsTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "ExportsTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportsTasks_Name",
                table: "ExportsTasks",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskParameters_TaskId",
                table: "TaskParameters",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskMails");

            migrationBuilder.DropTable(
                name: "TaskParameters");

            migrationBuilder.DropTable(
                name: "ExportsTasks");
        }
    }
}