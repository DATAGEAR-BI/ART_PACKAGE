using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class AddColumnTypeForCustomReportAndActiveForAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "ART",
                table: "AspNetUsers",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNullable",
                schema: "ART",
                table: "ArtSavedReportsColumns",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JsType",
                schema: "ART",
                table: "ArtSavedReportsColumns",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "ART",
                table: "ArtSavedCustomReport",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "ART",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsNullable",
                schema: "ART",
                table: "ArtSavedReportsColumns");

            migrationBuilder.DropColumn(
                name: "JsType",
                schema: "ART",
                table: "ArtSavedReportsColumns");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "ART",
                table: "ArtSavedCustomReport");
        }
    }
}
