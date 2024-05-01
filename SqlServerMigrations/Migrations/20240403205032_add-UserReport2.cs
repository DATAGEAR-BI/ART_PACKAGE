using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class addUserReport2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReport_ArtSavedCustomReport_ReportId",
                table: "UserReport");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReport_AspNetUsers_UserId",
                table: "UserReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReport",
                table: "UserReport");

            migrationBuilder.RenameTable(
                name: "UserReport",
                newName: "UserReports");

            migrationBuilder.RenameIndex(
                name: "IX_UserReport_UserId",
                table: "UserReports",
                newName: "IX_UserReports_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReports",
                table: "UserReports",
                columns: new[] { "ReportId", "UserId", "SharedFromId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83393df2-1bfa-471d-9a8a-8bf7c4b3f112",
                column: "ConcurrencyStamp",
                value: "a2133717-37c6-49d2-a8dd-e645669644b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae3a9d7a-5adf-4cd9-85c4-517e59d08513",
                column: "ConcurrencyStamp",
                value: "5fa9f90e-42e5-4ec5-94b9-6c0765bfc63a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60411ee-1127-4f5e-8f03-367ef13017a6",
                column: "ConcurrencyStamp",
                value: "a16d0e86-ac1e-41cb-ad5c-db422a646831");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96288d4-8936-4fb1-8427-d5b45dd66023",
                column: "ConcurrencyStamp",
                value: "5cce0926-9401-4bb4-9900-79d6d571c0d4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "109b4fb3-a8ff-4878-b362-7836d85133ee", "AQAAAAEAACcQAAAAEKZ9Z2X2KfsXmkhPMm23P6VD9IsAJLjuRu6hRAW8SBn12OVYSMw1IFDQKVuUC4JHcQ==", "71a18fd2-8dd3-47f3-bdc3-5e529cfa7a18" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserReports_ArtSavedCustomReport_ReportId",
                table: "UserReports",
                column: "ReportId",
                principalTable: "ArtSavedCustomReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReports_AspNetUsers_UserId",
                table: "UserReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReports_ArtSavedCustomReport_ReportId",
                table: "UserReports");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReports_AspNetUsers_UserId",
                table: "UserReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReports",
                table: "UserReports");

            migrationBuilder.RenameTable(
                name: "UserReports",
                newName: "UserReport");

            migrationBuilder.RenameIndex(
                name: "IX_UserReports_UserId",
                table: "UserReport",
                newName: "IX_UserReport_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReport",
                table: "UserReport",
                columns: new[] { "ReportId", "UserId", "SharedFromId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83393df2-1bfa-471d-9a8a-8bf7c4b3f112",
                column: "ConcurrencyStamp",
                value: "1a38282c-f652-4bf6-bb75-94111e8d6473");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae3a9d7a-5adf-4cd9-85c4-517e59d08513",
                column: "ConcurrencyStamp",
                value: "b43802f5-d424-4000-b7cc-082635ee484a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60411ee-1127-4f5e-8f03-367ef13017a6",
                column: "ConcurrencyStamp",
                value: "ac9edf38-012c-4d7d-a45c-d7dfaef9a931");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96288d4-8936-4fb1-8427-d5b45dd66023",
                column: "ConcurrencyStamp",
                value: "386d95da-446f-46e8-a04e-26b9ff2b347d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b60d05a4-e2ac-4f21-a33d-4ad322b0cae2", "AQAAAAEAACcQAAAAEIhW1HGfU9nwcix2DzkNI/VSIw05NbUtDmqVOEQMTeb0zheypYIDoL6BKsfsf/vlfA==", "c510aba0-8494-499b-bf12-4c33c3df40c5" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserReport_ArtSavedCustomReport_ReportId",
                table: "UserReport",
                column: "ReportId",
                principalTable: "ArtSavedCustomReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReport_AspNetUsers_UserId",
                table: "UserReport",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
