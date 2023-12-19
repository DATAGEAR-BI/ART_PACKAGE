using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.ExportSchedular
{
    public partial class AddendofmanthcolumnandCornExpression : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CornExpression",
                table: "ExportsTasks",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EndOfMonth",
                table: "ExportsTasks",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CornExpression",
                table: "ExportsTasks");

            migrationBuilder.DropColumn(
                name: "EndOfMonth",
                table: "ExportsTasks");
        }
    }
}
