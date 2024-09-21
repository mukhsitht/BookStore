using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, "George Orwell", 10m, new DateTime(2024, 9, 19, 20, 9, 15, 525, DateTimeKind.Local).AddTicks(2700), "Epic Reads Book Club" },
                    { 2, "John Green", 10m, new DateTime(2024, 9, 19, 20, 9, 15, 525, DateTimeKind.Local).AddTicks(2715), "A Sarah Dessen" },
                    { 3, "Melissa Pearl", 10m, new DateTime(2024, 9, 19, 20, 9, 15, 525, DateTimeKind.Local).AddTicks(2716), "Must-Read Teen Novel" },
                    { 4, " Jeramey Kraatz", 10m, new DateTime(2024, 9, 19, 20, 9, 15, 525, DateTimeKind.Local).AddTicks(2717), "Hunger for Dystopian" },
                    { 5, "John Green", 10m, new DateTime(2024, 9, 19, 20, 9, 15, 525, DateTimeKind.Local).AddTicks(2719), "The John Green" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
