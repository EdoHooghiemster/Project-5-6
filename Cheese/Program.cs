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
using QC = System.Data.SqlClient;

namespace Cheese
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            using (var connection = new QC.SqlConnection(  
                    "Server=tcp:cheesedb.database.windows.net,1433;Initial Catalog=CheeseDB;Persist Security Info=False;User ID=CheeseAdmin;Password=Ikbenadmin!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30"
                    
                    ))  
                {  
                    connection.Open();  
                    Console.WriteLine("Connected successfully.");  

                    Console.WriteLine("Press any key to finish...");  
                    Console.ReadKey(true);  
                }  
            
            
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();    
    }
}
