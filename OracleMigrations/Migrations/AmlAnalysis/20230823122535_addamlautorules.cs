using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations.AmlAnalysis
{
    public partial class addamlautorules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtAmlAnalysisRules",
                schema: "ART",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ReadableOutPut = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TableName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sql = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    Action = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    RouteToUser = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Active = table.Column<bool>(type: "NUMBER(1)", nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(type: "NUMBER(1)", nullable: false, defaultValue: false)
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
