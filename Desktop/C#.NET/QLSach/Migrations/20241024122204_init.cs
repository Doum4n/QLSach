using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QLSach.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    author_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_author_id",
                        column: x => x.author_id,
                        principalTable: "Authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    path = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    book_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.path);
                    table.ForeignKey(
                        name: "FK_Photo_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Tempora consequatur est.", "Dewayne" },
                    { 2, "A corporis molestiae soluta totam ut temporibus.", "Lorena" },
                    { 3, "Sint sint perferendis.", "Pedro" },
                    { 4, "Error vel tenetur dolorum necessitatibus.", "Constantin" },
                    { 5, "Iusto quis culpa voluptas omnis.", "Marilie" },
                    { 6, "Ut consequatur sunt ut iure quam laudantium minus.", "Ron" },
                    { 7, "Minus cupiditate consequatur expedita inventore.", "Dallas" },
                    { 8, "Eius impedit expedita.", "Meredith" },
                    { 9, "Praesentium nihil et officiis quo.", "Pietro" },
                    { 10, "Quasi asperiores omnis natus dolores voluptatem animi iusto quos velit.", "Elenor" },
                    { 11, "Distinctio veritatis nihil alias necessitatibus ut ut ducimus.", "Eve" },
                    { 12, "Saepe ab est eum rerum nisi.", "Quinten" },
                    { 13, "Et voluptate reiciendis deleniti.", "Hermina" },
                    { 14, "Aut et autem sunt error ut.", "Arthur" },
                    { 15, "Nisi quisquam magnam minus et.", "Lavada" },
                    { 16, "Amet at enim sit dolore.", "Jaime" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "author_id", "description", "name" },
                values: new object[,]
                {
                    { 1, 1, null, "Eligendi eaque error tenetur." },
                    { 2, 2, null, "Esse excepturi sunt." },
                    { 3, 3, null, "Ratione a reprehenderit laudantium non nesciunt animi aut voluptatem." },
                    { 4, 4, null, "Libero modi rerum dicta ut." },
                    { 5, 5, null, "Et tempora exercitationem alias eligendi nobis quia." },
                    { 6, 6, null, "Aperiam laboriosam numquam excepturi et at ea et excepturi ea." },
                    { 7, 7, null, "Repudiandae dolorum numquam." },
                    { 8, 8, null, "Soluta quod praesentium placeat corrupti." },
                    { 9, 9, null, "Veritatis corporis deserunt accusamus delectus rerum exercitationem doloribus." },
                    { 10, 10, null, "Debitis repellat expedita provident numquam ipsum enim sunt id quo." },
                    { 11, 11, null, "Dolore itaque asperiores qui libero deleniti." },
                    { 12, 12, null, "Harum enim voluptas." },
                    { 13, 13, null, "Sequi pariatur vel et non et fugiat recusandae voluptas." },
                    { 14, 14, null, "Rerum deserunt nisi officia consequatur quibusdam animi laborum et est." },
                    { 15, 15, null, "Ut quaerat et ratione est rem aperiam blanditiis." },
                    { 16, 16, null, "Reprehenderit explicabo quae." }
                });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "path", "book_id" },
                values: new object[,]
                {
                    { "10fake path", 9 },
                    { "11fake path", 10 },
                    { "12fake path", 11 },
                    { "13fake path", 12 },
                    { "14fake path", 13 },
                    { "15fake path", 14 },
                    { "16fake path", 15 },
                    { "17fake path", 16 },
                    { "2fake path", 1 },
                    { "3fake path", 2 },
                    { "4fake path", 3 },
                    { "5fake path", 4 },
                    { "6fake path", 5 },
                    { "7fake path", 6 },
                    { "8fake path", 7 },
                    { "9fake path", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_author_id",
                table: "Books",
                column: "author_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_book_id",
                table: "Photo",
                column: "book_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
