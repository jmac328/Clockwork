﻿using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;

namespace Clockwork.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentTimeQueries",
                columns: table => new
                {
                    CurrentTimeQueryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientIp = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    UTCTime = table.Column<DateTime>(nullable: false),
                    SelectedTimeZone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTimeQueries", x => x.CurrentTimeQueryId);
                });
        }
           

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentTimeQueries");
        }
    }
}
