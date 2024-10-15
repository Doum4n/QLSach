using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLSach.dbContext.Migrations
{
    /// <inheritdoc />
    public partial class c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "name" },
                values: new object[] { 6, "book99" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
