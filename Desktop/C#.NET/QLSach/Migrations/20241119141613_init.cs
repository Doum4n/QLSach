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
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_at = table.Column<DateOnly>(type: "date", nullable: false),
                    update_at = table.Column<DateOnly>(type: "date", nullable: false)
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
                    { 1, "Sed eum suscipit aspernatur dolor eius.", "Crystal" },
                    { 2, "Est consequatur quia in ut corporis commodi eaque reiciendis.", "Earnestine" },
                    { 3, "Consectetur veniam commodi velit voluptatibus itaque.", "Mazie" },
                    { 4, "Enim dolores qui.", "Amiya" },
                    { 5, "Quaerat et nihil consequatur fugiat placeat ipsa a quae ea.", "Wanda" },
                    { 6, "Sed expedita unde voluptatem.", "Giles" },
                    { 7, "Eligendi iusto quaerat ex dolor voluptatem mollitia voluptas.", "Jovan" },
                    { 8, "Eos minus non.", "Annie" },
                    { 9, "Atque deserunt recusandae quia ut dolor molestias quam distinctio.", "Tiara" },
                    { 10, "Est assumenda voluptas et laborum provident deserunt.", "Marshall" },
                    { 11, "Occaecati qui impedit.", "Guy" },
                    { 12, "Numquam qui nemo.", "Eduardo" },
                    { 13, "Illum nostrum nulla blanditiis.", "Salvatore" },
                    { 14, "Explicabo autem sint laboriosam qui et esse iure aut velit.", "Lulu" },
                    { 15, "Consequatur qui maxime voluptas ratione officia ab.", "Katlyn" },
                    { 16, "Rem iste officia nihil et eveniet omnis sint odit voluptatibus.", "Torrey" },
                    { 17, "Autem illo nesciunt vel sunt quia libero.", "Yvonne" },
                    { 18, "Quis laboriosam qui qui et eos.", "Edd" },
                    { 19, "Reprehenderit et deleniti et placeat laudantium harum labore accusamus.", "Verla" },
                    { 20, "Alias temporibus necessitatibus atque animi sunt pariatur ut est inventore.", "Cleve" },
                    { 21, "At magni qui.", "Precious" },
                    { 22, "Qui cupiditate repudiandae sint nobis et sed.", "Gladyce" },
                    { 23, "Quam voluptas adipisci amet et voluptas voluptas vel.", "Hattie" },
                    { 24, "Quos accusamus atque consequatur eligendi modi.", "Granville" },
                    { 25, "Autem quis et maxime est suscipit soluta laborum excepturi.", "Halle" },
                    { 26, "Necessitatibus suscipit nostrum saepe harum molestias esse pariatur voluptas.", "Alysha" },
                    { 27, "Voluptas itaque et.", "Marques" },
                    { 28, "Earum aliquam quis quia rem animi amet.", "Dahlia" },
                    { 29, "Quos fugit quibusdam qui.", "Abagail" },
                    { 30, "Unde ab eius ea dolores fugiat et architecto dolor facere.", "Abraham" },
                    { 31, "Dignissimos voluptatibus voluptatem tenetur qui ea ut commodi praesentium.", "Kaycee" },
                    { 32, "Voluptatem velit atque sint aut quia doloremque.", "Garth" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Dignissimos quidem consequatur et praesentium nulla maxime quia mollitia. Consequatur aliquam neque nobis consequatur in sit temporibus. Et qui ullam quia deserunt et sit ducimus dolores. Cum beatae aut. Sint vero voluptates ducimus minima sapiente et in. Nisi pariatur maxime ratione assumenda corporis perspiciatis quasi.", "Nostrum dolore officia libero dolorem.", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 2, "Nobis non et esse accusamus eaque pariatur ut. Tenetur non ut aliquid architecto id dicta accusamus. Quibusdam et dicta ducimus sed corrupti pariatur molestiae sapiente. Corrupti id perspiciatis et suscipit rerum impedit dignissimos.", "repudiandae", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 3, "Numquam at ut nesciunt doloremque velit illo et eveniet. At reiciendis nisi voluptatem ipsa non illo ut et. Qui quam nam mollitia eos sunt et et delectus. Nemo voluptatem aut nemo autem repellat nam sunt.", "Qui ea animi minima rem sunt expedita.", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 4, "Tenetur eius aut. Deleniti impedit qui. Ratione quidem et consequatur cumque esse iste. Molestiae perferendis impedit. Non laborum aliquid delectus inventore quis eaque minima quasi. Placeat eos expedita officiis similique quibusdam.", "Consectetur fuga quaerat totam animi odit omnis. Id vitae dignissimos velit qui. Repellendus labore mollitia recusandae nisi mollitia omnis quos. Nesciunt explicabo minus.", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 5, "Aspernatur qui distinctio alias dolorem. Sit necessitatibus consequatur quia. Rerum magnam a totam ut quia. Rerum consequatur atque dolorem ducimus maxime optio excepturi aliquam. Quam libero nihil sit ipsum mollitia.", "Qui quisquam error repellendus. Omnis eveniet ut quis aut eaque aliquid ipsa eius. Necessitatibus sequi consequatur earum ipsum blanditiis.", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "velit" },
                    { 2, "quaerat" },
                    { 3, "voluptas" },
                    { 4, "sit" },
                    { 5, "aperiam" },
                    { 6, "qui" },
                    { 7, "iure" },
                    { 8, "dolorum" },
                    { 9, "eius" },
                    { 10, "reprehenderit" },
                    { 11, "vero" },
                    { 12, "delectus" },
                    { 13, "libero" },
                    { 14, "eum" },
                    { 15, "ipsa" },
                    { 16, "deleniti" },
                    { 17, "est" },
                    { 18, "labore" },
                    { 19, "et" },
                    { 20, "sunt" },
                    { 21, "ex" },
                    { 22, "et" },
                    { 23, "quidem" },
                    { 24, "culpa" },
                    { 25, "ratione" },
                    { 26, "non" },
                    { 27, "velit" },
                    { 28, "molestias" },
                    { 29, "ducimus" },
                    { 30, "itaque" },
                    { 31, "ipsam" },
                    { 32, "perspiciatis" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Aric Corkery", "Minus dignissimos iste a quo quis aut deserunt et ut.", "User", "Braxton", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 2, "Lamar Wyman", "Fugiat facere odio illum harum minus iusto aliquid voluptatem molestiae.\nSint et fugiat et labore atque sint.", "Admin", "Rosina", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 3, "Edythe McClure", "ut", "Admin", "Gisselle", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 4, "Hyman Wisoky", "Deleniti praesentium molestiae porro et qui.\nAnimi quibusdam tempora voluptatem quibusdam autem ratione.\nAssumenda rerum corporis ut repudiandae quia nostrum ullam.\nConsequatur eligendi velit ipsa facere aliquam et animi.\nEt temporibus numquam error.", "Admin", "Dameon", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 5, "Keshawn Moore", "Repellat nihil repellendus reprehenderit quos esse.\nExcepturi quia omnis placeat accusantium assumenda ex.\nIpsa eligendi vitae quia vel ad ipsum aliquam.", "User", "Hannah", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 6, "Jeremie Hermann", "Maiores ut et illum natus fuga dolore.", "Admin", "Gwendolyn", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 7, "Jamel Schultz", "Quis odio voluptate maxime rerum quia maxime incidunt mollitia reiciendis. Voluptatibus qui voluptatibus. Optio quam a iusto et rerum. Tempora quia excepturi. Nisi autem itaque ad eum sequi ea nisi aut.", "User", "Leon", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 8, "Elian Mayert", "Totam perferendis adipisci qui molestiae.\nNeque recusandae quae dolorem rem mollitia sapiente non recusandae.\nReiciendis sapiente quia possimus quo itaque ipsa.\nQuas aspernatur quas deleniti corporis quidem ut ut.\nAut quibusdam quas iure necessitatibus nihil dolorum harum eos excepturi.\nEius voluptatem mollitia exercitationem soluta velit blanditiis fuga.", "User", "Aracely", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 9, "Vergie Brakus", "Culpa non quia dolores.", "Admin", "Demetrius", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 10, "Hadley Connelly", "Dolores id est ea numquam expedita ut sit dolorem reprehenderit.\nNecessitatibus et aut suscipit error error.\nHarum et officiis beatae perspiciatis minus est quis neque.", "Admin", "Kenna", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 11, "Shayna Rau", "Culpa in animi.\nNumquam aut qui ad eum.", "User", "Howard", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 12, "Paula Zemlak", "accusantium", "User", "Duncan", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 13, "Vanessa Fritsch", "Vero sed delectus commodi assumenda.\nIure autem non quia necessitatibus aut.", "User", "Catalina", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 14, "Heath Bernier", "Voluptatibus et voluptas ipsum laboriosam et labore sint vitae quis.", "User", "Abagail", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 15, "Levi Schinner", "Porro ut dolorum quia quis tenetur.", "User", "Alexie", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) },
                    { 16, "Josue Emard", "Corrupti ex cum dignissimos eos atque magni. Debitis enim pariatur sapiente iusto et consectetur nisi. Et suscipit voluptas sed repellendus dignissimos quos. Fuga velit non asperiores rerum molestiae consequatur. Vel officiis suscipit voluptates non sit itaque ipsam.", "Admin", "Billy", new DateOnly(2024, 11, 19), new DateOnly(2024, 11, 19) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "quantity", "rating", "remaining", "updated_at", "views", "year_public" },
                values: new object[,]
                {
                    { 1, 12, new DateTime(2024, 11, 19, 21, 16, 13, 586, DateTimeKind.Local).AddTicks(8404), "Temporibus ut adipisci sapiente consectetur quos et enim est eveniet. Inventore tempore molestias sapiente tenetur. Consectetur quod quia cumque ut fugit aspernatur porro similique optio. Id perspiciatis repudiandae.", 12, "Fuga molestias officiis earum.", (byte)9, (byte)0, (byte)2, new DateTime(2024, 11, 19, 21, 16, 13, 586, DateTimeKind.Local).AddTicks(8801), 0, 1937 },
                    { 2, 23, new DateTime(2024, 11, 19, 21, 16, 13, 586, DateTimeKind.Local).AddTicks(9703), "Occaecati molestiae sit. Impedit rerum maxime error vel. Nostrum eius eos mollitia consequuntur placeat odio quasi quia tempora.", 19, "Sint est reprehenderit reiciendis explicabo voluptatem quo.", (byte)9, (byte)0, (byte)0, new DateTime(2024, 11, 19, 21, 16, 13, 586, DateTimeKind.Local).AddTicks(9825), 0, 2024 },
                    { 3, 7, new DateTime(2024, 11, 19, 21, 16, 13, 586, DateTimeKind.Local).AddTicks(9839), "Aspernatur velit ut provident architecto. Dolorem adipisci consequatur et necessitatibus labore quod aut quod quia. Eum et voluptate ut aut et in laboriosam qui tempore.", 21, "Mollitia eaque vero.", (byte)8, (byte)0, (byte)3, new DateTime(2024, 11, 19, 21, 16, 13, 586, DateTimeKind.Local).AddTicks(9946), 0, 1928 },
                    { 4, 30, new DateTime(2024, 11, 19, 21, 16, 13, 586, DateTimeKind.Local).AddTicks(9959), "Inventore rerum non reprehenderit quia est et vel facilis accusantium. Tenetur quae fugit aliquam. Aut ut ea est est consequatur consequatur incidunt sit illum. Voluptatem et atque quia accusamus.", 4, "Excepturi consequatur laborum.", (byte)9, (byte)0, (byte)1, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(49), 0, 2011 },
                    { 5, 10, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(61), "Velit reprehenderit doloribus tempore voluptatibus. Beatae id aut id qui impedit. Quas cupiditate harum facere sed qui eius cum veniam. Repellat sed temporibus dolores dolor voluptate sapiente tempora praesentium provident.", 18, "Quia suscipit corrupti nam minus autem architecto et reiciendis aliquid.", (byte)7, (byte)0, (byte)3, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(181), 0, 2003 },
                    { 6, 6, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(193), "Hic totam qui. Eius itaque est eos dolor quam ex vero esse. Itaque ex et consequatur deserunt cumque. Quia est sit in officiis itaque voluptatibus tempora quibusdam sit. Quidem et aut. Consequatur qui minima animi ea voluptatibus in sit sit.", 15, "Eum vitae aspernatur quisquam quos ipsum qui.", (byte)7, (byte)0, (byte)5, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(323), 0, 2016 },
                    { 7, 13, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(334), "Qui voluptas voluptatem. Amet recusandae maiores et nemo voluptates. Officia qui magni dolor temporibus cum corporis consequatur. Sapiente tempore quia aut laborum dolores ut accusantium necessitatibus vitae. Sed sequi qui aut alias.", 27, "Et laborum id corporis.", (byte)9, (byte)0, (byte)3, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(449), 0, 1952 },
                    { 8, 29, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(461), "Deserunt distinctio voluptas quae nesciunt omnis quisquam. Quod reprehenderit enim inventore consequatur. Ea ex amet quam aspernatur eos nemo quam odit.", 23, "Qui est et porro quae impedit earum quis.", (byte)7, (byte)0, (byte)1, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(535), 0, 1960 },
                    { 9, 24, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(565), "Corporis pariatur ipsam repellendus dolorem aliquam voluptatem id facere repudiandae. Ut cum quasi nobis ut repellendus. Qui aspernatur et facere aut neque eos sed expedita. Ipsum qui et. Consequatur aliquid occaecati nobis. Commodi molestiae quia magnam veritatis modi tempore cupiditate.", 14, "Ut ipsa doloremque voluptates ut ad necessitatibus veniam nihil quia.", (byte)10, (byte)0, (byte)4, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(680), 0, 1947 },
                    { 10, 23, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(691), "Asperiores qui earum aliquid explicabo facilis quia. Sed sed repudiandae non aliquam officiis rerum occaecati ullam. Deleniti dignissimos eligendi iste rem. Aut consequatur ab enim dolor error velit. Quisquam sed voluptas commodi doloribus atque id beatae et cumque. Omnis voluptatem sequi iste vitae.", 19, "Minima magnam velit aspernatur.", (byte)5, (byte)0, (byte)5, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(824), 0, 1968 },
                    { 11, 14, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(836), "Sunt quia qui et tenetur eveniet reiciendis. Et nihil odit molestiae quia natus molestias est quo blanditiis. Recusandae optio ea amet asperiores adipisci non. Alias cupiditate aliquid cum dicta qui corporis vero beatae pariatur. Ea eveniet corrupti dolores aperiam ipsa. Quis non omnis et cumque exercitationem.", 10, "Facere corrupti aut.", (byte)5, (byte)0, (byte)0, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(959), 0, 1945 },
                    { 12, 9, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(970), "Inventore velit cupiditate maxime ut aperiam ab voluptas error quos. Quam non asperiores voluptatum sed delectus debitis at. Animi dolorem ut possimus soluta omnis deleniti. Sed earum est sit et delectus provident eligendi. Sit nostrum repudiandae ut qui blanditiis modi quia libero excepturi.", 22, "Est repellat tempora accusamus.", (byte)6, (byte)0, (byte)0, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1106), 0, 1930 },
                    { 13, 10, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1116), "Omnis nostrum consectetur esse illum dolores cupiditate labore ipsum. Omnis ut dolor quam omnis consectetur. Illum molestias qui perspiciatis nisi nihil. Qui est porro officiis et pariatur aut sit. Ex sint nihil beatae. Rem nobis inventore quia labore voluptates quia blanditiis itaque aut.", 5, "Dolores rerum consectetur cupiditate qui ullam velit.", (byte)5, (byte)0, (byte)2, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1260), 0, 2013 },
                    { 14, 5, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1271), "Neque provident possimus aut eius error adipisci blanditiis. Autem dolorum quidem fugit illum expedita qui. Quia distinctio non ea quidem eligendi commodi qui non.", 6, "Dolor sed autem eligendi.", (byte)7, (byte)0, (byte)0, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1367), 0, 1984 },
                    { 15, 17, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1377), "Est non eaque aperiam consequatur voluptatem est. Veniam dolorum eos magni nulla asperiores cumque quas aut. Recusandae placeat quod qui est et repellat velit dolor.", 26, "Vero quibusdam illum deleniti.", (byte)7, (byte)0, (byte)5, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1448), 0, 1922 },
                    { 16, 20, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1459), "Non et itaque et sunt ut ea et. Dolores aut eaque. Veritatis voluptatum quia enim dolorem.", 29, "Repudiandae exercitationem facere et laboriosam iusto.", (byte)10, (byte)0, (byte)1, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1550), 0, 1960 },
                    { 17, 26, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1560), "Quaerat tempora minima ipsum ad quam corrupti nulla. Assumenda vel inventore aspernatur non delectus veniam corrupti voluptate nostrum. Quos necessitatibus voluptatibus laudantium. Ea blanditiis quo praesentium sit sed eos dolor.", 13, "Similique tempore quas minus in autem iure ea quibusdam.", (byte)10, (byte)0, (byte)3, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1672), 0, 1914 },
                    { 18, 16, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1683), "Incidunt et soluta. Blanditiis iusto unde sequi quia eveniet quo adipisci ipsa. Provident corrupti at corporis aliquam ut assumenda. Impedit libero voluptatem. Voluptatum vel velit voluptatem. Laborum at esse placeat.", 31, "Quas voluptates molestias voluptatem aut maxime quis expedita est.", (byte)6, (byte)0, (byte)2, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1781), 0, 1958 },
                    { 19, 12, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1816), "Quia delectus voluptatem. Numquam nihil voluptatem ipsa. Vel odio nobis eveniet dolor quibusdam eum dolorem.", 19, "Id ratione sunt labore optio.", (byte)7, (byte)0, (byte)3, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1876), 0, 1989 },
                    { 20, 22, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1886), "Voluptas ipsa rerum magnam. In et est vel voluptates vel soluta enim culpa. Aliquam impedit eos cumque ipsa maiores et quidem repellendus. Occaecati velit ducimus qui rerum.", 9, "Sunt reiciendis sit aspernatur sed id qui quis doloremque saepe.", (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(1994), 0, 2012 },
                    { 21, 30, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2005), "Voluptate repellat dignissimos eos voluptate. Velit eos architecto temporibus fugit hic sed. Dolorem rerum iusto suscipit nesciunt quia animi beatae ad. Odit non officiis qui. Quia explicabo sunt odit eos ea vero. Libero voluptatem perspiciatis amet.", 27, "Dolores vel ipsa autem qui dolorem.", (byte)9, (byte)0, (byte)5, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2120), 0, 1905 },
                    { 22, 14, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2131), "Sint est magnam perspiciatis dolores sit ut unde. Est molestiae consequuntur est. Cum magni nostrum et debitis. Temporibus ut voluptatem quia sed neque quisquam aut ea. Non autem laudantium vitae quos numquam quia maxime saepe repudiandae. Aspernatur nihil voluptas explicabo.", 32, "Ex sit quis ea est repudiandae possimus occaecati aperiam doloremque.", (byte)10, (byte)0, (byte)5, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2271), 0, 1973 },
                    { 23, 13, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2281), "Et dolor ut. Expedita expedita quia neque culpa accusantium et nemo sed. Debitis ut distinctio cupiditate.", 14, "Rerum eaque est dicta quaerat quidem repellendus autem.", (byte)6, (byte)0, (byte)5, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2348), 0, 1939 },
                    { 24, 23, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2358), "Voluptas rem adipisci nostrum ut consequatur sed quia minus. Et ut aut nam ipsa praesentium sunt explicabo unde. Aliquid optio aliquid laborum qui doloribus eos at. Quis quis dolore quia. Est consequatur sed. Qui doloribus enim architecto inventore quis quam laborum.", 21, "Fugit vitae incidunt.", (byte)8, (byte)0, (byte)2, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2491), 0, 1996 },
                    { 25, 22, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2502), "Pariatur facilis iusto laboriosam dolorem. Voluptatem consectetur debitis dolorem id perspiciatis sint qui perspiciatis. Hic minus architecto laboriosam. Ullam aut adipisci illo. Itaque eius quisquam dolore libero qui et eos corrupti. Saepe fugit accusantium blanditiis voluptatem sapiente.", 25, "Nam voluptates libero dolor dolores possimus quibusdam.", (byte)5, (byte)0, (byte)4, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2633), 0, 1920 },
                    { 26, 7, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2644), "Et optio molestiae aut quo magni temporibus. Ut non et. Harum asperiores aliquid consequatur aliquid voluptas itaque corporis odio quam. Sed ea autem inventore voluptatibus error sunt. Sit aperiam exercitationem pariatur deserunt aut cumque. Voluptatem quod rem omnis aliquam iste sit omnis.", 28, "Voluptatem molestiae labore iste.", (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2903), 0, 1925 },
                    { 27, 24, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2914), "Ea aperiam libero. Laudantium error aut ipsum quod dignissimos. Illo quisquam enim distinctio. Rerum maiores corrupti iste.", 14, "Sed rem nemo.", (byte)8, (byte)0, (byte)5, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2976), 0, 1929 },
                    { 28, 23, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(2986), "Ipsa ipsum ad id occaecati iste corporis consequuntur quibusdam necessitatibus. Non ipsa repellendus ut eos praesentium. Consequatur reiciendis sequi.", 14, "Saepe dolorem molestiae quo magni molestias velit ut voluptas.", (byte)9, (byte)0, (byte)5, new DateTime(2024, 11, 19, 21, 16, 13, 587, DateTimeKind.Local).AddTicks(3084), 0, 1959 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBook",
                columns: new[] { "Id", "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 14, 4 },
                    { 2, 20, 3 },
                    { 3, 18, 4 },
                    { 4, 1, 5 },
                    { 5, 28, 3 },
                    { 6, 25, 3 },
                    { 7, 26, 5 },
                    { 8, 22, 3 },
                    { 9, 28, 4 },
                    { 10, 19, 3 },
                    { 11, 3, 4 },
                    { 12, 28, 1 },
                    { 13, 5, 1 },
                    { 14, 17, 3 },
                    { 15, 20, 1 },
                    { 16, 8, 3 },
                    { 17, 16, 1 },
                    { 18, 6, 4 },
                    { 19, 11, 5 },
                    { 20, 21, 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 1, 8, 14, "Impedit voluptatem qui sed reiciendis ipsa dolores repellendus inventore harum.", null },
                    { 2, 16, 5, "Beatae illo molestiae.", null },
                    { 3, 15, 14, "Cupiditate modi libero quos laborum nostrum quidem voluptas.", null },
                    { 4, 18, 16, "Velit expedita minus aut.", null },
                    { 5, 11, 16, "Molestias animi animi saepe aut mollitia voluptas.", null },
                    { 6, 25, 11, "Sed cupiditate quia facilis non soluta.", null },
                    { 7, 7, 16, "Omnis laboriosam commodi laboriosam molestiae eos.", null },
                    { 8, 6, 4, "Excepturi aspernatur sequi ea.", null },
                    { 9, 10, 3, "Commodi sint et totam labore ab.", null },
                    { 10, 25, 15, "Nesciunt omnis corporis quod harum voluptates harum consequatur maxime saepe.", null },
                    { 11, 16, 7, "Suscipit ullam quibusdam provident optio velit.", null },
                    { 12, 10, 3, "Nihil est velit ea aut molestiae et soluta alias.", null },
                    { 13, 21, 3, "Adipisci alias quam animi.", null },
                    { 14, 18, 8, "Autem at nesciunt dolore.", null },
                    { 15, 21, 9, "Quam architecto et quasi omnis.", null },
                    { 16, 25, 1, "Et voluptatem sit eum vel vel.", null }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "book_id", "path" },
                values: new object[,]
                {
                    { 1, 26, ".\\resources\\images\\poster.png" },
                    { 2, 8, ".\\resources\\images\\poster.png" },
                    { 3, 18, ".\\resources\\images\\poster.png" },
                    { 4, 11, ".\\resources\\images\\poster.png" },
                    { 5, 8, ".\\resources\\images\\poster.png" },
                    { 6, 1, ".\\resources\\images\\poster.png" },
                    { 7, 17, ".\\resources\\images\\poster.png" },
                    { 8, 6, ".\\resources\\images\\poster.png" },
                    { 9, 20, ".\\resources\\images\\poster.png" },
                    { 10, 6, ".\\resources\\images\\poster.png" },
                    { 11, 28, ".\\resources\\images\\poster.png" },
                    { 12, 17, ".\\resources\\images\\poster.png" },
                    { 13, 25, ".\\resources\\images\\poster.png" },
                    { 14, 4, ".\\resources\\images\\poster.png" },
                    { 15, 9, ".\\resources\\images\\poster.png" },
                    { 16, 20, ".\\resources\\images\\poster.png" }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 20, "Pending", 7, null, null, new DateTime(2024, 11, 14, 16, 15, 18, 820, DateTimeKind.Local).AddTicks(6978), null },
                    { 2, 12, "Canceled", 11, null, null, new DateTime(2024, 11, 15, 15, 21, 30, 971, DateTimeKind.Local).AddTicks(7704), null },
                    { 3, 17, "Canceled", 10, null, null, new DateTime(2024, 11, 12, 22, 53, 11, 757, DateTimeKind.Local).AddTicks(8264), null },
                    { 4, 17, "Pending", 10, null, null, new DateTime(2024, 11, 19, 2, 24, 39, 211, DateTimeKind.Local).AddTicks(991), null },
                    { 5, 7, "Borrowed", 15, new DateTime(2024, 11, 16, 1, 37, 54, 343, DateTimeKind.Local).AddTicks(6520), new DateTime(2024, 11, 23, 11, 6, 41, 239, DateTimeKind.Local).AddTicks(1937), new DateTime(2024, 11, 16, 11, 6, 41, 239, DateTimeKind.Local).AddTicks(1937), null },
                    { 6, 23, "Canceled", 10, null, null, new DateTime(2024, 11, 15, 9, 27, 37, 829, DateTimeKind.Local).AddTicks(3172), null },
                    { 7, 9, "Borrowed", 7, new DateTime(2024, 11, 17, 10, 29, 35, 244, DateTimeKind.Local).AddTicks(8426), new DateTime(2024, 11, 25, 8, 47, 50, 799, DateTimeKind.Local).AddTicks(2540), new DateTime(2024, 11, 18, 8, 47, 50, 799, DateTimeKind.Local).AddTicks(2540), null },
                    { 8, 12, "Pending", 5, null, null, new DateTime(2024, 11, 17, 9, 37, 58, 59, DateTimeKind.Local).AddTicks(8015), null },
                    { 9, 7, "Completed", 8, new DateTime(2024, 11, 18, 19, 4, 30, 269, DateTimeKind.Local).AddTicks(527), new DateTime(2024, 11, 22, 21, 22, 58, 353, DateTimeKind.Local).AddTicks(8476), new DateTime(2024, 11, 15, 21, 22, 58, 353, DateTimeKind.Local).AddTicks(8476), new DateTime(2024, 11, 18, 20, 34, 14, 700, DateTimeKind.Local).AddTicks(6730) },
                    { 10, 2, "Borrowed", 5, new DateTime(2024, 11, 17, 4, 4, 0, 322, DateTimeKind.Local).AddTicks(8576), new DateTime(2024, 11, 24, 21, 10, 34, 829, DateTimeKind.Local).AddTicks(1631), new DateTime(2024, 11, 17, 21, 10, 34, 829, DateTimeKind.Local).AddTicks(1631), null },
                    { 11, 9, "Borrowed", 7, new DateTime(2024, 11, 14, 0, 49, 2, 422, DateTimeKind.Local).AddTicks(9389), new DateTime(2024, 11, 23, 18, 19, 25, 4, DateTimeKind.Local).AddTicks(9703), new DateTime(2024, 11, 16, 18, 19, 25, 4, DateTimeKind.Local).AddTicks(9703), null },
                    { 12, 28, "Pending", 14, null, null, new DateTime(2024, 11, 15, 22, 57, 18, 471, DateTimeKind.Local).AddTicks(6756), null },
                    { 13, 8, "Borrowed", 5, new DateTime(2024, 11, 15, 10, 47, 11, 701, DateTimeKind.Local).AddTicks(6503), new DateTime(2024, 11, 26, 19, 18, 23, 535, DateTimeKind.Local).AddTicks(8422), new DateTime(2024, 11, 19, 19, 18, 23, 535, DateTimeKind.Local).AddTicks(8422), null },
                    { 14, 22, "Canceled", 16, null, null, new DateTime(2024, 11, 18, 18, 15, 54, 529, DateTimeKind.Local).AddTicks(1161), null },
                    { 15, 11, "Pending", 13, null, null, new DateTime(2024, 11, 13, 22, 52, 33, 985, DateTimeKind.Local).AddTicks(8628), null },
                    { 16, 5, "Canceled", 2, null, null, new DateTime(2024, 11, 13, 10, 45, 23, 525, DateTimeKind.Local).AddTicks(3652), null },
                    { 17, 8, "Pending", 2, null, null, new DateTime(2024, 11, 14, 6, 53, 0, 144, DateTimeKind.Local).AddTicks(4587), null },
                    { 18, 13, "Canceled", 5, null, null, new DateTime(2024, 11, 17, 12, 37, 44, 738, DateTimeKind.Local).AddTicks(9930), null },
                    { 19, 21, "Completed", 12, new DateTime(2024, 11, 15, 10, 28, 43, 80, DateTimeKind.Local).AddTicks(3769), new DateTime(2024, 11, 24, 2, 13, 49, 875, DateTimeKind.Local).AddTicks(8729), new DateTime(2024, 11, 17, 2, 13, 49, 875, DateTimeKind.Local).AddTicks(8729), new DateTime(2024, 11, 17, 1, 58, 14, 534, DateTimeKind.Local).AddTicks(8818) },
                    { 20, 25, "Borrowed", 4, new DateTime(2024, 11, 18, 20, 45, 20, 651, DateTimeKind.Local).AddTicks(1039), new DateTime(2024, 11, 20, 14, 25, 4, 895, DateTimeKind.Local).AddTicks(6571), new DateTime(2024, 11, 13, 14, 25, 4, 895, DateTimeKind.Local).AddTicks(6571), null },
                    { 21, 26, "Canceled", 14, null, null, new DateTime(2024, 11, 13, 16, 44, 38, 722, DateTimeKind.Local).AddTicks(6799), null },
                    { 22, 21, "Completed", 1, new DateTime(2024, 11, 16, 9, 31, 35, 32, DateTimeKind.Local).AddTicks(4293), new DateTime(2024, 11, 21, 14, 59, 43, 392, DateTimeKind.Local).AddTicks(8467), new DateTime(2024, 11, 14, 14, 59, 43, 392, DateTimeKind.Local).AddTicks(8467), new DateTime(2024, 11, 16, 21, 55, 24, 60, DateTimeKind.Local).AddTicks(3033) },
                    { 23, 19, "Completed", 2, new DateTime(2024, 11, 17, 10, 34, 16, 166, DateTimeKind.Local).AddTicks(4540), new DateTime(2024, 11, 21, 6, 10, 37, 36, DateTimeKind.Local).AddTicks(3142), new DateTime(2024, 11, 14, 6, 10, 37, 36, DateTimeKind.Local).AddTicks(3142), new DateTime(2024, 11, 18, 16, 28, 31, 695, DateTimeKind.Local).AddTicks(7833) },
                    { 24, 1, "Borrowed", 5, new DateTime(2024, 11, 17, 15, 1, 6, 692, DateTimeKind.Local).AddTicks(4733), new DateTime(2024, 11, 24, 16, 6, 54, 680, DateTimeKind.Local).AddTicks(1857), new DateTime(2024, 11, 17, 16, 6, 54, 680, DateTimeKind.Local).AddTicks(1857), null },
                    { 25, 27, "Borrowed", 8, new DateTime(2024, 11, 19, 15, 30, 59, 13, DateTimeKind.Local).AddTicks(7099), new DateTime(2024, 11, 25, 18, 24, 57, 892, DateTimeKind.Local).AddTicks(1761), new DateTime(2024, 11, 18, 18, 24, 57, 892, DateTimeKind.Local).AddTicks(1761), null },
                    { 26, 3, "Borrowed", 7, new DateTime(2024, 11, 19, 6, 17, 29, 695, DateTimeKind.Local).AddTicks(8505), new DateTime(2024, 11, 25, 3, 41, 28, 695, DateTimeKind.Local).AddTicks(6541), new DateTime(2024, 11, 18, 3, 41, 28, 695, DateTimeKind.Local).AddTicks(6541), null },
                    { 27, 9, "Pending", 12, null, null, new DateTime(2024, 11, 14, 23, 52, 1, 666, DateTimeKind.Local).AddTicks(2791), null },
                    { 28, 6, "Pending", 16, null, null, new DateTime(2024, 11, 12, 22, 1, 50, 202, DateTimeKind.Local).AddTicks(4908), null },
                    { 29, 10, "Canceled", 15, null, null, new DateTime(2024, 11, 18, 8, 8, 10, 698, DateTimeKind.Local).AddTicks(4942), null },
                    { 30, 15, "Canceled", 2, null, null, new DateTime(2024, 11, 15, 11, 9, 44, 602, DateTimeKind.Local).AddTicks(9685), null },
                    { 31, 7, "Borrowed", 8, new DateTime(2024, 11, 13, 22, 2, 39, 965, DateTimeKind.Local).AddTicks(2365), new DateTime(2024, 11, 22, 10, 34, 40, 490, DateTimeKind.Local).AddTicks(402), new DateTime(2024, 11, 15, 10, 34, 40, 490, DateTimeKind.Local).AddTicks(402), null },
                    { 32, 28, "Pending", 12, null, null, new DateTime(2024, 11, 14, 0, 25, 16, 965, DateTimeKind.Local).AddTicks(8548), null },
                    { 33, 16, "Canceled", 11, null, null, new DateTime(2024, 11, 17, 9, 39, 9, 177, DateTimeKind.Local).AddTicks(1126), null },
                    { 34, 8, "Borrowed", 4, new DateTime(2024, 11, 16, 10, 24, 30, 906, DateTimeKind.Local).AddTicks(382), new DateTime(2024, 11, 22, 21, 56, 1, 267, DateTimeKind.Local).AddTicks(8753), new DateTime(2024, 11, 15, 21, 56, 1, 267, DateTimeKind.Local).AddTicks(8753), null },
                    { 35, 16, "Completed", 6, new DateTime(2024, 11, 16, 5, 13, 11, 391, DateTimeKind.Local).AddTicks(880), new DateTime(2024, 11, 21, 20, 42, 43, 65, DateTimeKind.Local).AddTicks(8290), new DateTime(2024, 11, 14, 20, 42, 43, 65, DateTimeKind.Local).AddTicks(8290), new DateTime(2024, 11, 19, 19, 24, 5, 989, DateTimeKind.Local).AddTicks(5622) },
                    { 36, 10, "Borrowed", 16, new DateTime(2024, 11, 16, 6, 43, 21, 896, DateTimeKind.Local).AddTicks(2274), new DateTime(2024, 11, 25, 1, 54, 6, 868, DateTimeKind.Local).AddTicks(4403), new DateTime(2024, 11, 18, 1, 54, 6, 868, DateTimeKind.Local).AddTicks(4403), null },
                    { 37, 24, "Completed", 12, new DateTime(2024, 11, 14, 10, 56, 36, 947, DateTimeKind.Local).AddTicks(4658), new DateTime(2024, 11, 20, 6, 43, 13, 843, DateTimeKind.Local).AddTicks(6648), new DateTime(2024, 11, 13, 6, 43, 13, 843, DateTimeKind.Local).AddTicks(6648), new DateTime(2024, 11, 17, 20, 8, 50, 640, DateTimeKind.Local).AddTicks(4139) },
                    { 38, 4, "Borrowed", 11, new DateTime(2024, 11, 18, 3, 9, 7, 800, DateTimeKind.Local).AddTicks(2369), new DateTime(2024, 11, 22, 3, 54, 54, 296, DateTimeKind.Local).AddTicks(3977), new DateTime(2024, 11, 15, 3, 54, 54, 296, DateTimeKind.Local).AddTicks(3977), null },
                    { 39, 28, "Completed", 4, new DateTime(2024, 11, 14, 22, 0, 51, 314, DateTimeKind.Local).AddTicks(9960), new DateTime(2024, 11, 20, 21, 33, 25, 759, DateTimeKind.Local).AddTicks(442), new DateTime(2024, 11, 13, 21, 33, 25, 759, DateTimeKind.Local).AddTicks(442), new DateTime(2024, 11, 17, 5, 59, 47, 52, DateTimeKind.Local).AddTicks(6968) },
                    { 40, 27, "Pending", 16, null, null, new DateTime(2024, 11, 18, 0, 13, 27, 830, DateTimeKind.Local).AddTicks(1009), null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 17, 10, 5, "Sapiente nobis rem aut et.", 4 },
                    { 18, 18, 4, "Corrupti quidem est dolor et placeat quia deserunt.", 11 },
                    { 19, 1, 8, "Ut pariatur sequi voluptas ad voluptatem molestias similique est dignissimos.", 6 },
                    { 20, 8, 2, "Sint ea non voluptatem est sed a.", 10 },
                    { 21, 23, 11, "Sequi culpa quo nihil illum ut laboriosam facere accusamus corrupti.", 1 },
                    { 22, 6, 10, "Et aut quia dolore voluptas minima sit.", 2 },
                    { 23, 4, 16, "Magni delectus tempore quo doloribus ea quidem.", 6 },
                    { 24, 18, 9, "Nostrum sit in non unde reiciendis.", 4 },
                    { 25, 22, 5, "Sit veritatis corrupti laudantium veritatis vel.", 13 },
                    { 26, 11, 2, "Cumque nam incidunt fugit.", 5 },
                    { 27, 21, 7, "Quia dolorem praesentium sit aperiam.", 1 },
                    { 28, 10, 7, "Dicta consequatur voluptas earum.", 16 },
                    { 29, 24, 5, "Doloribus omnis delectus autem a accusantium suscipit dolores et.", 4 },
                    { 30, 28, 14, "Eos alias dolorum hic id quia dolor.", 10 },
                    { 31, 7, 11, "Enim autem nam iure.", 13 },
                    { 32, 17, 2, "Cum quod esse non soluta aut rerum.", 9 }
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
