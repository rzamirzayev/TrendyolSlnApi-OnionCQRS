using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrendyolSln.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "trendyol");

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "trendyol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "trendyol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "trendyol",
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "trendyol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Priorty = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "trendyol",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Details",
                schema: "trendyol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "trendyol",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "trendyol",
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(3389), false, "Music & Garden" },
                    { 2, new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(3468), false, "Jewelery" },
                    { 3, new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(3472), true, "Outdoors" }
                });

            migrationBuilder.InsertData(
                schema: "trendyol",
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priorty", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(5497), false, "Elektrik", 0, 1, null },
                    { 2, new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(5498), false, "Moda", 0, 2, null },
                    { 3, new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(5499), false, "Kompyuter", 1, 1, null },
                    { 4, new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(5500), false, "KISI", 2, 1, null }
                });

            migrationBuilder.InsertData(
                schema: "trendyol",
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 8, 20, 10, 41, 18, 498, DateTimeKind.Utc).AddTicks(6290), "A ut culpa minima earum.", false, "Et." },
                    { 2, 3, new DateTime(2025, 8, 20, 10, 41, 18, 498, DateTimeKind.Utc).AddTicks(6493), "Beatae amet maiores quia sint.", true, "Sequi." },
                    { 3, 4, new DateTime(2025, 8, 20, 10, 41, 18, 498, DateTimeKind.Utc).AddTicks(6515), "Neque enim maxime quae et.", false, "Culpa." }
                });

            migrationBuilder.InsertData(
                schema: "trendyol",
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 8, 20, 10, 41, 18, 501, DateTimeKind.Utc).AddTicks(3394), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 41.68829884447150m, false, 975.21m, "Small Plastic Bacon" },
                    { 2, 3, new DateTime(2025, 8, 20, 10, 41, 18, 501, DateTimeKind.Utc).AddTicks(3574), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 22.408604796493650m, false, 839.84m, "Unbranded Soft Chips" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductId",
                schema: "trendyol",
                table: "Categories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                schema: "trendyol",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                schema: "trendyol",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details",
                schema: "trendyol");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "trendyol");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "trendyol");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "trendyol");
        }
    }
}
