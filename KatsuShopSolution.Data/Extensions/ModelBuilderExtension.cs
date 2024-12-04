using KatsuShopSolution.Data.Entities;
using KatsuShopSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatsuShopSolution.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<AppConfig>().HasData(
                    new AppConfig()
                    {
                        Key = "HomeTitle",
                        Value = "This is home page of KatsuShop"
                    },
                    new AppConfig()
                    {
                        Key = "HomeKeyword",
                        Value = "This is keyword of KatsuShop"
                    },
                    new AppConfig()
                    {
                        Key = "HomeDescription",
                        Value = "This is description of KatsuShop"
                    }
                );
            builder.Entity<Language>().HasData(
                    new Language()
                    {
                        Id = "vi-VN",
                        Name = "Tiếng Việt",
                        IsDefault = true
                    },
                    new Language()
                    {
                        Id = "en-US",
                        Name = "English",
                        IsDefault = false
                    }
                );
            builder.Entity<Category>().HasData(
                    new Category()
                    {
                        Id = 1,
                        IsShowOnHome = true,
                        Name = "Category 1",
                        SortOrder = 1,
                        Status = Status.Active,
                        ParentId = null
                    },
                    new Category()
                    {
                        Id = 2,
                        IsShowOnHome = true,
                        Name = "Category 2",
                        SortOrder = 2,
                        Status = Status.Active,
                        ParentId = null
                    }
                );
            builder.Entity<CategoryTranslation>().HasData(
                   new CategoryTranslation()
                   {
                       Id = 1,
                       CategoryId = 1,
                       LanguageId = "vi-VN",
                       Name = "Danh mục 1",
                       SeoAlias = "danh-muc-1",
                       SeoDescription = "Danh mục 1",
                       SeoTitle = "Danh mục 1"
                   },
                   new CategoryTranslation()
                   {
                       Id = 2,
                       CategoryId = 1,
                       LanguageId = "en-US",
                       Name = "Category 1",
                       SeoAlias = "category-1",
                       SeoDescription = "Category 1",
                       SeoTitle = "Category 1"
                   },
                   new CategoryTranslation()
                   {
                       Id = 3,
                       CategoryId = 2,
                       LanguageId = "vi-VN",
                       Name = "Danh mục 2",
                       SeoAlias = "danh-muc-2",
                       SeoDescription = "Danh mục 2",
                       SeoTitle = "Danh mục 2"
                   },
                   new CategoryTranslation()
                   {
                       Id = 4,
                       CategoryId = 2,
                       LanguageId = "en-US",
                       Name = "Category 2",
                       SeoAlias = "category-2",
                       SeoDescription = "Category 2",
                       SeoTitle = "Category 2"
                   }
               );
            builder.Entity<Product>().HasData(
                    new Product()
                    {
                        Id = 1,
                        DateCreated = DateTime.UtcNow,
                        OriginalPrice = 100000,
                        Price = 120000,
                        Stock = 0,
                        ViewCount = 0,
                        Status = Status.Active,
                    },
                    new Product()
                    {
                        Id = 2,
                        DateCreated = DateTime.UtcNow,
                        OriginalPrice = 150000,
                        Price = 180000,
                        Stock = 0,
                        ViewCount = 0,
                        Status = Status.Active,
                    }
                );
            builder.Entity<ProductTranslation>().HasData(
                    new ProductTranslation()
                    {
                        Id = 1,
                        ProductId = 1,
                        LanguageId = "vi-VN",
                        Name = "Sản phẩm 1",
                        SeoTitle = "Sản phẩm 1",
                        SeoAlias = "san-pham-1",
                        SeoDescription = "Đây là thông tin sản phẩm 1",
                        Details = "Đây là chi tiết sản phẩm 1",
                    },
                    new ProductTranslation()
                    {
                        Id = 2,
                        ProductId = 1,
                        LanguageId = "en-US",
                        Name = "Product 1",
                        SeoTitle = "Product 1",
                        SeoAlias = "product-1",
                        SeoDescription = "This is description of product 1",
                        Details = "This is detail of product 1",
                    },
                    new ProductTranslation()
                    {
                        Id = 3,
                        ProductId = 2,
                        LanguageId = "vi-VN",
                        Name = "Sản phẩm 2",
                        SeoTitle = "Sản phẩm 2",
                        SeoAlias = "san-pham-2",
                        Details = "Đây là chi tiết sản phẩm 2",
                        SeoDescription = "Đây là thông tin sản phẩm 2",
                    },
                    new ProductTranslation()
                    {
                        Id = 4,
                        ProductId = 2,
                        LanguageId = "en-US",
                        Name = "Product 2",
                        SeoTitle = "Product 2",
                        SeoAlias = "product-2",
                        SeoDescription = "This is description of product 2",
                        Details = "This is detail of product 2",
                    }
                );
            builder.Entity<ProductInCategory>().HasData(
                    new ProductInCategory() { ProductId = 1, CategoryId = 1 },
                    new ProductInCategory() { ProductId = 2, CategoryId = 2 }
                );

            var roleId = new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3301");
            var adminId = new Guid("22EBD3A9-EA29-4002-A442-99ED1385FA59");
            builder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator role"
                });

            var hasher = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(
                    new AppUser
                    {
                        Id = adminId,
                        UserName = "admin",
                        NormalizedUserName = "admin",
                        Email = "mrk4tsu@gmail.com",
                        NormalizedEmail = "mrk4tsu@gmail.com",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Admin@123"),
                        SecurityStamp = string.Empty,
                        FullName = "Nguyen Duc Thang",
                        Dob = new DateTime(2002, 12, 22)
                    }
                );
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                    new IdentityUserRole<Guid>
                    {
                        RoleId = roleId,
                        UserId = adminId
                    });
        }
    }
}
