using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class addRelationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserArtSavedCustomReport");

            migrationBuilder.CreateTable(
                name: "UserReport",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    SharedFromId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ShareMessage = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReport", x => new { x.ReportId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserReport_ArtSavedCustomReport_ReportId",
                        column: x => x.ReportId,
                        principalTable: "ArtSavedCustomReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReport_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83393df2-1bfa-471d-9a8a-8bf7c4b3f112",
                column: "ConcurrencyStamp",
                value: "258ce875-e2a1-4238-aec0-bbc5ca75a03b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae3a9d7a-5adf-4cd9-85c4-517e59d08513",
                column: "ConcurrencyStamp",
                value: "0b660415-1bc8-44b5-a5cd-a8348f370204");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60411ee-1127-4f5e-8f03-367ef13017a6",
                column: "ConcurrencyStamp",
                value: "871d3932-ee78-4a9c-a2d9-9cbd62e44a1a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96288d4-8936-4fb1-8427-d5b45dd66023",
                column: "ConcurrencyStamp",
                value: "74befa17-ab19-49d5-854c-cceac539b3c9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b247c02-6c6c-4f20-b3c9-3c36ea923edc", "AQAAAAEAACcQAAAAEE3DssV2EX2wUup+wwqEMjUlpmwXEdhuMzv7ccbmakMoUaVKRhjvWlcgHHQcqJjNfg==", "55daa74a-69e5-427b-9427-102874015999" });

            migrationBuilder.CreateIndex(
                name: "IX_UserReport_SharedFromId",
                table: "UserReport",
                column: "SharedFromId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReport_UserId",
                table: "UserReport",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserReport");

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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83393df2-1bfa-471d-9a8a-8bf7c4b3f112",
                column: "ConcurrencyStamp",
                value: "f5384d18-bd53-42f1-adb4-240e318fc091");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae3a9d7a-5adf-4cd9-85c4-517e59d08513",
                column: "ConcurrencyStamp",
                value: "41928dc7-7028-45a2-865e-897d1cb68d8a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60411ee-1127-4f5e-8f03-367ef13017a6",
                column: "ConcurrencyStamp",
                value: "0274db94-bb39-440e-b170-6e52badd14a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96288d4-8936-4fb1-8427-d5b45dd66023",
                column: "ConcurrencyStamp",
                value: "c14db2eb-e03c-4b01-88a1-2d47d6679766");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d274a869-e17b-46b2-9395-5d7950511045", "AQAAAAEAACcQAAAAEMZNNUy8f4iwfGx2m3IFVzfW1E/Oo6JT/FwFZcjItRaOxrepxqz4HZLlFPb/a+h79g==", "322e9327-6af3-4c11-a58a-b3e2ce3475c9" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserArtSavedCustomReport_UsersId",
                table: "AppUserArtSavedCustomReport",
                column: "UsersId");
        }
    }
}
