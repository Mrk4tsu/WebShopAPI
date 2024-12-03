using KatsuShopSolution.Data.Configurations;
using KatsuShopSolution.Data.Entities;
using KatsuShopSolution.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace KatsuShopSolution.Data.EF
{
    public class KatsuShopDbContext : DbContext
    {
        public KatsuShopDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region[Fluent API Configure]
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            //Config Cart
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            //Config Category
            modelBuilder.ApplyConfiguration(new CategoryConfigurarion());
            //Config CategoryTranslations
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            //Config Contacts
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            //Config Language
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            //Config Order
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            //Config OrderDetail
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            //Config Product
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //Config ProductTranslations
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            //Config ProductInCategory
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            //Config Promotion
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            //Config Transaction
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            #endregion

            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }

}
