﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIInteractions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSuccess = table.Column<bool>(nullable: false),
                    APIRun = table.Column<DateTime>(nullable: false),
                    StatusReturn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIInteractions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIInteractions");
        }
    }
}
