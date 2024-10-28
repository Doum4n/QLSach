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
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<byte>(type: "tinyint unsigned", nullable: false)
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
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    parent_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_parent_id",
                        column: x => x.parent_id,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
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

            migrationBuilder.CreateTable(
                name: "BookInteractions",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_BookInteractions_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Velit accusamus unde laudantium explicabo error qui cupiditate veritatis recusandae.", "Julio" },
                    { 2, "Eaque non quasi qui nostrum deleniti porro est illo.", "Constantin" },
                    { 3, "Corporis fugiat consectetur doloremque.", "Jeff" },
                    { 4, "Ut ut quidem dolor molestias eos.", "Roslyn" },
                    { 5, "Possimus perspiciatis veritatis delectus corrupti itaque iste.", "Randal" },
                    { 6, "Itaque dicta expedita vitae neque ducimus architecto et in.", "Jazmyne" },
                    { 7, "Enim velit doloribus beatae.", "Cedrick" },
                    { 8, "Deserunt doloribus quibusdam.", "Yoshiko" },
                    { 9, "Facilis et cum aliquam rerum quis non delectus.", "Karolann" },
                    { 10, "Tenetur ad voluptatibus rerum dolorem.", "Irwin" },
                    { 11, "Rerum sit repellendus numquam consequatur sapiente.", "Daron" },
                    { 12, "Ut alias totam ad corrupti voluptatem beatae libero.", "Gladyce" },
                    { 13, "Magnam numquam ad ducimus et aperiam fugit harum aut.", "Lazaro" },
                    { 14, "Quisquam eos laudantium quis recusandae dolore.", "Carson" },
                    { 15, "Quibusdam minima nesciunt ut nam consequuntur.", "Julia" },
                    { 16, "Tempora ut consequatur iusto nesciunt.", "Clyde" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Maxime voluptatem voluptatem quidem illo facere.\nLabore non libero consequatur eaque.", "Morgan Pacocha" },
                    { 2, "Neque inventore incidunt voluptate sequi dolorum neque necessitatibus at placeat.\nDistinctio consequatur perferendis ullam velit.", "Julius Hickle" },
                    { 3, "Blanditiis at dolores rerum blanditiis quas magni dolores placeat quis. Rerum sed voluptas. Quasi natus at veritatis ab unde enim. Perferendis velit est a necessitatibus animi dolores doloribus.", "Brain Muller" },
                    { 4, "est", "Emmy Mitchell" },
                    { 5, "et", "Leora Gislason" },
                    { 6, "libero", "Rosanna Macejkovic" },
                    { 7, "Voluptatem ut assumenda sed corporis eum tenetur.\nSit neque autem et rem temporibus assumenda.\nAccusantium qui deserunt distinctio atque et.\nNon eaque adipisci quo et accusantium sapiente illum dicta praesentium.", "Linda Schumm" },
                    { 8, "non", "Obie Mohr" },
                    { 9, "Eos dolore id quod velit.", "Laverna Hilpert" },
                    { 10, "Culpa adipisci iusto velit aliquam tenetur repudiandae iure vero neque. Fugit dolores illum. Quis praesentium et.", "Reese Cruickshank" },
                    { 11, "Et facere est aut necessitatibus possimus enim voluptatibus. Quibusdam nihil id odio voluptatem dolorem id ipsam saepe. Nostrum qui omnis voluptas quis quae rerum sunt architecto debitis. Non architecto quasi sunt possimus provident nam laborum nihil. Et quia rerum ut provident sunt occaecati est id voluptate.", "Susanna Kerluke" },
                    { 12, "veritatis", "Asa Feeney" },
                    { 13, "Labore voluptatem voluptatem modi.\nDucimus qui vel voluptatem rem rem.\nNon animi optio in.", "Luisa Predovic" },
                    { 14, "Quia ut et sequi quod magni qui ut inventore necessitatibus.\nUllam sapiente rerum aut ut.\nAutem voluptates rerum explicabo.\nAd eius dolore.\nSequi est facere minus deserunt ut voluptas eligendi rerum.", "Hector Russel" },
                    { 15, "Eveniet laudantium nulla dicta dicta.\nEt autem quo eius libero et.\nAut neque sequi sint.", "Lila Ernser" },
                    { 16, "Error eaque laboriosam voluptatibus facilis aut et architecto quam.\nA porro non commodi nulla.", "Benton Reichert" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "description", "name", "rating" },
                values: new object[,]
                {
                    { 1, 1, "Amet suscipit magnam culpa ad eos nisi. Non tempore quaerat. Dolore sunt nisi officiis necessitatibus.", "Et et quis dolore consectetur quia non itaque.", (byte)0 },
                    { 2, 2, "Fugiat rem ullam aut veniam aliquid. Officiis quos et odio mollitia. Officiis ducimus eos quia velit dolor nostrum a adipisci odit. Sed consequatur eligendi. Non ut sed nihil quo et omnis perferendis in. Quaerat sint alias asperiores ut et.", "Impedit sed non ipsa maxime assumenda.", (byte)0 },
                    { 3, 3, "Natus amet sint voluptatem officia. Occaecati enim cumque vitae ut qui ut molestiae corrupti. Repellat consequuntur est perspiciatis ut nihil iste dolorum expedita ipsum. Ex et atque esse quod voluptates dolorem. Delectus eos sunt a tempora veniam id ea.", "Voluptatum ut ut quo non non rerum quo molestiae.", (byte)0 },
                    { 4, 4, "Eaque qui ipsum rem occaecati qui praesentium consequuntur corporis. Ipsam et repellendus et voluptas. Asperiores ea ea et sint cumque incidunt atque. Sed accusantium voluptatibus blanditiis. Aut velit possimus nobis consequatur velit excepturi facere.", "Maiores qui autem porro rerum velit officia necessitatibus corrupti quo.", (byte)0 },
                    { 5, 5, "Eos aliquam a nam sed odio natus praesentium. Mollitia aperiam quod quam ratione tempore corrupti voluptatem commodi rerum. Odit quis accusantium pariatur molestiae quis voluptatem unde quidem. Facilis enim veniam in. Et hic aut vel molestiae labore tempora reprehenderit. Omnis ipsa hic rerum voluptatem non eum.", "Nesciunt numquam eum.", (byte)0 },
                    { 6, 6, "Numquam aliquam rem dolorem velit quo. Unde alias cumque sint. Enim qui quam eos aut porro in ex et voluptatibus. Et sed molestias et est dicta. Ipsa et corrupti et molestiae.", "Atque a at quia.", (byte)0 },
                    { 7, 7, "At corrupti quidem ducimus saepe et distinctio ut. Voluptatem minima eligendi tenetur dolorem soluta quo nobis non. Adipisci sequi illum eaque nesciunt eos. Impedit vero et architecto tempora placeat. Explicabo veniam est officia cupiditate ut dolores architecto et. Explicabo totam quia ipsum exercitationem occaecati ab eum nobis.", "Quo minima porro voluptas harum harum magni odit.", (byte)0 },
                    { 8, 8, "Est iste doloribus ipsa. Est incidunt ipsum laborum labore. Voluptate natus unde debitis harum ratione nihil quis maxime. Esse reprehenderit corrupti eaque excepturi porro. Deleniti numquam eligendi.", "Dolores suscipit aut culpa cumque.", (byte)0 },
                    { 9, 9, "Voluptate repellendus fugit at. Voluptatem nesciunt ut molestias cumque est. Quis labore tempore dignissimos et et optio sit.", "Deserunt et animi repellat dolore consequatur consectetur distinctio officiis.", (byte)0 },
                    { 10, 10, "Minima atque maiores esse error. Iure temporibus quia. Voluptatum hic praesentium omnis reiciendis. Ad neque cupiditate aliquid. Quasi laudantium quia illo quas incidunt impedit. Doloremque necessitatibus quisquam nobis illo.", "Ducimus culpa est impedit dolores quia totam porro sed.", (byte)0 },
                    { 11, 11, "Est ipsum veritatis quia inventore quia et eum ratione. Sit voluptas eum consequatur et odit. Optio aut temporibus voluptatibus necessitatibus molestiae saepe. Modi reiciendis ut eius. Dicta ab qui exercitationem accusamus hic et perferendis. Et dolores et sapiente repellat et.", "Eaque explicabo id.", (byte)0 },
                    { 12, 12, "Explicabo quo autem veritatis et fugiat dignissimos consequuntur. Et necessitatibus a soluta. Nulla qui dolor vero esse sapiente quo dolor reiciendis voluptas.", "Repudiandae sit provident tempore.", (byte)0 },
                    { 13, 13, "Aliquam eveniet ullam culpa molestiae maiores rerum consequuntur qui eligendi. Aut quo nesciunt delectus earum. Odit dignissimos non harum amet voluptatem nostrum quae sit sunt. Et sunt alias.", "Similique voluptatem omnis laudantium dolorem.", (byte)0 },
                    { 14, 14, "Quis veniam quia id voluptatem nulla accusantium. Ipsum vel nostrum tenetur illum magnam et voluptatibus quis est. Iste dolor est sunt aut. Facere et optio. Quis placeat suscipit et quaerat aut enim fugit aut non. Quo dolores eum.", "Vero possimus culpa rerum quia qui.", (byte)0 },
                    { 15, 15, "Animi impedit qui delectus excepturi voluptas accusamus. Enim atque ut nemo. Modi quod ut dolorem dolorem aut ut quia voluptatem eum. Velit asperiores dolorem. Voluptas corporis esse libero aspernatur nulla aut sapiente quasi.", "Fuga sequi ex aut dolores.", (byte)0 },
                    { 16, 16, "Modi non qui pariatur dignissimos quisquam doloribus. Ea et occaecati aut incidunt officiis dicta. Deserunt dolorem beatae et nam similique iusto dolore perspiciatis reprehenderit. Delectus deleniti commodi magnam praesentium harum odio quisquam.", "Atque voluptatem officiis illum vitae.", (byte)0 }
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
                name: "IX_BookInteractions_CommentId",
                table: "BookInteractions",
                column: "CommentId",
                unique: true);

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
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_parent_id",
                table: "Comments",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
