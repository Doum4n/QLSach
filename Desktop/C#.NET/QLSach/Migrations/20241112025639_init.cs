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
                    quantity = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    remaining = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    { 1, "Omnis harum aut minus nemo quas quibusdam.", "Jayde" },
                    { 2, "Excepturi explicabo vel sed velit quasi et.", "Abraham" },
                    { 3, "Soluta ducimus officia et odit ullam vel quos sint.", "Antonetta" },
                    { 4, "Ut cupiditate et aperiam dolor culpa quis veritatis molestiae quia.", "Nicholaus" },
                    { 5, "Qui consequuntur dolorem temporibus eligendi molestias dignissimos expedita est nihil.", "Hosea" },
                    { 6, "Nostrum cum eaque impedit consequatur minus recusandae sit.", "Napoleon" },
                    { 7, "Reprehenderit asperiores voluptatem praesentium ipsum veritatis.", "Mabelle" },
                    { 8, "Dolor ut error magni a.", "Ewald" },
                    { 9, "Itaque autem voluptate qui iste dolorem nemo.", "Hassie" },
                    { 10, "Neque tempore asperiores consequatur rerum aut.", "George" },
                    { 11, "Sit aut veritatis eveniet soluta sunt.", "Christopher" },
                    { 12, "Consectetur sed qui quas iusto maxime hic quaerat facere architecto.", "Brant" },
                    { 13, "Voluptates asperiores blanditiis omnis.", "Avis" },
                    { 14, "Amet non excepturi et quod.", "Estell" },
                    { 15, "Esse est omnis maiores magnam deserunt.", "Aaliyah" },
                    { 16, "At expedita et temporibus et non sequi ducimus.", "Paul" },
                    { 17, "Autem saepe voluptatum voluptatem illum quia temporibus adipisci.", "Rhoda" },
                    { 18, "Omnis ut voluptas ex consequatur odit quis consequuntur sit ab.", "Lenna" },
                    { 19, "Temporibus laborum molestiae quam nihil perspiciatis cupiditate qui.", "Porter" },
                    { 20, "Nulla aperiam eos enim.", "Lucio" },
                    { 21, "Vitae quos possimus sint tenetur placeat quia earum dolor.", "Pauline" },
                    { 22, "Quia ut nobis consequatur ipsum voluptas a libero.", "Johann" },
                    { 23, "Omnis qui minus corrupti fugiat aut illo quisquam quo qui.", "Jaylon" },
                    { 24, "Ut consequatur expedita doloribus praesentium commodi voluptatem in.", "Stella" },
                    { 25, "Dolorum facilis dolorem debitis.", "Aracely" },
                    { 26, "Quisquam temporibus unde pariatur ipsum impedit inventore qui perferendis molestiae.", "Mabel" },
                    { 27, "Perspiciatis maxime architecto est.", "Rosa" },
                    { 28, "Quaerat provident incidunt dolorem quisquam commodi ipsum eaque qui rerum.", "Dock" },
                    { 29, "Voluptates a atque cum cupiditate esse non illo.", "Margaret" },
                    { 30, "Eveniet et hic quisquam cum accusamus officia rerum.", "Destiney" },
                    { 31, "Veritatis autem sed.", "Tyra" },
                    { 32, "In dolores incidunt ipsa delectus.", "Anderson" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "praesentium" },
                    { 2, "occaecati" },
                    { 3, "sapiente" },
                    { 4, "libero" },
                    { 5, "dolor" },
                    { 6, "ipsum" },
                    { 7, "aperiam" },
                    { 8, "cum" },
                    { 9, "ea" },
                    { 10, "exercitationem" },
                    { 11, "quam" },
                    { 12, "quo" },
                    { 13, "rerum" },
                    { 14, "a" },
                    { 15, "consequuntur" },
                    { 16, "vitae" },
                    { 17, "vel" },
                    { 18, "provident" },
                    { 19, "quibusdam" },
                    { 20, "soluta" },
                    { 21, "illum" },
                    { 22, "officiis" },
                    { 23, "nemo" },
                    { 24, "adipisci" },
                    { 25, "doloremque" },
                    { 26, "eveniet" },
                    { 27, "aperiam" },
                    { 28, "sed" },
                    { 29, "non" },
                    { 30, "possimus" },
                    { 31, "ut" },
                    { 32, "quaerat" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Eaque magnam in voluptates quae minus enim repellat aspernatur quae.", "Thad Rohan" },
                    { 2, "Maiores in mollitia quis.\nQuia ut atque asperiores.\nSequi sunt illo illo ullam delectus velit qui molestiae.\nAsperiores quas totam ut sit quia nobis consequatur.", "Tanya MacGyver" },
                    { 3, "sint", "Madaline Schumm" },
                    { 4, "Repellat quam animi dolores.", "Magali Ziemann" },
                    { 5, "Possimus fuga et aut sint cumque.\nNihil officiis est facere animi.\nVel quis aut consequatur quas et.\nDistinctio sed dolores aliquid sunt voluptatibus minus eos.", "Winston Feeney" },
                    { 6, "Id voluptatem est modi facilis dolores maxime sapiente sunt. Dicta officiis numquam aliquam suscipit veniam. Excepturi qui suscipit voluptatum. Eius blanditiis sint aut ex blanditiis omnis voluptatem molestiae sed.", "Nya Herzog" },
                    { 7, "Ut qui non dolor officia. Non voluptate eveniet. Libero consequatur aperiam velit porro eligendi occaecati eum at sit.", "Serenity Kunze" },
                    { 8, "Ab asperiores doloremque sit provident sit placeat nemo.", "Izabella Schulist" },
                    { 9, "Et placeat aut.\nIusto alias eum odit id temporibus.\nVoluptate tempora temporibus eum incidunt qui sapiente error consectetur doloribus.", "Tavares Monahan" },
                    { 10, "Doloribus velit quaerat facere deleniti reiciendis recusandae libero. Repellendus rem veniam totam distinctio odit vel vero sunt recusandae. Qui qui molestiae.", "Nils Bashirian" },
                    { 11, "omnis", "Gudrun Wilkinson" },
                    { 12, "Occaecati nesciunt accusantium dolor et nulla maiores ex.", "Eleonore Hyatt" },
                    { 13, "Commodi sint nam molestiae accusamus quod architecto.", "Jaida Stanton" },
                    { 14, "Dolorem totam dolores architecto.", "Javier Connelly" },
                    { 15, "Amet et nobis voluptas consequatur atque accusamus.\nVoluptatem adipisci eveniet quam a.\nDelectus ad incidunt aperiam.", "Justyn Ferry" },
                    { 16, "Nobis ipsum quam consequuntur voluptate aut alias.", "Roscoe McKenzie" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "quantity", "rating", "remaining", "updated_at", "views", "year_public" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(582), "Ut cum reprehenderit consequatur voluptatem dicta. Architecto voluptatum adipisci occaecati id. Nesciunt illum ut non ut possimus et suscipit natus. Earum laudantium quae odit esse illum dolor harum molestiae. Officia dolores delectus veritatis ea dolorem ducimus amet.", 30, "Ratione aut facere omnis minima voluptatem.", (byte)8, (byte)0, (byte)0, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(1107), 0, 1987 },
                    { 2, 4, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(1883), "Et velit eveniet officia voluptatem. Quisquam in ut quisquam quis qui error a. Iusto eum quisquam. Eveniet est dolor cupiditate omnis cumque eos ipsam placeat nihil. Quis asperiores non blanditiis.", 27, "Magnam tempora quidem consectetur reprehenderit aut.", (byte)7, (byte)0, (byte)3, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2045), 0, 1910 },
                    { 3, 23, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2058), "Earum sed maiores et et sed. Et necessitatibus necessitatibus consequatur nisi. Impedit impedit et et dolore optio. Placeat et excepturi sint error voluptatum sint nulla aspernatur. Magni dolore ad non sit repudiandae illo.", 8, "Ut culpa rerum possimus explicabo voluptas.", (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2177), 0, 2010 },
                    { 4, 30, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2189), "Vel reprehenderit similique illo et eos. Quo rerum saepe adipisci eum et esse animi vitae ipsa. Minima optio qui. Et sapiente eveniet non. Omnis adipisci aliquid quia consequatur quia error tempore.", 26, "Repudiandae non similique omnis voluptate fugit quia veritatis.", (byte)8, (byte)0, (byte)3, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2295), 0, 1968 },
                    { 5, 2, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2305), "Aliquid ab ad ut perferendis nihil laboriosam ipsa. Minima et omnis vel eligendi dignissimos ipsa nemo. Odit nesciunt sequi. Autem esse est eos enim tempora earum ut dolorum id. Omnis animi suscipit sit esse.", 26, "In ad ad doloribus temporibus velit sit est.", (byte)8, (byte)0, (byte)0, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2410), 0, 1960 },
                    { 6, 11, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2421), "Amet natus architecto esse nobis. Debitis quam ipsa facere asperiores voluptas. At aut nihil sunt ipsam nemo aut. Delectus suscipit amet incidunt.", 12, "Iste rem consequatur dignissimos sapiente eius.", (byte)5, (byte)0, (byte)5, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2498), 0, 2018 },
                    { 7, 16, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2509), "Nostrum aut officia amet. Non facere non doloremque voluptatem. Aperiam ipsam et quis sed quis accusamus.", 19, "Reiciendis reprehenderit labore.", (byte)10, (byte)0, (byte)0, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2567), 0, 1923 },
                    { 8, 25, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2578), "Praesentium nemo dolore libero voluptatem. Aut consequuntur totam facilis laborum corporis totam consequuntur dolore voluptatem. Eaque repellendus iure ut corporis recusandae mollitia recusandae explicabo.", 19, "Rerum recusandae itaque dolorem temporibus.", (byte)5, (byte)0, (byte)0, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2662), 0, 1931 },
                    { 9, 27, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2672), "Voluptates molestiae doloribus. Nostrum sed quae aspernatur tempore nihil natus atque non. Maiores assumenda qui exercitationem molestiae reiciendis delectus ullam quas. Atque impedit fuga consequuntur aut quibusdam. Voluptas blanditiis aliquid placeat suscipit.", 31, "Quo eum qui nemo reiciendis accusantium.", (byte)8, (byte)0, (byte)0, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2775), 0, 1949 },
                    { 10, 17, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2787), "In laudantium qui quo et voluptas aut. Modi culpa consequatur dolor et officiis maiores et repellendus. Qui sit voluptatum debitis. Veniam dolores error incidunt voluptatum officia.", 2, "Tempora incidunt in eum quod facilis.", (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2872), 0, 1920 },
                    { 11, 13, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2882), "Est omnis odio. Asperiores ut quae sit corporis dolor iste. Numquam animi fugit dolorem vel est unde. Veritatis sunt veritatis praesentium quaerat ut non.", 17, "Impedit reprehenderit laborum quis et.", (byte)8, (byte)0, (byte)3, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2959), 0, 1919 },
                    { 12, 26, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(2968), "Sequi ea similique ab enim in in. Voluptatem cumque unde minima voluptas. Facere et nostrum sapiente et aut. Animi omnis adipisci et dicta quaerat. Aliquid fuga nulla placeat.", 24, "Est repudiandae exercitationem natus blanditiis.", (byte)9, (byte)0, (byte)1, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3059), 0, 1983 },
                    { 13, 18, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3069), "Quia expedita illo illum totam dolorum ea quo ipsam. Omnis omnis nisi enim et. Sit velit eaque aut earum. Officiis omnis accusantium eos. Nihil dolorem aperiam et.", 23, "Sapiente iure deleniti iste vitae in accusantium non alias.", (byte)8, (byte)0, (byte)1, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3167), 0, 1977 },
                    { 14, 28, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3177), "Molestiae alias ad aut repellat. Repellendus in animi dolorum. In non asperiores nobis ab cum quae aut. Aut totam nihil similique nulla qui cupiditate nostrum aperiam illum. Aperiam aut facere iusto id velit.", 21, "Modi et in cumque laboriosam eum quae.", (byte)7, (byte)0, (byte)1, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3269), 0, 1942 },
                    { 15, 2, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3279), "Maxime et libero fuga et non at qui. Excepturi et magni cum eum quos rerum pariatur architecto. Voluptas aut illum ea saepe expedita. Ea debitis inventore qui.", 21, "Nostrum ducimus quis.", (byte)8, (byte)0, (byte)1, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3356), 0, 1981 },
                    { 16, 15, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3366), "Dolorem est laboriosam praesentium tempora assumenda. Distinctio aut quod asperiores aperiam quasi cupiditate libero. Dolorum nihil sed commodi. Voluptates nam libero quaerat et praesentium culpa. Alias iure neque perspiciatis aut tempora qui.", 24, "Enim architecto dolor asperiores debitis rem aut culpa atque.", (byte)7, (byte)0, (byte)0, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3469), 0, 1924 },
                    { 17, 10, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3479), "Nihil nulla quas ad dolorem velit ipsam eos a. Ullam perferendis non non dolorum a consequuntur repellat. Labore incidunt assumenda consequatur non nisi. Nostrum quos qui. Et ex quia nam et saepe autem. Repellendus officiis aut consequatur et ipsam.", 23, "Odio quod corporis esse.", (byte)8, (byte)0, (byte)0, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3590), 0, 1928 },
                    { 18, 28, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3601), "Natus nisi deserunt est tempora sunt culpa. Excepturi nam est eum laborum provident. Excepturi quasi hic sint minima. Sed deleniti officia exercitationem saepe deleniti rerum libero. Vero et labore aut voluptatum deleniti est sit eum. Repellat consectetur perspiciatis.", 14, "Nulla odit maxime consequatur enim.", (byte)7, (byte)0, (byte)5, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3708), 0, 1984 },
                    { 19, 29, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3718), "Molestiae occaecati quisquam sunt a tenetur eos quia numquam porro. Hic a consequuntur inventore sed quia ut eaque doloremque. Deserunt voluptatem aut ea id dolores.", 19, "Maiores perferendis nisi molestiae assumenda harum doloremque occaecati accusantium.", (byte)6, (byte)0, (byte)1, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3797), 0, 1997 },
                    { 20, 7, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3807), "Reprehenderit quam ratione ad. Et qui et minima libero qui cum laborum. Voluptas labore consequatur est quia rerum ut. Maiores voluptatem dicta ab et tempora. Cumque atque dolorem.", 10, "Aut voluptatem inventore minima.", (byte)5, (byte)0, (byte)0, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3897), 0, 1945 },
                    { 21, 29, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(3908), "Consequuntur deserunt laboriosam aut consectetur sit animi similique. Qui expedita tempore et explicabo qui. Dolor a nobis sit. Dolores earum corporis molestiae optio quasi itaque. Sit placeat magni dolores incidunt ducimus. Ex perspiciatis et.", 12, "Voluptatem ut consequatur atque dolore quo facilis.", (byte)10, (byte)0, (byte)3, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4008), 0, 1952 },
                    { 22, 29, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4017), "Minus odio vel harum dolores veritatis sit quas quos voluptatem. Accusamus voluptatem sapiente et saepe ut magnam neque. Est nesciunt voluptates et iusto dignissimos suscipit earum. Accusantium officiis laborum dicta.", 25, "Harum praesentium excepturi corporis omnis omnis quae in.", (byte)9, (byte)0, (byte)3, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4111), 0, 1990 },
                    { 23, 7, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4123), "Voluptates error vel voluptate. Et modi dolor cumque fugiat qui nisi. Autem et distinctio autem officia autem necessitatibus aut.", 10, "Numquam id non harum doloribus rerum enim necessitatibus.", (byte)10, (byte)0, (byte)3, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4191), 0, 2005 },
                    { 24, 30, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4201), "Nobis provident error. Cum maiores ea veritatis id. Aut cum minus veritatis ex. Qui officia nemo voluptate dignissimos ad laudantium impedit ut.", 18, "Nihil quo aliquam qui nihil delectus quidem.", (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4280), 0, 1962 },
                    { 25, 21, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4291), "Amet totam libero non animi eos nihil. Sit repellat recusandae reiciendis voluptas. Soluta est dicta velit iste laudantium minima beatae quibusdam. Aut eos ipsum voluptas amet.", 20, "Mollitia architecto cumque illum corrupti impedit ut vero.", (byte)10, (byte)0, (byte)5, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4377), 0, 1929 },
                    { 26, 20, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4387), "Autem suscipit qui rerum ut minima laudantium iste sit nesciunt. Saepe amet autem quaerat laborum perspiciatis est. Adipisci sit earum nam voluptatem molestias sint cupiditate. Sint quia sed commodi et perferendis velit. Eum nostrum pariatur provident magnam. Expedita cumque ipsam aut quis sapiente ducimus ex blanditiis excepturi.", 27, "Neque officia optio labore consequatur laborum.", (byte)5, (byte)0, (byte)5, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4510), 0, 1906 },
                    { 27, 21, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4525), "Iste aut qui porro consectetur quae voluptas sit. Sunt nemo consequatur aut. Illo neque ipsam iure. Consequatur et tenetur occaecati corrupti ipsum eos vel ea accusantium. Harum corporis eaque suscipit rerum placeat.", 1, "Natus distinctio qui dolore vel quia nam.", (byte)5, (byte)0, (byte)2, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4617), 0, 1900 },
                    { 28, 16, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4627), "Veniam delectus eius sed illo eum et labore magni incidunt. Natus provident sed voluptatem quae. Animi et quod possimus voluptate. Facilis architecto quia quidem sunt eligendi dolor placeat nam esse.", 29, "Ad voluptatum expedita quas voluptatem molestiae inventore.", (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 12, 9, 56, 39, 468, DateTimeKind.Local).AddTicks(4717), 0, 1935 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 1, 20, 16, "Qui dolor saepe sed omnis ad beatae et enim.", null },
                    { 2, 8, 12, "Et enim voluptates quo itaque.", null },
                    { 3, 3, 16, "Saepe qui maiores et ea molestiae.", null },
                    { 4, 6, 4, "Quas est vitae error id harum assumenda voluptatem.", null },
                    { 5, 5, 7, "Quibusdam aperiam aut aperiam magni eligendi.", null },
                    { 6, 18, 14, "Alias magni sapiente velit.", null },
                    { 7, 10, 9, "Voluptatem ipsum voluptate nihil soluta aut architecto sed.", null },
                    { 8, 24, 16, "Veritatis dolor repellat magnam aut repellendus voluptatem voluptatibus eligendi.", null },
                    { 9, 18, 15, "Aperiam et recusandae ipsum ad recusandae est omnis.", null },
                    { 10, 21, 5, "Ipsam aut ipsa vero dignissimos dolores perferendis.", null },
                    { 11, 27, 2, "Nihil recusandae error.", null },
                    { 12, 20, 11, "Dolor rem dolore et eos velit.", null },
                    { 13, 8, 4, "Doloribus ad et sed.", null },
                    { 14, 18, 5, "Nihil omnis nostrum et exercitationem.", null },
                    { 15, 20, 10, "Atque sunt id quis id.", null },
                    { 16, 5, 9, "Odit ex labore reprehenderit alias.", null }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "path", "book_id" },
                values: new object[,]
                {
                    { "10fake path", 20 },
                    { "11fake path", 28 },
                    { "12fake path", 2 },
                    { "13fake path", 28 },
                    { "14fake path", 5 },
                    { "15fake path", 25 },
                    { "16fake path", 22 },
                    { "1fake path", 25 },
                    { "2fake path", 18 },
                    { "3fake path", 27 },
                    { "4fake path", 16 },
                    { "5fake path", 11 },
                    { "6fake path", 11 },
                    { "7fake path", 15 },
                    { "8fake path", 28 },
                    { "9fake path", 23 }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 16, "Completed", 16, new DateTime(2024, 11, 11, 22, 38, 13, 711, DateTimeKind.Local).AddTicks(7868), new DateTime(2024, 11, 12, 13, 57, 56, 831, DateTimeKind.Local).AddTicks(5482), new DateTime(2024, 11, 5, 13, 57, 56, 831, DateTimeKind.Local).AddTicks(5482), new DateTime(2024, 11, 11, 5, 27, 22, 441, DateTimeKind.Local).AddTicks(1391) },
                    { 2, 18, "Canceled", 7, null, null, new DateTime(2024, 11, 12, 3, 57, 2, 326, DateTimeKind.Local).AddTicks(1673), null },
                    { 3, 10, "Borrowed", 16, new DateTime(2024, 11, 8, 5, 20, 29, 740, DateTimeKind.Local).AddTicks(8247), new DateTime(2024, 11, 15, 13, 33, 25, 761, DateTimeKind.Local).AddTicks(6371), new DateTime(2024, 11, 8, 13, 33, 25, 761, DateTimeKind.Local).AddTicks(6371), null },
                    { 4, 9, "Borrowed", 3, new DateTime(2024, 11, 8, 13, 35, 23, 267, DateTimeKind.Local).AddTicks(1705), new DateTime(2024, 11, 13, 3, 55, 11, 455, DateTimeKind.Local).AddTicks(5149), new DateTime(2024, 11, 6, 3, 55, 11, 455, DateTimeKind.Local).AddTicks(5149), null },
                    { 5, 23, "Borrowed", 16, new DateTime(2024, 11, 10, 9, 16, 45, 908, DateTimeKind.Local).AddTicks(947), new DateTime(2024, 11, 16, 0, 54, 31, 546, DateTimeKind.Local).AddTicks(9773), new DateTime(2024, 11, 9, 0, 54, 31, 546, DateTimeKind.Local).AddTicks(9773), null },
                    { 6, 8, "Borrowed", 13, new DateTime(2024, 11, 10, 12, 43, 38, 750, DateTimeKind.Local).AddTicks(4333), new DateTime(2024, 11, 12, 13, 57, 1, 496, DateTimeKind.Local).AddTicks(6019), new DateTime(2024, 11, 5, 13, 57, 1, 496, DateTimeKind.Local).AddTicks(6019), null },
                    { 7, 21, "Completed", 13, new DateTime(2024, 11, 12, 9, 53, 13, 889, DateTimeKind.Local).AddTicks(7210), new DateTime(2024, 11, 13, 0, 51, 28, 522, DateTimeKind.Local).AddTicks(7749), new DateTime(2024, 11, 6, 0, 51, 28, 522, DateTimeKind.Local).AddTicks(7749), new DateTime(2024, 11, 10, 23, 8, 14, 248, DateTimeKind.Local).AddTicks(2417) },
                    { 8, 14, "Borrowed", 1, new DateTime(2024, 11, 11, 5, 17, 15, 833, DateTimeKind.Local).AddTicks(4967), new DateTime(2024, 11, 17, 13, 20, 53, 431, DateTimeKind.Local).AddTicks(5267), new DateTime(2024, 11, 10, 13, 20, 53, 431, DateTimeKind.Local).AddTicks(5267), null },
                    { 9, 24, "Completed", 6, new DateTime(2024, 11, 10, 9, 42, 36, 905, DateTimeKind.Local).AddTicks(544), new DateTime(2024, 11, 18, 20, 51, 4, 708, DateTimeKind.Local).AddTicks(9380), new DateTime(2024, 11, 11, 20, 51, 4, 708, DateTimeKind.Local).AddTicks(9380), new DateTime(2024, 11, 11, 11, 39, 17, 800, DateTimeKind.Local).AddTicks(6170) },
                    { 10, 14, "Completed", 9, new DateTime(2024, 11, 9, 1, 16, 34, 665, DateTimeKind.Local).AddTicks(9713), new DateTime(2024, 11, 15, 11, 12, 5, 1, DateTimeKind.Local).AddTicks(5292), new DateTime(2024, 11, 8, 11, 12, 5, 1, DateTimeKind.Local).AddTicks(5292), new DateTime(2024, 11, 11, 14, 28, 2, 521, DateTimeKind.Local).AddTicks(3035) },
                    { 11, 24, "Canceled", 1, null, null, new DateTime(2024, 11, 11, 6, 45, 38, 75, DateTimeKind.Local).AddTicks(6890), null },
                    { 12, 12, "Completed", 16, new DateTime(2024, 11, 11, 11, 3, 39, 668, DateTimeKind.Local).AddTicks(4372), new DateTime(2024, 11, 13, 22, 49, 7, 790, DateTimeKind.Local).AddTicks(9402), new DateTime(2024, 11, 6, 22, 49, 7, 790, DateTimeKind.Local).AddTicks(9402), new DateTime(2024, 11, 10, 14, 14, 5, 64, DateTimeKind.Local).AddTicks(8727) },
                    { 13, 14, "Canceled", 1, null, null, new DateTime(2024, 11, 11, 14, 22, 43, 185, DateTimeKind.Local).AddTicks(4932), null },
                    { 14, 22, "Completed", 8, new DateTime(2024, 11, 8, 14, 41, 56, 648, DateTimeKind.Local).AddTicks(2382), new DateTime(2024, 11, 19, 4, 6, 7, 218, DateTimeKind.Local).AddTicks(658), new DateTime(2024, 11, 12, 4, 6, 7, 218, DateTimeKind.Local).AddTicks(658), new DateTime(2024, 11, 9, 10, 27, 44, 796, DateTimeKind.Local).AddTicks(3623) },
                    { 15, 18, "Completed", 10, new DateTime(2024, 11, 11, 9, 8, 11, 131, DateTimeKind.Local).AddTicks(7630), new DateTime(2024, 11, 12, 11, 26, 57, 344, DateTimeKind.Local).AddTicks(5217), new DateTime(2024, 11, 5, 11, 26, 57, 344, DateTimeKind.Local).AddTicks(5217), new DateTime(2024, 11, 11, 2, 23, 28, 711, DateTimeKind.Local).AddTicks(2236) },
                    { 16, 9, "Canceled", 4, null, null, new DateTime(2024, 11, 9, 2, 15, 59, 675, DateTimeKind.Local).AddTicks(6422), null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 17, 27, 5, "Laudantium consequatur velit tempora ut ea perferendis molestiae.", 8 },
                    { 18, 27, 6, "Facere eum qui aperiam iusto voluptatibus.", 7 },
                    { 19, 16, 11, "Ea error et vitae omnis a asperiores iure consequatur.", 16 },
                    { 20, 26, 15, "Ad quisquam quibusdam.", 14 },
                    { 21, 16, 16, "Quo quia est voluptates aspernatur facilis quidem velit ut sit.", 3 },
                    { 22, 24, 8, "Eaque accusamus totam quibusdam.", 16 },
                    { 23, 11, 1, "Illum cumque assumenda assumenda est ipsum qui expedita.", 14 },
                    { 24, 9, 13, "Aliquid magnam iste similique voluptatibus vel.", 12 },
                    { 25, 13, 13, "Non velit maxime rerum eos voluptatum sed sequi autem ut.", 7 },
                    { 26, 8, 7, "Commodi quod tenetur expedita modi accusantium beatae dolorem sequi natus.", 12 },
                    { 27, 19, 10, "Expedita exercitationem optio est adipisci nihil.", 14 },
                    { 28, 14, 7, "Temporibus reprehenderit quisquam nostrum.", 7 },
                    { 29, 16, 9, "Error natus assumenda veniam iste.", 7 },
                    { 30, 26, 15, "Consequuntur modi quibusdam doloremque autem sit.", 15 },
                    { 31, 18, 4, "Libero eligendi id error nulla doloribus minus quia.", 1 },
                    { 32, 22, 6, "Nobis corporis autem iusto.", 7 }
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
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Register");

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
