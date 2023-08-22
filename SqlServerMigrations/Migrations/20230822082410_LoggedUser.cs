using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class LoggedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Art_LoggedUser_AUD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Login_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Login_Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Art_LoggedUsers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Login_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Login_Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_ID", x => x.ID);
                });

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Art_LoggedUser_AUD");

            migrationBuilder.DropTable(
                name: "Art_LoggedUsers");

            
        }
    }
}
