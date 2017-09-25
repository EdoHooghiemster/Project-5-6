using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Model;

namespace Cheese
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            using (var db = new ProductContext())
            {

            Product m = new Product
            {
                name = "No country for old men",
                ProductInformation = new System.Collections.Generic.List<ProductInfo> {
                new ProductInfo{Name = "Tommy Lee"},
                new ProductInfo{Name = "Xavier Berdem"}
                }
            };
            db.Products.Add(m);
            db.SaveChanges();
            
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
