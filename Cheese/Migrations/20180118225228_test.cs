using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cheese.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kazen_Klanten_KlantId",
                table: "Kazen");

            migrationBuilder.DropIndex(
                name: "IX_Kazen_KlantId",
                table: "Kazen");

            migrationBuilder.DropColumn(
                name: "KlantId",
                table: "Kazen");

            migrationBuilder.AddColumn<int>(
                name: "Voorraad",
                table: "Kazen",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Voorraad",
                table: "Kazen");

            migrationBuilder.AddColumn<int>(
                name: "KlantId",
                table: "Kazen",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kazen_KlantId",
                table: "Kazen",
                column: "KlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kazen_Klanten_KlantId",
                table: "Kazen",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
