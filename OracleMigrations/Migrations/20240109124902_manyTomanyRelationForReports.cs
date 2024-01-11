using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class manyTomanyRelationForReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            
           

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ArtSavedCustomReport",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.CreateTable(
                name: "AppUserArtSavedCustomReport",
                columns: table => new
                {
                    ReportsId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UsersId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserArtSavedCustomReport", x => new { x.ReportsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppUserArtSavedCustomReport_ArtSavedCustomReport_ReportsId",
                        column: x => x.ReportsId,
                        principalTable: "ArtSavedCustomReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserArtSavedCustomReport_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserArtSavedCustomReport_UsersId",
                table: "AppUserArtSavedCustomReport",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserArtSavedCustomReport");
            

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "ART",
                table: "ArtSavedCustomReport",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");
            
            migrationBuilder.CreateIndex(
                name: "IX_ArtSavedCustomReport_UserId",
                schema: "ART",
                table: "ArtSavedCustomReport",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtSavedCustomReport_AspNetUsers_UserId",
                schema: "ART",
                table: "ArtSavedCustomReport",
                column: "UserId",
                principalSchema: "ART",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
