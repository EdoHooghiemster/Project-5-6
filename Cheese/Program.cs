using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

            using (var db = new CheeseContext())
            {

                Kaas k = new Kaas
                {
                    Naam = "Jonge Romig Zachte Noord-Hollandse Gouda",
                    Merk = "Noord-Hollandse Gouda",
                    Vet = "48+",
                    Melksoort = "Koe",
                    Biologisch = false,
                    Kaassoort = "Hollandse Kaas",
                    Eetbarekorst = false,
                    Afkomst = "Gouda",
                    Prijs = 10
                    
                };
                db.Kazen.Add(k);
                db.SaveChanges();
            }

            using (var db = new CheeseContext())
            {
                foreach (var Kaas in db.Kazen)
                {
                    Console.WriteLine(Kaas.Naam + "gevonden.");
                }
            }
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();    
    }
}
