using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.ExportSchedular
{
    public partial class addexcutionDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastExceutionDate",
                table: "ExportsTasks",
                type: "TIMESTAMP(7)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextExceutionDate",
                table: "ExportsTasks",
                type: "TIMESTAMP(7)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastExceutionDate",
                table: "ExportsTasks");

            migrationBuilder.DropColumn(
                name: "NextExceutionDate",
                table: "ExportsTasks");
        }
    }
}
