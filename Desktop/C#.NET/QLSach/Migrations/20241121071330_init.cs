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
                    { 1, "Facere officiis explicabo esse.", "Reina" },
                    { 2, "Dolores tempora ipsa ad.", "Jose" },
                    { 3, "Voluptatem voluptas eligendi modi ad animi nam magni repellendus.", "Alexzander" },
                    { 4, "Possimus in odio velit atque distinctio laboriosam ratione tempore autem.", "Alvina" },
                    { 5, "Deserunt est voluptate totam laudantium reprehenderit.", "Jacinto" },
                    { 6, "Et qui voluptatem.", "Randall" },
                    { 7, "Aut et ullam ratione.", "Jovany" },
                    { 8, "Exercitationem nemo quam libero amet tempora.", "Marlen" },
                    { 9, "Impedit et doloremque maxime accusamus quis aut quos non deserunt.", "Verda" },
                    { 10, "Ea labore voluptatem molestiae voluptates earum.", "Ollie" },
                    { 11, "Non blanditiis nam ducimus architecto eum aliquam.", "Milo" },
                    { 12, "Animi et ut similique voluptatem odio omnis explicabo optio et.", "Augustine" },
                    { 13, "Eaque sit nihil.", "Sofia" },
                    { 14, "Id blanditiis voluptatem nesciunt rerum odit molestiae consequuntur.", "Archibald" },
                    { 15, "Culpa officia excepturi.", "Cordell" },
                    { 16, "Ad nemo autem quibusdam.", "Emory" },
                    { 17, "Omnis omnis itaque deserunt error voluptas.", "Peter" },
                    { 18, "Et aut amet.", "Cullen" },
                    { 19, "Libero earum mollitia laboriosam.", "Theodora" },
                    { 20, "Itaque fugiat itaque aliquam sed velit.", "Lucius" },
                    { 21, "Voluptatem debitis cupiditate velit repellat amet vel impedit.", "Ursula" },
                    { 22, "Doloribus omnis consequuntur ut voluptas.", "Lavina" },
                    { 23, "Est unde rerum quo facilis eum laborum.", "Savannah" },
                    { 24, "Commodi minus sed praesentium.", "Loyce" },
                    { 25, "Sint quaerat commodi eos.", "Mittie" },
                    { 26, "Id omnis ratione molestiae amet quis dolore.", "Cortney" },
                    { 27, "Nihil incidunt placeat laborum rerum minima enim et magni expedita.", "Leola" },
                    { 28, "Fugiat consequuntur ullam unde ipsum doloremque quisquam consequatur et sint.", "Joshua" },
                    { 29, "Placeat voluptatem eius ut ut id et cupiditate facere veniam.", "Nora" },
                    { 30, "A sunt modi assumenda dolorem iusto autem sunt reprehenderit.", "Jean" },
                    { 31, "Consequuntur incidunt eum eaque optio.", "Deonte" },
                    { 32, "Repudiandae explicabo et et perspiciatis officiis.", "Johanna" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Accusamus est nesciunt qui optio qui ut amet et nemo. Unde molestiae molestias laboriosam temporibus a. Voluptatibus eum reiciendis et.", "Quia tempore autem quisquam commodi voluptas qui earum voluptatem consequuntur.\nQuisquam recusandae officiis vero.\nEst autem enim.\nDolor qui dolorem consectetur distinctio sed ea aut sint.\nConsectetur ut amet provident in unde.\nConsequuntur laudantium facere dignissimos a doloribus perspiciatis rerum dolorem ut.", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 2, "Rem pariatur similique aspernatur. Quae sapiente molestiae cum maiores non enim ipsum soluta. Sed animi velit. Et voluptatem magnam magnam sequi repellat aliquid.", "Et sit reiciendis enim nobis perspiciatis minima autem facere accusantium.", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 3, "Iure nam minus quis pariatur quo. Nemo porro facere. Ad perspiciatis est nulla accusantium. Ut qui et dolorem sit voluptatem ipsam iure. Error veritatis et architecto ullam quae delectus. Rem incidunt sunt iusto ea iusto quo est.", "autem", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 4, "Rerum repudiandae tenetur quibusdam iste rerum. Iusto sint et est enim magni fuga dolorum. Voluptatem alias esse.", "In alias omnis laudantium fugiat eius.", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 5, "At ut eius saepe enim doloribus asperiores molestias maxime. Vitae ad id sunt quaerat nesciunt. Omnis iure quos architecto repudiandae omnis officia magni. Autem culpa dolorum similique recusandae consectetur at.", "Atque doloremque voluptatem qui sunt nihil. Est sequi incidunt sunt. Placeat sequi veniam quam.", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "et" },
                    { 2, "eos" },
                    { 3, "ut" },
                    { 4, "impedit" },
                    { 5, "rem" },
                    { 6, "inventore" },
                    { 7, "ut" },
                    { 8, "aliquid" },
                    { 9, "voluptatem" },
                    { 10, "dolore" },
                    { 11, "molestiae" },
                    { 12, "nisi" },
                    { 13, "numquam" },
                    { 14, "veniam" },
                    { 15, "qui" },
                    { 16, "ipsam" },
                    { 17, "cupiditate" },
                    { 18, "placeat" },
                    { 19, "itaque" },
                    { 20, "illo" },
                    { 21, "in" },
                    { 22, "ad" },
                    { 23, "laudantium" },
                    { 24, "maiores" },
                    { 25, "temporibus" },
                    { 26, "iusto" },
                    { 27, "cumque" },
                    { 28, "ut" },
                    { 29, "in" },
                    { 30, "consequatur" },
                    { 31, "aliquid" },
                    { 32, "rerum" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Margie Von", "Adipisci in beatae quae in sint et. Qui expedita id dolorem ullam pariatur. Enim sequi quidem officiis recusandae odit. Consequatur distinctio aut libero aliquid vel eum necessitatibus porro sit. Deleniti consequatur nobis id. Dolorum tempore molestiae ut culpa veniam et non dolorem recusandae.", "Admin", "Chester", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 2, "Estevan Barrows", "quia", "User", "Jacques", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 3, "Octavia Mayer", "Nobis est nesciunt est nihil eum distinctio totam. Sapiente et magnam numquam esse. Iste illum ad et.", "Admin", "Eloy", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 4, "Dimitri Quitzon", "Et consectetur est.", "User", "Vivienne", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 5, "Julius Howell", "Eos eum natus animi eum officiis assumenda nesciunt commodi.", "User", "Evangeline", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 6, "Deonte Lueilwitz", "Repellendus nemo et.", "User", "Edwin", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 7, "Catalina Ryan", "Ipsa harum velit corporis in qui.", "Admin", "Irma", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 8, "Lacy Greenholt", "Quos reprehenderit quibusdam maiores consequatur voluptatem amet. Non distinctio sit beatae reprehenderit et. Quos amet dicta officiis cumque itaque provident dolores optio. Et voluptatem voluptas reprehenderit dicta voluptates exercitationem iste voluptatibus deserunt.", "User", "Mable", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 9, "Elenora Schamberger", "Amet voluptates voluptas rem aut natus.", "Admin", "Leone", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 10, "Freeman Baumbach", "Quo aspernatur harum sit non magnam cumque soluta amet. Ut optio aut enim exercitationem fugit. At architecto sapiente est asperiores occaecati cumque aut accusamus optio. Saepe enim blanditiis. Dolor quo vitae non fugit nam.", "Admin", "Vanessa", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 11, "Gerardo Emmerich", "consequatur", "User", "Jaquan", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 12, "Cleveland Hettinger", "Voluptatem consectetur iste necessitatibus consequatur nobis veniam sit.", "User", "Sigurd", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 13, "Kendrick Lakin", "Omnis vel maiores ut et.", "Admin", "Marianna", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 14, "Era Ratke", "est", "User", "Rick", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 15, "Gay Johns", "Officia et nesciunt perferendis nisi pariatur dolores dolor mollitia voluptatem.\nMagni ea a et a totam adipisci qui.\nQuaerat distinctio modi est et commodi rerum facere.", "User", "Lela", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) },
                    { 16, "Emmanuelle Fay", "in", "User", "Riley", new DateOnly(2024, 11, 21), new DateOnly(2024, 11, 21) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "quantity", "rating", "remaining", "updated_at", "views", "year_public" },
                values: new object[,]
                {
                    { 1, 14, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(2215), "Nostrum vel voluptate eum eligendi nobis ipsam recusandae. Et commodi odit aut dolor earum et. Voluptatem doloribus sed vitae qui officia et. Vel eius aperiam.", 9, "Autem dolorem quisquam vitae necessitatibus dicta officiis asperiores eos soluta.", (byte)7, (byte)0, (byte)0, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(2637), 0, 1906 },
                    { 2, 1, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(3499), "Sit autem non quia. Dignissimos aut aut distinctio omnis. Sunt consequuntur quia optio fugit repellat.", 8, "Autem qui quae ex.", (byte)6, (byte)0, (byte)1, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(3639), 0, 2020 },
                    { 3, 4, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(3651), "Perferendis qui ut tenetur cumque eius quasi. Quo labore laborum voluptas est ea dolor sunt molestias maxime. Et ullam aperiam quo quia. Explicabo deleniti quia occaecati minima facere provident provident. Omnis saepe dolorem quia vel.", 17, "Quasi nisi pariatur cumque reprehenderit.", (byte)8, (byte)0, (byte)2, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(3770), 0, 1943 },
                    { 4, 27, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(3781), "Voluptas dignissimos laboriosam sed quisquam amet. Maiores aperiam sint iure. Voluptas rerum culpa harum. Accusamus veniam aperiam asperiores occaecati blanditiis velit magnam culpa.", 6, "Provident harum omnis et id quia fugiat.", (byte)5, (byte)0, (byte)5, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(3890), 0, 1970 },
                    { 5, 8, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(3901), "Quisquam et odio modi in ad modi. Omnis qui in ducimus rerum ipsa sit debitis soluta sint. Qui eum voluptatem repellendus sint numquam perferendis sit corrupti ex. Consectetur quia illum aut architecto quaerat reprehenderit placeat atque dignissimos. Et non ipsum sed necessitatibus. Repudiandae et necessitatibus quam non at vel.", 24, "Maxime non enim ipsa.", (byte)7, (byte)0, (byte)3, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4071), 0, 1935 },
                    { 6, 23, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4082), "Accusamus consequatur et optio ut sunt quod ullam. Corrupti dolores sed necessitatibus rerum. Ea qui sunt repellat.", 3, "Beatae minus quam autem vero.", (byte)7, (byte)0, (byte)1, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4152), 0, 2002 },
                    { 7, 16, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4182), "Id voluptas id nihil quis quo rerum. Voluptas amet sed labore fugiat quas. Occaecati mollitia cupiditate et provident eos dolorum. Veritatis eaque ipsum. Dolores commodi dolorem autem et pariatur est nulla quia. Suscipit illum officia quia deleniti.", 30, "Totam dolores ullam facere cum incidunt quasi vitae blanditiis.", (byte)8, (byte)0, (byte)2, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4302), 0, 1990 },
                    { 8, 17, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4312), "Ducimus temporibus ab ab. Atque error repellendus vel assumenda quae sit vel. Vitae perferendis officiis omnis illo.", 17, "Ut omnis non assumenda.", (byte)5, (byte)0, (byte)4, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4398), 0, 2004 },
                    { 9, 7, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4409), "Laboriosam omnis deleniti quibusdam. Ducimus suscipit rerum fuga similique. Aut totam nihil quod velit omnis doloremque sint temporibus laudantium. Autem deserunt praesentium corporis sed et natus est. Illum et cupiditate assumenda consequatur veritatis dolor.", 29, "Voluptatem eligendi quasi.", (byte)10, (byte)0, (byte)3, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4528), 0, 1913 },
                    { 10, 11, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4539), "Autem mollitia eius consequatur sequi fuga officiis ab et. Consequatur sed pariatur harum consequatur eos. Impedit dicta consequatur ab exercitationem vel aliquam repellat labore. Ducimus unde vel.", 25, "Libero ad sint qui et.", (byte)7, (byte)0, (byte)4, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4622), 0, 1945 },
                    { 11, 32, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4633), "Rerum dolores itaque sunt id aut aperiam. Accusantium voluptatem dolores aliquid optio voluptas nobis. Impedit quae ut minima ratione sunt voluptas dolore neque quo. Quo sed distinctio perferendis praesentium deserunt asperiores et.", 13, "Ducimus dolore voluptatibus dolore eveniet labore cum et sint ut.", (byte)9, (byte)0, (byte)0, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4768), 0, 1938 },
                    { 12, 12, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4778), "Autem sunt molestias expedita. Occaecati odio qui quis soluta iusto similique. Est et doloribus autem blanditiis ipsa. Pariatur aperiam assumenda architecto nihil consectetur asperiores velit enim rerum. Veritatis quaerat hic dolor et rem numquam qui.", 12, "Sit repellendus ad et maxime et minus.", (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4906), 0, 1951 },
                    { 13, 5, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(4916), "Similique rerum distinctio qui. Eveniet cupiditate ratione. Unde esse suscipit consequatur alias eveniet consequatur. Itaque suscipit unde. Rem hic ab hic eum ad excepturi beatae ut. Nisi similique pariatur sequi distinctio blanditiis ex.", 12, "Fuga sunt nihil.", (byte)8, (byte)0, (byte)1, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5037), 0, 1947 },
                    { 14, 7, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5048), "Aut facere dignissimos quis adipisci vero nesciunt placeat. Dolor incidunt qui deleniti dolores. Rem doloremque sunt perspiciatis. Dolorem aperiam repellat sed soluta eos et repellendus. Odio repellat dolor. Eius et rerum sunt et laudantium tenetur nihil et.", 31, "Rem impedit et nesciunt ut iste aut vel totam possimus.", (byte)6, (byte)0, (byte)0, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5186), 0, 1901 },
                    { 15, 4, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5197), "Voluptates eius blanditiis deleniti soluta suscipit voluptatem. Eos quas cum dolores aut deleniti voluptatum quisquam asperiores. Voluptatem nobis omnis aspernatur adipisci sed.", 28, "Consequatur porro dolorum consectetur.", (byte)5, (byte)0, (byte)4, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5266), 0, 1924 },
                    { 16, 14, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5277), "Deserunt ut odio. Voluptate atque sapiente omnis aut. Qui vero tenetur. Eaque aspernatur quo possimus. In ipsum neque laudantium repudiandae esse laudantium libero illo. Necessitatibus ullam id est.", 10, "Soluta ipsa sit voluptatem sit nobis.", (byte)5, (byte)0, (byte)0, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5389), 0, 2013 },
                    { 17, 15, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5399), "Ipsum necessitatibus aut maxime consequatur. Molestias officia quaerat quia voluptas aut. Eos id quia sit ea blanditiis voluptatibus. Beatae ipsam architecto illum.", 8, "Quidem assumenda tenetur voluptates voluptatem.", (byte)9, (byte)0, (byte)3, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5494), 0, 1941 },
                    { 18, 1, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5503), "Accusantium sed tenetur reiciendis exercitationem earum delectus quas. Rerum quisquam consequatur eos. Esse consequatur laborum.", 3, "Et eveniet quos non est cumque.", (byte)8, (byte)0, (byte)0, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5688), 0, 1971 },
                    { 19, 10, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5699), "Iusto quidem sit et eum quod. Sed voluptas consequatur dolorem voluptas magnam vero. Nesciunt rerum magnam maiores.", 10, "Asperiores et dolorum officiis dicta soluta quia porro.", (byte)7, (byte)0, (byte)3, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5791), 0, 1985 },
                    { 20, 28, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5801), "Dolores consectetur fugiat et fuga. Deleniti voluptatem sint. In enim voluptas. Necessitatibus ut odit illo aliquid.", 4, "Optio ut et aut qui voluptas corrupti neque rem vel.", (byte)5, (byte)0, (byte)4, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5871), 0, 1982 },
                    { 21, 30, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5881), "Commodi ut exercitationem ea illum culpa. Officia eligendi quibusdam non cumque sed. Nisi et soluta. Repellat et incidunt in alias autem est nihil et cum. Nobis ab pariatur.", 21, "Est consequatur fugit tempora eos.", (byte)9, (byte)0, (byte)3, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5980), 0, 2007 },
                    { 22, 18, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(5990), "Tempore doloribus velit corrupti. Minus non accusamus aperiam sint dolor ut. Maiores dignissimos minima blanditiis. Animi dolor id fuga natus non sed itaque similique.", 5, "Quibusdam cumque cumque sunt dolores et.", (byte)6, (byte)0, (byte)4, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6101), 0, 1901 },
                    { 23, 22, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6111), "Enim non veritatis dolor officiis. Repellat aut reprehenderit molestias alias voluptate nulla. Architecto fuga non.", 11, "Ex aliquam eum reprehenderit ut ea et et voluptas doloremque.", (byte)10, (byte)0, (byte)2, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6177), 0, 2005 },
                    { 24, 4, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6189), "Ut fugiat possimus velit fugiat quia sed earum necessitatibus. Velit qui quidem non facere. Ex repudiandae itaque distinctio est numquam quaerat qui facilis.", 31, "Dolor temporibus placeat natus labore ut assumenda accusantium.", (byte)6, (byte)0, (byte)2, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6296), 0, 1923 },
                    { 25, 13, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6308), "Aperiam tenetur iusto id. Rerum ipsum numquam dicta incidunt distinctio. Quia officiis expedita cum et et. Id fugiat reiciendis aliquid eos.", 16, "Tempore ut sapiente incidunt.", (byte)8, (byte)0, (byte)3, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6406), 0, 2003 },
                    { 26, 10, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6418), "Consectetur quae velit voluptatem laborum architecto veniam optio esse ipsa. Velit necessitatibus accusamus alias ex quas sit deserunt quibusdam. Voluptates iste nihil recusandae maiores. Ea minus ea.", 31, "Est alias odio.", (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6497), 0, 2009 },
                    { 27, 32, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6508), "Earum quod eligendi autem et totam cumque. Dicta et magnam consequuntur. Adipisci culpa cum perspiciatis omnis enim dignissimos eum occaecati est. Aut dignissimos autem omnis. Magnam perferendis beatae quibusdam ut reiciendis tempora.", 18, "Vel illum veniam et nostrum earum.", (byte)7, (byte)0, (byte)3, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6623), 0, 1914 },
                    { 28, 19, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6634), "Dolor illum quaerat repellendus repellendus velit reprehenderit maiores. Molestias eaque saepe dolores sit delectus eaque. Consequatur praesentium eveniet ut esse asperiores et necessitatibus et. Soluta veritatis porro autem voluptatem quia mollitia. Porro qui dolores.", 22, "In qui est explicabo explicabo non.", (byte)5, (byte)0, (byte)4, new DateTime(2024, 11, 21, 14, 13, 29, 945, DateTimeKind.Local).AddTicks(6757), 0, 2020 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBook",
                columns: new[] { "Id", "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 9, 4 },
                    { 2, 24, 3 },
                    { 3, 11, 4 },
                    { 4, 19, 3 },
                    { 5, 21, 2 },
                    { 6, 14, 3 },
                    { 7, 4, 4 },
                    { 8, 22, 4 },
                    { 9, 4, 5 },
                    { 10, 4, 5 },
                    { 11, 12, 3 },
                    { 12, 17, 2 },
                    { 13, 11, 5 },
                    { 14, 21, 2 },
                    { 15, 8, 5 },
                    { 16, 22, 1 },
                    { 17, 10, 5 },
                    { 18, 23, 1 },
                    { 19, 6, 4 },
                    { 20, 11, 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 1, 17, 7, "Sapiente dicta doloremque labore alias est quisquam vero quia.", null },
                    { 2, 24, 5, "Quia veritatis architecto autem saepe qui nam.", null },
                    { 3, 22, 13, "Et magni et dolores in provident beatae ipsa sequi id.", null },
                    { 4, 2, 1, "Illo cumque veniam beatae qui eos qui exercitationem.", null },
                    { 5, 21, 6, "Dolor soluta et officiis doloribus numquam.", null },
                    { 6, 15, 8, "Architecto magni omnis quisquam architecto et nihil in ipsa.", null },
                    { 7, 26, 11, "Dolor in illum aspernatur impedit ad consequatur.", null },
                    { 8, 14, 10, "Ab et ut.", null },
                    { 9, 22, 3, "Itaque saepe rerum tenetur commodi.", null },
                    { 10, 8, 2, "Quasi maxime expedita sit quae sapiente consectetur fuga.", null },
                    { 11, 11, 14, "Delectus placeat dolorem laboriosam ut ut.", null },
                    { 12, 23, 10, "Vel officiis soluta repellat.", null },
                    { 13, 5, 8, "Qui culpa vitae.", null },
                    { 14, 22, 10, "Dolore qui id pariatur et quia a eos aut et.", null },
                    { 15, 5, 6, "Provident accusamus omnis perspiciatis in expedita.", null },
                    { 16, 12, 7, "Atque pariatur dolore omnis fuga aliquam aut.", null }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "book_id", "path" },
                values: new object[,]
                {
                    { 1, 28, ".\\resources\\images\\poster.png" },
                    { 2, 23, ".\\resources\\images\\poster.png" },
                    { 3, 13, ".\\resources\\images\\poster.png" },
                    { 4, 10, ".\\resources\\images\\poster.png" },
                    { 5, 2, ".\\resources\\images\\poster.png" },
                    { 6, 13, ".\\resources\\images\\poster.png" },
                    { 7, 21, ".\\resources\\images\\poster.png" },
                    { 8, 10, ".\\resources\\images\\poster.png" },
                    { 9, 10, ".\\resources\\images\\poster.png" },
                    { 10, 18, ".\\resources\\images\\poster.png" },
                    { 11, 5, ".\\resources\\images\\poster.png" },
                    { 12, 10, ".\\resources\\images\\poster.png" },
                    { 13, 22, ".\\resources\\images\\poster.png" },
                    { 14, 14, ".\\resources\\images\\poster.png" },
                    { 15, 28, ".\\resources\\images\\poster.png" },
                    { 16, 16, ".\\resources\\images\\poster.png" }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 8, "Canceled", 10, null, null, new DateTime(2024, 11, 20, 18, 18, 52, 445, DateTimeKind.Local).AddTicks(4598), null },
                    { 2, 17, "Completed", 1, new DateTime(2024, 11, 20, 2, 44, 28, 569, DateTimeKind.Local).AddTicks(5556), new DateTime(2024, 11, 26, 8, 22, 33, 664, DateTimeKind.Local).AddTicks(4964), new DateTime(2024, 11, 19, 8, 22, 33, 664, DateTimeKind.Local).AddTicks(4964), new DateTime(2024, 11, 19, 12, 26, 53, 580, DateTimeKind.Local).AddTicks(6697) },
                    { 3, 4, "Canceled", 13, null, null, new DateTime(2024, 11, 15, 21, 3, 47, 66, DateTimeKind.Local).AddTicks(3702), null },
                    { 4, 9, "Canceled", 9, null, null, new DateTime(2024, 11, 15, 22, 14, 58, 621, DateTimeKind.Local).AddTicks(3213), null },
                    { 5, 23, "Pending", 5, null, null, new DateTime(2024, 11, 15, 20, 57, 38, 17, DateTimeKind.Local).AddTicks(1870), null },
                    { 6, 14, "Canceled", 10, null, null, new DateTime(2024, 11, 20, 0, 16, 5, 431, DateTimeKind.Local).AddTicks(962), null },
                    { 7, 27, "Canceled", 12, null, null, new DateTime(2024, 11, 17, 18, 28, 42, 91, DateTimeKind.Local).AddTicks(6096), null },
                    { 8, 1, "Pending", 9, null, null, new DateTime(2024, 11, 21, 11, 25, 20, 424, DateTimeKind.Local).AddTicks(961), null },
                    { 9, 7, "Canceled", 9, null, null, new DateTime(2024, 11, 15, 17, 57, 9, 256, DateTimeKind.Local).AddTicks(8213), null },
                    { 10, 18, "Pending", 16, null, null, new DateTime(2024, 11, 19, 2, 59, 48, 538, DateTimeKind.Local).AddTicks(7621), null },
                    { 11, 23, "Completed", 10, new DateTime(2024, 11, 17, 7, 44, 16, 62, DateTimeKind.Local).AddTicks(6995), new DateTime(2024, 11, 22, 3, 41, 51, 622, DateTimeKind.Local).AddTicks(3311), new DateTime(2024, 11, 15, 3, 41, 51, 622, DateTimeKind.Local).AddTicks(3311), new DateTime(2024, 11, 19, 14, 13, 9, 471, DateTimeKind.Local).AddTicks(5189) },
                    { 12, 16, "Canceled", 13, null, null, new DateTime(2024, 11, 18, 4, 33, 20, 870, DateTimeKind.Local).AddTicks(3329), null },
                    { 13, 12, "Canceled", 11, null, null, new DateTime(2024, 11, 20, 19, 46, 20, 19, DateTimeKind.Local).AddTicks(1768), null },
                    { 14, 12, "Pending", 14, null, null, new DateTime(2024, 11, 18, 7, 56, 43, 660, DateTimeKind.Local).AddTicks(5900), null },
                    { 15, 4, "Pending", 12, null, null, new DateTime(2024, 11, 18, 18, 42, 52, 440, DateTimeKind.Local).AddTicks(8761), null },
                    { 16, 17, "Completed", 5, new DateTime(2024, 11, 16, 11, 52, 45, 572, DateTimeKind.Local).AddTicks(8713), new DateTime(2024, 11, 26, 18, 52, 26, 546, DateTimeKind.Local).AddTicks(1566), new DateTime(2024, 11, 19, 18, 52, 26, 546, DateTimeKind.Local).AddTicks(1566), new DateTime(2024, 11, 19, 1, 35, 46, 485, DateTimeKind.Local).AddTicks(8670) },
                    { 17, 4, "Canceled", 5, null, null, new DateTime(2024, 11, 20, 16, 7, 13, 939, DateTimeKind.Local).AddTicks(6204), null },
                    { 18, 9, "Pending", 5, null, null, new DateTime(2024, 11, 14, 18, 9, 4, 420, DateTimeKind.Local).AddTicks(5832), null },
                    { 19, 4, "Completed", 3, new DateTime(2024, 11, 16, 0, 29, 12, 583, DateTimeKind.Local).AddTicks(8948), new DateTime(2024, 11, 25, 23, 8, 57, 981, DateTimeKind.Local).AddTicks(5503), new DateTime(2024, 11, 18, 23, 8, 57, 981, DateTimeKind.Local).AddTicks(5503), new DateTime(2024, 11, 20, 13, 37, 23, 620, DateTimeKind.Local).AddTicks(7063) },
                    { 20, 21, "Borrowed", 14, new DateTime(2024, 11, 19, 13, 22, 48, 482, DateTimeKind.Local).AddTicks(1640), new DateTime(2024, 11, 23, 2, 57, 35, 519, DateTimeKind.Local).AddTicks(2077), new DateTime(2024, 11, 16, 2, 57, 35, 519, DateTimeKind.Local).AddTicks(2077), null },
                    { 21, 14, "Completed", 16, new DateTime(2024, 11, 20, 1, 24, 39, 762, DateTimeKind.Local).AddTicks(5415), new DateTime(2024, 11, 26, 5, 21, 32, 895, DateTimeKind.Local).AddTicks(1370), new DateTime(2024, 11, 19, 5, 21, 32, 895, DateTimeKind.Local).AddTicks(1370), new DateTime(2024, 11, 20, 5, 42, 20, 557, DateTimeKind.Local).AddTicks(4911) },
                    { 22, 1, "Pending", 7, null, null, new DateTime(2024, 11, 19, 12, 56, 8, 356, DateTimeKind.Local).AddTicks(5253), null },
                    { 23, 25, "Borrowed", 11, new DateTime(2024, 11, 16, 3, 17, 8, 214, DateTimeKind.Local).AddTicks(6347), new DateTime(2024, 11, 24, 16, 10, 40, 846, DateTimeKind.Local).AddTicks(8696), new DateTime(2024, 11, 17, 16, 10, 40, 846, DateTimeKind.Local).AddTicks(8696), null },
                    { 24, 16, "Canceled", 2, null, null, new DateTime(2024, 11, 18, 8, 55, 50, 245, DateTimeKind.Local).AddTicks(4816), null },
                    { 25, 16, "Completed", 6, new DateTime(2024, 11, 15, 16, 56, 6, 792, DateTimeKind.Local).AddTicks(5193), new DateTime(2024, 11, 23, 0, 42, 17, 79, DateTimeKind.Local).AddTicks(4003), new DateTime(2024, 11, 16, 0, 42, 17, 79, DateTimeKind.Local).AddTicks(4003), new DateTime(2024, 11, 19, 20, 32, 38, 641, DateTimeKind.Local).AddTicks(5996) },
                    { 26, 17, "Canceled", 10, null, null, new DateTime(2024, 11, 18, 14, 58, 8, 723, DateTimeKind.Local).AddTicks(6573), null },
                    { 27, 17, "Borrowed", 3, new DateTime(2024, 11, 21, 8, 18, 5, 0, DateTimeKind.Local).AddTicks(4132), new DateTime(2024, 11, 26, 15, 4, 29, 517, DateTimeKind.Local).AddTicks(6850), new DateTime(2024, 11, 19, 15, 4, 29, 517, DateTimeKind.Local).AddTicks(6850), null },
                    { 28, 16, "Completed", 4, new DateTime(2024, 11, 18, 11, 10, 30, 521, DateTimeKind.Local).AddTicks(5213), new DateTime(2024, 11, 28, 5, 42, 44, 569, DateTimeKind.Local).AddTicks(393), new DateTime(2024, 11, 21, 5, 42, 44, 569, DateTimeKind.Local).AddTicks(393), new DateTime(2024, 11, 20, 21, 42, 50, 605, DateTimeKind.Local).AddTicks(6284) },
                    { 29, 26, "Completed", 2, new DateTime(2024, 11, 18, 20, 12, 55, 374, DateTimeKind.Local).AddTicks(9181), new DateTime(2024, 11, 22, 4, 31, 46, 40, DateTimeKind.Local).AddTicks(1032), new DateTime(2024, 11, 15, 4, 31, 46, 40, DateTimeKind.Local).AddTicks(1032), new DateTime(2024, 11, 19, 2, 59, 10, 165, DateTimeKind.Local).AddTicks(6117) },
                    { 30, 16, "Canceled", 2, null, null, new DateTime(2024, 11, 18, 10, 46, 49, 216, DateTimeKind.Local).AddTicks(1256), null },
                    { 31, 17, "Canceled", 15, null, null, new DateTime(2024, 11, 15, 5, 20, 50, 522, DateTimeKind.Local).AddTicks(5407), null },
                    { 32, 3, "Completed", 11, new DateTime(2024, 11, 20, 13, 15, 21, 753, DateTimeKind.Local).AddTicks(4786), new DateTime(2024, 11, 26, 14, 54, 4, 631, DateTimeKind.Local).AddTicks(6802), new DateTime(2024, 11, 19, 14, 54, 4, 631, DateTimeKind.Local).AddTicks(6802), new DateTime(2024, 11, 20, 1, 29, 36, 371, DateTimeKind.Local).AddTicks(4329) },
                    { 33, 10, "Borrowed", 4, new DateTime(2024, 11, 16, 0, 14, 27, 134, DateTimeKind.Local).AddTicks(1442), new DateTime(2024, 11, 26, 3, 7, 9, 69, DateTimeKind.Local).AddTicks(4947), new DateTime(2024, 11, 19, 3, 7, 9, 69, DateTimeKind.Local).AddTicks(4947), null },
                    { 34, 28, "Canceled", 13, null, null, new DateTime(2024, 11, 15, 19, 40, 23, 150, DateTimeKind.Local).AddTicks(2769), null },
                    { 35, 22, "Borrowed", 9, new DateTime(2024, 11, 17, 11, 44, 51, 71, DateTimeKind.Local).AddTicks(1184), new DateTime(2024, 11, 22, 1, 51, 49, 456, DateTimeKind.Local).AddTicks(3241), new DateTime(2024, 11, 15, 1, 51, 49, 456, DateTimeKind.Local).AddTicks(3241), null },
                    { 36, 6, "Pending", 5, null, null, new DateTime(2024, 11, 19, 23, 38, 35, 899, DateTimeKind.Local).AddTicks(9129), null },
                    { 37, 3, "Canceled", 14, null, null, new DateTime(2024, 11, 18, 14, 9, 9, 645, DateTimeKind.Local).AddTicks(8608), null },
                    { 38, 15, "Pending", 15, null, null, new DateTime(2024, 11, 18, 2, 16, 17, 142, DateTimeKind.Local).AddTicks(8665), null },
                    { 39, 27, "Pending", 3, null, null, new DateTime(2024, 11, 15, 9, 18, 28, 561, DateTimeKind.Local).AddTicks(1044), null },
                    { 40, 20, "Canceled", 13, null, null, new DateTime(2024, 11, 20, 23, 36, 33, 567, DateTimeKind.Local).AddTicks(5062), null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 17, 12, 16, "Rerum est officia.", 11 },
                    { 18, 2, 1, "Doloribus aut libero suscipit molestiae qui ut perferendis.", 8 },
                    { 19, 4, 6, "Deleniti sit non.", 7 },
                    { 20, 12, 11, "Earum distinctio ea pariatur asperiores sint unde et.", 8 },
                    { 21, 6, 11, "Id ea labore nam similique et consectetur et ut qui.", 3 },
                    { 22, 27, 13, "Et optio velit est quaerat aliquam odio assumenda quo impedit.", 13 },
                    { 23, 5, 6, "Cum sed saepe dicta.", 15 },
                    { 24, 28, 8, "Illum in quasi vel sit eum tenetur non.", 15 },
                    { 25, 26, 13, "Ut dolore facilis aliquid aut necessitatibus est maiores sed.", 7 },
                    { 26, 9, 9, "Nisi qui id minus consequuntur recusandae.", 15 },
                    { 27, 15, 8, "Aut harum hic odit est eaque placeat enim ea id.", 1 },
                    { 28, 2, 10, "Mollitia sit ut et iusto odit minus.", 7 },
                    { 29, 19, 15, "Enim sint rerum nihil ad corporis.", 6 },
                    { 30, 24, 15, "Animi qui dolor quasi quas accusamus ipsa molestiae dignissimos.", 8 },
                    { 31, 12, 11, "A numquam unde ipsa repellat aut ut necessitatibus voluptatem perferendis.", 1 },
                    { 32, 16, 4, "Quas ut doloribus odit dolore itaque est non soluta culpa.", 10 }
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
