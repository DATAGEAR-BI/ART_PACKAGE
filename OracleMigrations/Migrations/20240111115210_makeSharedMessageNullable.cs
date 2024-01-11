using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class makeSharedMessageNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShareMessage",
                table: "UserReport",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShareMessage",
                table: "UserReport",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83393df2-1bfa-471d-9a8a-8bf7c4b3f112",
                column: "ConcurrencyStamp",
                value: "933facd1-bcf2-4030-aa4c-5b6e3c687336");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae3a9d7a-5adf-4cd9-85c4-517e59d08513",
                column: "ConcurrencyStamp",
                value: "6d874ca3-a453-4a85-905c-2adbc94ef71c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60411ee-1127-4f5e-8f03-367ef13017a6",
                column: "ConcurrencyStamp",
                value: "50fdef2c-1f61-4c8d-ba0f-23233c915774");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96288d4-8936-4fb1-8427-d5b45dd66023",
                column: "ConcurrencyStamp",
                value: "48e87a59-9d87-4a4c-bc65-e85916940d12");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f207f24-0272-4d69-a68d-a5e03ef2b071", "AQAAAAEAACcQAAAAEC1V7uF3uIgVYnJS/p8cpkU6/4jUNAlTnoSalBJ7tJFV/WA2U4GuNtZa7Ej+3eugDQ==", "98c628a0-073e-4a28-99f8-498d1aa6814e" });
        }
    }
}
