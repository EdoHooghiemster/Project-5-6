﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cheese.Migrations
{
    public partial class MikeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestellingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Betaald = table.Column<bool>(type: "bool", nullable: false),
                    Betaalmethode = table.Column<string>(type: "text", nullable: true),
                    KlantId = table.Column<int>(type: "int4", nullable: false),
                    Verzendadres = table.Column<string>(type: "text", nullable: true),
                    Verzonden = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellingen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kazen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Aantal = table.Column<int>(type: "int4", nullable: false),
                    Afbeelding = table.Column<string>(type: "text", nullable: true),
                    Afkomst = table.Column<string>(type: "text", nullable: true),
                    Beschrijving = table.Column<string>(type: "text", nullable: true),
                    Biologisch = table.Column<bool>(type: "bool", nullable: false),
                    Eetbarekorst = table.Column<bool>(type: "bool", nullable: false),
                    KaasId = table.Column<int>(type: "int4", nullable: true),
                    Kaassoort = table.Column<string>(type: "text", nullable: true),
                    Melksoort = table.Column<string>(type: "text", nullable: true),
                    Merk = table.Column<string>(type: "text", nullable: true),
                    Naam = table.Column<string>(type: "text", nullable: true),
                    Prijs = table.Column<float>(type: "float4", nullable: false),
                    Vet = table.Column<string>(type: "text", nullable: true),
                    Winkelwagen = table.Column<bool>(type: "bool", nullable: false)
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
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Achternaam = table.Column<string>(type: "text", nullable: false),
                    ActivatieCode = table.Column<Guid>(type: "uuid", nullable: false),
                    Adres = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Geactiveerd = table.Column<string>(type: "text", nullable: true),
                    Geboortedatum = table.Column<string>(type: "text", nullable: false),
                    Geslacht = table.Column<string>(type: "text", nullable: false),
                    KlantId = table.Column<int>(type: "int4", nullable: true),
                    Telnummer = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Voornaam = table.Column<string>(type: "text", nullable: false),
                    Wachtwoord = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    confirmWachtwoord = table.Column<string>(type: "text", nullable: false)
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
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    LeverancierId = table.Column<int>(type: "int4", nullable: true),
                    Telnummer = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Afbeelding = table.Column<string>(type: "text", nullable: true),
                    Afkomst = table.Column<int>(type: "int4", nullable: false),
                    Alcohol = table.Column<float>(type: "float4", nullable: false),
                    Beschrijving = table.Column<string>(type: "text", nullable: true),
                    Inhoud = table.Column<int>(type: "int4", nullable: false),
                    Merk = table.Column<string>(type: "text", nullable: true),
                    Naam = table.Column<string>(type: "text", nullable: true),
                    Prijs = table.Column<int>(type: "int4", nullable: false),
                    WijnId = table.Column<int>(type: "int4", nullable: true)
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