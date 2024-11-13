using System;
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_at = table.Column<DateOnly>(type: "date", nullable: false),
                    update_at = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id);
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
                    genre_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    year_public = table.Column<int>(type: "int", nullable: false),
                    views = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    remaining = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Books_Genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "Genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriesBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriesBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesBook_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
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
                    parent_id = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "Id");
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    book_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    register_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    borrow_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    expected_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    return_at = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Register_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Register_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    { 1, "Possimus aliquid ipsum ut nulla recusandae.", "Harold" },
                    { 2, "Repellendus alias rerum quod velit neque est assumenda tenetur corrupti.", "Fidel" },
                    { 3, "Rem et iure qui deserunt adipisci asperiores atque.", "Nelle" },
                    { 4, "Consequatur vel dolores praesentium corrupti.", "Verdie" },
                    { 5, "Veniam optio ab laboriosam temporibus.", "Vincent" },
                    { 6, "Vero quis explicabo nobis et.", "Betsy" },
                    { 7, "Et harum voluptatum dicta et suscipit corporis architecto.", "Antone" },
                    { 8, "Magni assumenda nihil est autem quo quis modi tenetur.", "Nick" },
                    { 9, "Soluta enim rem ea.", "Earl" },
                    { 10, "Animi dolore exercitationem eveniet dolorem illo nam.", "Gerald" },
                    { 11, "Amet dicta eos qui.", "Lila" },
                    { 12, "Aliquam sunt aut voluptas.", "Melany" },
                    { 13, "Voluptates perferendis non eaque voluptate deleniti.", "Laurence" },
                    { 14, "Et doloremque repellendus rem vero non recusandae omnis sunt laborum.", "Donny" },
                    { 15, "Reprehenderit hic sequi minus aperiam quo.", "Shaina" },
                    { 16, "Nemo nemo velit laudantium suscipit.", "Bridie" },
                    { 17, "Dignissimos quibusdam omnis dignissimos occaecati consequatur labore ad iure.", "Kimberly" },
                    { 18, "Voluptatum esse harum quibusdam porro.", "Russ" },
                    { 19, "Ratione quae adipisci assumenda.", "Jermey" },
                    { 20, "Cumque libero nihil ex.", "Bettie" },
                    { 21, "Provident dignissimos placeat repellat molestiae eveniet repudiandae et.", "Dariana" },
                    { 22, "Quam rem eligendi voluptas.", "Tabitha" },
                    { 23, "Blanditiis et ut veniam.", "Lacey" },
                    { 24, "Debitis quas veritatis et voluptatem itaque velit tenetur inventore.", "Forrest" },
                    { 25, "Neque quasi soluta fuga quaerat.", "Darian" },
                    { 26, "Et quia adipisci est et voluptatibus ipsam asperiores sed.", "Joanne" },
                    { 27, "Quasi illum distinctio provident sunt quisquam sit aut rerum.", "Dakota" },
                    { 28, "Facere architecto est vel.", "Blaze" },
                    { 29, "Maxime et et fugit.", "Trenton" },
                    { 30, "Aut qui adipisci officia saepe fuga iste impedit.", "Lewis" },
                    { 31, "Voluptas beatae nesciunt corporis eos deleniti blanditiis.", "Cicero" },
                    { 32, "Facilis pariatur blanditiis exercitationem.", "Richmond" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Eaque sit minus magnam. Temporibus dolore non fuga quasi sit doloremque sit. Id hic pariatur qui autem.", "voluptatem", new DateOnly(2024, 11, 13), new DateOnly(2024, 11, 13) },
                    { 2, "Voluptatem corporis eum sit eligendi. Sunt autem porro ipsam ex error eius ut vitae laboriosam. Non eum doloribus neque cum tempore enim laboriosam. Quasi eaque dicta officiis. Occaecati consequatur et tempora. Dolorem ea voluptates nostrum aut molestiae voluptatem.", "Numquam earum repellendus incidunt in ipsam.\nLibero quo odio alias harum repudiandae vel perferendis blanditiis.\nLaborum nesciunt quae alias voluptas blanditiis.", new DateOnly(2024, 11, 13), new DateOnly(2024, 11, 13) },
                    { 3, "Dolor ut magni minima possimus soluta ad. Officiis voluptas ad architecto est laudantium nihil nobis. Ipsa at eligendi ad quia est sit. Omnis dignissimos velit placeat alias qui.", "Quasi blanditiis neque quia quis.\nLibero cum ad reprehenderit sed voluptatibus sed sit.\nVoluptas reiciendis vitae velit.\nSoluta at libero est voluptas necessitatibus quae.\nIure libero quos non soluta voluptatum non inventore id aut.", new DateOnly(2024, 11, 13), new DateOnly(2024, 11, 13) },
                    { 4, "Deserunt quidem eum est quas omnis. Esse reprehenderit ea omnis atque nam nihil est molestias vel. Illo voluptas ex deserunt reprehenderit dolores sapiente cumque mollitia.", "Neque itaque in. Sit et cumque voluptatem aperiam est incidunt ut et. Velit itaque beatae exercitationem qui ut alias deserunt repudiandae quae. Qui porro consequuntur ut ut et. Et dolor non maxime omnis quo dolores vel dolores quam. Ea et quod.", new DateOnly(2024, 11, 13), new DateOnly(2024, 11, 13) },
                    { 5, "Et a quam. Ab iusto est ab facere repellendus alias id consequatur. Beatae doloremque porro dolor dicta.", "et", new DateOnly(2024, 11, 13), new DateOnly(2024, 11, 13) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "voluptas" },
                    { 2, "in" },
                    { 3, "eveniet" },
                    { 4, "temporibus" },
                    { 5, "laboriosam" },
                    { 6, "cumque" },
                    { 7, "quos" },
                    { 8, "eum" },
                    { 9, "labore" },
                    { 10, "minima" },
                    { 11, "eaque" },
                    { 12, "et" },
                    { 13, "voluptates" },
                    { 14, "doloribus" },
                    { 15, "rerum" },
                    { 16, "dolor" },
                    { 17, "et" },
                    { 18, "aliquam" },
                    { 19, "dolor" },
                    { 20, "omnis" },
                    { 21, "temporibus" },
                    { 22, "assumenda" },
                    { 23, "quas" },
                    { 24, "voluptas" },
                    { 25, "in" },
                    { 26, "in" },
                    { 27, "quia" },
                    { 28, "aperiam" },
                    { 29, "repudiandae" },
                    { 30, "dolor" },
                    { 31, "officiis" },
                    { 32, "assumenda" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "animi", "Oda Greenholt" },
                    { 2, "Magnam molestiae suscipit similique fuga dignissimos et necessitatibus et. Sit id fuga consectetur in repudiandae. Est dolor tenetur sequi dignissimos.", "Justus Feil" },
                    { 3, "dignissimos", "Brendan Welch" },
                    { 4, "Quos omnis esse.", "Britney Purdy" },
                    { 5, "Nemo voluptatum modi tempora. Perferendis in similique cupiditate voluptatem quia exercitationem eos quisquam. Voluptatibus sunt ut aperiam nulla enim eos culpa tempore incidunt. Vero amet sit nisi qui qui autem asperiores et adipisci. Sit sed autem est saepe.", "Marcia Langworth" },
                    { 6, "Repellat rerum animi beatae.", "Luciano Nikolaus" },
                    { 7, "Enim quasi ex veritatis.", "Elsa Swaniawski" },
                    { 8, "eum", "Llewellyn Bartoletti" },
                    { 9, "Vel minus ut nam voluptate blanditiis sit. Natus sint suscipit repellendus molestiae voluptatem corrupti eaque fugiat. Placeat a aut voluptas earum sunt dolorem commodi adipisci. Dolore et tempore ut sunt quia dolor autem ab.", "Meredith Spinka" },
                    { 10, "nemo", "Travis Ortiz" },
                    { 11, "Eaque quaerat expedita.", "Adeline Kassulke" },
                    { 12, "sit", "Orval Considine" },
                    { 13, "Ab numquam est magni.\nArchitecto accusantium est voluptatem.\nAut rem sed at.\nOccaecati perferendis qui dicta non.\nPlaceat voluptas aliquid amet.", "Royal Howell" },
                    { 14, "Omnis ut quia neque esse hic eligendi repudiandae vel.", "Glennie Hamill" },
                    { 15, "Tempore eligendi dignissimos optio.", "Norberto Walker" },
                    { 16, "Fugiat ut impedit voluptatem et voluptatem.", "Deangelo Robel" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "quantity", "rating", "remaining", "updated_at", "views", "year_public" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(3024), "Voluptas rerum ut ut officiis modi ut doloribus. Accusamus labore officiis. Consequatur delectus quae est illum doloremque. Amet commodi qui delectus assumenda aut. Et dicta dolorem fuga aut velit nihil quo nesciunt.", 28, "At sed et sequi.", (byte)6, (byte)0, (byte)1, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(3510), 0, 1912 },
                    { 2, 28, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(4612), "A nostrum aut sed. Odit perspiciatis dolor numquam itaque corporis perspiciatis provident voluptatem cumque. A architecto voluptatem officia aliquam placeat placeat veritatis quaerat. Aliquid occaecati asperiores eveniet quisquam quae tenetur sed consequuntur. Sunt et est ea aliquam.", 13, "Vel quam itaque saepe voluptas facilis.", (byte)9, (byte)0, (byte)3, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(4809), 0, 1994 },
                    { 3, 30, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(4822), "Optio consequuntur excepturi qui. Nisi quam alias sit qui voluptatibus error quos. Sed magni est officia velit ab et quia. Quis adipisci quo culpa sunt quo repudiandae ut totam officiis.", 9, "Soluta doloribus consequatur et et nisi quae.", (byte)7, (byte)0, (byte)5, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(4926), 0, 1944 },
                    { 4, 28, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(4939), "Harum consectetur dolorum veritatis veritatis deleniti delectus. Non qui est eum sit repudiandae sunt dolorem quo autem. Ut eligendi aut rerum aut. Culpa earum sit dolorem soluta voluptate asperiores.", 26, "Aliquid quas hic molestiae et sit ut expedita suscipit sit.", (byte)10, (byte)0, (byte)3, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5036), 0, 1953 },
                    { 5, 14, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5047), "Consequatur nobis non doloribus eaque cumque saepe ea. Ea temporibus laboriosam. Et iusto tempora sed a ut et architecto. Atque impedit sed corrupti tenetur voluptatem autem ea.", 5, "Nobis occaecati facere est.", (byte)9, (byte)0, (byte)2, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5134), 0, 1992 },
                    { 6, 16, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5145), "Qui suscipit placeat suscipit iure ut ducimus suscipit consequatur. Suscipit unde doloribus quia dolorum quia voluptatibus ratione. Harum repellendus quia. Non ut dolor ea recusandae blanditiis et.", 27, "Dolores beatae temporibus asperiores quo sit ea.", (byte)5, (byte)0, (byte)4, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5238), 0, 1978 },
                    { 7, 30, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5248), "Rerum labore tempora deleniti fugiat tempora. Quia aut officia delectus fuga officiis excepturi. Nostrum earum nesciunt aut odit modi. Suscipit aut occaecati. Quia quia accusamus quod. Temporibus dolore sapiente assumenda officia.", 14, "Non dolore nobis unde iure in iure et iure.", (byte)5, (byte)0, (byte)3, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5342), 0, 1949 },
                    { 8, 32, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5357), "Ex hic quia labore placeat similique. Pariatur doloribus minima amet veritatis placeat voluptatem. Inventore labore atque quos minima non qui rerum ut.", 23, "Voluptatem et repellat itaque facere sed id omnis.", (byte)8, (byte)0, (byte)1, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5432), 0, 1990 },
                    { 9, 23, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5442), "Sunt pariatur enim voluptatem ullam. Sit non numquam qui atque repudiandae voluptatem. Temporibus explicabo ullam labore.", 18, "Dolore enim voluptatem minima ea facere.", (byte)10, (byte)0, (byte)5, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5509), 0, 1996 },
                    { 10, 12, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5519), "Tempore ipsa nostrum sit hic. Recusandae consequatur veniam dolore est molestiae hic excepturi. Deleniti est illum illum autem neque autem dignissimos quia. Ut omnis quisquam labore facilis velit sapiente dolor qui natus. Rerum officiis est voluptatem accusantium quos labore eius.", 31, "Dolorem velit non eius id neque accusantium deserunt.", (byte)6, (byte)0, (byte)1, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5630), 0, 1957 },
                    { 11, 7, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5641), "Nesciunt mollitia hic laudantium ex totam. Animi ipsum rem porro maxime dolores quasi. Qui officia distinctio sunt. Rerum at expedita nemo temporibus.", 23, "Illum nesciunt in sapiente porro numquam quisquam fugit ea.", (byte)7, (byte)0, (byte)0, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5720), 0, 1988 },
                    { 12, 10, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5731), "Qui ad voluptatum quo cumque omnis. Nulla voluptas non iure esse sit dolor eius enim. Vel repellat sit voluptas voluptatum sapiente in et. Explicabo possimus quia labore voluptate autem expedita. Omnis corporis ipsam ullam aut. Adipisci iste est in.", 6, "Nemo est ad laudantium iste vero quos.", (byte)6, (byte)0, (byte)4, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5844), 0, 1960 },
                    { 13, 17, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5854), "Debitis nihil voluptas aperiam voluptatem voluptatibus placeat. Dolor sed aspernatur consequuntur. Voluptatem quidem laborum porro modi et. Ipsum iure officia expedita qui.", 21, "Provident quibusdam illo quibusdam in sed.", (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5936), 0, 2000 },
                    { 14, 1, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(5946), "Ea rerum assumenda autem ut enim. Quisquam assumenda eius et ut odio magni laborum et. Ipsa et quod ea animi hic sunt totam molestiae voluptatem. Omnis quis doloremque architecto. Aspernatur nostrum sit aliquid dignissimos dolor nemo nemo laborum.", 32, "Quisquam fugiat aut id.", (byte)10, (byte)0, (byte)4, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6050), 0, 1931 },
                    { 15, 12, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6060), "Eaque illo aut non ea ullam voluptas odit quas. Numquam est sit vel quia qui molestiae dolorem. Et cumque delectus dolorum. Non similique voluptatem dolores. Ducimus quasi quia iure.", 6, "Impedit sequi repellendus officia corporis aut perferendis molestiae voluptatem.", (byte)6, (byte)0, (byte)2, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6153), 0, 1902 },
                    { 16, 8, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6163), "Qui esse illum dolores. Ullam ea expedita rerum eos adipisci non nesciunt commodi minima. Modi deserunt ut id voluptate dolores.", 25, "Tenetur similique qui dolore sit itaque.", (byte)5, (byte)0, (byte)5, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6236), 0, 1990 },
                    { 17, 23, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6247), "Temporibus sit et voluptatem excepturi vel enim est molestiae. Cumque quaerat non neque facilis at hic qui harum. Unde tenetur illum. Totam possimus ea nesciunt ipsum totam culpa id. Consectetur delectus reiciendis optio.", 12, "Corporis velit sed.", (byte)8, (byte)0, (byte)5, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6341), 0, 1952 },
                    { 18, 13, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6352), "Sed quia quibusdam placeat natus quaerat consequatur. Rerum repudiandae officiis qui quia quia dicta ut qui nihil. Illum in qui neque.", 14, "Ea qui tenetur excepturi consequuntur tenetur dicta.", (byte)5, (byte)0, (byte)5, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6425), 0, 2019 },
                    { 19, 29, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6436), "Sunt excepturi inventore omnis. Repellendus ut tempore cupiditate consequatur. Nisi est dignissimos accusamus architecto corporis quasi. Modi molestiae alias quod sit ea. Iusto vel alias aut aut atque rerum recusandae. Quia voluptas eligendi harum qui accusantium vero molestias.", 14, "Ex nemo voluptatem.", (byte)6, (byte)0, (byte)1, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6542), 0, 1915 },
                    { 20, 21, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6553), "Ut maiores aliquid quo accusantium cupiditate sapiente. Eaque voluptas aspernatur quam id dignissimos molestias ad. Quam porro facere sit aut minima officia. Pariatur laborum laboriosam voluptatem reiciendis omnis repudiandae rerum.", 16, "Earum minus ut et ipsa a.", (byte)5, (byte)0, (byte)4, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6646), 0, 1983 },
                    { 21, 14, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6657), "Error corporis ex omnis architecto. Nihil voluptates voluptatem voluptas voluptatum rem ut. Placeat unde eligendi ut rem magnam. Modi ipsam quis beatae possimus eum ea consequatur voluptatem quos.", 22, "Odio et dolores.", (byte)7, (byte)0, (byte)4, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6736), 0, 1904 },
                    { 22, 4, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6747), "Consequatur quo illum esse optio aut nam mollitia repellendus accusantium. Voluptatem qui labore magni. Qui minus ducimus. Est culpa odio quia ea enim ut totam. Aut numquam aspernatur enim deserunt iure corporis ut est illo.", 16, "Non nam natus alias dolorum hic ex reprehenderit.", (byte)10, (byte)0, (byte)5, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6849), 0, 1980 },
                    { 23, 30, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6860), "Placeat voluptatem nisi ut qui maiores facere voluptate voluptas. Commodi fuga ut eum et veniam tempore dolor assumenda. Animi laborum fugit tempora et illo sunt eius. Earum sed molestiae ducimus. Voluptates quia nostrum natus et in in sint harum. Autem tempora esse dolores similique autem rerum et.", 5, "Corrupti non et quia ut excepturi.", (byte)10, (byte)0, (byte)1, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6982), 0, 1984 },
                    { 24, 22, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(6993), "Aut doloribus fuga dolorem adipisci et sit vel. Magni cum architecto ea eius explicabo accusamus ipsum nobis. Qui fugit explicabo et eaque aliquid maxime qui ea.", 24, "Et maxime consequatur iusto dolorem animi nisi quia omnis rem.", (byte)8, (byte)0, (byte)5, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(7200), 0, 1945 },
                    { 25, 8, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(7212), "Eveniet omnis et nam. Excepturi nesciunt beatae et distinctio. Et harum id nihil qui ut magnam quo autem et. Iste dolorem autem expedita et repudiandae reprehenderit dicta delectus.", 13, "Est possimus et eius perferendis voluptas debitis aut et tempora.", (byte)10, (byte)0, (byte)1, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(7306), 0, 1941 },
                    { 26, 8, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(7317), "Quaerat labore quia dolorem laboriosam velit debitis. Totam maiores est voluptates. Maiores quod dolores rerum magnam dolor facere sequi at. Vitae odit maiores consequuntur saepe architecto. Voluptas nihil necessitatibus error vero veniam sequi non est nihil.", 25, "Quo dolor ut eum tempora.", (byte)9, (byte)0, (byte)5, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(7415), 0, 1916 },
                    { 27, 7, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(7425), "Natus non repudiandae rerum modi consectetur libero tempore eos. Praesentium vel sunt. Cumque beatae at minus autem omnis sint.", 28, "Architecto sunt debitis atque.", (byte)6, (byte)0, (byte)1, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(7493), 0, 2003 },
                    { 28, 27, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(7504), "Quidem dolores vel reiciendis in fugit. Quia fugiat aperiam suscipit quia. Pariatur nisi hic natus aut accusantium totam qui.", 31, "Ipsam cumque perferendis magni sit vel corrupti est ut.", (byte)9, (byte)0, (byte)0, new DateTime(2024, 11, 13, 15, 2, 26, 85, DateTimeKind.Local).AddTicks(7575), 0, 1902 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBook",
                columns: new[] { "Id", "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 10, 4 },
                    { 2, 10, 2 },
                    { 3, 8, 2 },
                    { 4, 4, 5 },
                    { 5, 10, 4 },
                    { 6, 25, 5 },
                    { 7, 28, 3 },
                    { 8, 26, 3 },
                    { 9, 28, 2 },
                    { 10, 6, 4 },
                    { 11, 5, 5 },
                    { 12, 15, 1 },
                    { 13, 6, 5 },
                    { 14, 23, 1 },
                    { 15, 19, 3 },
                    { 16, 24, 1 },
                    { 17, 8, 3 },
                    { 18, 22, 4 },
                    { 19, 16, 3 },
                    { 20, 16, 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 1, 6, 14, "Enim sint reprehenderit et dolores et fugit deleniti sed sequi.", null },
                    { 2, 13, 16, "Impedit iste aut ducimus quo est eius.", null },
                    { 3, 27, 16, "Expedita omnis quia sint beatae magni saepe et et.", null },
                    { 4, 3, 16, "Repellendus est a vel.", null },
                    { 5, 1, 3, "Rerum in nisi et ab.", null },
                    { 6, 23, 1, "Aut ipsam quod quidem accusantium.", null },
                    { 7, 19, 13, "Nulla itaque recusandae voluptas.", null },
                    { 8, 2, 4, "Quibusdam quasi omnis voluptatem porro.", null },
                    { 9, 8, 3, "Et ea rem quibusdam atque saepe.", null },
                    { 10, 5, 13, "Officiis aut illum ut.", null },
                    { 11, 19, 15, "Voluptatem magni quisquam quas sit maiores et quia.", null },
                    { 12, 21, 14, "Et commodi ad in culpa voluptas ut non occaecati.", null },
                    { 13, 17, 14, "Omnis ut dolores et qui molestiae.", null },
                    { 14, 3, 10, "Sed quas occaecati deleniti incidunt aut quo dolores.", null },
                    { 15, 28, 5, "Dolor non qui expedita rerum sed dolorem iusto earum quam.", null },
                    { 16, 11, 4, "Sit animi itaque ea nam excepturi.", null }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "book_id", "path" },
                values: new object[,]
                {
                    { 1, 22, ".\\resources\\images\\poster.png" },
                    { 2, 9, ".\\resources\\images\\poster.png" },
                    { 3, 8, ".\\resources\\images\\poster.png" },
                    { 4, 6, ".\\resources\\images\\poster.png" },
                    { 5, 5, ".\\resources\\images\\poster.png" },
                    { 6, 9, ".\\resources\\images\\poster.png" },
                    { 7, 5, ".\\resources\\images\\poster.png" },
                    { 8, 4, ".\\resources\\images\\poster.png" },
                    { 9, 2, ".\\resources\\images\\poster.png" },
                    { 10, 6, ".\\resources\\images\\poster.png" },
                    { 11, 28, ".\\resources\\images\\poster.png" },
                    { 12, 2, ".\\resources\\images\\poster.png" },
                    { 13, 8, ".\\resources\\images\\poster.png" },
                    { 14, 9, ".\\resources\\images\\poster.png" },
                    { 15, 9, ".\\resources\\images\\poster.png" },
                    { 16, 8, ".\\resources\\images\\poster.png" }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 14, "Borrowed", 11, new DateTime(2024, 11, 12, 5, 25, 40, 861, DateTimeKind.Local).AddTicks(4714), new DateTime(2024, 11, 14, 11, 28, 12, 411, DateTimeKind.Local).AddTicks(1146), new DateTime(2024, 11, 7, 11, 28, 12, 411, DateTimeKind.Local).AddTicks(1146), null },
                    { 2, 21, "Completed", 15, new DateTime(2024, 11, 8, 0, 0, 59, 388, DateTimeKind.Local).AddTicks(9467), new DateTime(2024, 11, 18, 13, 23, 13, 885, DateTimeKind.Local).AddTicks(6917), new DateTime(2024, 11, 11, 13, 23, 13, 885, DateTimeKind.Local).AddTicks(6917), new DateTime(2024, 11, 11, 21, 46, 35, 391, DateTimeKind.Local).AddTicks(845) },
                    { 3, 7, "Completed", 7, new DateTime(2024, 11, 10, 21, 50, 42, 373, DateTimeKind.Local).AddTicks(5091), new DateTime(2024, 11, 19, 17, 18, 37, 572, DateTimeKind.Local).AddTicks(3173), new DateTime(2024, 11, 12, 17, 18, 37, 572, DateTimeKind.Local).AddTicks(3173), new DateTime(2024, 11, 13, 5, 37, 14, 472, DateTimeKind.Local).AddTicks(8820) },
                    { 4, 10, "Pending", 1, null, new DateTime(2024, 11, 14, 1, 51, 54, 495, DateTimeKind.Local).AddTicks(9683), new DateTime(2024, 11, 7, 1, 51, 54, 495, DateTimeKind.Local).AddTicks(9683), null },
                    { 5, 1, "Borrowed", 3, new DateTime(2024, 11, 12, 18, 38, 42, 246, DateTimeKind.Local).AddTicks(1090), new DateTime(2024, 11, 18, 21, 21, 53, 953, DateTimeKind.Local).AddTicks(5164), new DateTime(2024, 11, 11, 21, 21, 53, 953, DateTimeKind.Local).AddTicks(5164), null },
                    { 6, 23, "Borrowed", 7, new DateTime(2024, 11, 8, 16, 52, 12, 868, DateTimeKind.Local).AddTicks(9167), new DateTime(2024, 11, 15, 1, 56, 3, 898, DateTimeKind.Local).AddTicks(3723), new DateTime(2024, 11, 8, 1, 56, 3, 898, DateTimeKind.Local).AddTicks(3723), null },
                    { 7, 6, "Canceled", 7, null, null, new DateTime(2024, 11, 6, 20, 39, 37, 96, DateTimeKind.Local).AddTicks(4873), null },
                    { 8, 17, "Pending", 2, null, new DateTime(2024, 11, 18, 7, 8, 52, 809, DateTimeKind.Local).AddTicks(9156), new DateTime(2024, 11, 11, 7, 8, 52, 809, DateTimeKind.Local).AddTicks(9156), null },
                    { 9, 25, "Pending", 5, null, new DateTime(2024, 11, 18, 19, 20, 18, 831, DateTimeKind.Local).AddTicks(8567), new DateTime(2024, 11, 11, 19, 20, 18, 831, DateTimeKind.Local).AddTicks(8567), null },
                    { 10, 6, "Canceled", 6, null, null, new DateTime(2024, 11, 8, 1, 13, 33, 209, DateTimeKind.Local).AddTicks(3089), null },
                    { 11, 12, "Borrowed", 9, new DateTime(2024, 11, 9, 8, 9, 52, 723, DateTimeKind.Local).AddTicks(4179), new DateTime(2024, 11, 15, 10, 15, 3, 418, DateTimeKind.Local).AddTicks(6726), new DateTime(2024, 11, 8, 10, 15, 3, 418, DateTimeKind.Local).AddTicks(6726), null },
                    { 12, 19, "Borrowed", 9, new DateTime(2024, 11, 10, 20, 7, 2, 682, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 11, 19, 11, 4, 4, 830, DateTimeKind.Local).AddTicks(9433), new DateTime(2024, 11, 12, 11, 4, 4, 830, DateTimeKind.Local).AddTicks(9433), null },
                    { 13, 3, "Borrowed", 11, new DateTime(2024, 11, 11, 11, 0, 20, 648, DateTimeKind.Local).AddTicks(848), new DateTime(2024, 11, 16, 18, 41, 56, 185, DateTimeKind.Local).AddTicks(1143), new DateTime(2024, 11, 9, 18, 41, 56, 185, DateTimeKind.Local).AddTicks(1143), null },
                    { 14, 16, "Canceled", 12, null, null, new DateTime(2024, 11, 8, 0, 10, 23, 761, DateTimeKind.Local).AddTicks(7069), null },
                    { 15, 6, "Borrowed", 14, new DateTime(2024, 11, 7, 17, 5, 11, 139, DateTimeKind.Local).AddTicks(4931), new DateTime(2024, 11, 20, 10, 27, 22, 630, DateTimeKind.Local).AddTicks(2481), new DateTime(2024, 11, 13, 10, 27, 22, 630, DateTimeKind.Local).AddTicks(2481), null },
                    { 16, 28, "Borrowed", 3, new DateTime(2024, 11, 9, 15, 48, 27, 230, DateTimeKind.Local).AddTicks(5825), new DateTime(2024, 11, 15, 1, 37, 28, 305, DateTimeKind.Local).AddTicks(1499), new DateTime(2024, 11, 8, 1, 37, 28, 305, DateTimeKind.Local).AddTicks(1499), null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 17, 21, 1, "Dolor neque libero.", 2 },
                    { 18, 10, 3, "Quia illum itaque quisquam dignissimos.", 1 },
                    { 19, 8, 15, "Porro odit hic voluptate beatae omnis est necessitatibus iste quis.", 4 },
                    { 20, 25, 1, "Amet id cupiditate molestias quos autem tempora et sed.", 5 },
                    { 21, 28, 4, "Culpa non laboriosam.", 12 },
                    { 22, 20, 1, "Quasi rem hic fuga ipsum delectus eius numquam placeat dolor.", 13 },
                    { 23, 13, 15, "Officiis rerum reiciendis.", 1 },
                    { 24, 7, 2, "Consequatur dolore non vero eos hic est rerum.", 9 },
                    { 25, 23, 5, "Vitae repudiandae quae.", 1 },
                    { 26, 8, 4, "Voluptatibus earum ipsam recusandae debitis unde.", 10 },
                    { 27, 23, 12, "Ipsam qui tempore et harum delectus.", 10 },
                    { 28, 24, 8, "Sit qui ducimus.", 5 },
                    { 29, 14, 5, "Et facere dolorem est earum omnis tempore.", 13 },
                    { 30, 9, 1, "Ex quis laboriosam facere ea labore inventore.", 9 },
                    { 31, 20, 11, "Eaque est perspiciatis nostrum odit est aut dolor iusto reprehenderit.", 2 },
                    { 32, 3, 14, "Magnam debitis deleniti omnis.", 3 }
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
                name: "IX_Books_genre_id",
                table: "Books",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesBook_BookId",
                table: "CategoriesBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesBook_CategoryId",
                table: "CategoriesBook",
                column: "CategoryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Register_BookId",
                table: "Register",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Register_UserId",
                table: "Register",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookInteractions");

            migrationBuilder.DropTable(
                name: "CategoriesBook");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Register");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
