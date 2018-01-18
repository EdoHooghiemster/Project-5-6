using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cheese.Migrations
{
    public partial class favoritess123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kazen_Klanten_KlantId",
                table: "Kazen");

            migrationBuilder.AlterColumn<int>(
                name: "KlantId",
                table: "Kazen",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Kazen_Klanten_KlantId",
                table: "Kazen",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kazen_Klanten_KlantId",
                table: "Kazen");

            migrationBuilder.AlterColumn<int>(
                name: "KlantId",
                table: "Kazen",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kazen_Klanten_KlantId",
                table: "Kazen",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
