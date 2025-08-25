using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrendyolSln.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_ProductId",
                schema: "trendyol",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductId",
                schema: "trendyol",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "trendyol",
                table: "Categories");

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
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 49, 28, 92, DateTimeKind.Utc).AddTicks(42), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 33.837774854049750m, 983.72m, "Tasty Plastic Chips" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                schema: "trendyol",
                table: "CategoryProduct",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct",
                schema: "trendyol");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "trendyol",
                table: "Categories",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 947, DateTimeKind.Utc).AddTicks(3859), "Books & Toys" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 947, DateTimeKind.Utc).AddTicks(3961), "Home & Clothing" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 947, DateTimeKind.Utc).AddTicks(3970), "Industrial" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 947, DateTimeKind.Utc).AddTicks(6172), null });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 947, DateTimeKind.Utc).AddTicks(6175), null });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 947, DateTimeKind.Utc).AddTicks(6175), null });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 947, DateTimeKind.Utc).AddTicks(6176), null });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 948, DateTimeKind.Utc).AddTicks(9036), "Explicabo perspiciatis ex inventore nostrum.", "Corporis." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 948, DateTimeKind.Utc).AddTicks(9154), "Hic adipisci animi dolores inventore.", "Sit." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 948, DateTimeKind.Utc).AddTicks(9174), "Laborum facere reiciendis velit omnis.", "Et." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 950, DateTimeKind.Utc).AddTicks(8057), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 19.476875875624400m, 556.01m, "Intelligent Concrete Sausages" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 950, DateTimeKind.Utc).AddTicks(8316), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 13.662159284315450m, 935.57m, "Incredible Frozen Table" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductId",
                schema: "trendyol",
                table: "Categories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_ProductId",
                schema: "trendyol",
                table: "Categories",
                column: "ProductId",
                principalSchema: "trendyol",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
