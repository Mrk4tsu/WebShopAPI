using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KatsuShopSolution.Data.Migrations
{
    public partial class UpdateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
                column: "ConcurrencyStamp",
                value: "93ad727c-cf64-4891-9b94-71446e63c941");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("22ebd3a9-ea29-4002-a442-99ed1385fa59"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21a5e53f-f7c0-42b8-90bd-2bbbe0b0a277", "AQAAAAEAACcQAAAAEO8qiPRVJVtQWq4mW2zd79LSnrt/WNNFcBCEIbEtZAN/4SJ6PDSJVQyDmWp5Ux/R5w==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 12, 4, 13, 31, 29, 367, DateTimeKind.Utc).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 12, 4, 13, 31, 29, 367, DateTimeKind.Utc).AddTicks(5131));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
                column: "ConcurrencyStamp",
                value: "45f11b20-eb1c-45fa-9275-d41b5f094fe6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("22ebd3a9-ea29-4002-a442-99ed1385fa59"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2d53652-514a-4de4-8462-f2f671a7cf6f", "AQAAAAEAACcQAAAAEAyfg6ZR4wqD4hRRMOILD5aSjXH5D2JLbGNlRFsKGjx3kVJbICmTlfEOUJRNlOXGbg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 12, 4, 8, 33, 40, 902, DateTimeKind.Utc).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 12, 4, 8, 33, 40, 902, DateTimeKind.Utc).AddTicks(2631));
        }
    }
}
