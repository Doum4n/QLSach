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
                name: "StorageLocations",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocations", x => x.Name);
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
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "varchar(10)", nullable: false)
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
                    name = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    genre_id = table.Column<int>(type: "int", nullable: false),
                    publisher_id = table.Column<int>(type: "int", nullable: false),
                    photoPath = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rating = table.Column<float>(type: "float", nullable: false),
                    storage_location = table.Column<string>(type: "nvarchar(40)", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Books_StorageLocations_storage_location",
                        column: x => x.storage_location,
                        principalTable: "StorageLocations",
                        principalColumn: "Name",
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
                    { 1, "Eius officiis harum sed corrupti sapiente illo est.", "Deven" },
                    { 2, "Repudiandae iusto qui sit vero odit in.", "Sylvan" },
                    { 3, "Mollitia corrupti aut porro doloremque assumenda dolores dolores voluptas sint.", "Jillian" },
                    { 4, "Sunt magnam et voluptatem.", "Wilbert" },
                    { 5, "Dolorem voluptas et.", "Keegan" },
                    { 6, "Beatae dolore consectetur.", "Sonya" },
                    { 7, "Vero ut cupiditate.", "Valentine" },
                    { 8, "Sed temporibus nobis eligendi eum et at ipsum quos aspernatur.", "Minnie" },
                    { 9, "Totam alias voluptatibus aut adipisci fuga occaecati maxime.", "Halie" },
                    { 10, "Quaerat eveniet impedit provident quas.", "Breanne" },
                    { 11, "Sint asperiores neque cumque.", "Brycen" },
                    { 12, "Et dolores esse veritatis quaerat.", "Nat" },
                    { 13, "Commodi odit quae ipsum impedit consequuntur.", "Fabian" },
                    { 14, "Laudantium aut sit ipsam doloribus ab rerum excepturi mollitia.", "Etha" },
                    { 15, "Odio cumque itaque porro non nemo.", "Jazmin" },
                    { 16, "Nobis dolor dolor.", "Noemie" },
                    { 17, "Consectetur ad est est quo praesentium esse voluptatum.", "Noemi" },
                    { 18, "Inventore velit excepturi ipsum aliquam.", "Carlie" },
                    { 19, "Omnis fugiat tempore ea culpa dolore laborum sit.", "Muhammad" },
                    { 20, "Ex dolorum porro qui voluptatem.", "Lucile" },
                    { 21, "Tenetur non et commodi et ex rerum similique officia dolorem.", "Therese" },
                    { 22, "Doloribus nostrum et architecto adipisci.", "Buck" },
                    { 23, "Velit accusantium et aut ullam ipsum.", "Pasquale" },
                    { 24, "Laudantium beatae ut quisquam nihil.", "Howard" },
                    { 25, "In in numquam quo iure.", "Mohammed" },
                    { 26, "Provident in harum sunt ut qui voluptas vel.", "Estrella" },
                    { 27, "Maiores vel aliquid.", "Juvenal" },
                    { 28, "Et pariatur reiciendis.", "Katelynn" },
                    { 29, "Quo animi est.", "Eve" },
                    { 30, "Voluptatibus ut qui beatae.", "Adrianna" },
                    { 31, "Est molestiae libero.", "Merle" },
                    { 32, "Dolore rerum architecto modi sed minima laboriosam consequatur.", "Myrl" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Nulla nulla nemo modi eos ab a ea rem deleniti et et voluptatum vero ut quia non est animi sunt.", "qui", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 2, "Est adipisci officia facilis sed error facere fuga vitae magni est illum rem unde nulla suscipit tempora est quam blanditiis.", "et", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 3, "Sit qui reiciendis eos excepturi accusamus soluta repellendus nisi molestiae facilis commodi vel non quis voluptatum temporibus mollitia quia ut.", "fugiat", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 4, "Perferendis maiores et repellat fugit quis dicta perferendis recusandae cum nesciunt incidunt ab repellat est ut quis quia consequatur quam.", "est", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 5, "Odio quo pariatur eligendi repudiandae velit dolorem perferendis sit ut minus tempora autem minima qui sit voluptatem aut non earum.", "est", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "dignissimos" },
                    { 2, "molestiae" },
                    { 3, "fugiat" },
                    { 4, "et" },
                    { 5, "quasi" },
                    { 6, "ipsa" },
                    { 7, "nulla" },
                    { 8, "hic" },
                    { 9, "eveniet" },
                    { 10, "magni" },
                    { 11, "facere" },
                    { 12, "impedit" },
                    { 13, "et" },
                    { 14, "repudiandae" },
                    { 15, "et" },
                    { 16, "dolores" },
                    { 17, "deserunt" },
                    { 18, "repellendus" },
                    { 19, "rerum" },
                    { 20, "consequatur" },
                    { 21, "aut" },
                    { 22, "soluta" },
                    { 23, "sint" },
                    { 24, "omnis" },
                    { 25, "laudantium" },
                    { 26, "dolore" },
                    { 27, "perferendis" },
                    { 28, "saepe" },
                    { 29, "ex" },
                    { 30, "culpa" },
                    { 31, "quo" },
                    { 32, "quia" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "pariatur" },
                    { 2, "beatae" },
                    { 3, "impedit" },
                    { 4, "sapiente" },
                    { 5, "et" },
                    { 6, "natus" },
                    { 7, "porro" },
                    { 8, "dolores" },
                    { 9, "minima" },
                    { 10, "optio" },
                    { 11, "dolor" },
                    { 12, "aliquid" },
                    { 13, "sed" },
                    { 14, "est" },
                    { 15, "assumenda" },
                    { 16, "repellat" },
                    { 17, "quae" },
                    { 18, "sed" },
                    { 19, "itaque" },
                    { 20, "sed" },
                    { 21, "quidem" },
                    { 22, "architecto" },
                    { 23, "reprehenderit" },
                    { 24, "aut" },
                    { 25, "repellendus" },
                    { 26, "quasi" },
                    { 27, "laboriosam" },
                    { 28, "culpa" },
                    { 29, "voluptas" },
                    { 30, "qui" },
                    { 31, "sit" },
                    { 32, "sed" }
                });

            migrationBuilder.InsertData(
                table: "StorageLocations",
                columns: new[] { "Name", "Description" },
                values: new object[,]
                {
                    { "D4", "Suscipit velit qui natus excepturi officiis voluptas nostrum consequatur sed est minus dolorem maiores iusto laboriosam ipsam eius cum repudiandae." },
                    { "F5", "Sunt unde tempore omnis est id illum dignissimos accusantium minus laboriosam maiores a possimus maxime molestiae autem adipisci occaecati neque." },
                    { "L6", "Delectus quibusdam dolor voluptas repellendus quod in ea est optio voluptas nam a accusamus eaque odio repudiandae delectus maiores veritatis." },
                    { "T5", "Minus non exercitationem dolorem magni accusantium dolores iste voluptatibus quis recusandae ea perferendis dolor omnis rerum corporis voluptas dignissimos ullam." },
                    { "Y5", "Non commodi aspernatur tempore est adipisci aut hic laboriosam repellat qui saepe et beatae et ratione aspernatur doloremque at fugit." }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Gender", "Name", "Password", "Role", "UserName", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, 24, "Female", "Maurice Block", "ut", "Admin", "Naomi", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 2, 36, "Male", "Josue Reinger", "et", "Admin", "Monty", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 3, 37, "Male", "Noelia Considine", "pariatur", "Admin", "Gracie", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 4, 30, "Female", "Gussie Hudson", "qui", "User", "Yesenia", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 5, 55, "Male", "Melody Kihn", "dolorem", "User", "Vaughn", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 6, 53, "Female", "Magnolia Paucek", "voluptatem", "Staff", "Emely", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 7, 48, "Male", "June Schimmel", "ipsam", "Staff", "Emma", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 8, 59, "Female", "Howard Herman", "natus", "Staff", "Gennaro", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 9, 37, "Female", "Amy Carter", "est", "Staff", "Ruthe", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 10, 33, "Female", "Alexis Willms", "iusto", "Staff", "Breana", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 11, 46, "Other", "Valentine Gutkowski", "ipsum", "Staff", "Rory", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 12, 24, "Other", "Lois Schamberger", "dolorem", "Staff", "Norbert", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 13, 52, "Other", "Lon Gutmann", "quo", "Admin", "Toby", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 14, 43, "Other", "Pinkie Huel", "molestias", "Staff", "Winnifred", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 15, 49, "Other", "Edmund Emmerich", "dolor", "Staff", "Blaise", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 16, 29, "Male", "Margot Carroll", "occaecati", "User", "Hilario", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "photoPath", "public_at", "publisher_id", "quantity", "rating", "remaining", "storage_location", "updated_at", "views" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(2695), "Iure beatae enim vel commodi quia. Quod ut est et eius nam quo esse eius aut. Magni omnis occaecati molestias dolor. Accusamus voluptas officiis libero consequuntur maiores. Quia et consequatur.", 21, "consectetur", ".\\resources\\images\\poster.png", new DateOnly(2020, 6, 7), 7, 6, 0f, 1, "T5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(4701), 0 },
                    { 2, 30, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(5315), "Molestiae quod rerum debitis et amet alias vitae. Sed hic voluptatum mollitia quas. Magnam deserunt et quam suscipit inventore quasi cum voluptatem. Id unde dolor sit molestiae rem dolorem. Ipsum facilis dolorem officiis atque. Deleniti ut et non dolorum numquam rerum.", 10, "in", ".\\resources\\images\\poster.png", new DateOnly(2009, 1, 25), 11, 5, 0f, 3, "D4", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(5687), 0 },
                    { 3, 20, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(5702), "Quisquam vitae asperiores rerum voluptatem labore sint repellat esse sed. Velit at accusantium. Consequatur magni et adipisci corporis reprehenderit aspernatur fugiat inventore. Ea asperiores voluptatum vel qui nesciunt possimus. Voluptatem laborum aut molestiae fugiat nisi ipsam.", 11, "itaque", ".\\resources\\images\\poster.png", new DateOnly(2002, 10, 16), 17, 6, 0f, 2, "Y5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(5866), 0 },
                    { 4, 1, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(5878), "Velit voluptas iure neque deleniti in eveniet sit ut. Culpa aut inventore culpa eaque. Est libero et qui dignissimos et amet. Ut sequi aut. Aut laboriosam et harum reprehenderit cumque.", 12, "quod", ".\\resources\\images\\poster.png", new DateOnly(2023, 9, 3), 12, 5, 0f, 2, "F5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6003), 0 },
                    { 5, 7, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6017), "Illo itaque laborum. Dolorem dolorem est ut maiores autem dolorem nostrum. Vel qui suscipit qui aut. Quae occaecati est ab perspiciatis. Aut alias qui voluptas quo quo quo. Accusamus et cumque numquam numquam.", 32, "voluptatem", ".\\resources\\images\\poster.png", new DateOnly(2018, 5, 24), 30, 5, 0f, 2, "Y5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6182), 0 },
                    { 6, 26, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6195), "Quos dolores odio nostrum molestiae enim deserunt. Asperiores vel nobis autem est asperiores. Earum totam quia sapiente tempore sit amet earum. Id repudiandae et doloribus et aliquid est et ad sunt. Architecto aperiam soluta animi veritatis. Porro necessitatibus nobis ab eaque tempore ad ea voluptatem.", 32, "id", ".\\resources\\images\\poster.png", new DateOnly(2012, 12, 6), 19, 6, 0f, 3, "L6", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6334), 0 },
                    { 7, 23, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6346), "Vitae nam consequuntur qui quae ducimus et totam. Vero eligendi occaecati iure et assumenda. Nemo adipisci minima itaque.", 8, "esse", ".\\resources\\images\\poster.png", new DateOnly(2020, 12, 23), 27, 9, 0f, 0, "F5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6458), 0 },
                    { 8, 26, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6470), "Tempora voluptate dolore sapiente eius cupiditate dolorem excepturi et dolores. Fugit iure amet perspiciatis cum commodi omnis repudiandae placeat. Veniam et enim quia molestiae voluptatem ullam.", 9, "rerum", ".\\resources\\images\\poster.png", new DateOnly(2012, 2, 11), 14, 5, 0f, 1, "T5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6586), 0 },
                    { 9, 32, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6598), "Aliquam provident esse est facilis. Asperiores nobis tempore at qui corporis est. Ut nostrum non voluptas.", 8, "aut", ".\\resources\\images\\poster.png", new DateOnly(2021, 12, 7), 12, 6, 0f, 5, "D4", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6678), 0 },
                    { 10, 28, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6689), "Nisi tenetur quae quod quod voluptates soluta quae. Odio fugiat occaecati. Dolorem distinctio consequatur est velit dolorem omnis officia.", 24, "dolorem", ".\\resources\\images\\poster.png", new DateOnly(2023, 8, 4), 26, 8, 0f, 5, "Y5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6793), 0 },
                    { 11, 4, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6806), "Sint fuga quibusdam enim labore harum excepturi delectus. Soluta vel delectus magni. Explicabo maiores perferendis ipsa eligendi accusamus et laudantium fugit. Veniam dolor placeat quaerat voluptatem soluta modi maiores.", 31, "dolore", ".\\resources\\images\\poster.png", new DateOnly(2002, 8, 22), 32, 9, 0f, 2, "F5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6907), 0 },
                    { 12, 30, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(6919), "Tempora rem in quia tenetur deserunt amet ut ipsam. Quos quae aut qui repellendus. Eveniet et et perferendis. Illum ab atque. Soluta unde vel unde fugit officia rerum. Sit et placeat ea necessitatibus quo quasi veniam.", 5, "in", ".\\resources\\images\\poster.png", new DateOnly(2023, 6, 18), 29, 5, 0f, 0, "L6", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7062), 0 },
                    { 13, 32, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7074), "Eos omnis earum dolorum beatae corporis reiciendis praesentium ea. Voluptates ut et vel cupiditate veniam eos tempore voluptatem. Voluptatum nam sapiente dolorem eaque. Aspernatur ea eius temporibus possimus officiis explicabo. Libero est molestiae optio sunt sit et. Eos voluptate pariatur vitae nemo eos sunt dolorum accusamus.", 7, "et", ".\\resources\\images\\poster.png", new DateOnly(2017, 11, 9), 25, 10, 0f, 2, "Y5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7234), 0 },
                    { 14, 13, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7246), "Accusantium pariatur repellendus qui similique et. Autem non rerum velit doloremque. Amet sunt fugiat similique nihil. Deleniti nemo est qui ab cupiditate rerum. Sunt nihil consequuntur fugit suscipit quo pariatur atque nihil temporibus. Aut iure illo est in nihil.", 21, "eveniet", ".\\resources\\images\\poster.png", new DateOnly(2012, 3, 23), 12, 7, 0f, 3, "Y5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7395), 0 },
                    { 15, 29, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7406), "Molestias tenetur harum est error repellendus. Occaecati iste assumenda id ratione. Est nostrum recusandae odit laudantium molestiae eum saepe quia est.", 10, "sunt", ".\\resources\\images\\poster.png", new DateOnly(2018, 11, 24), 7, 7, 0f, 5, "L6", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7491), 0 },
                    { 16, 29, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7503), "Officia distinctio dolorem qui praesentium dolor sit voluptate aperiam sit. Et aliquid voluptatem architecto accusamus eveniet voluptas. Hic aspernatur excepturi id dolor veritatis esse tempore ut.", 26, "excepturi", ".\\resources\\images\\poster.png", new DateOnly(2015, 10, 30), 2, 10, 0f, 4, "F5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7608), 0 },
                    { 17, 21, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7620), "Ipsam mollitia voluptatem veritatis quod est reiciendis dolorum non. Et laboriosam et molestias qui. Aut modi autem explicabo odio ipsa quia. Architecto voluptas enim consequatur sed ad ullam adipisci earum. Cumque odit amet necessitatibus voluptatibus.", 30, "a", ".\\resources\\images\\poster.png", new DateOnly(2013, 9, 8), 11, 8, 0f, 1, "Y5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7769), 0 },
                    { 18, 26, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7782), "Atque exercitationem aut sapiente. Consequatur qui pariatur quia. Saepe sit dolor est blanditiis sed sit. Qui hic ut. Veniam et rerum. Excepturi possimus porro sint cupiditate fuga sit neque.", 23, "ab", ".\\resources\\images\\poster.png", new DateOnly(2004, 12, 22), 16, 7, 0f, 1, "Y5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7890), 0 },
                    { 19, 4, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(7932), "Aperiam maxime aut est perspiciatis quia amet. Dolorem omnis voluptatum nam amet molestiae facere consectetur autem ratione. Et porro ea sed maxime nesciunt debitis. Alias magni quam ad minima quam numquam voluptatem animi. Consequatur explicabo porro animi.", 22, "ad", ".\\resources\\images\\poster.png", new DateOnly(2016, 6, 10), 7, 7, 0f, 3, "L6", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8053), 0 },
                    { 20, 26, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8065), "Qui aut ea. Ut vel sapiente dolorum qui enim assumenda. Explicabo ea repellat velit. Rerum quia et rem.", 14, "adipisci", ".\\resources\\images\\poster.png", new DateOnly(2020, 8, 12), 5, 10, 0f, 5, "L6", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8176), 0 },
                    { 21, 16, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8210), "Enim aut itaque sint animi recusandae at dolor. Reprehenderit sit repellendus rem ut fugit quo laudantium laudantium. Autem ipsa aut nisi totam at. Ipsa eius fuga. Aperiam non veniam beatae vel laboriosam. Consequuntur et laudantium dolorum pariatur quia quisquam debitis quia impedit.", 19, "ea", ".\\resources\\images\\poster.png", new DateOnly(2019, 12, 11), 11, 8, 0f, 5, "F5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8365), 0 },
                    { 22, 12, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8377), "Nam dolor ad impedit mollitia qui aut ab iste sed. Est odio non saepe autem nisi in consequatur temporibus qui. Vitae quidem facilis sint id quisquam omnis sit consequatur. Ad veniam ut aut aliquam doloribus tenetur sed.", 14, "a", ".\\resources\\images\\poster.png", new DateOnly(2024, 10, 6), 27, 10, 0f, 2, "T5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8487), 0 },
                    { 23, 20, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8499), "Veniam debitis minus eos voluptas recusandae dolorum. Et in id ut voluptatem nulla qui et explicabo. Animi et quos in sunt.", 15, "sed", ".\\resources\\images\\poster.png", new DateOnly(2005, 10, 31), 24, 8, 0f, 3, "L6", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8618), 0 },
                    { 24, 20, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8630), "Qui necessitatibus provident qui quod ratione. Ipsum enim sunt possimus. In omnis omnis aliquam est eius sit placeat ea asperiores. Voluptatem quia sed occaecati. Maiores optio nulla.", 29, "fuga", ".\\resources\\images\\poster.png", new DateOnly(2013, 7, 6), 2, 6, 0f, 5, "F5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8753), 0 },
                    { 25, 5, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8765), "Aut quia mollitia sequi distinctio atque ab beatae ratione. Eligendi vel animi dolor architecto omnis beatae voluptatum ut at. Totam delectus possimus officiis cum inventore.", 30, "harum", ".\\resources\\images\\poster.png", new DateOnly(2007, 7, 26), 12, 6, 0f, 0, "T5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8857), 0 },
                    { 26, 30, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8871), "Pariatur laboriosam explicabo voluptas sint vel sequi pariatur cum. Quia est et dolorum illum eum ratione maiores. Voluptatem rem qui. Voluptatibus enim numquam voluptatem vero est et est.", 15, "similique", ".\\resources\\images\\poster.png", new DateOnly(2024, 2, 26), 23, 10, 0f, 0, "L6", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(8994), 0 },
                    { 27, 11, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9008), "Quas quis eos ut sit. Quis error cupiditate sit praesentium qui velit nulla sit. Alias voluptas laborum cum quis maiores accusantium consequatur. Ut eum ex hic quisquam aut. Ad molestiae et hic ex explicabo neque.", 12, "similique", ".\\resources\\images\\poster.png", new DateOnly(2002, 6, 21), 16, 7, 0f, 1, "Y5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9138), 0 },
                    { 28, 28, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9152), "Voluptas voluptas est quod quia mollitia adipisci. Exercitationem voluptates consequuntur debitis. Et sint nobis earum et qui. Eum placeat cum ipsa nostrum non beatae illo.", 19, "quae", ".\\resources\\images\\poster.png", new DateOnly(2016, 9, 3), 25, 7, 0f, 0, "F5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9247), 0 },
                    { 29, 20, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9260), "Dolorum eum consequatur. Atque dolore fuga et quasi iusto. Impedit fugit consequatur delectus.", 2, "aperiam", ".\\resources\\images\\poster.png", new DateOnly(2001, 9, 27), 12, 6, 0f, 0, "L6", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9364), 0 },
                    { 30, 18, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9377), "Adipisci culpa est. Nihil labore vitae sit libero quidem quo ut. Voluptatem in sit quia eos recusandae accusamus laudantium. A magni odio ipsa quasi quibusdam saepe.", 20, "natus", ".\\resources\\images\\poster.png", new DateOnly(2003, 10, 5), 15, 5, 0f, 3, "F5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9504), 0 },
                    { 31, 23, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9524), "Temporibus omnis voluptatum et et consequuntur rem explicabo facere dolores. Dolor non ut dignissimos. Saepe commodi earum ab ipsum labore ut quia eligendi cupiditate. Dolorem provident voluptatem amet eius esse qui maxime libero consequatur. Et et perferendis voluptas et nam aperiam tempore. Doloremque ullam magnam qui ullam.", 31, "voluptatum", ".\\resources\\images\\poster.png", new DateOnly(2006, 1, 3), 19, 9, 0f, 4, "Y5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9734), 0 },
                    { 32, 22, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9749), "Voluptatem animi accusamus corporis nobis sed. Voluptatem sunt tempora. Ex vel aut. Ratione et et.", 3, "eveniet", ".\\resources\\images\\poster.png", new DateOnly(2017, 3, 4), 16, 7, 0f, 3, "T5", new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9855), 0 },
                    { 33, 13, new DateTime(2024, 12, 1, 21, 38, 51, 962, DateTimeKind.Local).AddTicks(9869), "Sit doloribus dignissimos saepe accusamus minima in. Et eligendi qui quos cupiditate in odit numquam. Vel dignissimos vel non ipsa voluptatem omnis. Quis qui esse. Id facere ab dolorum ut perspiciatis illum esse aliquam. Pariatur illo dolores saepe reiciendis ipsam iure asperiores soluta.", 9, "recusandae", ".\\resources\\images\\poster.png", new DateOnly(2006, 9, 18), 5, 5, 0f, 1, "L6", new DateTime(2024, 12, 1, 21, 38, 51, 963, DateTimeKind.Local).AddTicks(180), 0 },
                    { 34, 4, new DateTime(2024, 12, 1, 21, 38, 51, 963, DateTimeKind.Local).AddTicks(195), "Non libero debitis laboriosam rerum sed deserunt consequuntur. Et animi quis eos non omnis quia. Eum vel aspernatur animi. Aliquid exercitationem alias molestiae iusto rerum ab et autem. Impedit ut et voluptas aut odio. Repellendus quia aut cupiditate animi officiis.", 17, "nesciunt", ".\\resources\\images\\poster.png", new DateOnly(2019, 1, 10), 22, 6, 0f, 2, "T5", new DateTime(2024, 12, 1, 21, 38, 51, 963, DateTimeKind.Local).AddTicks(322), 0 },
                    { 35, 19, new DateTime(2024, 12, 1, 21, 38, 51, 963, DateTimeKind.Local).AddTicks(336), "Sequi laudantium aut veniam. Ullam laboriosam sunt aut cumque optio minus harum fuga. Ut similique consequuntur nostrum quod ad consequatur. Doloribus vitae aliquam quae nesciunt voluptatum enim consequuntur omnis. Et harum omnis.", 32, "magni", ".\\resources\\images\\poster.png", new DateOnly(2008, 12, 18), 16, 10, 0f, 4, "L6", new DateTime(2024, 12, 1, 21, 38, 51, 963, DateTimeKind.Local).AddTicks(471), 0 },
                    { 36, 8, new DateTime(2024, 12, 1, 21, 38, 51, 963, DateTimeKind.Local).AddTicks(485), "Quibusdam et eum molestiae qui nemo deserunt voluptas. Et in distinctio reiciendis et velit. Delectus et quas aut voluptatem. Natus dolorem ea. Ut optio sed dolorem laudantium repellendus.", 27, "itaque", ".\\resources\\images\\poster.png", new DateOnly(2010, 3, 22), 22, 5, 0f, 2, "F5", new DateTime(2024, 12, 1, 21, 38, 51, 963, DateTimeKind.Local).AddTicks(617), 0 },
                    { 37, 4, new DateTime(2024, 12, 1, 21, 38, 51, 963, DateTimeKind.Local).AddTicks(631), "Eius laudantium tenetur beatae qui facilis numquam minima. Et rerum est et fuga id rerum eius non. Magni quisquam perferendis autem fuga. Porro unde esse sed ut officiis officia sit placeat illo. Itaque provident perspiciatis.", 1, "impedit", ".\\resources\\images\\poster.png", new DateOnly(2007, 1, 31), 29, 8, 0f, 3, "D4", new DateTime(2024, 12, 1, 21, 38, 51, 963, DateTimeKind.Local).AddTicks(817), 0 },
                    { 38, 30, new DateTime(2024, 12, 1, 21, 38, 51, 963, DateTimeKind.Local).AddTicks(832), "Unde non cum. Asperiores quia exercitationem aut impedit. Labore dolor voluptate natus. Dolore tenetur sit quam et sit enim nam nostrum quas.", 27, "velit", ".\\resources\\images\\poster.png", new DateOnly(2017, 4, 9), 22, 8, 0f, 3, "T5", new DateTime(2024, 12, 1, 21, 38, 51, 963, DateTimeKind.Local).AddTicks(926), 0 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBook",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 31, 5 },
                    { 35, 4 }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 37, "Canceled", 6, null, null, new DateTime(2024, 11, 30, 19, 43, 34, 571, DateTimeKind.Local).AddTicks(7953), null },
                    { 2, 25, "Borrowed", 13, new DateTime(2024, 11, 27, 7, 52, 9, 476, DateTimeKind.Local).AddTicks(1923), new DateTime(2024, 12, 6, 4, 10, 49, 64, DateTimeKind.Local).AddTicks(6249), new DateTime(2024, 11, 29, 4, 10, 49, 64, DateTimeKind.Local).AddTicks(6249), null },
                    { 3, 34, "Canceled", 9, null, null, new DateTime(2024, 11, 27, 20, 20, 47, 968, DateTimeKind.Local).AddTicks(6510), null },
                    { 4, 13, "Borrowed", 7, new DateTime(2024, 11, 27, 5, 50, 50, 453, DateTimeKind.Local).AddTicks(8852), new DateTime(2024, 12, 3, 11, 13, 46, 878, DateTimeKind.Local).AddTicks(9556), new DateTime(2024, 11, 26, 11, 13, 46, 878, DateTimeKind.Local).AddTicks(9556), null },
                    { 5, 37, "Canceled", 9, null, null, new DateTime(2024, 11, 28, 15, 55, 16, 867, DateTimeKind.Local).AddTicks(9665), null },
                    { 6, 21, "Completed", 15, new DateTime(2024, 11, 28, 3, 56, 48, 991, DateTimeKind.Local).AddTicks(9969), new DateTime(2024, 12, 7, 22, 26, 6, 737, DateTimeKind.Local).AddTicks(9155), new DateTime(2024, 11, 30, 22, 26, 6, 737, DateTimeKind.Local).AddTicks(9155), new DateTime(2024, 11, 30, 11, 52, 27, 601, DateTimeKind.Local).AddTicks(8936) },
                    { 7, 10, "Pending", 10, null, null, new DateTime(2024, 11, 30, 22, 19, 49, 610, DateTimeKind.Local).AddTicks(9947), null },
                    { 8, 19, "Borrowed", 7, new DateTime(2024, 11, 26, 19, 52, 2, 288, DateTimeKind.Local).AddTicks(2411), new DateTime(2024, 12, 6, 19, 44, 59, 965, DateTimeKind.Local).AddTicks(4756), new DateTime(2024, 11, 29, 19, 44, 59, 965, DateTimeKind.Local).AddTicks(4756), null },
                    { 9, 21, "Borrowed", 11, new DateTime(2024, 12, 1, 1, 25, 37, 338, DateTimeKind.Local).AddTicks(6955), new DateTime(2024, 12, 6, 13, 45, 47, 521, DateTimeKind.Local).AddTicks(5357), new DateTime(2024, 11, 29, 13, 45, 47, 521, DateTimeKind.Local).AddTicks(5357), null },
                    { 10, 5, "Completed", 9, new DateTime(2024, 11, 30, 21, 8, 40, 850, DateTimeKind.Local).AddTicks(1180), new DateTime(2024, 12, 4, 18, 7, 13, 964, DateTimeKind.Local).AddTicks(4426), new DateTime(2024, 11, 27, 18, 7, 13, 964, DateTimeKind.Local).AddTicks(4426), new DateTime(2024, 12, 1, 9, 14, 47, 926, DateTimeKind.Local).AddTicks(2522) },
                    { 11, 10, "Completed", 7, new DateTime(2024, 11, 29, 5, 42, 53, 921, DateTimeKind.Local).AddTicks(88), new DateTime(2024, 12, 3, 21, 38, 40, 161, DateTimeKind.Local).AddTicks(500), new DateTime(2024, 11, 26, 21, 38, 40, 161, DateTimeKind.Local).AddTicks(500), new DateTime(2024, 12, 1, 16, 57, 16, 557, DateTimeKind.Local).AddTicks(8838) },
                    { 12, 8, "Canceled", 9, null, null, new DateTime(2024, 11, 25, 5, 5, 48, 67, DateTimeKind.Local).AddTicks(9600), null },
                    { 13, 38, "Pending", 15, null, null, new DateTime(2024, 11, 25, 16, 38, 4, 641, DateTimeKind.Local).AddTicks(7662), null },
                    { 14, 3, "Pending", 3, null, null, new DateTime(2024, 11, 30, 16, 46, 56, 859, DateTimeKind.Local).AddTicks(5719), null },
                    { 15, 16, "Pending", 12, null, null, new DateTime(2024, 11, 26, 2, 31, 24, 413, DateTimeKind.Local).AddTicks(6066), null },
                    { 16, 14, "Canceled", 8, null, null, new DateTime(2024, 11, 27, 2, 41, 5, 102, DateTimeKind.Local).AddTicks(3880), null },
                    { 17, 38, "Pending", 12, null, null, new DateTime(2024, 12, 1, 10, 16, 5, 220, DateTimeKind.Local).AddTicks(3295), null },
                    { 18, 1, "Borrowed", 10, new DateTime(2024, 11, 26, 22, 26, 14, 471, DateTimeKind.Local).AddTicks(1189), new DateTime(2024, 12, 6, 0, 58, 17, 690, DateTimeKind.Local).AddTicks(3138), new DateTime(2024, 11, 29, 0, 58, 17, 690, DateTimeKind.Local).AddTicks(3138), null },
                    { 19, 30, "Canceled", 8, null, null, new DateTime(2024, 11, 27, 5, 56, 55, 240, DateTimeKind.Local).AddTicks(6431), null },
                    { 20, 6, "Borrowed", 16, new DateTime(2024, 11, 29, 7, 6, 52, 383, DateTimeKind.Local).AddTicks(9310), new DateTime(2024, 12, 5, 10, 56, 16, 686, DateTimeKind.Local).AddTicks(3188), new DateTime(2024, 11, 28, 10, 56, 16, 686, DateTimeKind.Local).AddTicks(3188), null },
                    { 21, 23, "Pending", 13, null, null, new DateTime(2024, 11, 29, 6, 58, 7, 653, DateTimeKind.Local).AddTicks(6238), null },
                    { 22, 30, "Borrowed", 9, new DateTime(2024, 11, 29, 22, 14, 41, 578, DateTimeKind.Local).AddTicks(7508), new DateTime(2024, 12, 8, 8, 2, 54, 725, DateTimeKind.Local).AddTicks(6774), new DateTime(2024, 12, 1, 8, 2, 54, 725, DateTimeKind.Local).AddTicks(6774), null },
                    { 23, 8, "Borrowed", 15, new DateTime(2024, 11, 27, 17, 42, 36, 463, DateTimeKind.Local).AddTicks(8719), new DateTime(2024, 12, 7, 11, 25, 31, 119, DateTimeKind.Local).AddTicks(2797), new DateTime(2024, 11, 30, 11, 25, 31, 119, DateTimeKind.Local).AddTicks(2797), null },
                    { 24, 3, "Completed", 10, new DateTime(2024, 11, 29, 12, 15, 20, 391, DateTimeKind.Local).AddTicks(4784), new DateTime(2024, 12, 3, 8, 17, 38, 687, DateTimeKind.Local).AddTicks(689), new DateTime(2024, 11, 26, 8, 17, 38, 687, DateTimeKind.Local).AddTicks(689), new DateTime(2024, 12, 1, 4, 36, 5, 383, DateTimeKind.Local).AddTicks(3761) },
                    { 25, 11, "Canceled", 10, null, null, new DateTime(2024, 12, 1, 10, 13, 36, 234, DateTimeKind.Local).AddTicks(2222), null },
                    { 26, 9, "Completed", 1, new DateTime(2024, 11, 29, 13, 54, 28, 852, DateTimeKind.Local).AddTicks(8093), new DateTime(2024, 12, 5, 9, 58, 50, 420, DateTimeKind.Local).AddTicks(9673), new DateTime(2024, 11, 28, 9, 58, 50, 420, DateTimeKind.Local).AddTicks(9673), new DateTime(2024, 11, 29, 9, 16, 55, 956, DateTimeKind.Local).AddTicks(4884) },
                    { 27, 29, "Completed", 10, new DateTime(2024, 12, 1, 2, 42, 18, 253, DateTimeKind.Local).AddTicks(9829), new DateTime(2024, 12, 2, 17, 46, 44, 354, DateTimeKind.Local).AddTicks(5533), new DateTime(2024, 11, 25, 17, 46, 44, 354, DateTimeKind.Local).AddTicks(5533), new DateTime(2024, 11, 30, 10, 17, 29, 531, DateTimeKind.Local).AddTicks(725) },
                    { 28, 13, "Borrowed", 3, new DateTime(2024, 11, 30, 12, 35, 9, 123, DateTimeKind.Local).AddTicks(6846), new DateTime(2024, 12, 6, 8, 2, 42, 49, DateTimeKind.Local).AddTicks(6506), new DateTime(2024, 11, 29, 8, 2, 42, 49, DateTimeKind.Local).AddTicks(6506), null },
                    { 29, 14, "Pending", 14, null, null, new DateTime(2024, 11, 28, 8, 12, 46, 944, DateTimeKind.Local).AddTicks(9557), null },
                    { 30, 35, "Pending", 12, null, null, new DateTime(2024, 11, 25, 12, 17, 14, 3, DateTimeKind.Local).AddTicks(3264), null },
                    { 31, 30, "Pending", 16, null, null, new DateTime(2024, 11, 27, 12, 3, 4, 214, DateTimeKind.Local).AddTicks(8394), null },
                    { 32, 23, "Pending", 1, null, null, new DateTime(2024, 11, 25, 15, 4, 50, 992, DateTimeKind.Local).AddTicks(3025), null },
                    { 33, 28, "Pending", 1, null, null, new DateTime(2024, 12, 1, 14, 38, 56, 133, DateTimeKind.Local).AddTicks(5394), null },
                    { 34, 38, "Canceled", 11, null, null, new DateTime(2024, 11, 26, 22, 48, 42, 965, DateTimeKind.Local).AddTicks(8676), null },
                    { 35, 35, "Completed", 5, new DateTime(2024, 11, 27, 3, 30, 51, 654, DateTimeKind.Local).AddTicks(6926), new DateTime(2024, 12, 7, 19, 29, 32, 363, DateTimeKind.Local).AddTicks(8350), new DateTime(2024, 11, 30, 19, 29, 32, 363, DateTimeKind.Local).AddTicks(8350), new DateTime(2024, 12, 1, 21, 38, 4, 206, DateTimeKind.Local).AddTicks(2133) },
                    { 36, 13, "Borrowed", 11, new DateTime(2024, 12, 1, 19, 54, 33, 383, DateTimeKind.Local).AddTicks(6857), new DateTime(2024, 12, 3, 18, 43, 11, 718, DateTimeKind.Local).AddTicks(2582), new DateTime(2024, 11, 26, 18, 43, 11, 718, DateTimeKind.Local).AddTicks(2582), null },
                    { 37, 20, "Borrowed", 16, new DateTime(2024, 11, 26, 10, 13, 42, 762, DateTimeKind.Local).AddTicks(4835), new DateTime(2024, 12, 2, 7, 22, 1, 154, DateTimeKind.Local).AddTicks(324), new DateTime(2024, 11, 25, 7, 22, 1, 154, DateTimeKind.Local).AddTicks(324), null },
                    { 38, 37, "Canceled", 10, null, null, new DateTime(2024, 11, 25, 8, 8, 33, 728, DateTimeKind.Local).AddTicks(5899), null },
                    { 39, 25, "Canceled", 9, null, null, new DateTime(2024, 11, 27, 12, 23, 0, 515, DateTimeKind.Local).AddTicks(7209), null },
                    { 40, 16, "Completed", 10, new DateTime(2024, 11, 29, 23, 10, 53, 974, DateTimeKind.Local).AddTicks(392), new DateTime(2024, 12, 3, 15, 22, 45, 571, DateTimeKind.Local).AddTicks(7154), new DateTime(2024, 11, 26, 15, 22, 45, 571, DateTimeKind.Local).AddTicks(7154), new DateTime(2024, 11, 29, 2, 54, 32, 308, DateTimeKind.Local).AddTicks(1665) }
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
                name: "IX_Books_storage_location",
                table: "Books",
                column: "storage_location");

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

            migrationBuilder.DropTable(
                name: "StorageLocations");
        }
    }
}
