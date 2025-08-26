using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrendyolSln.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct",
                schema: "trendyol");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                schema: "trendyol",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "trendyol",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "trendyol",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 26, 6, 49, 13, 338, DateTimeKind.Utc).AddTicks(1034), "Electronics & Tools" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 26, 6, 49, 13, 338, DateTimeKind.Utc).AddTicks(1148), "Garden & Sports" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 26, 6, 49, 13, 338, DateTimeKind.Utc).AddTicks(1155), "Shoes, Music & Outdoors" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 26, 6, 49, 13, 338, DateTimeKind.Utc).AddTicks(3205));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 26, 6, 49, 13, 338, DateTimeKind.Utc).AddTicks(3208));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 26, 6, 49, 13, 338, DateTimeKind.Utc).AddTicks(3209));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 26, 6, 49, 13, 338, DateTimeKind.Utc).AddTicks(3210));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 26, 6, 49, 13, 339, DateTimeKind.Utc).AddTicks(4525), "Voluptate exercitationem voluptates et quasi.", "Consequatur." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 26, 6, 49, 13, 339, DateTimeKind.Utc).AddTicks(4633), "Et omnis commodi culpa quia.", "Quo." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 26, 6, 49, 13, 339, DateTimeKind.Utc).AddTicks(4653), "In veniam dignissimos ut cum.", "Repellat." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 26, 6, 49, 13, 340, DateTimeKind.Utc).AddTicks(9940), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 6.968809356708850m, 922.10m, "Practical Fresh Soap" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 26, 6, 49, 13, 341, DateTimeKind.Utc).AddTicks(41), 16.089740482706650m, 195.89m, "Generic Frozen Shoes" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                schema: "trendyol",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories",
                schema: "trendyol");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                schema: "trendyol",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    ProductsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalSchema: "trendyol",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalSchema: "trendyol",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 49, 28, 88, DateTimeKind.Utc).AddTicks(4158), "Home & Movies" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 49, 28, 88, DateTimeKind.Utc).AddTicks(4801), "Health & Home" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 49, 28, 88, DateTimeKind.Utc).AddTicks(4816), "Shoes & Books" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 49, 28, 88, DateTimeKind.Utc).AddTicks(7693));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 49, 28, 88, DateTimeKind.Utc).AddTicks(7697));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 49, 28, 88, DateTimeKind.Utc).AddTicks(7698));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 49, 28, 88, DateTimeKind.Utc).AddTicks(7699));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 49, 28, 90, DateTimeKind.Utc).AddTicks(6812), "Doloribus dolores itaque cum ut.", "Aut." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 49, 28, 90, DateTimeKind.Utc).AddTicks(6928), "In laudantium laborum soluta consequatur.", "Consequatur." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 49, 28, 90, DateTimeKind.Utc).AddTicks(6950), "Minus cumque velit eos nobis.", "Rerum." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 49, 28, 91, DateTimeKind.Utc).AddTicks(9947), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 1.6031115172538700m, 697.84m, "Gorgeous Plastic Computer" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 49, 28, 92, DateTimeKind.Utc).AddTicks(42), 33.837774854049750m, 983.72m, "Tasty Plastic Chips" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                schema: "trendyol",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
