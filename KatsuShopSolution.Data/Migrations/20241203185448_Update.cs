using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KatsuShopSolution.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
                column: "ConcurrencyStamp",
                value: "9f040502-5507-46e5-8110-f1a19b693fd6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("22ebd3a9-ea29-4002-a442-99ed1385fa59"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bc50e350-69e1-4a0b-a744-eda3813c063c", "AQAAAAEAACcQAAAAEEm7HAgfayO4yCmcY1KJ+nvDmaBfBj9zZWcV1+G3Syyb6Bv3NUe8t4g1lfBJk99A1Q==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 18, 54, 47, 875, DateTimeKind.Utc).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 18, 54, 47, 875, DateTimeKind.Utc).AddTicks(4855));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
                column: "ConcurrencyStamp",
                value: "83024ee1-cab8-4898-8622-5d73b5e5a63d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("22ebd3a9-ea29-4002-a442-99ed1385fa59"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2957e2b3-a001-433b-88a4-fb5c1aaeca95", "AQAAAAEAACcQAAAAEA5/qGMqHVOmo5CtnPc/ktzAcLHnbodSN17c0ZNnsCi3W+yj14lagTxsvaS9Fog/iQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Description", "Name" },
                values: new object[] { new DateTime(2024, 12, 3, 17, 24, 48, 527, DateTimeKind.Utc).AddTicks(8314), "Chi tiết sản phẩm 1", "Product 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Description", "Name" },
                values: new object[] { new DateTime(2024, 12, 3, 17, 24, 48, 528, DateTimeKind.Utc).AddTicks(86), "Chi tiết sản phẩm 2", "Sản phẩm 2" });
        }
    }
}
