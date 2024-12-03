using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KatsuShopSolution.Data.Migrations
{
    public partial class SeedingDataIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), "83024ee1-cab8-4898-8622-5d73b5e5a63d", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), new Guid("22ebd3a9-ea29-4002-a442-99ed1385fa59") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("22ebd3a9-ea29-4002-a442-99ed1385fa59"), 0, "2957e2b3-a001-433b-88a4-fb5c1aaeca95", new DateTime(2002, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "mrk4tsu@gmail.com", true, "Nguyen Duc Thang", false, null, "mrk4tsu@gmail.com", "admin", "AQAAAAEAACcQAAAAEA5/qGMqHVOmo5CtnPc/ktzAcLHnbodSN17c0ZNnsCi3W+yj14lagTxsvaS9Fog/iQ==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 17, 24, 48, 527, DateTimeKind.Utc).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 17, 24, 48, 528, DateTimeKind.Utc).AddTicks(86));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), new Guid("22ebd3a9-ea29-4002-a442-99ed1385fa59") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("22ebd3a9-ea29-4002-a442-99ed1385fa59"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 17, 11, 58, 832, DateTimeKind.Utc).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 12, 3, 17, 11, 58, 832, DateTimeKind.Utc).AddTicks(4667));
        }
    }
}
