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
                    photoPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rating = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    public_at = table.Column<DateOnly>(type: "date", nullable: false),
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
                    { 1, "Impedit ut tempora optio nesciunt ut ratione quam fuga repellendus.", "Claudie" },
                    { 2, "Beatae tempore odio est commodi quam explicabo ut et.", "Cortez" },
                    { 3, "Quis numquam eum fuga voluptas minima.", "Evan" },
                    { 4, "Tenetur exercitationem est.", "Margarita" },
                    { 5, "Rem qui sed cumque.", "Lou" },
                    { 6, "Maxime minima et corporis mollitia rerum.", "Winfield" },
                    { 7, "Sit doloribus porro mollitia omnis et.", "Norma" },
                    { 8, "Consequatur in dolorum quis inventore quod voluptate officiis.", "Thomas" },
                    { 9, "Molestias inventore qui modi et adipisci.", "Adrien" },
                    { 10, "Illum nesciunt totam consequatur ipsa eum quia odit accusamus iusto.", "Adelle" },
                    { 11, "Mollitia aut nesciunt suscipit qui vel necessitatibus aut quia.", "Joanny" },
                    { 12, "Laudantium ea quasi quisquam assumenda corporis nobis.", "Jordy" },
                    { 13, "Quis exercitationem ea non earum tempore.", "Dexter" },
                    { 14, "Omnis quo dolores consectetur eius labore perspiciatis animi ut.", "Johan" },
                    { 15, "Tempora quia repellendus qui dolorem doloribus repudiandae sapiente.", "Shanel" },
                    { 16, "Corrupti molestiae temporibus et illo libero quo placeat et.", "Jeremy" },
                    { 17, "Qui accusantium nobis cumque recusandae possimus quo.", "Lavina" },
                    { 18, "Necessitatibus dolor sapiente veritatis sed reiciendis assumenda at omnis.", "Lucile" },
                    { 19, "Voluptatem et et accusamus.", "Aaliyah" },
                    { 20, "Repudiandae temporibus neque voluptatibus.", "Muhammad" },
                    { 21, "Possimus eos et ex beatae quia.", "Jaunita" },
                    { 22, "Qui nihil magni aut.", "Samson" },
                    { 23, "Quo quod aut voluptatem.", "Shannon" },
                    { 24, "Vel ut nihil voluptates beatae voluptatibus aut aut.", "Luna" },
                    { 25, "Illo expedita officia laboriosam ipsum quisquam.", "Eduardo" },
                    { 26, "Molestiae nihil aut at deleniti.", "Evans" },
                    { 27, "Nulla eveniet quasi laudantium et nesciunt.", "Waldo" },
                    { 28, "Repellendus est et deleniti ut perferendis quasi ut.", "Mac" },
                    { 29, "Veniam iure fuga nobis nihil molestiae dolores accusantium quos.", "Barrett" },
                    { 30, "Minus tempore fugiat dolor.", "Helmer" },
                    { 31, "Unde sed provident totam voluptatem quo voluptatem ut porro autem.", "Nicola" },
                    { 32, "Nihil aspernatur magni voluptatum modi omnis ipsam sit quia qui.", "Marc" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Ad eius officia sed et et a vel aut. Sed reprehenderit rerum in omnis ducimus numquam. Nemo voluptatem quia et ut qui doloremque.", "Enim dolorem dolores exercitationem corporis molestias veniam aliquam reprehenderit. Dicta non fugit. Maxime soluta aliquid earum laborum.", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 2, "Vero natus minus tenetur non. Ut aut dignissimos vitae iste. Laboriosam nam cum autem explicabo doloremque velit expedita magnam.", "Repellendus ex deleniti ut nihil sit nisi in hic. Quae eos ipsum. Molestias voluptate consequatur. Dolores perferendis ut dolor sed.", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 3, "Optio laborum nostrum modi deleniti. Odit deleniti consectetur aut illo incidunt illum et. Consequatur laborum qui vero a quod unde occaecati similique.", "Porro molestiae in.\nAut ipsam sit sit.\nDebitis aperiam ex et dolores ut et.\nSaepe quia ut voluptate.\nRepudiandae sapiente illum aut molestias sapiente expedita.", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 4, "Dolorem non dignissimos omnis. Autem itaque non. Et temporibus et explicabo modi est alias. Voluptate vel dolorem soluta enim.", "Non sit et placeat doloribus quaerat. Recusandae magnam ut occaecati. Soluta mollitia culpa iste. Hic itaque consequuntur corrupti eius temporibus eveniet quod aut consequatur. Non cumque et quasi vel omnis itaque numquam quod. Vitae et sed incidunt accusamus et perferendis porro cumque repellendus.", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 5, "Et deserunt molestiae recusandae voluptas repellendus labore. Molestiae quidem omnis occaecati omnis voluptatem minima odit quibusdam. Optio adipisci officiis quis totam aliquid iusto. A amet eligendi at ex dignissimos rem.", "sint", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "delectus" },
                    { 2, "officia" },
                    { 3, "aut" },
                    { 4, "facere" },
                    { 5, "debitis" },
                    { 6, "labore" },
                    { 7, "culpa" },
                    { 8, "minima" },
                    { 9, "natus" },
                    { 10, "ea" },
                    { 11, "repellendus" },
                    { 12, "est" },
                    { 13, "qui" },
                    { 14, "sed" },
                    { 15, "asperiores" },
                    { 16, "aliquam" },
                    { 17, "est" },
                    { 18, "dolorum" },
                    { 19, "ut" },
                    { 20, "saepe" },
                    { 21, "deleniti" },
                    { 22, "cum" },
                    { 23, "omnis" },
                    { 24, "aut" },
                    { 25, "voluptas" },
                    { 26, "dolorem" },
                    { 27, "facilis" },
                    { 28, "quis" },
                    { 29, "aut" },
                    { 30, "eligendi" },
                    { 31, "quibusdam" },
                    { 32, "voluptas" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Justine Kulas", "Rerum numquam maxime tempore.", "User", "Asia", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 2, "Quinn Bashirian", "autem", "User", "Electa", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 3, "Cooper Okuneva", "Ut impedit dolores vel itaque. Aliquam vel expedita ipsa ea recusandae. Ea sit fugit aut possimus eum molestias. Repellat sit omnis iste. Eligendi dolor beatae vel.", "Admin", "Gaston", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 4, "Zella Zemlak", "Voluptas doloremque at et libero. In sed sit architecto ea similique consequuntur aliquid. Qui et ut optio id dolor aut doloribus atque. Magnam labore illo eos distinctio sit. Quas voluptas omnis nihil ut ut eum. Aliquam nihil harum labore facere fugiat omnis consectetur quasi rerum.", "User", "Verna", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 5, "Glennie Jerde", "rerum", "User", "Kory", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 6, "Mohamed Thompson", "Dolorum sed culpa cumque impedit sed. Quas velit alias voluptas animi. Dolorem sequi aut minus officia deleniti error iure. Facilis ut ipsa et perspiciatis quae dolorem molestias saepe sit.", "Admin", "Zena", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 7, "Payton Kilback", "laborum", "Admin", "Hortense", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 8, "Maryam Connelly", "facere", "User", "Neva", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 9, "Emerald Brown", "Minima cupiditate hic autem dolores ut architecto. Rem debitis quae inventore assumenda natus ullam quidem necessitatibus eius. Dignissimos est omnis consequatur et et suscipit. Dolor voluptatem sint.", "Admin", "Rashawn", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 10, "Erling Dach", "Aut et aut explicabo optio quaerat ipsa et. Quibusdam dolores facilis quisquam saepe aperiam qui. Doloribus quisquam voluptates ut porro.", "Admin", "Camilla", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 11, "Berry Koelpin", "Adipisci mollitia explicabo quam. Ut nesciunt odit. Cupiditate et cupiditate in ut aliquid assumenda est rerum.", "User", "Alysson", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 12, "Dedrick Herzog", "Omnis est laboriosam voluptatem.\nRatione sit quia perferendis veritatis at quia consectetur.\nIn officia atque.\nDignissimos et sit neque ab similique quaerat.\nExplicabo odio in eveniet officia praesentium natus et.", "User", "Dannie", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 13, "Joana Metz", "Vel reprehenderit distinctio illum ut accusantium provident in omnis quibusdam. Facilis necessitatibus blanditiis quia omnis itaque et quidem qui ipsum. Vero quis mollitia enim. Id ab eos rerum atque.", "Admin", "Garry", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 14, "Ray Rodriguez", "consequuntur", "User", "Colin", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 15, "Ari Collier", "Et corporis expedita totam.\nRepellat sit dolorum quia.\nPraesentium corrupti veritatis fugit praesentium voluptas ut tenetur.", "User", "Tierra", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) },
                    { 16, "Effie Schneider", "Et sed est eos iusto quod. Consequatur odit dolorem consequatur asperiores. Vel nobis eos adipisci adipisci assumenda non reprehenderit facilis.", "Admin", "Chad", new DateOnly(2024, 11, 25), new DateOnly(2024, 11, 25) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "photoPath", "public_at", "quantity", "rating", "remaining", "updated_at", "views" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 11, 25, 20, 52, 57, 61, DateTimeKind.Local).AddTicks(9459), "Dolores voluptas quo porro dolorem laudantium. Deserunt voluptas est rerum et et quia. Eos eum eligendi tempora. Numquam a blanditiis nulla. Veritatis praesentium sit saepe perferendis corporis. Soluta hic repellendus asperiores.", 20, "Dolorum perferendis reprehenderit dolorem laboriosam.", ".\\resources\\images\\poster.png", new DateOnly(2021, 4, 15), (byte)8, (byte)0, (byte)0, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(1071), 0 },
                    { 2, 5, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(1727), "Minima voluptate quod. Natus rerum doloremque adipisci eos. Corporis fugit voluptate facere quia adipisci ratione. Architecto magni voluptates modi pariatur sunt autem non omnis.", 23, "Vitae dolorem autem aperiam molestias.", ".\\resources\\images\\poster.png", new DateOnly(2010, 6, 11), (byte)9, (byte)0, (byte)1, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(1934), 0 },
                    { 3, 2, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(1948), "Iure aut commodi optio aut sit enim amet fugiat aut. Culpa rerum dolor alias odio ea placeat voluptatem nihil. Vel cumque quidem voluptatem quod quam et praesentium dolores laudantium. Sequi ipsum atque provident.", 11, "Incidunt ducimus officia repellat voluptas debitis.", ".\\resources\\images\\poster.png", new DateOnly(2012, 9, 15), (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2070), 0 },
                    { 4, 4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2081), "Error voluptas soluta. Aliquid itaque consequatur exercitationem illum. Velit voluptatem quia et ut quis omnis accusamus.", 2, "Repellat quia id laborum est repellendus aliquid qui.", ".\\resources\\images\\poster.png", new DateOnly(2015, 10, 13), (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2159), 0 },
                    { 5, 26, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2169), "Molestias possimus tempore quae ut quisquam nam est. Qui delectus ea sed eum. Et qui sit iure aut quasi adipisci commodi odio laboriosam. Dolorum officia expedita nihil mollitia.", 18, "Ex est aliquam deleniti.", ".\\resources\\images\\poster.png", new DateOnly(2010, 5, 29), (byte)5, (byte)0, (byte)0, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2267), 0 },
                    { 6, 15, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2278), "Libero earum consequuntur eaque optio nihil. Ut est sed. Corporis saepe voluptas.", 10, "Quia et facilis labore corporis enim cum.", ".\\resources\\images\\poster.png", new DateOnly(1999, 11, 6), (byte)7, (byte)0, (byte)4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2346), 0 },
                    { 7, 13, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2356), "Doloribus non et perferendis qui officia. Quibusdam et corporis quisquam placeat minima blanditiis. Qui veniam sed. Id mollitia qui eos nam soluta. Et est pariatur occaecati est et ut sint architecto deserunt.", 15, "Harum animi facere nihil distinctio unde consequatur quos.", ".\\resources\\images\\poster.png", new DateOnly(2013, 10, 8), (byte)6, (byte)0, (byte)5, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2464), 0 },
                    { 8, 28, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2475), "Iste dolores voluptas ut explicabo ut rerum repellendus. Vel ut et odit impedit et. Dicta corporis suscipit voluptas. Est repudiandae cum voluptatem dolores quaerat consequatur.", 21, "Quas perspiciatis minus recusandae fuga quisquam.", ".\\resources\\images\\poster.png", new DateOnly(2001, 12, 21), (byte)10, (byte)0, (byte)3, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2560), 0 },
                    { 9, 22, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2571), "Non est iusto sapiente blanditiis praesentium labore et magni. Fugiat sit quia. Inventore ratione tempora voluptatem accusamus dolor nesciunt minima autem. Enim est ea rerum inventore in quam. Hic sed et dolore aut aut omnis laborum. Ea at et ea et beatae.", 31, "Autem veniam id possimus alias.", ".\\resources\\images\\poster.png", new DateOnly(2021, 12, 23), (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2694), 0 },
                    { 10, 20, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2704), "Doloribus sint quis sit similique commodi. Debitis aut aliquid neque molestiae eum. Sint rerum asperiores assumenda quis dignissimos explicabo laborum eos voluptates.", 23, "Asperiores quae totam suscipit sit qui nobis.", ".\\resources\\images\\poster.png", new DateOnly(2000, 11, 24), (byte)8, (byte)0, (byte)0, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2793), 0 },
                    { 11, 24, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2804), "Sapiente possimus odio vel error mollitia et reprehenderit. Molestiae veritatis unde consequuntur. Impedit est accusamus delectus.", 21, "Voluptatem nobis alias blanditiis harum quia.", ".\\resources\\images\\poster.png", new DateOnly(1999, 6, 6), (byte)10, (byte)0, (byte)4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2870), 0 },
                    { 12, 6, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2881), "Vero velit vel ut explicabo sed iste minima et. Est tempore quasi corporis vero eos qui. Velit itaque repellendus aut qui ullam quisquam architecto ea. Alias quisquam deserunt minus id illo ipsam possimus.", 20, "Libero inventore aut.", ".\\resources\\images\\poster.png", new DateOnly(2021, 8, 17), (byte)9, (byte)0, (byte)5, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2976), 0 },
                    { 13, 31, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(2987), "Maiores voluptatem quaerat pariatur asperiores. Dignissimos illum repudiandae reiciendis delectus alias. Blanditiis totam vitae tempore unde aut ut aut. Eligendi vel sed similique. Eos dignissimos exercitationem labore.", 25, "Eligendi qui et excepturi cumque cumque.", ".\\resources\\images\\poster.png", new DateOnly(2012, 6, 19), (byte)9, (byte)0, (byte)0, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3081), 0 },
                    { 14, 27, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3093), "Ab enim molestiae. Saepe et iure recusandae est ullam fugiat consequatur enim. Aut excepturi porro libero tenetur laudantium eum. Ea rerum aut repellendus quo sunt ut numquam ut et.", 32, "Harum nobis enim expedita minus eveniet quis aliquam fugiat enim.", ".\\resources\\images\\poster.png", new DateOnly(1999, 6, 6), (byte)10, (byte)0, (byte)5, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3186), 0 },
                    { 15, 4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3199), "Asperiores corrupti deleniti eum error dolorem consequatur sed dicta repellendus. Eos ipsum voluptas pariatur. Sit iusto omnis ut voluptatem minima blanditiis ut quia. Neque vero possimus.", 20, "Hic corrupti dolor perspiciatis voluptatum et.", ".\\resources\\images\\poster.png", new DateOnly(2020, 11, 20), (byte)10, (byte)0, (byte)0, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3415), 0 },
                    { 16, 28, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3428), "Et reiciendis tempora qui. Aut autem pariatur. Eius dolorum iusto doloribus ut sit vel facere atque.", 23, "Maiores omnis quos perferendis id repellendus.", ".\\resources\\images\\poster.png", new DateOnly(2019, 8, 22), (byte)7, (byte)0, (byte)1, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3499), 0 },
                    { 17, 12, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3510), "Unde eaque libero. Perferendis aut et cum amet ea debitis. Sint exercitationem velit. Quis quam est.", 6, "Quo est perspiciatis praesentium beatae enim accusamus.", ".\\resources\\images\\poster.png", new DateOnly(2014, 6, 7), (byte)6, (byte)0, (byte)1, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3580), 0 },
                    { 18, 32, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3592), "Molestias sunt et et aut molestiae dolor quo autem. Assumenda sint distinctio. Sunt non qui occaecati odio repellat harum aspernatur dolores. Minima ipsa quam ipsum omnis illum dolorum rem perspiciatis. Ut nemo culpa.", 14, "Itaque harum similique molestiae.", ".\\resources\\images\\poster.png", new DateOnly(2019, 2, 18), (byte)10, (byte)0, (byte)4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3689), 0 },
                    { 19, 9, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3700), "Voluptatem eum molestias non recusandae similique aliquid reprehenderit. Nihil soluta corporis inventore aut aut nam. Aut ut dignissimos et. Quis at modi sequi perspiciatis ipsum.", 18, "Ex accusamus qui distinctio.", ".\\resources\\images\\poster.png", new DateOnly(2001, 9, 30), (byte)6, (byte)0, (byte)3, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3785), 0 },
                    { 20, 1, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3798), "Modi eaque iure ipsum eos accusamus quasi molestias excepturi et. Earum est labore quisquam ut laboriosam ut. Dolorem dolore quod accusamus veritatis. Autem et mollitia cumque beatae cupiditate dolorem. Maiores adipisci quas fugit.", 4, "Sequi voluptatibus praesentium ab libero a.", ".\\resources\\images\\poster.png", new DateOnly(2022, 10, 8), (byte)9, (byte)0, (byte)0, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3891), 0 },
                    { 21, 15, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(3903), "Quaerat architecto ipsum perspiciatis eos et veniam quaerat. Voluptates atque occaecati explicabo enim non. Nostrum qui rerum quam. Alias recusandae repudiandae quae unde id cupiditate eos quo. Vel nihil a doloribus ut dolorem rem quas laborum animi. Dignissimos recusandae aut totam dolor sint.", 22, "Illo id distinctio magni odio.", ".\\resources\\images\\poster.png", new DateOnly(2023, 11, 23), (byte)10, (byte)0, (byte)4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4034), 0 },
                    { 22, 11, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4046), "Iure quis reiciendis vero maxime dolor. Dicta odit est occaecati. Voluptatem iusto recusandae eaque adipisci.", 20, "Numquam repellendus dolorem rerum et non aut.", ".\\resources\\images\\poster.png", new DateOnly(2004, 1, 31), (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4115), 0 },
                    { 23, 8, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4127), "Vitae ut provident. Porro quia voluptatem exercitationem mollitia quas. Modi voluptatem accusantium a omnis quod soluta deserunt quisquam soluta. Est veniam quaerat ad magni soluta enim. Voluptas velit debitis delectus voluptatem sed sunt fugit qui. Eos omnis non enim quis.", 22, "Nulla atque eos ut maxime illo nihil occaecati omnis quia.", ".\\resources\\images\\poster.png", new DateOnly(2015, 3, 3), (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4244), 0 },
                    { 24, 10, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4257), "Iure enim et ad qui. Perspiciatis reprehenderit sit sequi qui id commodi sit. Aut nemo quia impedit modi. Voluptatem quibusdam molestiae. Molestias ullam in quis illo explicabo aut. Nostrum natus incidunt commodi.", 17, "Sunt quis eum et saepe et distinctio inventore atque sed.", ".\\resources\\images\\poster.png", new DateOnly(2004, 1, 27), (byte)5, (byte)0, (byte)5, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4361), 0 },
                    { 25, 10, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4373), "Placeat voluptatem excepturi quod nam consequatur deleniti suscipit a consequatur. Perferendis quis dicta consectetur ducimus. Quibusdam ipsam aspernatur quae autem voluptas vitae aperiam in. Ad nam inventore porro tenetur et. Sed omnis dolores error minima dolores minus nisi commodi. Non possimus illo.", 21, "Fugit iure ipsum sint.", ".\\resources\\images\\poster.png", new DateOnly(2006, 10, 14), (byte)7, (byte)0, (byte)0, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4488), 0 },
                    { 26, 20, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4502), "Omnis fugit est doloribus dignissimos eos quasi. Sequi maiores nulla dolores necessitatibus maxime voluptatem qui accusamus perferendis. Non cupiditate aperiam excepturi quam facilis aut deleniti aspernatur ab. Commodi perspiciatis et commodi. Odit perspiciatis rem.", 16, "Odit atque sit qui non quia possimus consequatur.", ".\\resources\\images\\poster.png", new DateOnly(2003, 3, 1), (byte)8, (byte)0, (byte)2, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4603), 0 },
                    { 27, 15, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4616), "Inventore aliquid est impedit assumenda reiciendis recusandae beatae vero. Non aspernatur debitis qui non velit. Voluptas id ipsum sed laboriosam et est maxime quasi aspernatur. Ut necessitatibus voluptatibus laborum ea. Labore dolor qui voluptatem voluptatem non ipsam.", 18, "Aut iusto non doloremque incidunt nihil id nesciunt adipisci.", ".\\resources\\images\\poster.png", new DateOnly(2016, 2, 14), (byte)10, (byte)0, (byte)5, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4726), 0 },
                    { 28, 10, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4739), "Blanditiis atque sequi dolore earum aut et ipsa. Atque sint repudiandae rerum quis facilis libero expedita. Architecto non quas aut iure enim sed quae vitae accusamus.", 25, "Ut hic atque.", ".\\resources\\images\\poster.png", new DateOnly(2015, 3, 13), (byte)8, (byte)0, (byte)4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4816), 0 },
                    { 29, 23, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4828), "Dolor eum maiores exercitationem excepturi dolor aperiam soluta qui eos. Nihil consequatur ad deleniti sed quo accusamus. Rem voluptates praesentium at voluptatem. Repudiandae illum dolorum explicabo.", 21, "Minus asperiores fugit sequi ipsum blanditiis sit molestias et.", ".\\resources\\images\\poster.png", new DateOnly(2019, 12, 13), (byte)9, (byte)0, (byte)1, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4920), 0 },
                    { 30, 18, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(4932), "Sit harum provident ea nihil illum mollitia porro id. Repudiandae et quo deserunt totam ullam porro. Dolorem labore accusamus nulla nostrum. Odio qui culpa dolores nam.", 4, "Sint iusto porro temporibus et iure.", ".\\resources\\images\\poster.png", new DateOnly(2012, 1, 16), (byte)8, (byte)0, (byte)4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5013), 0 },
                    { 31, 11, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5025), "Excepturi officiis quam. Quidem sint atque animi et ab. Ullam nisi rerum. Ratione est blanditiis nihil ipsum est autem nulla vero ut.", 19, "Harum sunt in consequuntur.", ".\\resources\\images\\poster.png", new DateOnly(2006, 6, 9), (byte)7, (byte)0, (byte)3, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5105), 0 },
                    { 32, 12, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5118), "Inventore aut omnis non veniam libero. Accusantium est magni asperiores. At ex odio accusamus rerum. Optio doloribus eaque libero vitae eos ipsum. Voluptatem vero omnis voluptate et ducimus consequatur est.", 11, "Earum et reprehenderit amet aut nemo porro.", ".\\resources\\images\\poster.png", new DateOnly(2018, 12, 23), (byte)10, (byte)0, (byte)2, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5214), 0 },
                    { 33, 30, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5226), "Laborum minima repudiandae ullam. Et quas rerum provident quam aspernatur quam dicta. Repellendus qui consequatur aut nemo esse veritatis vel earum illum.", 5, "Saepe nobis mollitia earum amet enim aut vero.", ".\\resources\\images\\poster.png", new DateOnly(2015, 2, 14), (byte)5, (byte)0, (byte)4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5306), 0 },
                    { 34, 4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5318), "Voluptatum enim debitis. Exercitationem qui sed recusandae qui excepturi quos et. Fugit tempora reprehenderit laborum est quia. Dolor eos ut sequi corporis enim molestiae temporibus sed. Error libero nesciunt consequatur quia eaque est deserunt amet in.", 15, "Vel magnam animi.", ".\\resources\\images\\poster.png", new DateOnly(2018, 11, 26), (byte)7, (byte)0, (byte)0, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5423), 0 },
                    { 35, 10, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5435), "Omnis rerum quis excepturi suscipit quia assumenda aut et. Et vel nesciunt. Assumenda ab velit voluptas. Saepe repellat corrupti esse voluptatum laudantium odit vero quasi.", 26, "Sit aperiam ad voluptates id eum harum aut.", ".\\resources\\images\\poster.png", new DateOnly(2024, 9, 6), (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5520), 0 },
                    { 36, 4, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5532), "Iure consequuntur fuga eos voluptates sunt eligendi harum expedita est. Non reiciendis adipisci quam non dolor. Cumque libero ut autem unde facere minima id veritatis. Eos rerum deserunt deserunt quia occaecati modi omnis eum. Sunt labore non quod ut minus aliquid dolorem suscipit magnam.", 30, "Repudiandae quia cupiditate deserunt.", ".\\resources\\images\\poster.png", new DateOnly(2007, 6, 24), (byte)8, (byte)0, (byte)5, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5641), 0 },
                    { 37, 27, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5656), "Dolor suscipit sed est qui. Inventore cumque eos molestiae tempora sit. Aperiam tempore occaecati non molestiae ad.", 24, "Reprehenderit voluptate occaecati officiis nemo error aut quis sit et.", ".\\resources\\images\\poster.png", new DateOnly(2015, 1, 23), (byte)7, (byte)0, (byte)3, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5732), 0 },
                    { 38, 21, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5744), "Quidem maxime eius est qui quos quidem sunt harum voluptatem. Eveniet illum voluptatem animi. Doloremque magnam inventore. Explicabo officiis est aut repellendus. Optio est numquam aut voluptatibus. Eaque laboriosam qui occaecati quibusdam magnam dolorum ut.", 12, "Sunt quia optio ex impedit eos officiis qui laboriosam.", ".\\resources\\images\\poster.png", new DateOnly(2009, 9, 11), (byte)5, (byte)0, (byte)1, new DateTime(2024, 11, 25, 20, 52, 57, 62, DateTimeKind.Local).AddTicks(5853), 0 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBook",
                columns: new[] { "Id", "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 28, 3 },
                    { 2, 30, 3 },
                    { 3, 35, 2 },
                    { 4, 9, 4 },
                    { 5, 32, 3 },
                    { 6, 16, 5 },
                    { 7, 21, 3 },
                    { 8, 1, 4 },
                    { 9, 25, 3 },
                    { 10, 12, 2 },
                    { 11, 31, 4 },
                    { 12, 36, 3 },
                    { 13, 6, 2 },
                    { 14, 18, 4 },
                    { 15, 34, 2 },
                    { 16, 19, 2 },
                    { 17, 6, 5 },
                    { 18, 25, 2 },
                    { 19, 36, 4 },
                    { 20, 14, 1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 1, 14, 10, "Praesentium exercitationem sit quod tenetur sed quos.", null },
                    { 2, 8, 15, "Est occaecati ullam animi quos necessitatibus sit sed facere.", null },
                    { 3, 31, 2, "Occaecati rerum aut.", null },
                    { 4, 15, 14, "Sunt sapiente quia numquam.", null },
                    { 5, 8, 5, "Reprehenderit eveniet dolorem nobis.", null },
                    { 6, 34, 4, "Repudiandae corrupti aspernatur deserunt facilis ratione voluptatem vero et ex.", null },
                    { 7, 20, 9, "Ut qui est.", null },
                    { 8, 28, 16, "Voluptas repellat est repellendus velit qui eaque eveniet.", null },
                    { 9, 20, 9, "Totam repudiandae doloremque nihil earum eius.", null },
                    { 10, 30, 6, "Rerum pariatur voluptas totam minima illum corporis consequatur.", null },
                    { 11, 25, 5, "Eveniet autem dolorem in est non eos.", null },
                    { 12, 6, 7, "Ducimus doloremque et ut et quas ea optio.", null },
                    { 13, 33, 1, "Corporis sit voluptates eligendi quidem temporibus.", null },
                    { 14, 21, 15, "Est neque non suscipit delectus repellat reprehenderit.", null },
                    { 15, 28, 16, "Qui inventore qui harum sint et libero.", null },
                    { 16, 9, 4, "In ad eaque voluptatem a sed.", null }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 17, "Canceled", 7, null, null, new DateTime(2024, 11, 23, 11, 7, 34, 43, DateTimeKind.Local).AddTicks(2306), null },
                    { 2, 28, "Borrowed", 10, new DateTime(2024, 11, 22, 6, 50, 53, 190, DateTimeKind.Local).AddTicks(9914), new DateTime(2024, 11, 27, 16, 10, 2, 633, DateTimeKind.Local).AddTicks(4081), new DateTime(2024, 11, 20, 16, 10, 2, 633, DateTimeKind.Local).AddTicks(4081), null },
                    { 3, 32, "Borrowed", 5, new DateTime(2024, 11, 21, 6, 32, 26, 111, DateTimeKind.Local).AddTicks(4090), new DateTime(2024, 11, 29, 14, 56, 45, 288, DateTimeKind.Local).AddTicks(5412), new DateTime(2024, 11, 22, 14, 56, 45, 288, DateTimeKind.Local).AddTicks(5412), null },
                    { 4, 11, "Canceled", 12, null, null, new DateTime(2024, 11, 21, 5, 6, 53, 673, DateTimeKind.Local).AddTicks(1957), null },
                    { 5, 22, "Canceled", 8, null, null, new DateTime(2024, 11, 25, 20, 9, 28, 603, DateTimeKind.Local).AddTicks(4227), null },
                    { 6, 12, "Canceled", 4, null, null, new DateTime(2024, 11, 20, 14, 27, 58, 256, DateTimeKind.Local).AddTicks(4517), null },
                    { 7, 4, "Canceled", 15, null, null, new DateTime(2024, 11, 21, 20, 27, 51, 777, DateTimeKind.Local).AddTicks(7964), null },
                    { 8, 1, "Borrowed", 1, new DateTime(2024, 11, 23, 23, 17, 41, 635, DateTimeKind.Local).AddTicks(7942), new DateTime(2024, 12, 2, 19, 17, 51, 249, DateTimeKind.Local).AddTicks(475), new DateTime(2024, 11, 25, 19, 17, 51, 249, DateTimeKind.Local).AddTicks(475), null },
                    { 9, 30, "Borrowed", 7, new DateTime(2024, 11, 24, 23, 41, 54, 172, DateTimeKind.Local).AddTicks(8332), new DateTime(2024, 12, 2, 0, 5, 47, 437, DateTimeKind.Local).AddTicks(1469), new DateTime(2024, 11, 25, 0, 5, 47, 437, DateTimeKind.Local).AddTicks(1469), null },
                    { 10, 2, "Borrowed", 5, new DateTime(2024, 11, 20, 19, 9, 40, 507, DateTimeKind.Local).AddTicks(1123), new DateTime(2024, 11, 29, 5, 43, 13, 176, DateTimeKind.Local).AddTicks(240), new DateTime(2024, 11, 22, 5, 43, 13, 176, DateTimeKind.Local).AddTicks(240), null },
                    { 11, 24, "Borrowed", 10, new DateTime(2024, 11, 20, 14, 9, 49, 151, DateTimeKind.Local).AddTicks(751), new DateTime(2024, 12, 2, 7, 37, 2, 960, DateTimeKind.Local).AddTicks(3198), new DateTime(2024, 11, 25, 7, 37, 2, 960, DateTimeKind.Local).AddTicks(3198), null },
                    { 12, 30, "Borrowed", 7, new DateTime(2024, 11, 22, 7, 6, 18, 340, DateTimeKind.Local).AddTicks(8688), new DateTime(2024, 12, 2, 20, 46, 42, 425, DateTimeKind.Local).AddTicks(3095), new DateTime(2024, 11, 25, 20, 46, 42, 425, DateTimeKind.Local).AddTicks(3095), null },
                    { 13, 26, "Completed", 14, new DateTime(2024, 11, 22, 21, 14, 50, 7, DateTimeKind.Local).AddTicks(5894), new DateTime(2024, 11, 26, 22, 50, 24, 749, DateTimeKind.Local).AddTicks(7610), new DateTime(2024, 11, 19, 22, 50, 24, 749, DateTimeKind.Local).AddTicks(7610), new DateTime(2024, 11, 24, 11, 53, 5, 650, DateTimeKind.Local).AddTicks(349) },
                    { 14, 15, "Completed", 13, new DateTime(2024, 11, 25, 9, 13, 33, 460, DateTimeKind.Local).AddTicks(1640), new DateTime(2024, 12, 1, 5, 8, 46, 680, DateTimeKind.Local).AddTicks(1810), new DateTime(2024, 11, 24, 5, 8, 46, 680, DateTimeKind.Local).AddTicks(1810), new DateTime(2024, 11, 23, 18, 17, 44, 32, DateTimeKind.Local).AddTicks(5168) },
                    { 15, 16, "Pending", 10, null, null, new DateTime(2024, 11, 20, 22, 47, 38, 705, DateTimeKind.Local).AddTicks(5700), null },
                    { 16, 30, "Completed", 12, new DateTime(2024, 11, 24, 5, 59, 12, 165, DateTimeKind.Local).AddTicks(9678), new DateTime(2024, 12, 1, 5, 6, 29, 169, DateTimeKind.Local).AddTicks(5726), new DateTime(2024, 11, 24, 5, 6, 29, 169, DateTimeKind.Local).AddTicks(5726), new DateTime(2024, 11, 25, 3, 12, 38, 832, DateTimeKind.Local).AddTicks(7966) },
                    { 17, 9, "Completed", 13, new DateTime(2024, 11, 24, 14, 33, 24, 223, DateTimeKind.Local).AddTicks(9610), new DateTime(2024, 12, 2, 16, 27, 50, 98, DateTimeKind.Local).AddTicks(5468), new DateTime(2024, 11, 25, 16, 27, 50, 98, DateTimeKind.Local).AddTicks(5468), new DateTime(2024, 11, 25, 18, 21, 17, 849, DateTimeKind.Local).AddTicks(4816) },
                    { 18, 16, "Completed", 5, new DateTime(2024, 11, 22, 2, 55, 1, 145, DateTimeKind.Local).AddTicks(7989), new DateTime(2024, 11, 30, 21, 33, 23, 875, DateTimeKind.Local).AddTicks(5987), new DateTime(2024, 11, 23, 21, 33, 23, 875, DateTimeKind.Local).AddTicks(5987), new DateTime(2024, 11, 24, 19, 8, 4, 283, DateTimeKind.Local).AddTicks(751) },
                    { 19, 4, "Completed", 3, new DateTime(2024, 11, 19, 22, 52, 11, 670, DateTimeKind.Local).AddTicks(7345), new DateTime(2024, 11, 30, 11, 46, 48, 326, DateTimeKind.Local).AddTicks(4543), new DateTime(2024, 11, 23, 11, 46, 48, 326, DateTimeKind.Local).AddTicks(4543), new DateTime(2024, 11, 24, 22, 4, 42, 135, DateTimeKind.Local).AddTicks(7215) },
                    { 20, 23, "Pending", 13, null, null, new DateTime(2024, 11, 22, 18, 52, 59, 388, DateTimeKind.Local).AddTicks(5343), null },
                    { 21, 20, "Canceled", 14, null, null, new DateTime(2024, 11, 22, 16, 35, 18, 801, DateTimeKind.Local).AddTicks(4098), null },
                    { 22, 24, "Completed", 1, new DateTime(2024, 11, 22, 4, 4, 28, 59, DateTimeKind.Local).AddTicks(2808), new DateTime(2024, 12, 1, 9, 32, 15, 683, DateTimeKind.Local).AddTicks(1589), new DateTime(2024, 11, 24, 9, 32, 15, 683, DateTimeKind.Local).AddTicks(1589), new DateTime(2024, 11, 23, 21, 24, 24, 257, DateTimeKind.Local).AddTicks(4947) },
                    { 23, 38, "Completed", 9, new DateTime(2024, 11, 25, 11, 54, 57, 700, DateTimeKind.Local).AddTicks(1082), new DateTime(2024, 11, 28, 9, 21, 13, 874, DateTimeKind.Local).AddTicks(5140), new DateTime(2024, 11, 21, 9, 21, 13, 874, DateTimeKind.Local).AddTicks(5140), new DateTime(2024, 11, 23, 23, 28, 10, 972, DateTimeKind.Local).AddTicks(413) },
                    { 24, 20, "Borrowed", 16, new DateTime(2024, 11, 22, 18, 32, 43, 927, DateTimeKind.Local).AddTicks(1798), new DateTime(2024, 11, 28, 2, 59, 2, 827, DateTimeKind.Local).AddTicks(9992), new DateTime(2024, 11, 21, 2, 59, 2, 827, DateTimeKind.Local).AddTicks(9992), null },
                    { 25, 32, "Completed", 8, new DateTime(2024, 11, 20, 9, 16, 41, 888, DateTimeKind.Local).AddTicks(3533), new DateTime(2024, 11, 26, 19, 24, 53, 174, DateTimeKind.Local).AddTicks(3902), new DateTime(2024, 11, 19, 19, 24, 53, 174, DateTimeKind.Local).AddTicks(3902), new DateTime(2024, 11, 24, 22, 47, 38, 216, DateTimeKind.Local).AddTicks(8391) },
                    { 26, 23, "Canceled", 16, null, null, new DateTime(2024, 11, 22, 2, 18, 52, 429, DateTimeKind.Local).AddTicks(5684), null },
                    { 27, 35, "Borrowed", 3, new DateTime(2024, 11, 25, 12, 2, 42, 132, DateTimeKind.Local).AddTicks(41), new DateTime(2024, 11, 27, 12, 35, 47, 247, DateTimeKind.Local).AddTicks(3664), new DateTime(2024, 11, 20, 12, 35, 47, 247, DateTimeKind.Local).AddTicks(3664), null },
                    { 28, 33, "Borrowed", 8, new DateTime(2024, 11, 23, 9, 35, 40, 522, DateTimeKind.Local).AddTicks(3400), new DateTime(2024, 12, 2, 20, 25, 2, 224, DateTimeKind.Local).AddTicks(4062), new DateTime(2024, 11, 25, 20, 25, 2, 224, DateTimeKind.Local).AddTicks(4062), null },
                    { 29, 25, "Pending", 4, null, null, new DateTime(2024, 11, 21, 16, 7, 41, 291, DateTimeKind.Local).AddTicks(6139), null },
                    { 30, 37, "Canceled", 14, null, null, new DateTime(2024, 11, 19, 9, 47, 45, 958, DateTimeKind.Local).AddTicks(540), null },
                    { 31, 15, "Borrowed", 10, new DateTime(2024, 11, 24, 15, 9, 8, 603, DateTimeKind.Local).AddTicks(6836), new DateTime(2024, 11, 30, 22, 28, 21, 270, DateTimeKind.Local).AddTicks(2201), new DateTime(2024, 11, 23, 22, 28, 21, 270, DateTimeKind.Local).AddTicks(2201), null },
                    { 32, 36, "Canceled", 15, null, null, new DateTime(2024, 11, 25, 15, 25, 11, 613, DateTimeKind.Local).AddTicks(2287), null },
                    { 33, 13, "Completed", 10, new DateTime(2024, 11, 21, 12, 35, 18, 702, DateTimeKind.Local).AddTicks(2072), new DateTime(2024, 11, 26, 9, 57, 34, 555, DateTimeKind.Local).AddTicks(2052), new DateTime(2024, 11, 19, 9, 57, 34, 555, DateTimeKind.Local).AddTicks(2052), new DateTime(2024, 11, 25, 11, 24, 38, 130, DateTimeKind.Local).AddTicks(914) },
                    { 34, 27, "Canceled", 4, null, null, new DateTime(2024, 11, 25, 0, 4, 27, 985, DateTimeKind.Local).AddTicks(3538), null },
                    { 35, 33, "Borrowed", 2, new DateTime(2024, 11, 19, 22, 42, 54, 440, DateTimeKind.Local).AddTicks(7806), new DateTime(2024, 11, 29, 13, 17, 18, 100, DateTimeKind.Local).AddTicks(7971), new DateTime(2024, 11, 22, 13, 17, 18, 100, DateTimeKind.Local).AddTicks(7971), null },
                    { 36, 10, "Pending", 4, null, null, new DateTime(2024, 11, 22, 6, 57, 4, 133, DateTimeKind.Local).AddTicks(7062), null },
                    { 37, 1, "Completed", 7, new DateTime(2024, 11, 23, 12, 0, 7, 379, DateTimeKind.Local).AddTicks(6947), new DateTime(2024, 11, 29, 16, 34, 29, 90, DateTimeKind.Local).AddTicks(8567), new DateTime(2024, 11, 22, 16, 34, 29, 90, DateTimeKind.Local).AddTicks(8567), new DateTime(2024, 11, 23, 23, 31, 41, 311, DateTimeKind.Local).AddTicks(8111) },
                    { 38, 20, "Pending", 8, null, null, new DateTime(2024, 11, 22, 3, 59, 19, 719, DateTimeKind.Local).AddTicks(7550), null },
                    { 39, 28, "Canceled", 6, null, null, new DateTime(2024, 11, 20, 4, 19, 1, 67, DateTimeKind.Local).AddTicks(7826), null },
                    { 40, 18, "Canceled", 1, null, null, new DateTime(2024, 11, 24, 2, 14, 0, 126, DateTimeKind.Local).AddTicks(2000), null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 17, 20, 2, "Quis qui quod qui aut occaecati tempora voluptatum adipisci explicabo.", 5 },
                    { 18, 4, 13, "Sit vel commodi.", 12 },
                    { 19, 29, 5, "Voluptatem dolorem odio et consectetur odit et.", 3 },
                    { 20, 20, 9, "Et eveniet cumque.", 6 },
                    { 21, 3, 15, "In inventore ipsum error delectus saepe.", 11 },
                    { 22, 4, 15, "Sequi beatae non nihil corrupti qui rem facilis quisquam.", 7 },
                    { 23, 22, 9, "Aut sit et magnam odit magnam excepturi blanditiis id.", 16 },
                    { 24, 33, 8, "Adipisci quisquam impedit qui.", 10 },
                    { 25, 10, 12, "Debitis iure alias est quasi error fugiat consequatur ducimus.", 13 },
                    { 26, 15, 11, "Eos repellendus aperiam.", 2 },
                    { 27, 6, 10, "Vel et non error consequuntur a in voluptatum.", 2 },
                    { 28, 32, 13, "Occaecati iusto soluta et.", 8 },
                    { 29, 18, 4, "Numquam dignissimos voluptatem esse sint repudiandae molestias sit impedit.", 8 },
                    { 30, 34, 13, "Consequatur quis quis et.", 7 },
                    { 31, 13, 12, "Dolorem eos quibusdam dicta eius ea quae quisquam commodi vel.", 2 },
                    { 32, 17, 12, "Est consequuntur qui quibusdam nostrum est.", 12 }
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
