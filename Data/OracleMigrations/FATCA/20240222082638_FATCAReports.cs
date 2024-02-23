using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.OracleMigrations.FATCA
{
    public partial class FATCAReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ART");

            migrationBuilder.CreateSequence(
                name: "HF_JOB_ID_SEQ",
                schema: "ART");

            migrationBuilder.CreateSequence(
                name: "HF_SEQUENCE",
                schema: "ART");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "HF_JOB_ID_SEQ",
                schema: "ART");

            migrationBuilder.DropSequence(
                name: "HF_SEQUENCE",
                schema: "ART");
        }
    }
}
