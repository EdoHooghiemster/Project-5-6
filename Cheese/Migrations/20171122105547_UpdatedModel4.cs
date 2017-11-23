using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cheese.Migrations
{
    public partial class UpdatedModel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Geboortedatum",
                table: "Klanten",
                type: "text",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Winkelwagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Aantal = table.Column<int>(type: "int4", nullable: false),
                    Naam = table.Column<string>(type: "text", nullable: true),
                    Prijs = table.Column<int>(type: "int4", nullable: false),
                    Soort = table.Column<string>(type: "text", nullable: true),
                    WinkelwagenId = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winkelwagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Winkelwagens_Winkelwagens_WinkelwagenId",
                        column: x => x.WinkelwagenId,
                        principalTable: "Winkelwagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Winkelwagens_WinkelwagenId",
                table: "Winkelwagens",
                column: "WinkelwagenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Winkelwagens");

            migrationBuilder.AlterColumn<int>(
                name: "Geboortedatum",
                table: "Klanten",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
