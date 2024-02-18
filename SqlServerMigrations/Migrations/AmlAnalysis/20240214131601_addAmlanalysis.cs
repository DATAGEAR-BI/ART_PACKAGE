using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations.AmlAnalysis
{
    public partial class addAmlanalysis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql($@"
                CREATE VIEW ART_DB.ART_AML_ANALYSIS_VIEW AS
                SELECT * FROM MEB_CORE.dbo.ART_AML_ANALYSIS_VIEW
            ");
            
            migrationBuilder.CreateTable(
                name: "ArtAmlAnalysisRules",
                schema: "ART_DB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadableOutPut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sql = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    Action = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RouteToUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtAmlAnalysisRules", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtAmlAnalysisRules",
                schema: "ART");
        }
    }
}
