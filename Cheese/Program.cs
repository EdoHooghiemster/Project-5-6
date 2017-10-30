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
using Cheese.Models;

namespace Cheese
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();

            /*using (var db = new CheeseContext())
            {
                Kaas k = new Kaas{
                    Id = 2,
                    Naam = "Jonge Boerenkaas",
                    Merk = "Huis",
                    Melksoort = "Koe",
                    Vet = "48+",
                    Biologisch = false,
                    Kaassoort = "Hollandse Kaas",
                    Eetbarekorst = false,
                    Afkomst = "Nederlandse kaasboerderij",
                    Prijs = 1
                    };
                    
                };
                db.Add(k);
                db.SaveChanges();

                //SELECT ALL CHEESE AND FILTER: ALLEEN MELKSOORT "Koe"
                var projected_cheese = from k in db.Kazen
                        where k.Melksoort == "Koe"
                        select k;*/
            
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();    
    }
}
