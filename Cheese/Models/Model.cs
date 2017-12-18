using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Cheese.Models
{
  public class CheeseContext : DbContext
  {
    public DbSet<Kaas> Kazen { get; set; }
    public DbSet<Wijn> Wijnen { get; set; }
    public DbSet<Klant> Klanten { get; set; }
    public DbSet<Bestelling> Bestellingen { get; set; }
    public DbSet<Leverancier> Leveranciers { get; set; }
    public DbSet<Winkelwagen> Winkelwagens { get; set; }
    
    //this method is run automatically by EF the first time we run the application
     public CheeseContext(DbContextOptions<CheeseContext> options): base(options)
        {
        }

        public CheeseContext()
        {
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
    public string Afbeelding {get; set;}
    public string Beschrijving{get; set;}
    public List<Kaas> Kazen { get; set; }
    public bool Winkelwagen { get; set; }
    [Range(0.0, 100000000 , ErrorMessage = "U kan geen negatief aantal in uw winkelwagen plaatsen")]
    public int Aantal { get; set; }

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
    public string Afbeelding{get; set;}
    public string Beschrijving{get; set;}
    public List<Wijn> Wijnen { get; set; }
  }

  public class Klant
  {
      public int Id { get; set; }
      [Required(ErrorMessage = "Voornaam is nodig")]
      public string Voornaam { get; set; }
      [Required(ErrorMessage = "Achternaam is nodig")]
      public string Achternaam { get; set; }
      
      [Required(ErrorMessage = "Geslacht is nodig")]
      public string Geslacht { get; set; }

      [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "onjuist ingevoerd")] 
      [Required(ErrorMessage = "Geboortedatum is nodig")]
      public string Geboortedatum { get; set; }
      [Required(ErrorMessage = "Email is nodig")]
      
      [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Voer een juiste e-mail in.")]
      public string Email { get; set; }
    
     
     [Required(ErrorMessage = "Wachtwoord is nodig")]
     [StringLength(20,MinimumLength = 0, ErrorMessage = "Wachtwoord mag maximaal 20 karakters lang zijn")]
      public string Wachtwoord{get; set;}

    
    [Compare("Wachtwoord", ErrorMessage = "Wachtwoord komt niet overeen.")]
    public string confirmWachtwoord { get; set; }

    [Required(ErrorMessage = "Telefoonnummer is nodig")]
    [StringLength(10,MinimumLength = 10, ErrorMessage = "Nummer moet 10 cijfers lang zijn")]

    public string Telnummer { get; set; }
    [Required(ErrorMessage = "Straatnaam is nodig")]
    public string Straatnaam { get; set; }
    [Required(ErrorMessage = "Huisnummer is nodig")]
    [RegularExpression(@"^[1-9].*$", ErrorMessage = "Ongeldig huisnummer")]
    public string Huisnummer { get; set; }
    [Required(ErrorMessage = "Postcode is nodig")]
    [RegularExpression(@"^[1-9]{1}[0-9]{3} ?[A-HJ-Za-hj-z]{2}$", ErrorMessage = "Ongeldige postcode")]
    public string Postcode { get; set; }

    public Guid ActivatieCode { get; set; }

    public string Geactiveerd { get; set; }
   
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

  public class Winkelwagen
    {
        public int Id { get; set; }
        public string Soort { get; set; }
        public int Aantal { get; set; }
        public string Naam { get; set; }
        public int Prijs { get; set; }
        public List<Winkelwagen> Winkelwagens { get; set; }

    }
}