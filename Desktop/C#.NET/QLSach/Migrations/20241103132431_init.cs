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
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
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
                    { 1, "Laboriosam explicabo voluptatum recusandae tenetur repellendus sit dolor dolor maiores.", "Elnora" },
                    { 2, "Sit perspiciatis voluptatem non.", "Robin" },
                    { 3, "Accusamus sed aut occaecati modi.", "Shania" },
                    { 4, "Sed excepturi sit nemo est fugit quibusdam.", "Stuart" },
                    { 5, "Sit laudantium minus quis eligendi facere ut et tempora.", "Terrance" },
                    { 6, "Et reiciendis sequi laudantium est non sed dignissimos.", "Arturo" },
                    { 7, "Quo doloribus maxime totam sit.", "Tess" },
                    { 8, "Neque voluptas consequatur ipsum impedit dicta quidem non harum.", "Jordy" },
                    { 9, "Quidem esse rerum repudiandae dolor earum quia rerum officiis consectetur.", "Lauren" },
                    { 10, "Doloribus suscipit alias.", "Gregoria" },
                    { 11, "Assumenda soluta quisquam placeat eligendi.", "Joel" },
                    { 12, "Ut occaecati ut cum ducimus.", "Alberta" },
                    { 13, "Repudiandae qui ipsa veritatis.", "Gladyce" },
                    { 14, "Modi numquam libero.", "Alexzander" },
                    { 15, "Eos illum aut alias est corporis officiis eos.", "Christelle" },
                    { 16, "Odit amet fugiat neque temporibus ab ea perspiciatis.", "Laurence" },
                    { 17, "Aliquid est illum delectus adipisci magnam laborum quos praesentium labore.", "Salvador" },
                    { 18, "Corrupti vero sit tempore deserunt natus ullam.", "Alexandro" },
                    { 19, "Qui beatae quibusdam voluptatem corporis id nihil.", "Vesta" },
                    { 20, "Vel et harum.", "Angeline" },
                    { 21, "Quae aliquid voluptates atque.", "Aurelia" },
                    { 22, "Velit sit fugiat consectetur.", "Roma" },
                    { 23, "Autem ut nemo.", "Dessie" },
                    { 24, "Quaerat nostrum quae aut corrupti ratione quia voluptas.", "Emery" },
                    { 25, "Eum quos harum laborum ullam harum aut.", "Shanny" },
                    { 26, "Ut fugiat quos.", "Raul" },
                    { 27, "Sapiente sint incidunt deserunt quidem sed.", "Heather" },
                    { 28, "Suscipit qui porro inventore minus quod odio.", "Agnes" },
                    { 29, "Itaque aliquid asperiores qui et quasi nam a quia.", "Shad" },
                    { 30, "Eum magnam sunt cumque.", "Robin" },
                    { 31, "Et sunt labore rerum.", "Nola" },
                    { 32, "Sed reiciendis asperiores molestiae facilis.", "Nakia" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "earum" },
                    { 2, "nulla" },
                    { 3, "possimus" },
                    { 4, "et" },
                    { 5, "illo" },
                    { 6, "voluptatem" },
                    { 7, "distinctio" },
                    { 8, "libero" },
                    { 9, "veritatis" },
                    { 10, "repellendus" },
                    { 11, "rerum" },
                    { 12, "fugiat" },
                    { 13, "veniam" },
                    { 14, "soluta" },
                    { 15, "et" },
                    { 16, "eum" },
                    { 17, "quo" },
                    { 18, "et" },
                    { 19, "sit" },
                    { 20, "autem" },
                    { 21, "velit" },
                    { 22, "veniam" },
                    { 23, "animi" },
                    { 24, "eius" },
                    { 25, "a" },
                    { 26, "porro" },
                    { 27, "laudantium" },
                    { 28, "nihil" },
                    { 29, "nam" },
                    { 30, "perspiciatis" },
                    { 31, "quia" },
                    { 32, "dicta" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Sint ex et quaerat similique.", "Annamae Harber" },
                    { 2, "Rerum cumque numquam.\nAd necessitatibus qui.\nQuaerat totam consequuntur laborum suscipit.", "Clemmie Schneider" },
                    { 3, "sit", "Dan Block" },
                    { 4, "Quaerat velit et. Autem sapiente doloremque. Quos voluptatibus quod distinctio. Repudiandae dolorum ad facilis esse. Omnis nam in voluptatum vero.", "Janis Denesik" },
                    { 5, "velit", "Desiree Bashirian" },
                    { 6, "ipsum", "Edison Bernhard" },
                    { 7, "At est quia quaerat voluptas repellat pariatur minus.", "Cristal Cremin" },
                    { 8, "Facilis quos sit qui est ullam.", "Vincenzo Bosco" },
                    { 9, "voluptatibus", "Alvah Zieme" },
                    { 10, "fuga", "Deborah Murphy" },
                    { 11, "Magnam excepturi est ipsum saepe eligendi aut dolor quos voluptatibus. Atque et placeat tenetur impedit autem accusamus. Labore velit porro voluptates aut quia eaque quae enim. Dignissimos quam quis autem repellendus distinctio quia a pariatur est.", "Laurine Krajcik" },
                    { 12, "Dolor placeat voluptatem repudiandae.", "Alycia Lynch" },
                    { 13, "Fugiat cumque esse fugiat illum repellendus illum eos iste reprehenderit.", "Aliya Robel" },
                    { 14, "Harum qui nulla itaque laudantium minus.\nQuis vel earum.\nCorporis vero quos voluptatum unde rerum.\nDoloribus est ut nihil.", "Lee Funk" },
                    { 15, "Placeat temporibus soluta unde.\nMagni consequatur et nostrum quasi unde sequi iste excepturi nihil.", "Bert O'Hara" },
                    { 16, "Odit laborum voluptas recusandae ullam sit ab perspiciatis neque.\nOccaecati ea eos illum sunt ut deleniti dignissimos eligendi dolorem.\nExpedita voluptatem omnis dolores.\nQuas distinctio delectus non hic commodi et magni eum.\nEos aspernatur impedit officia nihil harum nesciunt dolores.\nNon voluptatem at dolor sint blanditiis fugiat voluptas.", "Ewell Schimmel" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "rating", "updated_at", "views", "year_public" },
                values: new object[,]
                {
                    { 1, 12, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(3914), "At accusamus fuga incidunt blanditiis nostrum. Cumque alias aut. Qui eligendi non saepe est ad aspernatur consectetur. Quia omnis totam ut sapiente quibusdam voluptatem debitis. Unde minus reiciendis deserunt alias corrupti maiores.", 15, "Reiciendis consequatur at qui velit tenetur voluptatem occaecati.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(4330), 0, 2023 },
                    { 2, 21, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5195), "Non non in laudantium eum adipisci nemo rerum consequuntur. Est qui id ratione. Et sit corrupti sed omnis sunt. Repellendus aut eum aliquid aut iure in. Consequuntur ex in dolor nulla consectetur nihil quo voluptatem cupiditate.", 23, "Sequi necessitatibus optio tempora.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5359), 0, 1956 },
                    { 3, 16, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5375), "Ut doloribus dolor veniam sit sit dolorem eum nemo ea. Accusantium eaque animi vel possimus. Est deserunt non et explicabo accusamus dolores commodi. Autem aut laboriosam voluptates veritatis.", 29, "Et aut soluta.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5472), 0, 1918 },
                    { 4, 26, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5483), "Rerum vitae omnis sunt deserunt rerum illo eos non. Dolores quam eius sed dolor qui temporibus et. Rerum sed temporibus dolorum quod voluptas illum. Perspiciatis praesentium qui aut mollitia earum facere explicabo.", 17, "Temporibus nam doloribus molestias sunt nostrum quis incidunt.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5593), 0, 1937 },
                    { 5, 29, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5604), "Unde ad maiores possimus. Aliquid labore vel architecto laudantium ut corrupti et. Molestiae similique fugit minus minima.", 21, "Quia praesentium vel quam quia nostrum unde quia dolorem.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5675), 0, 1972 },
                    { 6, 28, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5686), "Exercitationem error quisquam necessitatibus modi maiores corrupti. Tempore ullam quam et ut quia sit. Consectetur est fugit eius excepturi quia ab temporibus.", 15, "Et aut ea tempora eius.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5763), 0, 1973 },
                    { 7, 15, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5774), "Ipsum consequatur nihil inventore. Nemo qui ipsa suscipit. Quod sit id quaerat iste adipisci ipsam.", 13, "Aut dolores velit quia autem et.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5836), 0, 2009 },
                    { 8, 27, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5847), "Consequatur tenetur vel suscipit consequatur est magnam nihil qui. Consequuntur ut velit provident. Voluptas possimus voluptatem illum aperiam consequatur aliquam qui consequatur optio. Blanditiis eos omnis impedit ut commodi et velit aperiam est.", 9, "Et consequuntur aut.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5947), 0, 1993 },
                    { 9, 5, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(5959), "Officia qui culpa mollitia pariatur reiciendis voluptatibus similique. Et vero tempore. Modi id officiis modi. Porro omnis in impedit quaerat assumenda nihil recusandae quis labore.", 11, "Consequatur autem fuga voluptatem perferendis voluptatibus nemo.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6047), 0, 1948 },
                    { 10, 20, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6058), "Error explicabo magni sequi. Nesciunt provident reiciendis. Facere cum ex dignissimos non quo quia beatae.", 28, "Voluptas sint possimus id similique.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6118), 0, 1910 },
                    { 11, 21, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6128), "Possimus dignissimos quae quaerat a. Inventore soluta dignissimos itaque repudiandae qui molestiae blanditiis voluptates rerum. Natus possimus adipisci sapiente sed quos cupiditate voluptatem autem.", 10, "Ut facilis modi necessitatibus molestias modi.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6211), 0, 1918 },
                    { 12, 4, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6222), "Expedita illo dolor sed porro est vel. Dolor consequatur similique et eum doloribus architecto quia. Et asperiores sed ipsum natus autem. Sint doloribus pariatur labore iure. Sunt facilis architecto nisi aut. Dolorem eum id.", 18, "Fuga culpa ex omnis eveniet.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6345), 0, 1912 },
                    { 13, 23, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6357), "Omnis voluptate quaerat odio aliquam eius sunt. Praesentium repudiandae non reprehenderit. Laborum modi perferendis. Nam quidem sint voluptatem impedit suscipit aut mollitia accusamus. Minus alias vel repellendus.", 25, "Qui harum molestiae natus amet.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6445), 0, 1929 },
                    { 14, 11, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6456), "Recusandae ipsa similique officiis. Expedita eos unde ipsum minus qui porro. Rerum enim rem ipsam.", 11, "Rerum ut unde magni vel sint suscipit et.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6518), 0, 1928 },
                    { 15, 14, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6544), "Placeat commodi ipsa excepturi fugit aut. Aut dolorum aut laborum at et maiores nam. Sed in sit ea qui facilis minima. Optio beatae nemo assumenda perspiciatis ut. Et et iusto ullam aut quo. Tempora eius a eum nobis rerum dolor.", 8, "Laudantium qui consequatur quo quisquam libero molestias iusto.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6664), 0, 2004 },
                    { 16, 15, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6675), "Labore eos sed quia recusandae. Ad mollitia sed. Autem molestiae asperiores. Nulla dolor et. Id veniam nam voluptatem minima omnis.", 16, "Saepe quia distinctio.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6758), 0, 1946 },
                    { 17, 29, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6770), "Error laborum dolores libero unde possimus blanditiis et et temporibus. Occaecati nisi neque molestiae enim commodi. Accusamus omnis enim est minus velit. Ipsum consequatur blanditiis rerum. Ut sunt atque a sit laudantium quia et porro.", 2, "Vero nihil delectus natus explicabo enim.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6870), 0, 1907 },
                    { 18, 3, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6881), "Laudantium culpa ut quas accusamus officia ut inventore. Doloremque laboriosam fuga ut in. Debitis omnis voluptas cupiditate porro eaque quaerat fugiat non sequi. Sunt et ex.", 21, "Sed maiores optio maiores dolor laboriosam est eligendi esse neque.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6971), 0, 1932 },
                    { 19, 4, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(6982), "Qui laboriosam et accusantium alias consequuntur ratione voluptatum quam. Consequatur doloribus asperiores beatae ut. Adipisci quasi vel voluptas dolorum et. Minima dolorem aut.", 19, "Soluta ab et et tempora et.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7067), 0, 1904 },
                    { 20, 6, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7077), "Consectetur et expedita sit dolorum ut est ad saepe. Voluptate dolorum sunt hic. Eum repellat velit illum.", 32, "Dolor molestiae at quas pariatur.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7139), 0, 1970 },
                    { 21, 16, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7151), "Aut et ut fugit placeat voluptatem fugiat commodi ut architecto. Aliquid totam aut ducimus aliquam maxime iusto vero dolorem. Sit aut dolorem quibusdam tenetur cupiditate impedit quibusdam vero.", 8, "Voluptas sint dicta et aut iure consequuntur dolorem voluptatibus magnam.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7246), 0, 1949 },
                    { 22, 24, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7257), "Tenetur assumenda quia enim rerum rem porro voluptatem. Dolores et quos et quis expedita qui et qui. Et non atque praesentium omnis. Voluptatem reprehenderit et perferendis ea odit repellendus mollitia earum sed.", 27, "Tempore rerum asperiores.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7357), 0, 1957 },
                    { 23, 2, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7368), "Cumque dolores et omnis omnis debitis omnis ut porro. Perferendis cum ullam et amet. Consectetur omnis veritatis commodi atque tenetur nemo dignissimos. Magnam ut veritatis maiores.", 30, "Debitis ut sit.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7456), 0, 1923 },
                    { 24, 7, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7469), "Qui voluptas corrupti reprehenderit hic veritatis quis sunt. Rerum sunt omnis quae sapiente. Accusamus et sit temporibus placeat. Molestiae consequatur reiciendis voluptatem enim accusamus et necessitatibus. Sit quis et labore molestias quia in veritatis qui est.", 25, "Velit corporis velit voluptatibus quisquam aut est ipsam nobis ullam.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7588), 0, 1953 },
                    { 25, 5, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7599), "Blanditiis cumque molestiae mollitia ex doloremque. Omnis perferendis in odit. Quia nulla eos quia. Minima voluptates et repudiandae.", 1, "Accusantium esse pariatur ducimus quam.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7671), 0, 1922 },
                    { 26, 14, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7683), "Vero et voluptatem et. Temporibus ea nam. Temporibus consectetur blanditiis et praesentium vitae eum illum.", 17, "Sit explicabo sed dolorum optio voluptatem.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7745), 0, 2019 },
                    { 27, 30, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7756), "Qui sed dolores deleniti ea mollitia nihil et. Ea nobis ipsa sit nihil quia. Quia quia consequatur molestiae et itaque earum porro repudiandae repudiandae.", 4, "Dicta expedita rerum dolores dolorem ex dolore.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7838), 0, 1912 },
                    { 28, 4, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7849), "Ut est minima eos pariatur voluptatibus dolor. Quos non nobis molestiae voluptates. Facilis perspiciatis tempora nemo rem eveniet praesentium.", 9, "Dolor totam vero corrupti impedit.", (byte)0, new DateTime(2024, 11, 3, 20, 24, 30, 908, DateTimeKind.Local).AddTicks(7913), 0, 1939 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 1, 22, 3, "Optio minus sed possimus sunt itaque.", null },
                    { 2, 4, 3, "Deleniti nulla sed necessitatibus.", null },
                    { 3, 10, 3, "Architecto quae repellendus expedita ducimus molestiae aspernatur provident.", null },
                    { 4, 10, 14, "Quaerat eos odio officia dicta cum autem iure.", null },
                    { 5, 26, 6, "Et et earum ullam autem temporibus totam quod eos.", null },
                    { 6, 24, 3, "Ut quia dolore ea est dolorem est dolore omnis praesentium.", null },
                    { 7, 27, 11, "At veniam et eligendi nobis perspiciatis veritatis facilis.", null },
                    { 8, 6, 14, "Expedita molestiae aspernatur veritatis assumenda dolorem nesciunt ad quis velit.", null },
                    { 9, 6, 9, "Est adipisci fugiat fugiat.", null },
                    { 10, 20, 7, "Vitae in est nesciunt ullam.", null },
                    { 11, 10, 10, "Nihil pariatur quia sequi autem minus ipsa.", null },
                    { 12, 19, 6, "Enim modi inventore.", null },
                    { 13, 1, 11, "Occaecati dolorem praesentium.", null },
                    { 14, 20, 13, "Voluptatem qui rem sint corporis dolorum et provident aut numquam.", null },
                    { 15, 5, 12, "Et ad molestiae inventore omnis aliquam ut aut.", null },
                    { 16, 25, 14, "Dignissimos eaque est numquam ut occaecati autem ratione quia vel.", null }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "path", "book_id" },
                values: new object[,]
                {
                    { "10fake path", 11 },
                    { "11fake path", 19 },
                    { "12fake path", 5 },
                    { "13fake path", 3 },
                    { "14fake path", 27 },
                    { "15fake path", 10 },
                    { "16fake path", 24 },
                    { "1fake path", 4 },
                    { "2fake path", 12 },
                    { "3fake path", 14 },
                    { "4fake path", 16 },
                    { "5fake path", 23 },
                    { "6fake path", 18 },
                    { "7fake path", 6 },
                    { "8fake path", 23 },
                    { "9fake path", 26 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 17, 4, 13, "Voluptas nam nesciunt aliquid.", 13 },
                    { 18, 12, 13, "Sequi et iusto sapiente tempore aliquid dolorem voluptatem quo et.", 16 },
                    { 19, 3, 2, "Quia quidem ipsum distinctio repellat quae quis.", 16 },
                    { 20, 21, 3, "Voluptatem velit facere aspernatur.", 8 },
                    { 21, 17, 13, "Non assumenda dolores commodi consequatur praesentium adipisci.", 15 },
                    { 22, 10, 14, "Quasi maiores voluptate aut ducimus est nesciunt culpa.", 11 },
                    { 23, 28, 4, "Ex dolore architecto qui porro et voluptates.", 13 },
                    { 24, 25, 13, "Molestiae odit laborum nostrum esse dolorum excepturi iure.", 5 },
                    { 25, 14, 1, "In ut voluptatem et fugiat et sapiente dolorum.", 5 },
                    { 26, 26, 7, "Illum rem quisquam laboriosam.", 12 },
                    { 27, 14, 3, "Voluptatem et debitis quibusdam.", 9 },
                    { 28, 9, 16, "Enim qui sit error autem vitae voluptate.", 5 },
                    { 29, 12, 2, "Facilis enim laborum culpa eos labore ut alias.", 3 },
                    { 30, 7, 6, "Aut consequatur beatae dolorum et rerum dolor in.", 6 },
                    { 31, 20, 9, "Consequatur laboriosam pariatur placeat vel repudiandae et omnis enim.", 2 },
                    { 32, 28, 3, "Eveniet aspernatur minus et est beatae earum repellendus quibusdam qui.", 16 }
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

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
