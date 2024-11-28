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
                    { 1, "Illum dolore aliquid consequatur quas aut.", "Fanny" },
                    { 2, "Vel est iste exercitationem quia nobis modi officiis.", "Peter" },
                    { 3, "Iusto suscipit autem.", "Jeramie" },
                    { 4, "Et quam quia.", "Jorge" },
                    { 5, "Atque unde adipisci reprehenderit molestias voluptatem quis sequi velit placeat.", "Ayla" },
                    { 6, "Veritatis rerum est temporibus nesciunt cum sint enim ullam sunt.", "Vernon" },
                    { 7, "Rerum consectetur tempore aspernatur.", "Katrine" },
                    { 8, "Aut explicabo quia suscipit dolores.", "Berry" },
                    { 9, "Ut soluta quo nihil est qui laboriosam unde qui ipsum.", "Lonzo" },
                    { 10, "Nihil quas odio reiciendis aperiam.", "Lorenza" },
                    { 11, "Ea sint iste inventore pariatur corrupti nostrum.", "Mason" },
                    { 12, "Nemo ut dignissimos deleniti delectus consequatur ipsam.", "Shany" },
                    { 13, "Natus est eius.", "Vance" },
                    { 14, "Consequuntur fugiat quia.", "Alayna" },
                    { 15, "Corrupti eaque asperiores quos soluta voluptate accusantium.", "Tressa" },
                    { 16, "Quia quo fugiat.", "Malcolm" },
                    { 17, "Voluptatum laudantium aut rerum.", "Jordane" },
                    { 18, "Voluptatem omnis porro est amet quis ea quidem quis.", "Rosalind" },
                    { 19, "Tempora quia maxime excepturi vel aperiam omnis explicabo.", "Kennedy" },
                    { 20, "Quia consectetur sed eos consectetur tempora esse exercitationem.", "Madyson" },
                    { 21, "Ab praesentium animi dolor est hic.", "Lesley" },
                    { 22, "Dicta atque maiores excepturi dolorem quia vitae.", "Jodie" },
                    { 23, "Ut error unde consectetur.", "Laury" },
                    { 24, "Est necessitatibus vel incidunt quia eum.", "Karley" },
                    { 25, "Consequatur fuga omnis natus qui nisi.", "Vidal" },
                    { 26, "Qui aliquid cumque consequatur necessitatibus.", "Dino" },
                    { 27, "Autem vero vitae natus et accusamus rem ullam perspiciatis cum.", "Antwan" },
                    { 28, "Ipsam vero saepe.", "Declan" },
                    { 29, "Reiciendis adipisci sit aspernatur voluptatem ut debitis.", "Clark" },
                    { 30, "Exercitationem non ullam tenetur vel asperiores corporis fugit.", "Blaise" },
                    { 31, "Error et nobis qui blanditiis et porro sit ut.", "Jon" },
                    { 32, "Accusantium a consequatur error ut accusamus.", "Avis" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Delectus praesentium ea aperiam esse ipsam omnis nam qui numquam voluptatem numquam et cumque eos illo voluptas occaecati fugit vel.", "quidem", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 2, "Ipsa autem molestias ex alias rerum consequatur officiis cupiditate soluta qui qui consequatur sit facilis quo aspernatur dolore vero reprehenderit.", "quos", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 3, "Voluptatem aut expedita quo quia voluptas sunt et laborum tenetur quam et pariatur molestiae velit inventore quisquam corporis alias accusamus.", "quo", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 4, "Aliquam sit et molestiae beatae neque ut ratione enim quis recusandae sint doloremque beatae ut deserunt quo fugit ipsam qui.", "nulla", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 5, "Similique ducimus deleniti minus inventore voluptatibus sapiente porro dolor et id quos maiores voluptas sequi quae ut consequatur impedit distinctio.", "dolores", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "et" },
                    { 2, "quia" },
                    { 3, "minima" },
                    { 4, "reprehenderit" },
                    { 5, "officia" },
                    { 6, "dignissimos" },
                    { 7, "est" },
                    { 8, "est" },
                    { 9, "consequatur" },
                    { 10, "quo" },
                    { 11, "doloremque" },
                    { 12, "autem" },
                    { 13, "velit" },
                    { 14, "iure" },
                    { 15, "illum" },
                    { 16, "voluptate" },
                    { 17, "laudantium" },
                    { 18, "incidunt" },
                    { 19, "aliquam" },
                    { 20, "qui" },
                    { 21, "praesentium" },
                    { 22, "exercitationem" },
                    { 23, "mollitia" },
                    { 24, "maxime" },
                    { 25, "vel" },
                    { 26, "saepe" },
                    { 27, "quia" },
                    { 28, "excepturi" },
                    { 29, "iure" },
                    { 30, "aut" },
                    { 31, "nemo" },
                    { 32, "ut" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "consequatur" },
                    { 2, "tempore" },
                    { 3, "expedita" },
                    { 4, "consequuntur" },
                    { 5, "facilis" },
                    { 6, "voluptate" },
                    { 7, "et" },
                    { 8, "ipsa" },
                    { 9, "est" },
                    { 10, "dolor" },
                    { 11, "ad" },
                    { 12, "soluta" },
                    { 13, "sed" },
                    { 14, "molestiae" },
                    { 15, "maiores" },
                    { 16, "in" },
                    { 17, "non" },
                    { 18, "culpa" },
                    { 19, "consequatur" },
                    { 20, "explicabo" },
                    { 21, "voluptatibus" },
                    { 22, "perferendis" },
                    { 23, "facilis" },
                    { 24, "inventore" },
                    { 25, "minus" },
                    { 26, "culpa" },
                    { 27, "qui" },
                    { 28, "modi" },
                    { 29, "ut" },
                    { 30, "quisquam" },
                    { 31, "reprehenderit" },
                    { 32, "eveniet" }
                });

            migrationBuilder.InsertData(
                table: "StorageLocations",
                columns: new[] { "Name", "Description" },
                values: new object[,]
                {
                    { "J8", "Non aut eos ut occaecati eius dolorem in suscipit quasi officiis eaque deserunt officia aliquid aut nobis numquam tempora delectus." },
                    { "L2", "Doloremque molestias tempore nemo ut necessitatibus odit consequatur id libero aut at voluptas tenetur enim necessitatibus qui beatae consequatur quam." },
                    { "Q7", "Dolorem possimus at error sit quo nulla perferendis illo sunt necessitatibus a vel odio accusamus commodi sapiente quaerat expedita aut." },
                    { "T1", "Adipisci assumenda nulla est ea quod odit sit natus expedita voluptas voluptas omnis qui fugit sint id aut aut dolorum." },
                    { "X3", "Quis et harum quam dolores vitae omnis quam ipsam beatae pariatur consequuntur modi enim voluptate nisi ducimus occaecati et enim." }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Gender", "Name", "Password", "Role", "UserName", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, 42, "Female", "Fabiola Jacobs", "facilis", "User", "Loraine", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 2, 51, "Female", "Deon Lynch", "et", "User", "Arthur", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 3, 39, "Other", "Viviane Kessler", "magni", "Staff", "Kellen", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 4, 22, "Male", "Jack Reinger", "recusandae", "Admin", "Ron", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 5, 54, "Other", "Addison Bergstrom", "officia", "User", "Eulalia", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 6, 26, "Other", "Maximillia Nolan", "esse", "Admin", "Baylee", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 7, 18, "Female", "Tamara Smitham", "ullam", "Staff", "Bridgette", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 8, 52, "Female", "Max Williamson", "est", "Staff", "Fleta", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 9, 41, "Male", "Brayan Bogan", "sed", "User", "Gudrun", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 10, 32, "Female", "Ena Reichel", "incidunt", "Staff", "Marcus", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 11, 40, "Female", "Alphonso Boyer", "dolores", "Admin", "Emory", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 12, 21, "Female", "Merle Keeling", "harum", "Staff", "Maurice", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 13, 47, "Male", "Gussie Beatty", "inventore", "Admin", "Kelley", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 14, 34, "Female", "Caleigh Klocko", "incidunt", "Admin", "Evalyn", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 15, 39, "Male", "Sage Fisher", "dignissimos", "User", "Toby", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 16, 57, "Male", "Raleigh Fay", "quibusdam", "Staff", "Tristian", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "photoPath", "public_at", "publisher_id", "quantity", "rating", "remaining", "storage_location", "updated_at", "views" },
                values: new object[,]
                {
                    { 1, 26, new DateTime(2024, 11, 28, 21, 31, 41, 331, DateTimeKind.Local).AddTicks(8204), "Dolores fugiat occaecati suscipit error ut pariatur eveniet ut. Culpa ipsam reiciendis incidunt deserunt debitis. Quis quis aut labore quidem expedita commodi. Deleniti praesentium fugit.", 3, "non", ".\\resources\\images\\poster.png", new DateOnly(2005, 9, 29), 8, 9, 0f, 2, "Q7", new DateTime(2024, 11, 28, 21, 31, 41, 331, DateTimeKind.Local).AddTicks(9544), 0 },
                    { 2, 28, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(119), "Eos ut eaque est officia explicabo dicta cumque. Enim quia dolor. Repellendus corrupti voluptatibus ea dolores expedita. Repudiandae rem consectetur sed similique mollitia sed. Nulla dolorem animi unde laborum ut. Eius perferendis perferendis.", 9, "ipsam", ".\\resources\\images\\poster.png", new DateOnly(2014, 3, 25), 10, 7, 0f, 2, "J8", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(377), 0 },
                    { 3, 3, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(391), "Et magnam qui. Placeat architecto quas qui minima aut rem. Aut debitis quam suscipit deserunt magnam. Officiis ut temporibus ea.", 27, "velit", ".\\resources\\images\\poster.png", new DateOnly(2015, 6, 30), 11, 7, 0f, 3, "L2", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(508), 0 },
                    { 4, 10, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(520), "Veniam quae assumenda. Voluptatem nobis dolores ducimus itaque. Et accusantium natus qui autem nemo eaque rem vitae eveniet. Et vel aut perspiciatis fuga.", 20, "necessitatibus", ".\\resources\\images\\poster.png", new DateOnly(2009, 10, 19), 16, 8, 0f, 2, "Q7", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(632), 0 },
                    { 5, 11, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(644), "Quasi atque ut soluta id magni quisquam. Repudiandae modi aut occaecati error eos et maiores adipisci. Officiis impedit inventore iure rem.", 7, "ut", ".\\resources\\images\\poster.png", new DateOnly(2007, 5, 24), 1, 9, 0f, 1, "X3", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(730), 0 },
                    { 6, 2, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(741), "Illum quod a. Eos accusantium quo consequatur non inventore. A sit ullam. Id quae ut minima aperiam voluptas. Quia est qui occaecati.", 29, "distinctio", ".\\resources\\images\\poster.png", new DateOnly(1999, 5, 6), 27, 8, 0f, 4, "J8", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(849), 0 },
                    { 7, 12, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(860), "Unde est animi ad voluptatum placeat esse harum. Minima fugiat voluptatibus quis iste nostrum aut sed cumque itaque. Architecto reprehenderit temporibus.", 13, "dolores", ".\\resources\\images\\poster.png", new DateOnly(2021, 11, 29), 7, 7, 0f, 4, "X3", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(938), 0 },
                    { 8, 13, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(949), "Qui sit ratione. Ut dolores quis voluptatem minima est commodi ut. Quo id iure velit perspiciatis accusamus accusantium.", 31, "dolor", ".\\resources\\images\\poster.png", new DateOnly(2009, 2, 24), 30, 9, 0f, 5, "J8", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1047), 0 },
                    { 9, 30, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1058), "Quia recusandae iusto inventore quaerat debitis vel perferendis ipsa illum. Officia est saepe magni est delectus tenetur dolorem omnis at. Mollitia dignissimos deleniti dolor unde. Quaerat saepe et.", 20, "enim", ".\\resources\\images\\poster.png", new DateOnly(2003, 7, 23), 16, 6, 0f, 1, "T1", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1150), 0 },
                    { 10, 21, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1161), "Corrupti dolores blanditiis nam. Iste sed et voluptates velit. Qui facilis nulla consectetur deleniti labore et ipsam aut nihil.", 24, "pariatur", ".\\resources\\images\\poster.png", new DateOnly(2022, 2, 16), 12, 6, 0f, 1, "T1", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1259), 0 },
                    { 11, 15, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1269), "Labore hic est aperiam et eos. Quis architecto aliquid quia voluptatem velit ea itaque rerum aspernatur. Aut cum molestiae explicabo voluptatem sunt non repudiandae minima. Maiores aut aut perferendis aperiam non recusandae eveniet consequuntur quae. Est quod autem quas quas quis aut.", 1, "est", ".\\resources\\images\\poster.png", new DateOnly(2014, 1, 13), 20, 5, 0f, 4, "T1", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1402), 0 },
                    { 12, 23, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1413), "Excepturi labore aut. Est nemo ratione et. Odit repudiandae labore.", 12, "rem", ".\\resources\\images\\poster.png", new DateOnly(2007, 9, 17), 25, 10, 0f, 1, "X3", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1473), 0 },
                    { 13, 1, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1483), "Quam qui debitis architecto quod. Et alias ut sit cum quod recusandae aspernatur quaerat doloremque. Voluptas similique nisi repudiandae illum molestiae repudiandae et.", 27, "eos", ".\\resources\\images\\poster.png", new DateOnly(2001, 4, 5), 6, 10, 0f, 2, "L2", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1600), 0 },
                    { 14, 28, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1611), "Enim dolorem recusandae hic rerum et. Ut numquam voluptate ut nostrum deleniti neque et ut quibusdam. Quod molestiae eum. Nihil magnam facilis. Voluptas autem vel explicabo quas sit molestiae.", 4, "omnis", ".\\resources\\images\\poster.png", new DateOnly(2019, 3, 29), 9, 5, 0f, 5, "L2", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1705), 0 },
                    { 15, 28, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1717), "Illum quisquam sint et laboriosam est blanditiis. Omnis et aut ut assumenda dolorem aut qui. Sapiente harum recusandae et quibusdam voluptatem. Molestiae aut consectetur est est dolore.", 7, "sed", ".\\resources\\images\\poster.png", new DateOnly(2014, 12, 29), 25, 5, 0f, 4, "X3", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1837), 0 },
                    { 16, 21, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1849), "Voluptatum fugit minima nemo et autem distinctio commodi libero. Quae omnis rem. Qui totam rerum animi. Blanditiis ad voluptatem dignissimos sit dicta et. Tenetur dolores omnis.", 10, "aliquid", ".\\resources\\images\\poster.png", new DateOnly(2018, 5, 14), 3, 8, 0f, 1, "X3", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1960), 0 },
                    { 17, 31, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(1971), "Omnis molestiae quis illum. Assumenda voluptatum et enim sed necessitatibus. Delectus ipsa quis ut. Sit sint illo est qui necessitatibus facilis est eum. Laudantium dolor ullam sequi consectetur velit provident molestiae consequatur. Est et voluptates quam repellendus voluptas pariatur fugiat excepturi.", 24, "nemo", ".\\resources\\images\\poster.png", new DateOnly(2008, 3, 22), 14, 7, 0f, 0, "L2", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2107), 0 },
                    { 18, 25, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2118), "Hic dolorem corrupti rerum et eaque ab et rerum. Provident numquam libero provident. Nostrum accusantium officiis non minus sed et. Placeat voluptatem suscipit aliquid dolor. Non laboriosam commodi sunt nesciunt fugit voluptas et doloremque.", 32, "blanditiis", ".\\resources\\images\\poster.png", new DateOnly(1999, 5, 25), 7, 5, 0f, 5, "J8", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2244), 0 },
                    { 19, 4, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2256), "Cumque et molestiae. Illo dolores perferendis vel id atque eius. Explicabo magnam ut. Qui sapiente sed.", 2, "fugiat", ".\\resources\\images\\poster.png", new DateOnly(2024, 11, 25), 2, 10, 0f, 1, "X3", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2350), 0 },
                    { 20, 3, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2361), "Quo illum vel itaque qui quia est. In blanditiis minima amet sint animi. Ducimus voluptatibus minima sint.", 16, "soluta", ".\\resources\\images\\poster.png", new DateOnly(2016, 5, 23), 15, 8, 0f, 4, "Q7", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2432), 0 },
                    { 21, 17, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2456), "Quia nisi sapiente qui. Molestiae sed saepe vel. Qui iste aperiam fuga iste ratione.", 26, "magnam", ".\\resources\\images\\poster.png", new DateOnly(2017, 8, 19), 27, 8, 0f, 4, "T1", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2543), 0 },
                    { 22, 13, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2555), "Ea inventore et recusandae nobis quidem veniam eos. Corrupti officia officiis in ratione minima excepturi occaecati et exercitationem. Odit sed dolorum eaque maiores. Tempore dolores aliquid necessitatibus odio. Amet odit mollitia dolorem totam omnis distinctio ut vitae et. Consequuntur ea qui odit omnis doloribus suscipit reiciendis.", 27, "ut", ".\\resources\\images\\poster.png", new DateOnly(2008, 11, 18), 6, 5, 0f, 2, "T1", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2704), 0 },
                    { 23, 1, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2716), "Enim id cumque ea perspiciatis est sunt. Molestiae voluptas id ut inventore asperiores aut ducimus iste. Ducimus libero commodi. Vel magnam sit amet sit.", 12, "quas", ".\\resources\\images\\poster.png", new DateOnly(2001, 5, 27), 4, 10, 0f, 4, "J8", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2813), 0 },
                    { 24, 32, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2824), "Et doloremque eveniet soluta velit et blanditiis animi eaque. Ad rem aut est et necessitatibus. Vel ut est.", 24, "quis", ".\\resources\\images\\poster.png", new DateOnly(2003, 8, 28), 11, 5, 0f, 2, "T1", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2911), 0 },
                    { 25, 15, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(2923), "Illo ullam et ipsa reprehenderit. Labore quod et qui animi omnis et. Blanditiis voluptatum quod est rerum.", 21, "repudiandae", ".\\resources\\images\\poster.png", new DateOnly(2018, 6, 25), 11, 9, 0f, 2, "L2", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3001), 0 },
                    { 26, 16, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3015), "Ducimus nulla omnis rerum. Fugiat qui blanditiis eveniet ex. Ipsam nam iusto inventore possimus aperiam sit ut. Reiciendis culpa consequatur est temporibus quo distinctio quo vel.", 22, "veniam", ".\\resources\\images\\poster.png", new DateOnly(2020, 1, 3), 21, 7, 0f, 4, "X3", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3134), 0 },
                    { 27, 11, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3148), "Corrupti cupiditate aliquid laboriosam et quia distinctio aspernatur ullam sequi. Sint deleniti illum hic eveniet. Quam magnam esse repudiandae est voluptatem. Ut autem earum. Aut voluptas aliquid ad aut adipisci aut quis. Quia illo qui.", 22, "doloremque", ".\\resources\\images\\poster.png", new DateOnly(2003, 1, 21), 32, 8, 0f, 2, "Q7", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3301), 0 },
                    { 28, 30, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3315), "Occaecati quo eaque velit soluta. Eos officia possimus. Et porro eveniet expedita et eum sapiente.", 1, "ut", ".\\resources\\images\\poster.png", new DateOnly(2011, 6, 12), 11, 9, 0f, 1, "L2", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3389), 0 },
                    { 29, 9, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3402), "Non voluptas laborum enim rerum quasi ad. Eaque molestiae nemo. Perferendis vitae officia id ipsum quam accusamus asperiores. Unde voluptatem ab voluptatem.", 12, "cum", ".\\resources\\images\\poster.png", new DateOnly(2016, 11, 25), 3, 9, 0f, 4, "T1", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3516), 0 },
                    { 30, 29, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3528), "Aliquam nesciunt dolorem fugiat aspernatur. Veniam non ut odit cum quo recusandae est in non. Consequuntur aut officiis consequuntur earum qui porro sint harum. Eum voluptatem magni possimus. Quo rerum animi. Quasi unde praesentium.", 8, "reprehenderit", ".\\resources\\images\\poster.png", new DateOnly(2010, 3, 9), 14, 9, 0f, 1, "X3", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3678), 0 },
                    { 31, 6, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3692), "Voluptatem minus quisquam voluptatem velit id et beatae eos. Sapiente autem autem eveniet nobis. Suscipit assumenda rerum. Rem cupiditate dolorem vel earum odit eius rem. A facilis similique odio ducimus esse. Molestiae omnis et.", 32, "non", ".\\resources\\images\\poster.png", new DateOnly(2007, 9, 18), 21, 5, 0f, 5, "X3", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3803), 0 },
                    { 32, 2, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3817), "Sint vel soluta tenetur consequatur enim consectetur aspernatur repudiandae. Maxime eum sint animi est nam necessitatibus deserunt quo. Tenetur aut est incidunt qui voluptas necessitatibus repellendus.", 31, "tenetur", ".\\resources\\images\\poster.png", new DateOnly(2017, 4, 26), 13, 9, 0f, 5, "X3", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3925), 0 },
                    { 33, 3, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(3938), "Deleniti ex delectus a. Maxime hic id sit voluptate non nam porro assumenda itaque. Sit ipsa culpa quas. Et autem doloribus minima minus inventore. Libero dicta sed repudiandae dolorum voluptas optio. Et aspernatur iusto error dolor dolor ducimus molestiae.", 17, "aperiam", ".\\resources\\images\\poster.png", new DateOnly(2004, 10, 23), 6, 10, 0f, 2, "T1", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(4178), 0 },
                    { 34, 26, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(4191), "Quas sed consequatur alias ullam tempora ipsam vitae. Voluptate quaerat et quasi sit sed minima mollitia et. Autem odio ex. Quibusdam dignissimos qui illum sunt ad voluptas. Nulla officiis nostrum.", 14, "quae", ".\\resources\\images\\poster.png", new DateOnly(2007, 8, 24), 27, 7, 0f, 4, "T1", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(4287), 0 },
                    { 35, 22, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(4300), "Nobis ex dolor illum sed possimus quam temporibus repellendus id. At et quas est nulla magnam provident. Adipisci libero deleniti quis qui. Dolorem eligendi omnis et possimus quae aut qui. Occaecati ipsum quidem quis consectetur qui voluptas ea laboriosam voluptas.", 19, "nesciunt", ".\\resources\\images\\poster.png", new DateOnly(2009, 11, 3), 8, 9, 0f, 0, "J8", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(4442), 0 },
                    { 36, 2, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(4457), "Sequi et quod. Voluptas assumenda qui dolorem excepturi magni quia inventore aut eum. Vel blanditiis odio voluptas natus enim ducimus. Aperiam dicta dolores. Architecto dignissimos ratione porro velit saepe quos magni. Accusantium sint ullam.", 27, "distinctio", ".\\resources\\images\\poster.png", new DateOnly(2000, 4, 14), 23, 10, 0f, 5, "L2", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(4581), 0 },
                    { 37, 12, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(4593), "Excepturi soluta sed corrupti dolor porro quis esse. Et cum error placeat sed ex reprehenderit et distinctio. Modi occaecati a et maxime dolore perspiciatis est totam.", 19, "maiores", ".\\resources\\images\\poster.png", new DateOnly(2000, 11, 27), 19, 5, 0f, 3, "Q7", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(4710), 0 },
                    { 38, 23, new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(4723), "Possimus laborum tempora necessitatibus praesentium. Voluptate vel sint voluptatibus recusandae eius sapiente. Voluptas dolor maiores ut neque harum consequuntur. Est iure est nisi. Aut odio minus id assumenda debitis consequatur blanditiis. Labore hic eos ullam iusto minus non quibusdam eos.", 28, "quod", ".\\resources\\images\\poster.png", new DateOnly(2023, 8, 14), 10, 5, 0f, 5, "Q7", new DateTime(2024, 11, 28, 21, 31, 41, 332, DateTimeKind.Local).AddTicks(4876), 0 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBook",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 34, 4 }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 5, "Completed", 8, new DateTime(2024, 11, 28, 1, 56, 48, 479, DateTimeKind.Local).AddTicks(2042), new DateTime(2024, 12, 1, 11, 29, 17, 49, DateTimeKind.Local).AddTicks(2430), new DateTime(2024, 11, 24, 11, 29, 17, 49, DateTimeKind.Local).AddTicks(2430), new DateTime(2024, 11, 27, 13, 4, 41, 305, DateTimeKind.Local).AddTicks(8104) },
                    { 2, 24, "Canceled", 15, null, null, new DateTime(2024, 11, 23, 12, 4, 59, 64, DateTimeKind.Local).AddTicks(8793), null },
                    { 3, 9, "Canceled", 9, null, null, new DateTime(2024, 11, 27, 9, 32, 15, 546, DateTimeKind.Local).AddTicks(6302), null },
                    { 4, 30, "Completed", 13, new DateTime(2024, 11, 28, 20, 36, 8, 277, DateTimeKind.Local).AddTicks(3512), new DateTime(2024, 12, 5, 15, 4, 38, 185, DateTimeKind.Local).AddTicks(4925), new DateTime(2024, 11, 28, 15, 4, 38, 185, DateTimeKind.Local).AddTicks(4925), new DateTime(2024, 11, 27, 13, 29, 27, 800, DateTimeKind.Local).AddTicks(7478) },
                    { 5, 27, "Borrowed", 13, new DateTime(2024, 11, 24, 6, 40, 47, 523, DateTimeKind.Local).AddTicks(4711), new DateTime(2024, 12, 2, 2, 3, 53, 42, DateTimeKind.Local).AddTicks(8585), new DateTime(2024, 11, 25, 2, 3, 53, 42, DateTimeKind.Local).AddTicks(8585), null },
                    { 6, 6, "Canceled", 6, null, null, new DateTime(2024, 11, 26, 20, 24, 56, 259, DateTimeKind.Local).AddTicks(9837), null },
                    { 7, 18, "Borrowed", 12, new DateTime(2024, 11, 28, 8, 31, 12, 306, DateTimeKind.Local).AddTicks(9082), new DateTime(2024, 12, 5, 9, 6, 18, 684, DateTimeKind.Local).AddTicks(4415), new DateTime(2024, 11, 28, 9, 6, 18, 684, DateTimeKind.Local).AddTicks(4415), null },
                    { 8, 30, "Completed", 4, new DateTime(2024, 11, 27, 21, 12, 15, 706, DateTimeKind.Local).AddTicks(2064), new DateTime(2024, 12, 3, 3, 39, 18, 479, DateTimeKind.Local).AddTicks(5648), new DateTime(2024, 11, 26, 3, 39, 18, 479, DateTimeKind.Local).AddTicks(5648), new DateTime(2024, 11, 28, 10, 56, 33, 329, DateTimeKind.Local).AddTicks(2615) },
                    { 9, 34, "Borrowed", 12, new DateTime(2024, 11, 26, 23, 10, 32, 644, DateTimeKind.Local).AddTicks(398), new DateTime(2024, 12, 2, 1, 30, 27, 107, DateTimeKind.Local).AddTicks(1313), new DateTime(2024, 11, 25, 1, 30, 27, 107, DateTimeKind.Local).AddTicks(1313), null },
                    { 10, 32, "Borrowed", 1, new DateTime(2024, 11, 24, 6, 44, 19, 602, DateTimeKind.Local).AddTicks(6315), new DateTime(2024, 12, 2, 19, 21, 42, 200, DateTimeKind.Local).AddTicks(2287), new DateTime(2024, 11, 25, 19, 21, 42, 200, DateTimeKind.Local).AddTicks(2287), null },
                    { 11, 3, "Canceled", 4, null, null, new DateTime(2024, 11, 22, 19, 28, 21, 297, DateTimeKind.Local).AddTicks(4067), null },
                    { 12, 13, "Pending", 7, null, null, new DateTime(2024, 11, 28, 3, 1, 21, 590, DateTimeKind.Local).AddTicks(9686), null },
                    { 13, 17, "Canceled", 10, null, null, new DateTime(2024, 11, 22, 0, 41, 7, 782, DateTimeKind.Local).AddTicks(8978), null },
                    { 14, 33, "Pending", 5, null, null, new DateTime(2024, 11, 23, 15, 19, 12, 227, DateTimeKind.Local).AddTicks(9478), null },
                    { 15, 23, "Pending", 2, null, null, new DateTime(2024, 11, 28, 12, 59, 39, 573, DateTimeKind.Local).AddTicks(7913), null },
                    { 16, 13, "Borrowed", 11, new DateTime(2024, 11, 26, 9, 2, 15, 621, DateTimeKind.Local).AddTicks(8584), new DateTime(2024, 12, 4, 22, 49, 53, 229, DateTimeKind.Local).AddTicks(4503), new DateTime(2024, 11, 27, 22, 49, 53, 229, DateTimeKind.Local).AddTicks(4503), null },
                    { 17, 23, "Borrowed", 2, new DateTime(2024, 11, 27, 9, 38, 42, 872, DateTimeKind.Local).AddTicks(2987), new DateTime(2024, 12, 1, 7, 37, 56, 199, DateTimeKind.Local).AddTicks(2550), new DateTime(2024, 11, 24, 7, 37, 56, 199, DateTimeKind.Local).AddTicks(2550), null },
                    { 18, 28, "Pending", 7, null, null, new DateTime(2024, 11, 23, 18, 36, 20, 919, DateTimeKind.Local).AddTicks(4501), null },
                    { 19, 26, "Borrowed", 12, new DateTime(2024, 11, 26, 1, 43, 55, 386, DateTimeKind.Local).AddTicks(4231), new DateTime(2024, 12, 3, 7, 13, 54, 302, DateTimeKind.Local).AddTicks(8056), new DateTime(2024, 11, 26, 7, 13, 54, 302, DateTimeKind.Local).AddTicks(8056), null },
                    { 20, 13, "Pending", 1, null, null, new DateTime(2024, 11, 28, 18, 5, 18, 50, DateTimeKind.Local).AddTicks(2723), null },
                    { 21, 7, "Borrowed", 3, new DateTime(2024, 11, 23, 20, 21, 54, 972, DateTimeKind.Local).AddTicks(5741), new DateTime(2024, 11, 29, 14, 42, 4, 109, DateTimeKind.Local).AddTicks(8449), new DateTime(2024, 11, 22, 14, 42, 4, 109, DateTimeKind.Local).AddTicks(8449), null },
                    { 22, 34, "Borrowed", 10, new DateTime(2024, 11, 26, 22, 34, 37, 875, DateTimeKind.Local).AddTicks(4251), new DateTime(2024, 12, 1, 17, 15, 14, 976, DateTimeKind.Local).AddTicks(9461), new DateTime(2024, 11, 24, 17, 15, 14, 976, DateTimeKind.Local).AddTicks(9461), null },
                    { 23, 32, "Completed", 3, new DateTime(2024, 11, 28, 10, 30, 26, 49, DateTimeKind.Local).AddTicks(3875), new DateTime(2024, 12, 3, 1, 21, 45, 368, DateTimeKind.Local).AddTicks(4888), new DateTime(2024, 11, 26, 1, 21, 45, 368, DateTimeKind.Local).AddTicks(4888), new DateTime(2024, 11, 28, 15, 28, 49, 308, DateTimeKind.Local).AddTicks(5994) },
                    { 24, 26, "Pending", 16, null, null, new DateTime(2024, 11, 27, 4, 6, 17, 139, DateTimeKind.Local).AddTicks(3783), null },
                    { 25, 1, "Completed", 15, new DateTime(2024, 11, 27, 5, 4, 4, 552, DateTimeKind.Local).AddTicks(747), new DateTime(2024, 11, 30, 12, 50, 34, 189, DateTimeKind.Local).AddTicks(2476), new DateTime(2024, 11, 23, 12, 50, 34, 189, DateTimeKind.Local).AddTicks(2476), new DateTime(2024, 11, 26, 1, 52, 56, 888, DateTimeKind.Local).AddTicks(3377) },
                    { 26, 3, "Canceled", 15, null, null, new DateTime(2024, 11, 28, 6, 33, 0, 835, DateTimeKind.Local).AddTicks(3102), null },
                    { 27, 38, "Canceled", 2, null, null, new DateTime(2024, 11, 24, 0, 25, 8, 691, DateTimeKind.Local).AddTicks(7699), null },
                    { 28, 15, "Borrowed", 14, new DateTime(2024, 11, 25, 4, 17, 28, 696, DateTimeKind.Local).AddTicks(736), new DateTime(2024, 11, 29, 6, 42, 14, 350, DateTimeKind.Local).AddTicks(157), new DateTime(2024, 11, 22, 6, 42, 14, 350, DateTimeKind.Local).AddTicks(157), null },
                    { 29, 16, "Pending", 8, null, null, new DateTime(2024, 11, 26, 4, 2, 14, 596, DateTimeKind.Local).AddTicks(9607), null },
                    { 30, 37, "Canceled", 8, null, null, new DateTime(2024, 11, 24, 0, 20, 38, 903, DateTimeKind.Local).AddTicks(1213), null },
                    { 31, 7, "Borrowed", 5, new DateTime(2024, 11, 27, 10, 30, 26, 397, DateTimeKind.Local).AddTicks(8683), new DateTime(2024, 12, 2, 10, 55, 54, 314, DateTimeKind.Local).AddTicks(7560), new DateTime(2024, 11, 25, 10, 55, 54, 314, DateTimeKind.Local).AddTicks(7560), null },
                    { 32, 22, "Borrowed", 15, new DateTime(2024, 11, 24, 3, 51, 7, 646, DateTimeKind.Local).AddTicks(1102), new DateTime(2024, 12, 4, 12, 17, 30, 603, DateTimeKind.Local).AddTicks(1414), new DateTime(2024, 11, 27, 12, 17, 30, 603, DateTimeKind.Local).AddTicks(1414), null },
                    { 33, 9, "Canceled", 12, null, null, new DateTime(2024, 11, 26, 4, 18, 27, 925, DateTimeKind.Local).AddTicks(1073), null },
                    { 34, 13, "Borrowed", 15, new DateTime(2024, 11, 25, 8, 41, 25, 670, DateTimeKind.Local).AddTicks(1847), new DateTime(2024, 11, 30, 16, 47, 50, 43, DateTimeKind.Local).AddTicks(3971), new DateTime(2024, 11, 23, 16, 47, 50, 43, DateTimeKind.Local).AddTicks(3971), null },
                    { 35, 17, "Pending", 2, null, null, new DateTime(2024, 11, 28, 6, 21, 59, 298, DateTimeKind.Local).AddTicks(3467), null },
                    { 36, 9, "Borrowed", 4, new DateTime(2024, 11, 24, 22, 17, 40, 149, DateTimeKind.Local).AddTicks(765), new DateTime(2024, 12, 4, 0, 45, 4, 84, DateTimeKind.Local).AddTicks(4840), new DateTime(2024, 11, 27, 0, 45, 4, 84, DateTimeKind.Local).AddTicks(4840), null },
                    { 37, 34, "Pending", 14, null, null, new DateTime(2024, 11, 22, 10, 15, 35, 457, DateTimeKind.Local).AddTicks(3786), null },
                    { 38, 14, "Pending", 10, null, null, new DateTime(2024, 11, 26, 18, 15, 33, 263, DateTimeKind.Local).AddTicks(9445), null },
                    { 39, 23, "Canceled", 14, null, null, new DateTime(2024, 11, 25, 6, 37, 5, 865, DateTimeKind.Local).AddTicks(7311), null },
                    { 40, 10, "Pending", 8, null, null, new DateTime(2024, 11, 27, 22, 21, 8, 168, DateTimeKind.Local).AddTicks(9703), null }
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
