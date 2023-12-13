using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.ExportSchedular
{
    public partial class addmailtextanduserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskParameters");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ExportsTasks",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MailContent",
                table: "ExportsTasks",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParametersJson",
                table: "ExportsTasks",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "ExportsTasks",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ExportsTasks",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ExportsTasks");

            migrationBuilder.DropColumn(
                name: "MailContent",
                table: "ExportsTasks");

            migrationBuilder.DropColumn(
                name: "ParametersJson",
                table: "ExportsTasks");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "ExportsTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExportsTasks");

            migrationBuilder.CreateTable(
                name: "TaskParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TaskId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Operator = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ParameterName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ParameterValue = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
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
                name: "IX_TaskParameters_TaskId",
                table: "TaskParameters",
                column: "TaskId");
        }
    }
}
