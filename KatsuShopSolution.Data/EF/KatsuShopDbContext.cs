using KatsuShopSolution.Data.Configurations;
using KatsuShopSolution.Data.Entities;
using KatsuShopSolution.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace KatsuShopSolution.Data.EF
{
    public class KatsuShopDbContext : IdentityDbContext<AppUser, AppRole, Guid>
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
            //Config AppUser
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            //Config AppRole
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            #endregion

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);


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
