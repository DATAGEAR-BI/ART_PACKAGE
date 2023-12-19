using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.ExportSchedular
{
    public partial class dropmailstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskMails");

            migrationBuilder.AddColumn<string>(
                name: "MailsSerialized",
                table: "ExportsTasks",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailsSerialized",
                table: "ExportsTasks");

            migrationBuilder.CreateTable(
                name: "TaskMails",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Mail = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
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
        }
    }
}
