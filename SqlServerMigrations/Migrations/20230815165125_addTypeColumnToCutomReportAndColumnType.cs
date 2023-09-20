using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class addTypeColumnToCutomReportAndColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ArtSavedCustomReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddColumn<bool>(
                name: "IsNullable",
                table: "ArtSavedReportsColumns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JsType",
                table: "ArtSavedReportsColumns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNullable",
                table: "ArtSavedReportsColumns");

            migrationBuilder.DropColumn(
                name: "JsType",
                table: "ArtSavedReportsColumns");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ArtSavedCustomReport");
        }
    }
}
