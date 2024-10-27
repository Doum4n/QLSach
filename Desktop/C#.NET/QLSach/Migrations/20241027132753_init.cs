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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    author_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_author_id",
                        column: x => x.author_id,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookInteractions",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    liked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    saved = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInteractions", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BookInteractions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookInteractions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    path = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    book_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.path);
                    table.ForeignKey(
                        name: "FK_Photos_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Molestias atque reprehenderit odio quae non explicabo.", "Willa" },
                    { 2, "Labore ducimus aliquam culpa praesentium quo facilis.", "Filomena" },
                    { 3, "Voluptatem eos non.", "Aurelie" },
                    { 4, "Et autem odio ut assumenda recusandae.", "Brannon" },
                    { 5, "Ducimus minima corporis vel omnis.", "Kurt" },
                    { 6, "Veniam aut quaerat neque sequi aut.", "Bette" },
                    { 7, "Autem nulla quibusdam eveniet veritatis.", "Lee" },
                    { 8, "Et voluptatem fuga numquam.", "Corene" },
                    { 9, "Sunt deleniti et et eos.", "Tamara" },
                    { 10, "Quod officia reiciendis eveniet et laboriosam est quo assumenda.", "Johan" },
                    { 11, "At quas cupiditate dolores sunt voluptatem est sunt vel.", "Mariano" },
                    { 12, "Dignissimos quasi ut aliquam nam soluta sit cupiditate placeat illo.", "Pattie" },
                    { 13, "Deserunt dolore dolore laudantium dignissimos earum quae aspernatur doloremque sit.", "Braden" },
                    { 14, "In nemo vel.", "Chanel" },
                    { 15, "Doloremque recusandae est unde necessitatibus aliquid et id eligendi ut.", "Horacio" },
                    { 16, "Voluptatem aut consequatur est autem.", "Vern" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "description", "name" },
                values: new object[,]
                {
                    { 1, 1, "Expedita sit qui quaerat est blanditiis dolorum eveniet amet voluptas. Dolorem nemo illum quaerat esse. Deleniti quibusdam ea libero ut quas ipsam. Repellat suscipit aliquid.", "In omnis tenetur maiores qui ea fugiat quia." },
                    { 2, 2, "Optio totam est voluptatem animi dolores quidem et. Eos aut omnis consectetur ut qui tempora beatae. Est nisi aut voluptates excepturi voluptas doloribus nemo qui.", "Sunt nam quo ad magni nihil quam magni." },
                    { 3, 3, "Sed aut quidem necessitatibus nihil vero. Consequatur reprehenderit minus doloremque enim est enim veritatis. Et eveniet non tenetur fugit est. Nihil natus temporibus odio excepturi iure necessitatibus et earum laboriosam. Alias non architecto facere et. Quo cupiditate reprehenderit accusamus ut.", "In voluptates facere aut sint optio officia voluptas est corporis." },
                    { 4, 4, "Iusto in quas. Quis rem placeat repudiandae provident rerum recusandae. Ullam minus culpa optio. Nobis at asperiores et sit. Et ea qui.", "Ut voluptates eveniet quibusdam." },
                    { 5, 5, "Repudiandae dolorem non ipsam. Perspiciatis qui blanditiis laudantium possimus autem aut. Qui sint aut fugiat et. Maxime animi quam qui esse sit exercitationem sunt impedit. Aut et et.", "Quidem placeat nam modi eos ea voluptatem in nemo consequuntur." },
                    { 6, 6, "Nulla repudiandae rerum dolorem voluptatem temporibus amet alias et rem. Et veritatis nihil natus aut rerum. Sed deserunt aut ut expedita.", "Perspiciatis sequi architecto aut a cupiditate sit veniam." },
                    { 7, 7, "Nulla itaque eius sequi explicabo corrupti autem odit. Ipsam doloremque in. Aut voluptates consectetur voluptates molestiae. Dolore qui et.", "Rem nam pariatur illum asperiores libero molestias asperiores." },
                    { 8, 8, "Nihil tenetur nihil est ea. In libero natus architecto iste enim sapiente. Qui ut rerum mollitia dolorem rem similique fugiat nulla aut. Temporibus soluta vero aut. Vel repellat assumenda recusandae excepturi quia deleniti magni perferendis.", "Deserunt autem eos." },
                    { 9, 9, "Molestias a eos officia soluta veniam rerum cumque. Et qui qui laudantium nobis voluptas sed eos. Et accusamus reprehenderit ipsum. Labore rem provident dolores. Quis quis expedita quo dolores explicabo quis. Voluptatem sed ut autem sint unde nulla.", "Commodi ut voluptatem dolor quos quasi inventore." },
                    { 10, 10, "Cum iusto voluptatem voluptatem maxime earum. Quod quo quod incidunt inventore a. Nihil quos aut dolore beatae alias autem eveniet. Autem id voluptas quia eaque. Possimus dolorum perspiciatis harum nisi sunt sit at. Recusandae debitis sed aperiam consequatur.", "Voluptatem laudantium rerum et." },
                    { 11, 11, "Qui qui labore vitae et maiores sunt ut sed libero. Laborum incidunt iure quibusdam veniam hic. Odit quia recusandae quisquam corporis in. Rerum doloremque quo. Mollitia veniam provident aut veniam cum a doloremque.", "Quidem veritatis sapiente et provident maiores a." },
                    { 12, 12, "Sed vel quibusdam at illo eum. Vero quia qui et. Id doloribus dignissimos incidunt ut et autem et iure eos. Ut est voluptatem sequi omnis vitae itaque est. Vero alias sunt vitae sequi dolorum et.", "Eos culpa doloribus quaerat facere quis officia sed repellendus." },
                    { 13, 13, "Veniam reiciendis non quae nostrum. Qui reprehenderit culpa soluta ipsa eius voluptates temporibus. Quia dolorem repellat quos. Eum aut consequuntur et consectetur rem nisi.", "Fuga consequatur doloribus reprehenderit voluptates." },
                    { 14, 14, "Fugiat aut recusandae hic magnam nulla et. Quam magni voluptas nesciunt optio qui amet iure. Aut unde aliquid laborum ut est et. Cum similique repudiandae. A excepturi esse aut iusto ea eveniet non deserunt.", "Fuga nihil maxime est nesciunt ipsum reprehenderit." },
                    { 15, 15, "Nisi accusamus aliquam. Recusandae dolorem saepe rerum neque nam nobis eum. Dolor sit voluptatem dolorum velit facilis. Pariatur rerum eaque vel rerum qui eius.", "Vitae numquam et nam ut." },
                    { 16, 16, "Tempore architecto ea. Ut recusandae ipsum temporibus. Voluptas cupiditate laborum. Repellendus earum eum inventore.", "Et maiores id molestiae tenetur adipisci minus et repellat." }
                });

            migrationBuilder.InsertData(
                table: "Photos",
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
                name: "IX_BookInteractions_UserId",
                table: "BookInteractions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_author_id",
                table: "Books",
                column: "author_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_book_id",
                table: "Photos",
                column: "book_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookInteractions");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
