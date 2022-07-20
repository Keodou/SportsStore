using Microsoft.EntityFrameworkCore;
using SportsStore.Models.Entities;

namespace SportsStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 1,
                Name = "Kayak",
                Description = "SWIIIIIIIM",
                Price = 60M,
                Category = "WaterSports"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 2,
                Name = "Lifejacket",
                Description = "Protective and fashion",
                Price = 48M,
                Category = "WaterSports"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 3,
                Name = "Soccer Ball",
                Description = "FIFA approwed size",
                Price = 19M,
                Category = "Soccer"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 4,
                Name = "Corner Flags",
                Description = "Give your playing field",
                Price = 19M,
                Category = "Soccer"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 5,
                Name = "Stadium",
                Description = "Flat-packed 35,000-seat stadium",
                Price = 79000M,
                Category = "Soccer"
            });
        }
    }
}
