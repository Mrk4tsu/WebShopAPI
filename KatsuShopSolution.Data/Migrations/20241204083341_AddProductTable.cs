using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KatsuShopSolution.Data.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

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
    }
}
