using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cheese.Models
{
    public class logincontext : DbContext
    {
        public DbSet<Klant> Account {get; set;}
    }
}