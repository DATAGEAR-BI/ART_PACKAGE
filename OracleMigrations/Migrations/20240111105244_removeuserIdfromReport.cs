using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleMigrations.Migrations
{
    public partial class removeuserIdfromReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ArtSavedCustomReport");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83393df2-1bfa-471d-9a8a-8bf7c4b3f112",
                column: "ConcurrencyStamp",
                value: "a80fb8a2-099e-43eb-956a-e86185d741d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae3a9d7a-5adf-4cd9-85c4-517e59d08513",
                column: "ConcurrencyStamp",
                value: "b80523e0-50fb-48fa-bede-8c7e5ac41040");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60411ee-1127-4f5e-8f03-367ef13017a6",
                column: "ConcurrencyStamp",
                value: "23824caa-5721-4f9a-9920-f01f3826e2bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96288d4-8936-4fb1-8427-d5b45dd66023",
                column: "ConcurrencyStamp",
                value: "fd732364-accf-41df-819b-fdfe2fd6da25");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49870ecb-10e5-43ff-acbf-34f61734bf9c", "AQAAAAEAACcQAAAAEKWaqIoOD73wkSjrklI81pcyOxpDlj1WbcsoKTWtQam7L2w1sl96+aVN6sBlFEvACg==", "d44192b7-d1e3-410d-991e-d0e474637cab" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ArtSavedCustomReport",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
