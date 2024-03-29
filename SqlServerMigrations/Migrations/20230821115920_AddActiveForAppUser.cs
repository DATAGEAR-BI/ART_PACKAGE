﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class AddActiveForAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "AspNetUsers");


        }
    }
}
