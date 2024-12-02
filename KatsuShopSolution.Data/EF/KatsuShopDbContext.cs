using KatsuShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KatsuShopSolution.Data.EF
{
    public class KatsuShopDbContext : DbContext
    {
        public KatsuShopDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

}
