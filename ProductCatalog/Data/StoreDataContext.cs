using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Map;
using ProductCatalog.Models;

namespace ProductCatalog.Data
{
    public class StoreDataContext : DbContext
    {        

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=devAPI;Data Source=DESKTOP-AU7631G");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}
//solução no SalesWebMVC
/*public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options)
    : base(options)
{
}*/

//JASON:
/*,
  "ConnectionStrings": {
    "ProductCatalogContext": "Server=(localdb)\\mssqllocaldb;Database=ProductCatalogContext-4c271277-ad64-4d29-a82b-620cf435c1db;Trusted_Connection=True;MultipleActiveResultSets=true"
  }*/