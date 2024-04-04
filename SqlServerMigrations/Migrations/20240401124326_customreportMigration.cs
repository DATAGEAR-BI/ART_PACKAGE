using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class customreportMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtSavedCustomReport_AspNetUsers_UserId",
                table: "ArtSavedCustomReport");

            migrationBuilder.DropIndex(
                name: "IX_ArtSavedCustomReport_UserId",
                table: "ArtSavedCustomReport");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ArtSavedCustomReport");

            migrationBuilder.AddColumn<bool>(
                name: "IsShared",
                table: "ArtSavedCustomReport",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserReport",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SharedFromId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShareMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReport", x => new { x.ReportId, x.UserId, x.SharedFromId });
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
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2f25ef2-3ea6-4c1a-a74c-8c61f6d48865", "art_customreport", "ART_CUTOMREPORT" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae3a9d7a-5adf-4cd9-85c4-517e59d08513",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4da14a8-9193-4770-8655-18be17a88041", "art_admin", "ART_ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60411ee-1127-4f5e-8f03-367ef13017a6",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c3da18e-9180-4bc9-a096-ed07511f3fbe", "art_home", "ART_HOME" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f96288d4-8936-4fb1-8427-d5b45dd66023", "f49554d9-4317-42b4-9753-1043254f4b09", "art_superadmin", "ART_SUPERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8d5fde3-3b4a-4bc0-9e0d-ae315aac3cb5", "AQAAAAEAACcQAAAAENcMhRxwn7QLK+hce8KitV/pH2oaMpR4+10azt8oWW/eE5DmSnMD1aIfJoWOxuHwyg==", "4a2575f7-a887-43fd-9c47-2b715607ba3a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f96288d4-8936-4fb1-8427-d5b45dd66023", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.CreateIndex(
                name: "IX_UserReport_UserId",
                table: "UserReport",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserReport");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f96288d4-8936-4fb1-8427-d5b45dd66023", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96288d4-8936-4fb1-8427-d5b45dd66023");

            migrationBuilder.DropColumn(
                name: "IsShared",
                table: "ArtSavedCustomReport");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ArtSavedCustomReport",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83393df2-1bfa-471d-9a8a-8bf7c4b3f112",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba40e7d4-ddb9-4471-a7bf-399ea5c65d0d", "CutomReport", "CUTOMREPORT" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae3a9d7a-5adf-4cd9-85c4-517e59d08513",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d4bc811-f379-4676-8492-99d6a383b15f", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60411ee-1127-4f5e-8f03-367ef13017a6",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2bbf990a-6659-4b51-8e9a-5d7ff168a41c", "Home", "HOME" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc69a310-baa6-46f8-8a2a-22cc44e22913", "AQAAAAEAACcQAAAAENZEJDz1x5O3Ov6Wm0YI8sgPrleI2HZ7AGMIzBCkrTnryfnjombgKSggiv3GQnGKPA==", "5b4e360b-7d3d-4728-a922-1c1a198bca24" });

            migrationBuilder.CreateIndex(
                name: "IX_ArtSavedCustomReport_UserId",
                table: "ArtSavedCustomReport",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtSavedCustomReport_AspNetUsers_UserId",
                table: "ArtSavedCustomReport",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
