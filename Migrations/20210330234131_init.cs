﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Matrosca.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Local = table.Column<string>(type: "TEXT", nullable: true),
                    DataEvent = table.Column<string>(type: "TEXT", nullable: true),
                    Theme = table.Column<string>(type: "TEXT", nullable: true),
                    PeopleQty = table.Column<int>(type: "INTEGER", nullable: false),
                    Lote = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
