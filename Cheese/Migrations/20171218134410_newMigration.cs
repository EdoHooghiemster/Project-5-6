using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cheese.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestellingen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Betaald = table.Column<bool>(nullable: false),
                    Betaalmethode = table.Column<string>(nullable: true),
                    KlantId = table.Column<int>(nullable: false),
                    Verzendadres = table.Column<string>(nullable: true),
                    Verzonden = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellingen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kazen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Aantal = table.Column<int>(nullable: false),
                    Afbeelding = table.Column<string>(nullable: true),
                    Afkomst = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true),
                    Biologisch = table.Column<bool>(nullable: false),
                    Eetbarekorst = table.Column<bool>(nullable: false),
                    KaasId = table.Column<int>(nullable: true),
                    Kaassoort = table.Column<string>(nullable: true),
                    Melksoort = table.Column<string>(nullable: true),
                    Merk = table.Column<string>(nullable: true),
                    Naam = table.Column<string>(nullable: true),
                    Prijs = table.Column<float>(nullable: false),
                    Vet = table.Column<string>(nullable: true),
                    Winkelwagen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kazen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kazen_Kazen_KaasId",
                        column: x => x.KaasId,
                        principalTable: "Kazen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Achternaam = table.Column<string>(nullable: false),
                    ActivatieCode = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Geactiveerd = table.Column<string>(nullable: true),
                    Geboortedatum = table.Column<string>(nullable: false),
                    Geslacht = table.Column<string>(nullable: false),
                    Huisnummer = table.Column<string>(nullable: false),
                    KlantId = table.Column<int>(nullable: true),
                    Postcode = table.Column<string>(nullable: false),
                    Straatnaam = table.Column<string>(nullable: false),
                    Telnummer = table.Column<string>(maxLength: 10, nullable: false),
                    Voornaam = table.Column<string>(nullable: false),
                    Wachtwoord = table.Column<string>(maxLength: 20, nullable: false),
                    confirmWachtwoord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klanten_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leveranciers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Adres = table.Column<string>(nullable: true),
                    LeverancierId = table.Column<int>(nullable: true),
                    Telnummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leveranciers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leveranciers_Leveranciers_LeverancierId",
                        column: x => x.LeverancierId,
                        principalTable: "Leveranciers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wijnen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Afbeelding = table.Column<string>(nullable: true),
                    Afkomst = table.Column<int>(nullable: false),
                    Alcohol = table.Column<float>(nullable: false),
                    Beschrijving = table.Column<string>(nullable: true),
                    Inhoud = table.Column<int>(nullable: false),
                    Merk = table.Column<string>(nullable: true),
                    Naam = table.Column<string>(nullable: true),
                    Prijs = table.Column<int>(nullable: false),
                    WijnId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wijnen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wijnen_Wijnen_WijnId",
                        column: x => x.WijnId,
                        principalTable: "Wijnen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Winkelwagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Aantal = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Prijs = table.Column<int>(nullable: false),
                    Soort = table.Column<string>(nullable: true),
                    WinkelwagenId = table.Column<int>(nullable: true)
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
                name: "IX_Kazen_KaasId",
                table: "Kazen",
                column: "KaasId");

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_KlantId",
                table: "Klanten",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Leveranciers_LeverancierId",
                table: "Leveranciers",
                column: "LeverancierId");

            migrationBuilder.CreateIndex(
                name: "IX_Wijnen_WijnId",
                table: "Wijnen",
                column: "WijnId");

            migrationBuilder.CreateIndex(
                name: "IX_Winkelwagens_WinkelwagenId",
                table: "Winkelwagens",
                column: "WinkelwagenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bestellingen");

            migrationBuilder.DropTable(
                name: "Kazen");

            migrationBuilder.DropTable(
                name: "Klanten");

            migrationBuilder.DropTable(
                name: "Leveranciers");

            migrationBuilder.DropTable(
                name: "Wijnen");

            migrationBuilder.DropTable(
                name: "Winkelwagens");
        }
    }
}
