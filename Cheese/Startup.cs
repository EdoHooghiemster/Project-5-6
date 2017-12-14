using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cheese.Models;
using Microsoft.EntityFrameworkCore;
using QC = System.Data.SqlClient;

namespace Cheese
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

        //Add this line to your method
        services.AddDbContext<CheeseContext> (
        opt => opt.UseSqlServer(@"Server=tcp:cheesedb.database.windows.net,1433;Initial Catalog=CheeseDB;Persist Security Info=False;User ID=CheeseAdmin;Password=Ikbenadmin!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"));
 
            // services.AddDbContext<CheeseContext> (
            //         using (var connection = new QC.SqlConnection(  
            //         "Server=tcp:cheesedb.database.windows.net,1433;Initial Catalog=CheeseDB;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"
                    
            //         ))
            //     {  
            //         connection.Open();  
            //         Console.WriteLine("Connected successfully.");  

            //         Console.WriteLine("Press any key to finish...");  
            //         Console.ReadKey(true);  
            //     }  
            
            services.AddMvc ();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Kaas}/{action=Index}/{id?}");
            });
        }
    }
}
