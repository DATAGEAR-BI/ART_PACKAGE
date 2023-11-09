using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations.ExportSchedular
{
    public partial class makeParamterJson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operator",
                table: "TaskParameters");

            migrationBuilder.DropColumn(
                name: "ParameterValue",
                table: "TaskParameters");

            migrationBuilder.RenameColumn(
                name: "ParameterName",
                table: "TaskParameters",
                newName: "ParametersJson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParametersJson",
                table: "TaskParameters",
                newName: "ParameterName");

            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "TaskParameters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParameterValue",
                table: "TaskParameters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
