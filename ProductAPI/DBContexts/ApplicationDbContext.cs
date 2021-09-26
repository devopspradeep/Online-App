using Microsoft.EntityFrameworkCore;
using OnlineApp.Services.ProductAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineApp.Services.ProductAPI.DBContexts
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
