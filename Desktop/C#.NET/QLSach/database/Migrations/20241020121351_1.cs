using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QLSach.database.migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
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
                    { 1, "Occaecati ut beatae et.", "Mara" },
                    { 2, "Corporis mollitia quasi laboriosam ut.", "Camren" },
                    { 3, "Suscipit consequuntur aliquam blanditiis consequatur explicabo pariatur porro delectus.", "Marlon" },
                    { 4, "Accusantium eos aut perferendis doloremque et.", "Unique" },
                    { 5, "Non commodi nihil non.", "Jaden" },
                    { 6, "Consequatur nobis maiores eos optio voluptatem maiores.", "Nathaniel" },
                    { 7, "Culpa praesentium non veniam.", "Violet" },
                    { 8, "Eum ut aut consectetur odio minima ut aspernatur.", "Lamar" },
                    { 9, "Libero sed id quia.", "Nora" },
                    { 10, "Est omnis et qui est et dicta occaecati molestiae.", "Savanna" },
                    { 11, "Error ut itaque at doloremque ad.", "Petra" },
                    { 12, "Aut quidem autem numquam soluta.", "Gaetano" },
                    { 13, "Rerum modi rem.", "Ellie" },
                    { 14, "Placeat pariatur sint.", "Jadon" },
                    { 15, "Ullam tempore amet quis sapiente sunt.", "Alison" },
                    { 16, "Quidem ab blanditiis eaque aut consectetur numquam dolor deleniti impedit.", "Maxwell" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "author_id", "description", "name" },
                values: new object[,]
                {
                    { 1, 1, null, "Assumenda fugiat voluptas voluptatibus repellendus eveniet ut expedita." },
                    { 2, 2, null, "Ut non delectus qui dolor placeat id similique.\nAsperiores molestias numquam ea voluptates est quasi dolor.\nIusto labore voluptate debitis nemo.\nFacilis at ipsa ratione quisquam delectus neque provident fugit." },
                    { 3, 3, null, "voluptatem" },
                    { 4, 4, null, "Occaecati ullam hic dolorem laudantium aspernatur sint. Consequatur enim optio praesentium. Maxime occaecati voluptatibus blanditiis accusantium harum." },
                    { 5, 5, null, "Beatae aut voluptatibus eaque.\nVoluptas accusantium laudantium modi incidunt.\nAccusantium voluptates autem aliquid error doloribus illum possimus et." },
                    { 6, 6, null, "aspernatur" },
                    { 7, 7, null, "Qui eaque nemo." },
                    { 8, 8, null, "Perferendis ut officia." },
                    { 9, 9, null, "Et atque vero et et unde non est rerum.\nEst deleniti natus.\nMaxime ea perferendis aut iure quam.\nEligendi placeat quia accusantium quis quo eligendi rem.\nDeleniti dolorem quasi exercitationem voluptatem sequi tempora magnam assumenda." },
                    { 10, 10, null, "Nulla veniam rerum eligendi et.\nEt et commodi quaerat ipsum.\nSed dolor sed sunt voluptatem sint sit dolor facere.\nUt dolorem voluptatem ex tempore quo maiores totam omnis." },
                    { 11, 11, null, "Laudantium sapiente quod blanditiis molestiae et illum." },
                    { 12, 12, null, "quae" },
                    { 13, 13, null, "provident" },
                    { 14, 14, null, "Corrupti et modi aperiam esse.\nEt tempora impedit sunt itaque doloribus.\nFacere in voluptatem.\nVitae accusantium error dolorem.\nRepellendus harum in odio illum ipsa voluptatem quo quas qui.\nIpsam inventore nemo." },
                    { 15, 15, null, "Quaerat similique quis dolorem adipisci eum.\nEst nisi excepturi necessitatibus odio molestias ut.\nUt explicabo error et quia et sequi corrupti cum culpa.\nArchitecto optio veritatis voluptatum et et quam." },
                    { 16, 16, null, "dolor" }
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
