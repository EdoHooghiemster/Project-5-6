﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Cheese.Models;
using System;

namespace Cheese.Migrations
{
    [DbContext(typeof(CheeseContext))]
    [Migration("20171006091349_MikePcDB")]
    partial class MikePcDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Model.Bestelling", b =>
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

            modelBuilder.Entity("Model.Kaas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Afkomst");

                    b.Property<bool>("Biologisch");

                    b.Property<bool>("Eetbarekorst");

                    b.Property<int?>("KaasId");

                    b.Property<string>("Kaassoort");

                    b.Property<string>("Melksoort");

                    b.Property<string>("Merk");

                    b.Property<string>("Naam");

                    b.Property<float>("Prijs");

                    b.Property<string>("Vet");

                    b.HasKey("Id");

                    b.HasIndex("KaasId");

                    b.ToTable("Kazen");
                });

            modelBuilder.Entity("Model.Klant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Achternaam");

                    b.Property<string>("Adres");

                    b.Property<string>("Email");

                    b.Property<int>("Geboortedatum");

                    b.Property<string>("Geslacht");

                    b.Property<int?>("KlantId");

                    b.Property<string>("Telnummer");

                    b.Property<string>("Voornaam");

                    b.HasKey("Id");

                    b.HasIndex("KlantId");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("Model.Leverancier", b =>
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

            modelBuilder.Entity("Model.Wijn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Afkomst");

                    b.Property<float>("Alcohol");

                    b.Property<int>("Inhoud");

                    b.Property<string>("Merk");

                    b.Property<string>("Naam");

                    b.Property<int>("Prijs");

                    b.Property<int?>("WijnId");

                    b.HasKey("Id");

                    b.HasIndex("WijnId");

                    b.ToTable("Wijnen");
                });

            modelBuilder.Entity("Model.Kaas", b =>
                {
                    b.HasOne("Model.Kaas")
                        .WithMany("Kazen")
                        .HasForeignKey("KaasId");
                });

            modelBuilder.Entity("Model.Klant", b =>
                {
                    b.HasOne("Model.Klant")
                        .WithMany("Klanten")
                        .HasForeignKey("KlantId");
                });

            modelBuilder.Entity("Model.Leverancier", b =>
                {
                    b.HasOne("Model.Leverancier")
                        .WithMany("Leveranciers")
                        .HasForeignKey("LeverancierId");
                });

            modelBuilder.Entity("Model.Wijn", b =>
                {
                    b.HasOne("Model.Wijn")
                        .WithMany("Wijnen")
                        .HasForeignKey("WijnId");
                });
#pragma warning restore 612, 618
        }
    }
}
