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
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-AU7631G;Database=devAPI;User ID=dev;Password=Dev2512");                    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}
