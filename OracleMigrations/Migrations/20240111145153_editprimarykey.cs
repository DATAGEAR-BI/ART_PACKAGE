using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class editprimarykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReport",
                table: "UserReport");

            migrationBuilder.AlterColumn<string>(
                name: "SharedFromId",
                table: "UserReport",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReport",
                table: "UserReport",
                columns: new[] { "ReportId", "UserId", "SharedFromId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83393df2-1bfa-471d-9a8a-8bf7c4b3f112",
                column: "ConcurrencyStamp",
                value: "0b9ddd6f-4bb2-40bc-93aa-a4f6ec0a46a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae3a9d7a-5adf-4cd9-85c4-517e59d08513",
                column: "ConcurrencyStamp",
                value: "e2ec8018-74ec-40d7-afd1-1a59b0ed7a54");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60411ee-1127-4f5e-8f03-367ef13017a6",
                column: "ConcurrencyStamp",
                value: "c22354f3-62a7-452e-9d4e-fae7031b734d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96288d4-8936-4fb1-8427-d5b45dd66023",
                column: "ConcurrencyStamp",
                value: "66c34ab5-f99b-4b3e-909f-94ae05417821");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "894dac60-80b7-4fe4-a5c1-1224c70700c8", "AQAAAAEAACcQAAAAEAsRLDyP20IxtSLbqblE9gZrtcTyA/eg/GKmfh9vsia/bZmuQSGga5hFdQPXVXu3Eg==", "07091d2b-367e-4a0c-8668-9645aff339f4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReport",
                table: "UserReport");

            migrationBuilder.AlterColumn<string>(
                name: "SharedFromId",
                table: "UserReport",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReport",
                table: "UserReport",
                columns: new[] { "ReportId", "UserId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83393df2-1bfa-471d-9a8a-8bf7c4b3f112",
                column: "ConcurrencyStamp",
                value: "b9141802-6aac-4a5e-843b-3778b2d64b1b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae3a9d7a-5adf-4cd9-85c4-517e59d08513",
                column: "ConcurrencyStamp",
                value: "dbfc15f8-d927-47b2-bdfa-88b0e91f60e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60411ee-1127-4f5e-8f03-367ef13017a6",
                column: "ConcurrencyStamp",
                value: "a14b657e-9ae4-4bb3-8b59-4d5575d3bc35");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96288d4-8936-4fb1-8427-d5b45dd66023",
                column: "ConcurrencyStamp",
                value: "1f79343b-a54a-4863-a047-dd3f2ad23930");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "233b6c1b-a4d8-43b6-9031-6fb2745378df", "AQAAAAEAACcQAAAAEJjJU7PIDkjqWH26DxFxdHY8rkFVpNW5KUBfE4xqNZrV2nI/KmlEILLJ8Vs5SAyliQ==", "1a45ee37-2429-4f6b-964e-fae238f91cef" });
        }
    }
}
