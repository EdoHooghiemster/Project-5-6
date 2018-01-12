﻿// <auto-generated />
using Cheese.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Cheese.Migrations
{
    [DbContext(typeof(CheeseContext))]
    partial class CheeseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Cheese.Models.Bestelling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Betaald");

                    b.Property<string>("Betaalmethode");

                    b.Property<int>("KlantId");

                    b.Property<string>("Verzendadres");

                    b.Property<bool>("Verzonden");

                    b.HasKey("Id");

                    b.ToTable("Bestellingen");
                });

            modelBuilder.Entity("Cheese.Models.Kaas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Aantal");

                    b.Property<string>("Afbeelding");

                    b.Property<string>("Afkomst");

                    b.Property<string>("Beschrijving");

                    b.Property<bool>("Biologisch");

                    b.Property<bool>("Eetbarekorst");

                    b.Property<bool>("Favorieten");

                    b.Property<int?>("KaasId");

                    b.Property<string>("Kaassoort");

                    b.Property<int?>("KlantId");

                    b.Property<string>("Melksoort");

                    b.Property<string>("Merk");

                    b.Property<string>("Naam");

                    b.Property<float>("Prijs");

                    b.Property<string>("Vet");

                    b.Property<bool>("Winkelwagen");

                    b.HasKey("Id");

                    b.HasIndex("KaasId");

                    b.HasIndex("KlantId");

                    b.ToTable("Kazen");
                });

            modelBuilder.Entity("Cheese.Models.Klant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Achternaam")
                        .IsRequired();

                    b.Property<Guid>("ActivatieCode");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Geactiveerd");

                    b.Property<string>("Geboortedatum")
                        .IsRequired();

                    b.Property<string>("Geslacht")
                        .IsRequired();

                    b.Property<string>("Huisnummer")
                        .IsRequired();

                    b.Property<int?>("KlantId");

                    b.Property<string>("Postcode")
                        .IsRequired();

                    b.Property<string>("Straatnaam")
                        .IsRequired();

                    b.Property<string>("Telnummer")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Voornaam")
                        .IsRequired();

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("confirmWachtwoord");

                    b.HasKey("Id");

                    b.HasIndex("KlantId");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("Cheese.Models.Leverancier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adres");

                    b.Property<int?>("LeverancierId");

                    b.Property<string>("Telnummer");

                    b.HasKey("Id");

                    b.HasIndex("LeverancierId");

                    b.ToTable("Leveranciers");
                });

            modelBuilder.Entity("Cheese.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("KaasName");

                    b.Property<int?>("RatingId");

                    b.Property<int>("Score");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("RatingId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Cheese.Models.Wijn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Afbeelding");

                    b.Property<int>("Afkomst");

                    b.Property<float>("Alcohol");

                    b.Property<string>("Beschrijving");

                    b.Property<int>("Inhoud");

                    b.Property<string>("Merk");

                    b.Property<string>("Naam");

                    b.Property<int>("Prijs");

                    b.Property<int?>("WijnId");

                    b.HasKey("Id");

                    b.HasIndex("WijnId");

                    b.ToTable("Wijnen");
                });

            modelBuilder.Entity("Cheese.Models.Winkelwagen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Aantal");

                    b.Property<string>("Naam");

                    b.Property<int>("Prijs");

                    b.Property<string>("Soort");

                    b.Property<int?>("WinkelwagenId");

                    b.HasKey("Id");

                    b.HasIndex("WinkelwagenId");

                    b.ToTable("Winkelwagens");
                });

            modelBuilder.Entity("Cheese.Models.Kaas", b =>
                {
                    b.HasOne("Cheese.Models.Kaas")
                        .WithMany("Kazen")
                        .HasForeignKey("KaasId");

                    b.HasOne("Cheese.Models.Klant")
                        .WithMany("Kaas")
                        .HasForeignKey("KlantId");
                });

            modelBuilder.Entity("Cheese.Models.Klant", b =>
                {
                    b.HasOne("Cheese.Models.Klant")
                        .WithMany("Klanten")
                        .HasForeignKey("KlantId");
                });

            modelBuilder.Entity("Cheese.Models.Leverancier", b =>
                {
                    b.HasOne("Cheese.Models.Leverancier")
                        .WithMany("Leveranciers")
                        .HasForeignKey("LeverancierId");
                });

            modelBuilder.Entity("Cheese.Models.Rating", b =>
                {
                    b.HasOne("Cheese.Models.Rating")
                        .WithMany("Ratings")
                        .HasForeignKey("RatingId");
                });

            modelBuilder.Entity("Cheese.Models.Wijn", b =>
                {
                    b.HasOne("Cheese.Models.Wijn")
                        .WithMany("Wijnen")
                        .HasForeignKey("WijnId");
                });

            modelBuilder.Entity("Cheese.Models.Winkelwagen", b =>
                {
                    b.HasOne("Cheese.Models.Winkelwagen")
                        .WithMany("Winkelwagens")
                        .HasForeignKey("WinkelwagenId");
                });
#pragma warning restore 612, 618
        }
    }
}
