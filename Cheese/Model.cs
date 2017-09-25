using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Model
{
  public class ProductContext : DbContext
  {
    //this is actual entity object linked to the movies in our DB
    public DbSet<Product> Products { get; set; }
    //this is actual entity object linked to the actors in our DB
    public DbSet<ProductInfo> ProductInformation { get; set; }

    //this method is run automatically by EF the first time we run the application
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
      //here we define the name of our database
      optionsBuilder.UseNpgsql("User ID=postgres;Password=MikeGolf;Host=localhost;Port=5432;Database=Products;Pooling=true;");
    }
  }

  //this is the typed representation of a movie in our project
  public class Product
  {
    public int Id { get; set; }
    public string name { get; set; }
    public List<ProductInfo> ProductInformation { get; set; }
  }

  //this is the typed representation of an actor in our project
  public class ProductInfo
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProductId { get; set; }
  }
}