using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrendyolSln.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 43, 29, 947, DateTimeKind.Utc).AddTicks(6172));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 43, 29, 947, DateTimeKind.Utc).AddTicks(6175));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 43, 29, 947, DateTimeKind.Utc).AddTicks(6175));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 43, 29, 947, DateTimeKind.Utc).AddTicks(6176));

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
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 43, 29, 950, DateTimeKind.Utc).AddTicks(8316), 13.662159284315450m, 935.57m, "Incredible Frozen Table" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(3389), "Music & Garden" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(3468), "Jewelery" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(3472), "Outdoors" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(5497));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(5498));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(5499));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 20, 10, 41, 18, 496, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 41, 18, 498, DateTimeKind.Utc).AddTicks(6290), "A ut culpa minima earum.", "Et." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 41, 18, 498, DateTimeKind.Utc).AddTicks(6493), "Beatae amet maiores quia sint.", "Sequi." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 41, 18, 498, DateTimeKind.Utc).AddTicks(6515), "Neque enim maxime quae et.", "Culpa." });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 41, 18, 501, DateTimeKind.Utc).AddTicks(3394), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 41.68829884447150m, 975.21m, "Small Plastic Bacon" });

            migrationBuilder.UpdateData(
                schema: "trendyol",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 20, 10, 41, 18, 501, DateTimeKind.Utc).AddTicks(3574), 22.408604796493650m, 839.84m, "Unbranded Soft Chips" });
        }
    }
}
