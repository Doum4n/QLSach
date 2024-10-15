using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QLSach.dbContext.Migrations
{
    /// <inheritdoc />
    public partial class BookSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "book6");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "book1" },
                    { 2, "book2" },
                    { 3, "book3" },
                    { 4, "book4" },
                    { 5, "book5" },
                    { 7, "book7" },
                    { 8, "book8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "book99");
        }
    }
}
