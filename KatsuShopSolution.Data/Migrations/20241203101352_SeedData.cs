using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KatsuShopSolution.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTitle", "This is home page of KatsuShop" },
                    { "HomeKeyword", "This is keyword of KatsuShop" },
                    { "HomeDescription", "This is description of KatsuShop" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "Name", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, "Category 1", null, 1, 1 },
                    { 2, true, "Category 2", null, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "vi-VN", true, "Tiếng Việt" },
                    { "en-US", false, "English" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreated", "Description", "Name", "OriginalPrice", "Price", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 3, 10, 13, 52, 430, DateTimeKind.Utc).AddTicks(1144), "Chi tiết sản phẩm 1", "Product 1", 100000m, 120000m, 1 },
                    { 2, new DateTime(2024, 12, 3, 10, 13, 52, 430, DateTimeKind.Utc).AddTicks(2972), "Chi tiết sản phẩm 2", "Sản phẩm 2", 150000m, 180000m, 1 }
                });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, 1, "vi-VN", "Danh mục 1", "danh-muc-1", "Danh mục 1", "Danh mục 1" },
                    { 3, 2, "vi-VN", "Danh mục 2", "danh-muc-2", "Danh mục 2", "Danh mục 2" },
                    { 2, 1, "en-US", "Category 1", "category-1", "Category 1", "Category 1" },
                    { 4, 2, "en-US", "Category 2", "category-2", "Category 2", "Category 2" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductTranslations",
                columns: new[] { "Id", "Details", "LanguageId", "Name", "ProductId", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, "Đây là chi tiết sản phẩm 1", "vi-VN", "Sản phẩm 1", 1, "san-pham-1", "Đây là thông tin sản phẩm 1", "Sản phẩm 1" },
                    { 2, "This is detail of product 1", "en-US", "Product 1", 1, "product-1", "This is description of product 1", "Product 1" },
                    { 3, "Đây là chi tiết sản phẩm 2", "vi-VN", "Sản phẩm 2", 2, "san-pham-2", "Đây là thông tin sản phẩm 2", "Sản phẩm 2" },
                    { 4, "This is detail of product 2", "en-US", "Product 2", 2, "product-2", "This is description of product 2", "Product 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDescription");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyword");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "en-US");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "vi-VN");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
