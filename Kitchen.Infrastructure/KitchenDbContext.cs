using Kitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Kitchen.Infrastructure
{
    public class KitchenDbContext : DbContext
    {
        public KitchenDbContext(DbContextOptions<KitchenDbContext> optinos) : base(optinos) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<FoodCategory> FoodCategories { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodPriceHistory> FoodPrices { get; set; }
    }
}
