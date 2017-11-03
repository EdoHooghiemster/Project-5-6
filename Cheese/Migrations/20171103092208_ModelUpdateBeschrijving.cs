using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cheese.Migrations
{
    public partial class ModelUpdateBeschrijving : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Afbeelding",
                table: "Wijnen",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Beschrijving",
                table: "Wijnen",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wachtwoord",
                table: "Klanten",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Beschrijving",
                table: "Kazen",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Afbeelding",
                table: "Wijnen");

            migrationBuilder.DropColumn(
                name: "Beschrijving",
                table: "Wijnen");

            migrationBuilder.DropColumn(
                name: "Wachtwoord",
                table: "Klanten");

            migrationBuilder.DropColumn(
                name: "Beschrijving",
                table: "Kazen");
        }
    }
}
