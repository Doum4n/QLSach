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
                    name = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(300)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
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
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "nvarchar(100)", nullable: false),
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
                    name = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    genre_id = table.Column<int>(type: "int", nullable: false),
                    publisher_id = table.Column<int>(type: "int", nullable: false),
                    photoPath = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rating = table.Column<float>(type: "float", nullable: false),
                    public_at = table.Column<DateOnly>(type: "date", nullable: false),
                    views = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    remaining = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Books_Publishers_publisher_id",
                        column: x => x.publisher_id,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriesBook",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesBook", x => new { x.BookId, x.CategoryId });
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
                name: "Feedbacks",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    rating = table.Column<float>(type: "float", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Feedbacks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
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
                    register_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    borrow_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    expected_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    return_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(40)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Deleniti dolorem vel aut hic natus.", "Sabrina" },
                    { 2, "Ex tenetur molestiae repellendus ea.", "Hermina" },
                    { 3, "Voluptatem numquam similique debitis porro explicabo impedit ut repudiandae.", "Tristin" },
                    { 4, "Dolorem tenetur accusamus quas.", "Omari" },
                    { 5, "Dolor quaerat tenetur soluta quod dolorum ut eos enim.", "Jack" },
                    { 6, "Est dicta consequuntur cupiditate ipsum odit quia et sed voluptas.", "Carmelo" },
                    { 7, "Iusto aut sint magnam corrupti aut quia vero distinctio.", "Noah" },
                    { 8, "Illo non dolorum ea provident.", "Abel" },
                    { 9, "Tempore voluptas delectus ea aut vitae.", "Kailyn" },
                    { 10, "Sit ex labore asperiores dolor ut reprehenderit cupiditate a.", "Alysha" },
                    { 11, "Numquam sit nulla rem qui.", "Clotilde" },
                    { 12, "Laudantium in laboriosam veniam et deleniti incidunt.", "Erwin" },
                    { 13, "Dolorem praesentium consequatur qui dolor labore eos dolor.", "Daron" },
                    { 14, "At delectus corporis vel dolor fuga doloremque eos laboriosam velit.", "Augustus" },
                    { 15, "Ratione et laudantium commodi eligendi nobis incidunt aut.", "Emelie" },
                    { 16, "Fuga voluptas praesentium quia aliquam.", "Destin" },
                    { 17, "Similique eum nihil sunt.", "Mitchel" },
                    { 18, "Animi cum dolorum reprehenderit autem aperiam doloremque.", "Bryce" },
                    { 19, "Quod adipisci eos quidem inventore ut consequatur iusto.", "Kim" },
                    { 20, "Reiciendis iste nemo.", "Karlie" },
                    { 21, "Eaque ipsam sed ut vel consequatur in voluptas.", "Santiago" },
                    { 22, "Est sit nobis sit inventore consequatur autem.", "Sydnee" },
                    { 23, "Saepe voluptate aut.", "Elvis" },
                    { 24, "Omnis qui reprehenderit saepe enim molestiae impedit necessitatibus voluptatem officia.", "Michel" },
                    { 25, "Labore quaerat excepturi velit sequi cumque nam aliquid laboriosam aperiam.", "Carlee" },
                    { 26, "Facere voluptas tempora necessitatibus delectus et.", "Elena" },
                    { 27, "Est sit rem quam neque laboriosam reprehenderit odit.", "Gabriel" },
                    { 28, "Vel natus rem enim corporis omnis.", "Van" },
                    { 29, "Earum molestias delectus nemo veritatis facilis id.", "Brandy" },
                    { 30, "Voluptas corrupti beatae amet dolores eligendi earum.", "Bertrand" },
                    { 31, "Non numquam aut qui quasi soluta vero.", "Burdette" },
                    { 32, "Rerum harum sed nihil rem inventore.", "Myles" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Accusamus eos et quibusdam unde commodi perferendis sequi sed quis architecto enim ut in natus consequatur facilis assumenda ipsa perferendis.", "non", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 2, "Ab totam autem totam sit veritatis enim velit quod aliquam autem voluptate libero laudantium ut molestiae in quia nemo consequatur.", "quis", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 3, "Id inventore earum inventore ab accusantium ut laboriosam et quos dolor et labore aut quis non perspiciatis qui quia quam.", "dolorum", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 4, "Ut unde suscipit voluptatem animi non explicabo in repellat odio omnis eaque itaque iusto ut incidunt rerum esse et tempora.", "error", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 5, "Cupiditate harum qui eveniet voluptatem quam et tempora ut enim fugit nulla et praesentium optio consequuntur consequuntur et et vel.", "odit", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "dolor" },
                    { 2, "corrupti" },
                    { 3, "voluptas" },
                    { 4, "aut" },
                    { 5, "atque" },
                    { 6, "dolor" },
                    { 7, "in" },
                    { 8, "quos" },
                    { 9, "nam" },
                    { 10, "beatae" },
                    { 11, "provident" },
                    { 12, "consequatur" },
                    { 13, "veritatis" },
                    { 14, "est" },
                    { 15, "deserunt" },
                    { 16, "non" },
                    { 17, "illum" },
                    { 18, "voluptatum" },
                    { 19, "tempora" },
                    { 20, "eos" },
                    { 21, "id" },
                    { 22, "et" },
                    { 23, "cum" },
                    { 24, "illo" },
                    { 25, "maxime" },
                    { 26, "ut" },
                    { 27, "eveniet" },
                    { 28, "eum" },
                    { 29, "dolor" },
                    { 30, "sunt" },
                    { 31, "expedita" },
                    { 32, "sunt" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "provident" },
                    { 2, "quo" },
                    { 3, "eveniet" },
                    { 4, "dolores" },
                    { 5, "est" },
                    { 6, "deleniti" },
                    { 7, "autem" },
                    { 8, "vel" },
                    { 9, "nam" },
                    { 10, "sunt" },
                    { 11, "qui" },
                    { 12, "accusamus" },
                    { 13, "velit" },
                    { 14, "amet" },
                    { 15, "consectetur" },
                    { 16, "totam" },
                    { 17, "optio" },
                    { 18, "dolorum" },
                    { 19, "inventore" },
                    { 20, "incidunt" },
                    { 21, "odio" },
                    { 22, "ab" },
                    { 23, "vero" },
                    { 24, "aut" },
                    { 25, "eos" },
                    { 26, "sequi" },
                    { 27, "veritatis" },
                    { 28, "et" },
                    { 29, "temporibus" },
                    { 30, "eveniet" },
                    { 31, "ipsum" },
                    { 32, "praesentium" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Miles Lemke", "eos", "User", "Aubrey", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 2, "Haley Homenick", "quasi", "User", "Clemmie", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 3, "Ila Hammes", "recusandae", "Admin", "Toni", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 4, "Kaylin Kuhn", "accusantium", "Staff", "Stella", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 5, "Estel Klein", "culpa", "User", "Jayne", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 6, "Betsy Gutkowski", "aut", "User", "Filomena", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 7, "Jordyn Fisher", "in", "Staff", "Freddie", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 8, "Kasandra Labadie", "omnis", "Admin", "Oswaldo", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 9, "Zola Casper", "quo", "Staff", "Domenic", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 10, "Amaya Stoltenberg", "libero", "Staff", "Nasir", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 11, "Natasha Roob", "temporibus", "Admin", "Hester", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 12, "Breanna Orn", "tenetur", "User", "Harmon", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 13, "Elaina Heller", "numquam", "Admin", "Charity", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 14, "Zion Towne", "est", "Admin", "Oswald", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 15, "Renee Runolfsdottir", "temporibus", "User", "Noe", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) },
                    { 16, "Preston Schaefer", "voluptates", "Admin", "Odie", new DateOnly(2024, 11, 27), new DateOnly(2024, 11, 27) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "photoPath", "public_at", "publisher_id", "quantity", "rating", "remaining", "updated_at", "views" },
                values: new object[,]
                {
                    { 1, 21, new DateTime(2024, 11, 27, 14, 4, 0, 143, DateTimeKind.Local).AddTicks(9057), "Officia tempore omnis voluptatem. Tempora similique aut et accusantium officia consequatur omnis ducimus. Minus consequatur qui omnis et. Voluptatem consequatur perspiciatis vero quae nihil ut. Provident ratione quaerat molestiae eos.", 3, "Amet minima quibusdam reiciendis.", ".\\resources\\images\\poster.png", new DateOnly(2010, 10, 27), 25, 7, 0f, 2, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(950), 0 },
                    { 2, 29, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(1644), "Dolor dolorem tempore omnis et corrupti consequatur rerum iusto harum. Tempora occaecati alias ducimus. Vitae fuga asperiores rem sint sed velit delectus facere soluta. Temporibus ut sunt non saepe. Eius sint autem voluptates aut veniam sint quod ut.", 25, "Molestiae unde et. Quia est labore voluptas laboriosam non. Dignissimos odio explicabo atque itaque ipsum aut magni at.", ".\\resources\\images\\poster.png", new DateOnly(2000, 6, 3), 32, 8, 0f, 2, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(1960), 0 },
                    { 3, 10, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(1975), "Vitae repellendus exercitationem et. Quia accusamus quia perspiciatis corrupti fuga. Reiciendis et est dolorem optio qui sapiente dicta error. Magnam quis ab et tenetur quo saepe omnis eum necessitatibus. Molestiae ut sint tempora.", 27, "In quas earum iusto dolores voluptas sunt. Nemo et saepe omnis dignissimos qui. Quae non natus assumenda natus. Vero voluptatem quas est molestiae nemo aut deleniti vero.", ".\\resources\\images\\poster.png", new DateOnly(2003, 6, 25), 2, 8, 0f, 4, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(2164), 0 },
                    { 4, 13, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(2177), "Est laboriosam quo consequatur eveniet deleniti inventore et facere voluptatem. Veritatis modi voluptates quidem consectetur vel maxime. Autem quidem rerum qui iste perferendis.", 14, "Eos velit omnis voluptas voluptatem nam hic dolores. Totam consequuntur qui voluptatem et consequatur. Et et placeat. Quis et pariatur modi corrupti tempora. Qui accusamus sunt consequatur officiis. Quia quos dignissimos dignissimos sed nostrum voluptas harum iusto ipsa.", ".\\resources\\images\\poster.png", new DateOnly(2013, 3, 22), 17, 7, 0f, 2, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(2377), 0 },
                    { 5, 29, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(2390), "Ut aut enim totam quam. Veritatis voluptas et error non enim quis. Minima error accusantium debitis perspiciatis eum est eum.", 15, "totam", ".\\resources\\images\\poster.png", new DateOnly(2021, 12, 26), 19, 5, 0f, 4, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(2482), 0 },
                    { 6, 21, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(2500), "Dolorem blanditiis qui in assumenda qui rem aut et aut. Voluptatem dolore porro voluptatem occaecati blanditiis est fuga rem. Dolorum accusamus eum. Earum asperiores quod fugit enim expedita. Velit et eum at.", 29, "autem", ".\\resources\\images\\poster.png", new DateOnly(2023, 9, 16), 18, 10, 0f, 5, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(2686), 0 },
                    { 7, 11, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(2703), "Error est itaque voluptatem deleniti veniam perferendis suscipit. A repudiandae laboriosam totam nihil ratione. Unde ab quidem qui magnam molestias ab.", 32, "ipsam", ".\\resources\\images\\poster.png", new DateOnly(2003, 11, 6), 15, 5, 0f, 5, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(2833), 0 },
                    { 8, 10, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(2851), "Veritatis est et tempore blanditiis consequatur consequatur et ex. Dolorum non porro et quo. Hic est facilis autem accusamus eos qui consequuntur. Adipisci eaque iste voluptatem porro. Enim repellat enim voluptates. Quo dolores ullam laborum.", 26, "Eveniet officiis molestiae dolores soluta rem deserunt dolorum natus et. Dolore perferendis qui modi. Corrupti quasi illo.", ".\\resources\\images\\poster.png", new DateOnly(2001, 7, 16), 22, 9, 0f, 5, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3014), 0 },
                    { 9, 24, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3025), "Aut modi sint quidem incidunt ab iste nostrum. Quasi molestiae officiis officia deleniti. Itaque delectus rem tempora est necessitatibus ea eaque et. Nihil ut natus sunt nesciunt.", 24, "Voluptatem quis porro molestiae enim.\nAsperiores enim accusamus et nostrum voluptatum optio dolor sapiente impedit.\nPariatur voluptas vitae temporibus rerum similique.\nQui minima laborum voluptatibus.", ".\\resources\\images\\poster.png", new DateOnly(2017, 11, 24), 29, 9, 0f, 0, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3175), 0 },
                    { 10, 13, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3188), "Excepturi nulla repellendus saepe sit nulla et. Est quis est inventore culpa. Voluptatem esse unde quia nisi sit veniam voluptas minus et. Est rerum consectetur molestiae doloremque doloribus libero veniam odio doloribus. Dicta laborum omnis. Sed fuga quia vitae molestiae ad occaecati.", 1, "Eos assumenda voluptatum est vitae aut asperiores cum pariatur numquam.", ".\\resources\\images\\poster.png", new DateOnly(2007, 2, 13), 5, 5, 0f, 0, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3339), 0 },
                    { 11, 24, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3351), "Qui necessitatibus cum occaecati vel cum occaecati mollitia. Repudiandae voluptatibus corrupti nam fuga ducimus laudantium placeat impedit. Harum voluptatem aliquam eos. Beatae expedita voluptatem perferendis quis vel aut. Totam alias sed est nam nobis laboriosam accusamus quasi vero. Sed doloribus harum deserunt et dolor assumenda voluptatem alias omnis.", 5, "est", ".\\resources\\images\\poster.png", new DateOnly(2019, 4, 17), 10, 10, 0f, 2, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3501), 0 },
                    { 12, 9, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3514), "Soluta magnam sed soluta tempora at ut ut. Excepturi nihil qui voluptatem voluptatem. Pariatur exercitationem unde aut. Repellendus incidunt quis sit aut corrupti ab ipsam vero neque. Saepe mollitia ad iusto.", 20, "Sapiente rerum repellat illum sed iusto necessitatibus et nihil. Ratione fugiat non. Non beatae doloribus voluptas minima libero accusantium est.", ".\\resources\\images\\poster.png", new DateOnly(2000, 5, 4), 31, 8, 0f, 2, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3668), 0 },
                    { 13, 9, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3680), "Alias omnis consectetur recusandae dolorem autem praesentium occaecati. Doloribus expedita sunt laborum consectetur architecto id laboriosam eos enim. Facere impedit est dolor omnis quod et.", 10, "Consectetur quia fugiat rem numquam non aut vel. Et ipsa aut. Fugit eos qui modi enim quia omnis nobis.", ".\\resources\\images\\poster.png", new DateOnly(2022, 2, 13), 25, 6, 0f, 5, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3813), 0 },
                    { 14, 3, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3825), "Distinctio rerum officiis ducimus magnam velit sed sequi. Nihil omnis tempora totam omnis. Et eveniet ipsa nisi. Voluptatibus laborum est quaerat quae. Modi veritatis hic.", 11, "Aliquam non maxime et pariatur est voluptatem. Sit ut similique rerum atque. Pariatur id libero voluptatem et et aut. Non quaerat totam consequatur quas dolorum. Suscipit velit saepe quia labore voluptate.", ".\\resources\\images\\poster.png", new DateOnly(2003, 11, 25), 18, 10, 0f, 0, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(3994), 0 },
                    { 15, 22, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(4006), "Necessitatibus deserunt repellendus et unde. Ex vel repudiandae. Inventore dolorem reiciendis autem ea qui sit nam eum tempora. Deserunt exercitationem id mollitia iure quo magnam laudantium officia.", 8, "et", ".\\resources\\images\\poster.png", new DateOnly(2005, 6, 11), 17, 6, 0f, 5, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(4106), 0 },
                    { 16, 8, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(4117), "Id hic distinctio dignissimos. Corrupti fuga repellendus dolor laborum sit corrupti consequatur. Fugit ut magni. Qui quos non explicabo mollitia repudiandae. In laudantium commodi tempora. Fugit error dolore et animi soluta et ut quo id.", 23, "Eum beatae vel occaecati eaque doloremque quo.", ".\\resources\\images\\poster.png", new DateOnly(2001, 4, 21), 9, 10, 0f, 2, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(4245), 0 },
                    { 17, 5, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(4258), "Autem error fugit qui dignissimos. Sed molestiae corrupti voluptatem eum architecto quis. Enim tempora facilis. Beatae harum ex nostrum enim laboriosam hic facere. Accusamus nostrum aut rerum ut molestiae.", 31, "Eos accusamus nemo accusamus iusto tenetur consequatur aspernatur praesentium sed. Fugit iusto quae quae perspiciatis et facere qui. Exercitationem labore iusto id perferendis dolores soluta fugiat deserunt a.", ".\\resources\\images\\poster.png", new DateOnly(1999, 1, 28), 6, 8, 0f, 3, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(4528), 0 },
                    { 18, 17, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(4541), "Omnis quia veritatis rerum ipsam. Ipsa esse ullam et aut exercitationem voluptatem numquam modi incidunt. Consequatur molestiae molestiae doloribus. Sit distinctio veniam quos iste vel.", 32, "Neque doloribus ut delectus repellat eveniet in nostrum commodi ullam.\nEst consequatur quas eum nihil.\nRepellat quod veritatis eos facere dolorem voluptas temporibus alias voluptas.\nUt dolorem animi porro pariatur dolorem veritatis.", ".\\resources\\images\\poster.png", new DateOnly(2003, 12, 4), 16, 9, 0f, 4, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(4701), 0 },
                    { 19, 6, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(4712), "Est voluptatum eligendi corporis laboriosam eum sunt omnis autem. Sint iste voluptatibus ut odit perferendis tenetur consequatur. Consequuntur voluptatem numquam dolore vel optio. Qui laborum sed. Quis veniam et sed vel et quo consequuntur architecto. Voluptas et sunt numquam doloribus aut.", 31, "Rerum sequi omnis consequatur.\nMinima quod ipsum debitis eos cumque et placeat.\nVoluptatem nihil perferendis nulla nihil quis quis dolorem qui.\nCupiditate et sit iure eveniet dolor.", ".\\resources\\images\\poster.png", new DateOnly(2011, 1, 13), 32, 6, 0f, 3, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(4901), 0 },
                    { 20, 24, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(4914), "Rem quae labore nemo fugiat deleniti maxime id voluptatem reiciendis. Omnis debitis est. Labore corrupti magni. Neque unde magnam tempore fugit explicabo nisi et vel. Expedita pariatur illo.", 2, "Vel totam et itaque sunt earum sed tempore.", ".\\resources\\images\\poster.png", new DateOnly(2010, 10, 26), 7, 9, 0f, 2, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5027), 0 },
                    { 21, 8, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5038), "Consequatur est rem aut. In voluptas dolor. Reprehenderit architecto illo. Ut ducimus quidem et excepturi. Excepturi rerum illo. Sit suscipit natus ut et maxime beatae.", 29, "Temporibus dolores inventore dignissimos et in excepturi. Perspiciatis est quam amet quasi nostrum. Cum perferendis aspernatur amet fugiat. Omnis officia adipisci sit qui nostrum quae voluptatem. Delectus repudiandae aliquam natus.", ".\\resources\\images\\poster.png", new DateOnly(2020, 11, 16), 17, 7, 0f, 0, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5209), 0 },
                    { 22, 9, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5221), "Impedit doloremque modi numquam dicta deserunt molestias et fuga. Esse at modi doloribus doloremque aut quam. Qui magni saepe eum iusto cum.", 23, "Repellendus et debitis laboriosam quia beatae et sit ut occaecati. At beatae error velit sed exercitationem. Quas necessitatibus praesentium et vitae iusto ut omnis est quo. Qui sint accusamus laboriosam eveniet consequuntur est occaecati illum illo. Nostrum sit dignissimos.", ".\\resources\\images\\poster.png", new DateOnly(2015, 11, 3), 19, 8, 0f, 4, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5388), 0 },
                    { 23, 15, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5401), "Quia autem voluptatem quae. Molestiae consectetur quos mollitia dolor sint. Est eos aut voluptatem quidem rerum. Labore vel numquam porro.", 12, "Voluptatum consectetur rem voluptatem.\nOmnis illo illo.\nFugit molestias quisquam numquam laboriosam recusandae qui consequuntur.\nCum rerum quisquam eum nesciunt.\nFacilis quos veniam sequi et dolorem dolorum.\nExplicabo animi laboriosam omnis dolores non porro.", ".\\resources\\images\\poster.png", new DateOnly(2024, 9, 15), 24, 6, 0f, 0, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5562), 0 },
                    { 24, 14, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5574), "Ex consectetur nobis tenetur est. Atque consectetur quis ut. Tempore et qui et itaque nostrum odit ullam deleniti. Doloribus assumenda adipisci. Eaque omnis est ea. Culpa expedita voluptatem totam.", 22, "odio", ".\\resources\\images\\poster.png", new DateOnly(2019, 10, 1), 5, 6, 0f, 1, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5680), 0 },
                    { 25, 8, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5693), "Repellat quis quam et nihil veniam iusto et ut eos. Accusantium et magni non tempora ut sunt ea ratione aut. Asperiores molestias ipsam aut et velit aut eligendi impedit.", 11, "Dolor illo et.", ".\\resources\\images\\poster.png", new DateOnly(2000, 11, 28), 32, 7, 0f, 3, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5806), 0 },
                    { 26, 23, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5820), "Sit id molestias dolores error. Unde esse veniam. Molestiae perferendis quaerat excepturi vel. Saepe vel sunt alias quis fugiat velit rerum repellendus.", 30, "Officia consequatur cumque. Aliquid itaque voluptatem perspiciatis. Saepe omnis quia. Adipisci velit dignissimos fuga. Iure eaque occaecati sapiente. Aut et quas expedita facilis sed.", ".\\resources\\images\\poster.png", new DateOnly(2004, 8, 16), 21, 6, 0f, 2, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5973), 0 },
                    { 27, 8, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(5986), "Vel mollitia nisi corporis dolorem ipsa ea. Dolores itaque dolorem qui. Atque quo veritatis cumque rerum minus rerum placeat odit quasi. Alias fugiat ut.", 18, "Quidem praesentium ut hic est.\nRatione cumque reprehenderit commodi perspiciatis blanditiis.\nOmnis ut aut illum quia omnis nemo architecto sapiente iusto.", ".\\resources\\images\\poster.png", new DateOnly(2023, 3, 18), 28, 6, 0f, 3, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(6128), 0 },
                    { 28, 11, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(6141), "Adipisci et magnam perspiciatis quod. Numquam ex eaque eius temporibus. Vero mollitia blanditiis praesentium hic ea qui aut. Accusamus sunt laudantium dicta. Placeat omnis qui assumenda voluptatem voluptatum natus consequatur blanditiis. Non libero qui praesentium suscipit.", 6, "Odio tempora ut sit non aut.\nUt eius doloribus.\nVoluptas nam aspernatur omnis quo illum repellendus alias aut.\nMagni sed et accusantium sit.\nMollitia autem consequuntur maxime ea maxime sint quas eos voluptatem.\nConsequuntur ad et maiores quidem quis.", ".\\resources\\images\\poster.png", new DateOnly(2000, 9, 12), 4, 6, 0f, 0, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(6353), 0 },
                    { 29, 21, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(6367), "Dignissimos illo ea libero voluptatum id qui amet. Incidunt voluptates animi. Soluta aspernatur sed nam quas possimus velit accusantium neque molestiae. Neque illum est quasi et doloremque iure molestiae sed.", 4, "Molestiae aut iste rerum iste ipsam mollitia saepe.\nCupiditate aspernatur dolores cumque molestiae exercitationem occaecati ipsa natus reprehenderit.\nUllam aliquid perspiciatis dolore voluptatem.\nIllum aut in doloribus sunt provident.\nSequi ut facere amet repellat voluptatibus qui veniam.", ".\\resources\\images\\poster.png", new DateOnly(2002, 4, 17), 19, 6, 0f, 2, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(6561), 0 },
                    { 30, 16, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(6576), "Vel enim nesciunt voluptas illum nemo. Similique dolorem et ipsum pariatur. Porro deserunt porro aut ducimus incidunt facilis aut dolorum impedit. Consectetur nobis ut harum natus at ullam qui. Earum voluptate delectus aspernatur omnis dicta consequatur nulla eos. Animi quas maxime sint quia.", 22, "Rerum sed aut excepturi eligendi.", ".\\resources\\images\\poster.png", new DateOnly(1999, 4, 17), 15, 7, 0f, 1, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(6721), 0 },
                    { 31, 18, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(6736), "Voluptas laborum temporibus totam error praesentium necessitatibus. Harum aut eaque quam amet porro in. Voluptatem recusandae aut aut blanditiis. Deleniti nostrum aut incidunt qui quo nobis maxime. Corporis enim fuga ut.", 7, "Ipsa molestiae neque et occaecati.\nQuod et nostrum.\nPlaceat officia quod dolor minus itaque.", ".\\resources\\images\\poster.png", new DateOnly(2009, 6, 10), 9, 6, 0f, 1, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(6883), 0 },
                    { 32, 18, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(6897), "Aut natus temporibus minima architecto. Et illum laudantium accusantium repellendus quod autem tempore. Consequatur dolorem atque distinctio a. Quia impedit illum reiciendis recusandae in quia esse ea ratione. Quae enim consequatur ut quidem eum unde libero quae. Doloremque qui dolore deleniti non.", 25, "Odit quia quae saepe illum harum et ut.\nMinima repellendus quam rerum tempore quo dicta necessitatibus impedit deleniti.", ".\\resources\\images\\poster.png", new DateOnly(2010, 1, 13), 30, 5, 0f, 1, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7068), 0 },
                    { 33, 30, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7081), "Quibusdam mollitia id error esse. Veritatis dolore distinctio repellat. Aut sit nam. Quae nesciunt architecto repudiandae.", 23, "Fugiat fuga dolorem tempore molestias inventore.", ".\\resources\\images\\poster.png", new DateOnly(2006, 7, 24), 6, 9, 0f, 5, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7171), 0 },
                    { 34, 32, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7189), "Vero atque at doloribus ab accusantium tempore voluptatem. Modi quo eveniet illo. Quibusdam occaecati sint qui. Quae id ut earum quos.", 17, "ratione", ".\\resources\\images\\poster.png", new DateOnly(2019, 4, 14), 18, 8, 0f, 4, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7277), 0 },
                    { 35, 18, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7291), "Nihil vel rerum veniam deserunt vel id architecto. Doloremque quo voluptates eius voluptatum. Rerum ut omnis esse ut facilis occaecati. Qui reiciendis vero autem atque. Tempora atque necessitatibus similique aperiam voluptatem harum.", 19, "vero", ".\\resources\\images\\poster.png", new DateOnly(2010, 3, 3), 20, 7, 0f, 5, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7412), 0 },
                    { 36, 28, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7425), "Est qui expedita autem deserunt enim illum. Perspiciatis fugit quidem sed. Dolorem et nostrum culpa iusto est sint.", 10, "Et reprehenderit rerum aut hic sit dignissimos temporibus.\nDolores et et.\nSaepe sequi voluptatem tenetur debitis mollitia et excepturi qui aut.\nCommodi saepe cupiditate.", ".\\resources\\images\\poster.png", new DateOnly(2001, 10, 8), 13, 6, 0f, 5, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7565), 0 },
                    { 37, 31, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7578), "Corporis et quasi laborum. Et voluptate ipsam error soluta sed expedita. Maxime totam explicabo soluta et repellat. Ipsam cumque nobis quasi deserunt. Quis incidunt et omnis id unde est.", 6, "Tempora totam eum consequatur earum laborum aut.\nIncidunt voluptatem enim.\nPossimus sit dolorem aliquid dolorum et iusto ullam eligendi accusamus.\nSunt minus odit nemo labore nostrum sit molestiae.\nEx eos quasi.", ".\\resources\\images\\poster.png", new DateOnly(2012, 12, 14), 3, 8, 0f, 2, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7755), 0 },
                    { 38, 16, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7769), "Illo qui excepturi enim quia. Rerum qui architecto iure sit est voluptates. Reiciendis omnis expedita natus dignissimos dolore illum rerum. Sed molestiae dolorem voluptatibus cum molestias est enim qui asperiores. Unde facere sit molestias. Hic dolores qui quae.", 22, "Reprehenderit exercitationem enim.\nAspernatur beatae beatae.\nVelit dolores nihil quo et odit eaque placeat odit numquam.\nVoluptate voluptatem ut quia magnam qui sed sed quis adipisci.\nRerum quis vel est eos facere occaecati.", ".\\resources\\images\\poster.png", new DateOnly(2003, 3, 27), 2, 5, 0f, 0, new DateTime(2024, 11, 27, 14, 4, 0, 144, DateTimeKind.Local).AddTicks(7966), 0 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBook",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 35, 4 },
                    { 36, 4 }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 11, "Completed", 12, new DateTime(2024, 11, 27, 2, 54, 26, 975, DateTimeKind.Local).AddTicks(3918), new DateTime(2024, 12, 3, 3, 7, 2, 303, DateTimeKind.Local).AddTicks(1027), new DateTime(2024, 11, 26, 3, 7, 2, 303, DateTimeKind.Local).AddTicks(1027), new DateTime(2024, 11, 24, 21, 58, 48, 450, DateTimeKind.Local).AddTicks(5295) },
                    { 2, 3, "Canceled", 5, null, null, new DateTime(2024, 11, 22, 21, 55, 8, 305, DateTimeKind.Local).AddTicks(110), null },
                    { 3, 30, "Canceled", 7, null, null, new DateTime(2024, 11, 27, 8, 13, 52, 555, DateTimeKind.Local).AddTicks(978), null },
                    { 4, 34, "Borrowed", 1, new DateTime(2024, 11, 27, 4, 51, 53, 416, DateTimeKind.Local).AddTicks(280), new DateTime(2024, 12, 1, 10, 45, 44, 885, DateTimeKind.Local).AddTicks(6327), new DateTime(2024, 11, 24, 10, 45, 44, 885, DateTimeKind.Local).AddTicks(6327), null },
                    { 5, 27, "Completed", 13, new DateTime(2024, 11, 23, 19, 25, 40, 244, DateTimeKind.Local).AddTicks(6582), new DateTime(2024, 12, 4, 8, 37, 54, 92, DateTimeKind.Local).AddTicks(3848), new DateTime(2024, 11, 27, 8, 37, 54, 92, DateTimeKind.Local).AddTicks(3848), new DateTime(2024, 11, 27, 9, 19, 30, 881, DateTimeKind.Local).AddTicks(5958) },
                    { 6, 13, "Borrowed", 12, new DateTime(2024, 11, 26, 0, 32, 36, 337, DateTimeKind.Local).AddTicks(3283), new DateTime(2024, 11, 30, 14, 34, 45, 362, DateTimeKind.Local).AddTicks(9325), new DateTime(2024, 11, 23, 14, 34, 45, 362, DateTimeKind.Local).AddTicks(9325), null },
                    { 7, 6, "Canceled", 1, null, null, new DateTime(2024, 11, 26, 4, 55, 34, 970, DateTimeKind.Local).AddTicks(5424), null },
                    { 8, 1, "Canceled", 6, null, null, new DateTime(2024, 11, 26, 14, 59, 30, 163, DateTimeKind.Local).AddTicks(8900), null },
                    { 9, 4, "Completed", 5, new DateTime(2024, 11, 23, 16, 25, 9, 474, DateTimeKind.Local).AddTicks(4630), new DateTime(2024, 11, 29, 2, 24, 30, 97, DateTimeKind.Local).AddTicks(4641), new DateTime(2024, 11, 22, 2, 24, 30, 97, DateTimeKind.Local).AddTicks(4641), new DateTime(2024, 11, 25, 22, 59, 0, 961, DateTimeKind.Local).AddTicks(4713) },
                    { 10, 3, "Canceled", 15, null, null, new DateTime(2024, 11, 27, 7, 40, 26, 86, DateTimeKind.Local).AddTicks(368), null },
                    { 11, 7, "Completed", 2, new DateTime(2024, 11, 27, 12, 52, 44, 811, DateTimeKind.Local).AddTicks(5579), new DateTime(2024, 11, 30, 19, 15, 14, 69, DateTimeKind.Local).AddTicks(7213), new DateTime(2024, 11, 23, 19, 15, 14, 69, DateTimeKind.Local).AddTicks(7213), new DateTime(2024, 11, 25, 14, 24, 6, 713, DateTimeKind.Local).AddTicks(1627) },
                    { 12, 38, "Completed", 11, new DateTime(2024, 11, 25, 19, 47, 49, 34, DateTimeKind.Local).AddTicks(8355), new DateTime(2024, 12, 2, 14, 32, 10, 61, DateTimeKind.Local).AddTicks(3570), new DateTime(2024, 11, 25, 14, 32, 10, 61, DateTimeKind.Local).AddTicks(3570), new DateTime(2024, 11, 25, 4, 20, 20, 402, DateTimeKind.Local).AddTicks(9813) },
                    { 13, 30, "Borrowed", 11, new DateTime(2024, 11, 24, 16, 40, 52, 568, DateTimeKind.Local).AddTicks(2682), new DateTime(2024, 12, 4, 13, 28, 18, 287, DateTimeKind.Local).AddTicks(8030), new DateTime(2024, 11, 27, 13, 28, 18, 287, DateTimeKind.Local).AddTicks(8030), null },
                    { 14, 10, "Pending", 12, null, null, new DateTime(2024, 11, 27, 10, 51, 3, 985, DateTimeKind.Local).AddTicks(5164), null },
                    { 15, 16, "Canceled", 3, null, null, new DateTime(2024, 11, 26, 7, 46, 24, 922, DateTimeKind.Local).AddTicks(6889), null },
                    { 16, 28, "Completed", 10, new DateTime(2024, 11, 25, 22, 15, 57, 837, DateTimeKind.Local).AddTicks(8749), new DateTime(2024, 12, 3, 19, 52, 6, 849, DateTimeKind.Local).AddTicks(9461), new DateTime(2024, 11, 26, 19, 52, 6, 849, DateTimeKind.Local).AddTicks(9461), new DateTime(2024, 11, 25, 22, 8, 5, 868, DateTimeKind.Local).AddTicks(416) },
                    { 17, 26, "Canceled", 8, null, null, new DateTime(2024, 11, 24, 10, 58, 21, 770, DateTimeKind.Local).AddTicks(2773), null },
                    { 18, 4, "Borrowed", 11, new DateTime(2024, 11, 26, 2, 40, 48, 533, DateTimeKind.Local).AddTicks(7397), new DateTime(2024, 12, 1, 3, 48, 4, 325, DateTimeKind.Local).AddTicks(7374), new DateTime(2024, 11, 24, 3, 48, 4, 325, DateTimeKind.Local).AddTicks(7374), null },
                    { 19, 25, "Canceled", 16, null, null, new DateTime(2024, 11, 24, 10, 21, 46, 667, DateTimeKind.Local).AddTicks(1031), null },
                    { 20, 8, "Borrowed", 13, new DateTime(2024, 11, 24, 23, 1, 32, 823, DateTimeKind.Local).AddTicks(7984), new DateTime(2024, 12, 2, 6, 48, 28, 760, DateTimeKind.Local).AddTicks(2351), new DateTime(2024, 11, 25, 6, 48, 28, 760, DateTimeKind.Local).AddTicks(2351), null },
                    { 21, 5, "Canceled", 12, null, null, new DateTime(2024, 11, 23, 1, 57, 41, 623, DateTimeKind.Local).AddTicks(6600), null },
                    { 22, 18, "Borrowed", 14, new DateTime(2024, 11, 23, 20, 40, 40, 795, DateTimeKind.Local).AddTicks(8017), new DateTime(2024, 12, 4, 6, 7, 43, 861, DateTimeKind.Local).AddTicks(1189), new DateTime(2024, 11, 27, 6, 7, 43, 861, DateTimeKind.Local).AddTicks(1189), null },
                    { 23, 25, "Completed", 3, new DateTime(2024, 11, 27, 2, 8, 11, 765, DateTimeKind.Local).AddTicks(2899), new DateTime(2024, 11, 29, 22, 10, 46, 751, DateTimeKind.Local).AddTicks(615), new DateTime(2024, 11, 22, 22, 10, 46, 751, DateTimeKind.Local).AddTicks(615), new DateTime(2024, 11, 26, 14, 16, 26, 505, DateTimeKind.Local).AddTicks(61) },
                    { 24, 35, "Completed", 2, new DateTime(2024, 11, 21, 18, 7, 12, 266, DateTimeKind.Local).AddTicks(4002), new DateTime(2024, 11, 28, 0, 40, 57, 654, DateTimeKind.Local).AddTicks(2629), new DateTime(2024, 11, 21, 0, 40, 57, 654, DateTimeKind.Local).AddTicks(2629), new DateTime(2024, 11, 27, 8, 42, 9, 864, DateTimeKind.Local).AddTicks(6146) },
                    { 25, 3, "Pending", 9, null, null, new DateTime(2024, 11, 23, 18, 40, 55, 654, DateTimeKind.Local).AddTicks(9274), null },
                    { 26, 31, "Pending", 9, null, null, new DateTime(2024, 11, 22, 22, 2, 26, 468, DateTimeKind.Local).AddTicks(5519), null },
                    { 27, 34, "Borrowed", 9, new DateTime(2024, 11, 22, 0, 56, 18, 307, DateTimeKind.Local).AddTicks(2799), new DateTime(2024, 11, 28, 13, 55, 8, 150, DateTimeKind.Local).AddTicks(9925), new DateTime(2024, 11, 21, 13, 55, 8, 150, DateTimeKind.Local).AddTicks(9925), null },
                    { 28, 16, "Pending", 16, null, null, new DateTime(2024, 11, 24, 21, 14, 32, 260, DateTimeKind.Local).AddTicks(1737), null },
                    { 29, 5, "Canceled", 7, null, null, new DateTime(2024, 11, 23, 1, 49, 29, 738, DateTimeKind.Local).AddTicks(9313), null },
                    { 30, 29, "Borrowed", 12, new DateTime(2024, 11, 22, 18, 42, 19, 84, DateTimeKind.Local).AddTicks(9382), new DateTime(2024, 12, 3, 9, 55, 20, 513, DateTimeKind.Local).AddTicks(889), new DateTime(2024, 11, 26, 9, 55, 20, 513, DateTimeKind.Local).AddTicks(889), null },
                    { 31, 13, "Completed", 11, new DateTime(2024, 11, 21, 16, 59, 8, 83, DateTimeKind.Local).AddTicks(1468), new DateTime(2024, 11, 29, 1, 32, 52, 263, DateTimeKind.Local).AddTicks(1975), new DateTime(2024, 11, 22, 1, 32, 52, 263, DateTimeKind.Local).AddTicks(1975), new DateTime(2024, 11, 24, 16, 33, 25, 574, DateTimeKind.Local).AddTicks(4815) },
                    { 32, 9, "Canceled", 12, null, null, new DateTime(2024, 11, 24, 11, 17, 14, 511, DateTimeKind.Local).AddTicks(5981), null },
                    { 33, 7, "Borrowed", 13, new DateTime(2024, 11, 27, 11, 55, 25, 230, DateTimeKind.Local).AddTicks(6819), new DateTime(2024, 12, 4, 1, 10, 27, 408, DateTimeKind.Local).AddTicks(5010), new DateTime(2024, 11, 27, 1, 10, 27, 408, DateTimeKind.Local).AddTicks(5010), null },
                    { 34, 33, "Borrowed", 3, new DateTime(2024, 11, 22, 15, 36, 46, 71, DateTimeKind.Local).AddTicks(3490), new DateTime(2024, 12, 1, 4, 0, 14, 43, DateTimeKind.Local).AddTicks(2032), new DateTime(2024, 11, 24, 4, 0, 14, 43, DateTimeKind.Local).AddTicks(2032), null },
                    { 35, 21, "Pending", 2, null, null, new DateTime(2024, 11, 25, 2, 34, 13, 400, DateTimeKind.Local).AddTicks(9891), null },
                    { 36, 38, "Completed", 5, new DateTime(2024, 11, 24, 9, 4, 36, 871, DateTimeKind.Local).AddTicks(6635), new DateTime(2024, 11, 28, 1, 19, 9, 428, DateTimeKind.Local).AddTicks(3869), new DateTime(2024, 11, 21, 1, 19, 9, 428, DateTimeKind.Local).AddTicks(3869), new DateTime(2024, 11, 26, 3, 41, 0, 28, DateTimeKind.Local).AddTicks(5544) },
                    { 37, 1, "Borrowed", 16, new DateTime(2024, 11, 24, 18, 33, 38, 265, DateTimeKind.Local).AddTicks(8297), new DateTime(2024, 12, 1, 0, 1, 48, 324, DateTimeKind.Local).AddTicks(8772), new DateTime(2024, 11, 24, 0, 1, 48, 324, DateTimeKind.Local).AddTicks(8772), null },
                    { 38, 38, "Pending", 1, null, null, new DateTime(2024, 11, 22, 20, 42, 15, 250, DateTimeKind.Local).AddTicks(871), null },
                    { 39, 8, "Borrowed", 10, new DateTime(2024, 11, 26, 20, 57, 56, 339, DateTimeKind.Local).AddTicks(2290), new DateTime(2024, 11, 30, 12, 46, 47, 652, DateTimeKind.Local).AddTicks(4739), new DateTime(2024, 11, 23, 12, 46, 47, 652, DateTimeKind.Local).AddTicks(4739), null },
                    { 40, 11, "Completed", 2, new DateTime(2024, 11, 26, 12, 35, 54, 849, DateTimeKind.Local).AddTicks(8523), new DateTime(2024, 12, 4, 2, 23, 1, 514, DateTimeKind.Local).AddTicks(5687), new DateTime(2024, 11, 27, 2, 23, 1, 514, DateTimeKind.Local).AddTicks(5687), new DateTime(2024, 11, 27, 2, 8, 43, 137, DateTimeKind.Local).AddTicks(570) }
                });

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
                name: "IX_Books_publisher_id",
                table: "Books",
                column: "publisher_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesBook_CategoryId",
                table: "CategoriesBook",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
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
                name: "CategoriesBook");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Register");

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

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
