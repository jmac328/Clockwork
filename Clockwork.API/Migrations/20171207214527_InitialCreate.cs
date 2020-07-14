using Microsoft.EntityFrameworkCore.Migrations;
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

            //Create time zone table
            migrationBuilder.CreateTable(
               name: "TimeZones",
               columns: table => new
               {
                   TimeZoneId = table.Column<int>(nullable: false)
                       .Annotation("Sqlite:Autoincrement", true),
                   TimeZoneName = table.Column<string>(nullable: true),
                   TimeZoneValue = table.Column<int>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_TimeZones", x => x.TimeZoneId);
               });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "UTC", 0 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "ANAT - Anadyr Time", 12 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "SBT - Solomon Islands Time", 11 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "AEST - Australian Eastern Standard Time", 10 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "JST - Japan Standard Time", 9 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "CST - China Standard Time", 8 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "WIB - Western Indonesian Time", 7 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "BST - Bangladesh Standard Time", 6 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "UZT - Uzbekistan Time", 5 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "GST - Gulf Standard Time", 4 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "MSK - Moscow Standard Time", 3 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "CEST - Central European Summer Time", 2 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "BST - British Summer Time ", 1 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "CVT - Cape Verde Time", -1 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "WGST - Western Greenland Summer Time", -2 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "ART - Argentina Time", -3 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "EDT - Eastern Daylight Time", -4 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "CDT - Central Daylight Time", -5 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "CST - Central Standard Time", -6 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "PDT - Pacific Daylight Time", -7 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "AKDT - Alaska Daylight Time", -8 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "HDT - ", -9 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "HST - Hawaii Standard Time", -10 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "NUT - Niue Time", -11 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "AOE - Anywhere on Earth", -12 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "LINT - Line Islands Time", 14 });
            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "TimeZoneName", "TimeZoneValue" },
                values: new object[] { "TOT - Tonga Time", 13 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentTimeQueries");
            migrationBuilder.DropTable(
                name: "TimeZones");
        }
    }
}
