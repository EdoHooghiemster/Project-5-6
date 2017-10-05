using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Model
{
  public class CheeseContext : DbContext
  {
    public DbSet<Kaas> Kazen { get; set; }
    public DbSet<Wijn> Wijnen { get; set; }
    public DbSet<Klant> Klanten { get; set; }
    public DbSet<Bestelling> Bestellingen { get; set; }
    public DbSet<Leverancier> Leveranciers { get; set; } 
    
    //this method is run automatically by EF the first time we run the application
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
      //here we define the name of our database
      optionsBuilder.UseNpgsql("User ID=postgres;Password=;Host=localhost;Port=5432;Database=CheeseDB;Pooling=true;");
    }
  }

  public class Kaas
  {
    public int Id { get; set; }
    public string Naam { get; set; }
    public string Merk { get; set; }
    public string Melksoort { get; set; }
    public string Vet { get; set; }
    public bool Biologisch { get; set; }
    public string Kaassoort { get; set; }
    public bool Eetbarekorst { get; set; }
    public string Afkomst { get; set; }
    public float Prijs { get; set; }
    public List<Kaas> Kazen { get; set; }
  }

  public class Wijn
  {
    public int Id { get; set; }
    public string Naam { get; set; }
    public string Merk { get; set; }
    public int Inhoud { get; set; }
    public float Alcohol { get; set; }
    public int Afkomst { get; set; }
    public int Prijs { get; set; }
    public List<Wijn> Wijnen { get; set; }
  }

  public class Klant
  {
      public int Id { get; set; }
      public string Voornaam { get; set; }
      public string Achternaam { get; set; }
      public string Geslacht { get; set; }
      public int Geboortedatum { get; set; }
      public string Email { get; set; }
      public string Telnummer { get; set; }
      public string Adres { get; set; }
      public List<Klant> Klanten { get; set; }
  }

  public class Bestelling
  {
      public int Id { get; set; }
      public string Verzendadres { get; set; }
      public string Betaalmethode { get; set; }
      public bool Betaald { get; set; }
      public bool Verzonden { get; set; }
      public int KlantId { get; set; }
  }

  public class Leverancier
  {
      public int Id { get; set; }
      public string Adres { get; set; }
      public string Telnummer { get; set; }
      public List<Leverancier> Leveranciers { get; set; }
  }
}