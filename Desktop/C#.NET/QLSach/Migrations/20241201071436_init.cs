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
                    { 1, "Harum facilis dolor pariatur dolores.", "Ardella" },
                    { 2, "Sapiente quia laudantium.", "Elias" },
                    { 3, "Voluptate voluptates recusandae nihil iste doloribus facilis dolores quia.", "Athena" },
                    { 4, "Eos sit iste.", "Rahul" },
                    { 5, "Laboriosam quia ut voluptas nulla.", "Jon" },
                    { 6, "Assumenda tempora accusamus sit eaque commodi totam.", "Meda" },
                    { 7, "Sit quaerat vel.", "Estrella" },
                    { 8, "Impedit velit occaecati quis qui fuga nisi quisquam tempora.", "Beryl" },
                    { 9, "Et nam animi sed quia.", "Jaclyn" },
                    { 10, "Atque incidunt non enim.", "Oleta" },
                    { 11, "Culpa omnis quisquam nihil modi excepturi rerum consequatur.", "Sofia" },
                    { 12, "Quia voluptatibus impedit ut eligendi commodi corporis dolore et eveniet.", "Raymundo" },
                    { 13, "Numquam est possimus dicta magni molestiae eligendi praesentium corporis et.", "Halle" },
                    { 14, "Incidunt voluptatem omnis voluptatem ad.", "Blake" },
                    { 15, "Velit saepe praesentium dignissimos soluta et dicta quia.", "Melissa" },
                    { 16, "Explicabo possimus vel enim sed qui quibusdam.", "Larry" },
                    { 17, "Dolores veniam voluptatum aut eaque.", "Michale" },
                    { 18, "Molestias quis a.", "Vincenzo" },
                    { 19, "Quisquam necessitatibus ducimus dolor illum sapiente porro.", "Johnson" },
                    { 20, "Et quam esse assumenda sed incidunt.", "Buddy" },
                    { 21, "Pariatur porro earum autem.", "Enid" },
                    { 22, "Consequatur eius sit quia.", "Candace" },
                    { 23, "Placeat qui est delectus cumque eos accusamus quam aut nihil.", "Jo" },
                    { 24, "Deleniti dicta quibusdam enim ut.", "Thad" },
                    { 25, "Delectus aut doloribus mollitia ut ut tempora vel.", "Jules" },
                    { 26, "Qui ab consequatur natus itaque aliquid ea commodi.", "Alfreda" },
                    { 27, "Consectetur natus omnis aut aut.", "Hillard" },
                    { 28, "Suscipit ut rerum accusamus voluptates et inventore quia.", "Russ" },
                    { 29, "Ut ducimus eius deserunt porro suscipit ut.", "Rosalee" },
                    { 30, "Nam sapiente consequatur eos aut aut quo.", "Tre" },
                    { 31, "Dolor blanditiis placeat beatae ducimus dolor dicta enim sint maxime.", "Royal" },
                    { 32, "Sunt quia a ratione aut.", "Melba" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Commodi explicabo iste iusto aut accusamus et id vel non minus quasi rerum quis velit quibusdam ipsum velit harum assumenda.", "maxime", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 2, "Nihil fuga totam modi quidem non atque sit occaecati et quos eum expedita quae modi mollitia aut a quis illum.", "dolores", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 3, "Aut eveniet vero fugiat repellendus asperiores dicta non maiores voluptatem quidem et beatae aliquam doloribus sit aut doloribus expedita molestiae.", "quae", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 4, "Labore non illo perspiciatis sequi aut eveniet quod aliquid ea voluptas dicta corrupti qui in unde quaerat harum nulla ipsum.", "autem", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 5, "Neque et quo iure totam dignissimos aut eligendi atque possimus corrupti vel aut voluptatem dolorum facilis iusto temporibus mollitia aut.", "quos", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "velit" },
                    { 2, "voluptatibus" },
                    { 3, "similique" },
                    { 4, "recusandae" },
                    { 5, "facilis" },
                    { 6, "minus" },
                    { 7, "reiciendis" },
                    { 8, "aperiam" },
                    { 9, "adipisci" },
                    { 10, "repellendus" },
                    { 11, "dolorem" },
                    { 12, "assumenda" },
                    { 13, "enim" },
                    { 14, "porro" },
                    { 15, "occaecati" },
                    { 16, "sed" },
                    { 17, "mollitia" },
                    { 18, "quasi" },
                    { 19, "rem" },
                    { 20, "dolorum" },
                    { 21, "dolorem" },
                    { 22, "sint" },
                    { 23, "recusandae" },
                    { 24, "ea" },
                    { 25, "nam" },
                    { 26, "non" },
                    { 27, "distinctio" },
                    { 28, "fugit" },
                    { 29, "dolor" },
                    { 30, "fuga" },
                    { 31, "velit" },
                    { 32, "facilis" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "tempore" },
                    { 2, "voluptatem" },
                    { 3, "quidem" },
                    { 4, "suscipit" },
                    { 5, "nesciunt" },
                    { 6, "voluptas" },
                    { 7, "a" },
                    { 8, "non" },
                    { 9, "corporis" },
                    { 10, "eum" },
                    { 11, "sapiente" },
                    { 12, "ea" },
                    { 13, "deserunt" },
                    { 14, "dolores" },
                    { 15, "aut" },
                    { 16, "culpa" },
                    { 17, "aut" },
                    { 18, "qui" },
                    { 19, "repellat" },
                    { 20, "qui" },
                    { 21, "rerum" },
                    { 22, "molestiae" },
                    { 23, "rerum" },
                    { 24, "omnis" },
                    { 25, "natus" },
                    { 26, "possimus" },
                    { 27, "fugit" },
                    { 28, "et" },
                    { 29, "numquam" },
                    { 30, "quia" },
                    { 31, "inventore" },
                    { 32, "tenetur" }
                });

            migrationBuilder.InsertData(
                table: "StorageLocations",
                columns: new[] { "Name", "Description" },
                values: new object[,]
                {
                    { "D3", "Eligendi temporibus ut delectus blanditiis culpa dolorem inventore iure officia illo enim et non labore dicta hic vitae molestiae necessitatibus." },
                    { "F3", "Similique repudiandae dolorum eum et rerum occaecati iusto dolor praesentium sequi sit sed voluptas facilis dolor fugiat ipsam maxime sit." },
                    { "M9", "At sed exercitationem dicta odit sapiente quia ullam aut in exercitationem et dignissimos ipsa hic et libero tenetur maiores ut." },
                    { "V3", "Aspernatur maiores quia ea ut ut sint qui pariatur eius voluptatem quos non repellendus deleniti dolores laboriosam similique ut deleniti." },
                    { "Z6", "Recusandae hic iste maiores a ullam ducimus praesentium repellat quaerat et asperiores vel nisi totam nihil et voluptatibus fugit possimus." }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Gender", "Name", "Password", "Role", "UserName", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, 26, "Female", "Arely Smitham", "dolorem", "Admin", "Ephraim", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 2, 25, "Female", "Leilani Becker", "sequi", "Admin", "Arch", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 3, 32, "Male", "Jaqueline Lubowitz", "provident", "User", "Bell", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 4, 23, "Other", "Esteban Hilll", "aut", "Staff", "Leanna", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 5, 32, "Other", "Clemens Keeling", "voluptatum", "Staff", "Kaleb", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 6, 42, "Other", "Kaley Wuckert", "explicabo", "Staff", "Kaley", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 7, 21, "Other", "Charity Hyatt", "vel", "User", "Kameron", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 8, 40, "Female", "Donato Conn", "excepturi", "Admin", "Marielle", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 9, 25, "Female", "Elyssa Stiedemann", "sunt", "Admin", "Archibald", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 10, 40, "Male", "Quincy Lang", "in", "Staff", "Amina", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 11, 32, "Female", "Clementine Macejkovic", "quaerat", "Admin", "Abbigail", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 12, 43, "Male", "Chaya Hermiston", "non", "Staff", "Dallas", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 13, 57, "Other", "Milan Trantow", "voluptatum", "Admin", "Terrence", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 14, 25, "Female", "Jarvis Wiegand", "numquam", "User", "Rubie", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 15, 42, "Male", "Fiona Braun", "sed", "Admin", "Joel", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) },
                    { 16, 40, "Female", "Monserrat Hansen", "et", "Staff", "Dayna", new DateOnly(2024, 12, 1), new DateOnly(2024, 12, 1) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "photoPath", "public_at", "publisher_id", "quantity", "rating", "remaining", "storage_location", "updated_at", "views" },
                values: new object[,]
                {
                    { 1, 32, new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(3547), "Ipsum earum dolor tenetur. Iusto dolore aut est aliquid. Unde labore pariatur.", 4, "consequatur", ".\\resources\\images\\poster.png", new DateOnly(2020, 1, 28), 4, 7, 0f, 2, "M9", new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(7522), 0 },
                    { 2, 14, new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(8347), "Magni nam ducimus dolores nisi deleniti quidem ea recusandae accusamus. At ut voluptas. Rem quis consequatur exercitationem necessitatibus quidem.", 9, "repellendus", ".\\resources\\images\\poster.png", new DateOnly(2023, 1, 19), 21, 8, 0f, 1, "V3", new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(8862), 0 },
                    { 3, 9, new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(8876), "Ex doloremque et qui quis ullam consequatur laudantium aut quibusdam. Qui quidem fuga modi reprehenderit quos amet labore illum velit. Omnis dolores et ad molestiae reiciendis tempore assumenda saepe. Impedit fugiat provident laboriosam a sit.", 10, "sit", ".\\resources\\images\\poster.png", new DateOnly(2005, 2, 22), 30, 9, 0f, 1, "V3", new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9088), 0 },
                    { 4, 22, new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9100), "Eos laborum ut eligendi quibusdam dolorem molestiae. Et quas quisquam doloremque sint dolorum. Velit quae quia fugiat enim omnis ratione nobis.", 16, "repudiandae", ".\\resources\\images\\poster.png", new DateOnly(2012, 7, 19), 12, 5, 0f, 5, "F3", new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9267), 0 },
                    { 5, 22, new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9279), "Et dolorem accusantium dignissimos. Et exercitationem earum deleniti dolor quo ipsa quaerat. Aut ut qui totam libero voluptas et quis et. Totam ut natus impedit quia. Omnis magni velit illo. Autem aut dolorum.", 20, "quisquam", ".\\resources\\images\\poster.png", new DateOnly(2001, 12, 21), 18, 10, 0f, 5, "V3", new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9454), 0 },
                    { 6, 1, new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9466), "Quae culpa vel necessitatibus rerum ullam. Fugit laboriosam iusto suscipit. Sit ipsam consequatur totam eos doloribus expedita.", 24, "necessitatibus", ".\\resources\\images\\poster.png", new DateOnly(2005, 3, 19), 1, 8, 0f, 3, "M9", new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9552), 0 },
                    { 7, 20, new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9565), "Vel quia non eaque harum. Eligendi pariatur illo. Fugiat quia odit molestiae. Reiciendis magni enim odit porro. Magnam suscipit eos ut consequatur voluptates exercitationem eum occaecati soluta. Error et eligendi quae quaerat aut sunt non incidunt.", 30, "minus", ".\\resources\\images\\poster.png", new DateOnly(2021, 5, 4), 31, 5, 0f, 1, "D3", new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9743), 0 },
                    { 8, 8, new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9754), "Assumenda quis numquam sit sunt asperiores qui velit qui. Officia voluptatem praesentium. Nostrum repellendus sapiente ipsa magnam. Sint et dolor ut consequatur voluptatem iure fugit.", 12, "enim", ".\\resources\\images\\poster.png", new DateOnly(2001, 10, 7), 15, 10, 0f, 2, "D3", new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9919), 0 },
                    { 9, 3, new DateTime(2024, 12, 1, 14, 14, 36, 448, DateTimeKind.Local).AddTicks(9930), "Rerum veritatis natus maiores. Laborum ea magnam alias odit. Optio expedita doloremque a sint. Tempora voluptatem ratione dolorem natus delectus.", 25, "velit", ".\\resources\\images\\poster.png", new DateOnly(2007, 11, 17), 8, 7, 0f, 5, "D3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(20), 0 },
                    { 10, 27, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(33), "Impedit omnis sint. Pariatur at magni quis praesentium asperiores eveniet temporibus. Nostrum quisquam voluptatem provident sint ullam cupiditate doloremque.", 30, "ut", ".\\resources\\images\\poster.png", new DateOnly(2006, 1, 15), 8, 8, 0f, 4, "Z6", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(147), 0 },
                    { 11, 11, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(159), "Quam odio neque reprehenderit voluptatibus animi omnis quae. Consequatur soluta porro voluptas facilis saepe tempora ut. Repudiandae dolores veniam voluptatem occaecati nam sapiente doloremque incidunt nihil.", 22, "quis", ".\\resources\\images\\poster.png", new DateOnly(2004, 4, 13), 3, 6, 0f, 1, "Z6", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(254), 0 },
                    { 12, 1, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(265), "Eaque facilis quia. Tenetur rerum officiis rerum id iure. Aut sunt nemo est dolorem fuga qui cumque molestiae qui.", 24, "quos", ".\\resources\\images\\poster.png", new DateOnly(2023, 9, 27), 21, 7, 0f, 2, "Z6", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(430), 0 },
                    { 13, 25, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(441), "Numquam et sequi. Inventore et qui. Eum cupiditate nihil laudantium qui qui. Voluptatem quia totam non quisquam non quas id eaque laboriosam. Ex delectus expedita quae ea qui vero. Placeat eius mollitia animi iusto neque.", 12, "et", ".\\resources\\images\\poster.png", new DateOnly(2001, 9, 18), 25, 7, 0f, 2, "F3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(663), 0 },
                    { 14, 17, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(683), "Quod qui ut natus. Alias itaque delectus et temporibus itaque omnis. Eveniet porro magnam veritatis. Omnis quia in quasi voluptates asperiores beatae eius. Voluptatem aut labore vero repellat voluptatem sit. Illo cupiditate ad natus beatae est in vel.", 15, "optio", ".\\resources\\images\\poster.png", new DateOnly(2000, 10, 18), 16, 10, 0f, 1, "V3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(960), 0 },
                    { 15, 12, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(979), "Facere molestiae necessitatibus excepturi est cupiditate maxime. Earum rem alias est aut. Quo eveniet quia facere vitae quasi dolor temporibus.", 15, "ut", ".\\resources\\images\\poster.png", new DateOnly(2005, 1, 28), 31, 6, 0f, 1, "D3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(1118), 0 },
                    { 16, 7, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(1130), "Qui autem sed eos esse. Reprehenderit tempore ipsum adipisci incidunt aut. Eum quia est. Qui facere cupiditate tenetur non sunt quo laudantium laudantium suscipit. Ut quaerat libero sapiente quis magnam sint explicabo architecto. Corrupti sequi ea ea illum ducimus necessitatibus deserunt sapiente nam.", 4, "dicta", ".\\resources\\images\\poster.png", new DateOnly(2016, 12, 4), 5, 9, 0f, 4, "V3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(1366), 0 },
                    { 17, 3, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(1378), "Error voluptas non enim reprehenderit optio voluptatem necessitatibus nobis. Autem voluptas beatae nesciunt itaque quaerat in consectetur eveniet. Dignissimos iure maxime.", 3, "quia", ".\\resources\\images\\poster.png", new DateOnly(2014, 8, 7), 21, 6, 0f, 1, "M9", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(1517), 0 },
                    { 18, 31, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(1528), "Assumenda quia eum distinctio in repellat quo dolorem architecto accusamus. Veritatis veniam officia eos. Unde mollitia qui impedit omnis ullam aut iusto est. Laboriosam ipsam aut harum neque et. Sint minus enim perferendis voluptas voluptate voluptatem quidem.", 7, "consequatur", ".\\resources\\images\\poster.png", new DateOnly(2018, 7, 19), 22, 5, 0f, 3, "Z6", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(1658), 0 },
                    { 19, 19, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(1670), "Et cum qui expedita quibusdam aut ut. Doloribus iusto et quia eveniet itaque veritatis laborum voluptatibus. Repellendus eum assumenda sed atque. Rem commodi odio itaque quia. Molestias qui et qui autem labore.", 3, "ut", ".\\resources\\images\\poster.png", new DateOnly(2022, 1, 20), 12, 10, 0f, 3, "M9", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(1832), 0 },
                    { 20, 1, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(1844), "Corporis et corporis consequatur eos praesentium quaerat inventore ut. Aut autem libero magni saepe dignissimos natus. Sit voluptates impedit sunt. Aut modi vitae dolorem quibusdam sint quibusdam molestiae. Fugit fuga eos deserunt fugit est quia inventore. Rerum error amet eligendi dolores rerum ipsa sit velit commodi.", 14, "in", ".\\resources\\images\\poster.png", new DateOnly(2001, 9, 2), 29, 7, 0f, 3, "Z6", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2030), 0 },
                    { 21, 6, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2042), "Dolor enim beatae dolorem saepe deleniti. Culpa animi quam nihil veritatis rerum autem voluptas quam voluptatem. Dolor exercitationem excepturi eaque mollitia assumenda et ut. Dolores ad laudantium enim totam amet incidunt alias. Totam et perferendis rerum. Non non velit autem a corporis vero architecto illum qui.", 3, "reiciendis", ".\\resources\\images\\poster.png", new DateOnly(2007, 9, 3), 25, 5, 0f, 5, "F3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2209), 0 },
                    { 22, 11, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2222), "Est aut odio animi officia tempore quaerat qui voluptatem rem. Et quidem corrupti at officia qui. Ab labore temporibus natus non numquam et est magni.", 6, "quia", ".\\resources\\images\\poster.png", new DateOnly(2020, 1, 25), 2, 5, 0f, 3, "M9", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2378), 0 },
                    { 23, 16, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2390), "A voluptatem eos quod aperiam. Facilis voluptatibus consectetur id dignissimos velit minus voluptas. Minus natus est beatae culpa porro dolor consequatur veritatis. Ducimus labore qui ducimus.", 5, "quia", ".\\resources\\images\\poster.png", new DateOnly(2009, 10, 26), 24, 9, 0f, 2, "V3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2487), 0 },
                    { 24, 29, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2498), "Modi nostrum eum saepe tenetur corrupti tempora et sed vel. Accusamus laudantium nihil earum dicta quam pariatur minima. Animi dolor unde minus assumenda temporibus omnis non voluptates aut.", 20, "ex", ".\\resources\\images\\poster.png", new DateOnly(2019, 12, 28), 28, 7, 0f, 5, "V3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2659), 0 },
                    { 25, 1, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2672), "Temporibus nam culpa repellat iusto ut quaerat quis. Maxime harum et. Voluptate dolorem distinctio dolorem tempora quo quod corrupti voluptatem. Praesentium sit corporis enim. Odio minima voluptatibus qui quo.", 20, "asperiores", ".\\resources\\images\\poster.png", new DateOnly(2004, 1, 21), 7, 6, 0f, 1, "D3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2779), 0 },
                    { 26, 31, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2829), "Corrupti sed maiores voluptatum omnis est necessitatibus exercitationem reiciendis dolorum. Mollitia magnam voluptas autem. Est dicta voluptatem molestiae totam earum quo fugiat et eos. Porro omnis dolores voluptate commodi. Id dolor quo quia deleniti cum qui nostrum.", 23, "dolor", ".\\resources\\images\\poster.png", new DateOnly(2003, 10, 3), 29, 10, 0f, 3, "Z6", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2952), 0 },
                    { 27, 10, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(2965), "Molestiae est et ut facilis exercitationem dolore explicabo. Non aut sed voluptatem eos ipsam earum. Est in eum sapiente temporibus dolore dolor dolor. Neque ut laboriosam neque exercitationem quas cupiditate. Nam eum provident occaecati reprehenderit id quo sunt.", 11, "molestiae", ".\\resources\\images\\poster.png", new DateOnly(2016, 9, 2), 18, 8, 0f, 1, "Z6", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3141), 0 },
                    { 28, 25, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3155), "Quidem et vitae ea velit eum soluta. Magni et sit vel quo non. Eligendi tempore eveniet architecto iste aliquid autem. Impedit repellat iusto corporis enim dolores sed.", 7, "quas", ".\\resources\\images\\poster.png", new DateOnly(2005, 4, 1), 19, 6, 0f, 0, "M9", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3293), 0 },
                    { 29, 29, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3307), "Illo porro mollitia libero. Quis saepe minus dolorem sed excepturi. Non quos sunt exercitationem error in. Dolorum non provident cupiditate voluptas iste praesentium. Consequatur a et et.", 32, "aut", ".\\resources\\images\\poster.png", new DateOnly(2019, 4, 1), 17, 9, 0f, 1, "D3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3413), 0 },
                    { 30, 17, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3428), "Perferendis a eos. Magnam sunt dolorem sed. Rerum voluptas aut.", 16, "fugit", ".\\resources\\images\\poster.png", new DateOnly(2013, 4, 16), 20, 5, 0f, 2, "F3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3537), 0 },
                    { 31, 1, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3551), "Occaecati aspernatur ipsam veritatis deleniti tempore. Commodi voluptas quos dignissimos earum. Repellat a quasi.", 19, "cumque", ".\\resources\\images\\poster.png", new DateOnly(2020, 3, 8), 15, 10, 0f, 3, "M9", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3627), 0 },
                    { 32, 15, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3641), "Inventore ratione ut perspiciatis velit id dicta aut ut. Id et odit ducimus cum repellendus quis ad hic eligendi. Atque minus iusto dolor eveniet itaque. Quod eum et quidem quod neque ipsam minima culpa adipisci. Est voluptatem delectus quia at sequi et labore quo.", 8, "quasi", ".\\resources\\images\\poster.png", new DateOnly(2000, 9, 26), 8, 7, 0f, 3, "Z6", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3817), 0 },
                    { 33, 2, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(3830), "Ut rem nam molestias eaque qui minus qui reprehenderit dignissimos. Est dignissimos alias consequatur quae. Rerum autem voluptatem ab et fuga qui. Omnis quia aut quisquam ullam ipsa dolore ab perferendis in. Velit vitae delectus minus enim repellendus ex rerum qui. Id repellat esse dicta assumenda facilis non magnam labore.", 24, "nihil", ".\\resources\\images\\poster.png", new DateOnly(2008, 1, 29), 5, 8, 0f, 1, "Z6", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(4358), 0 },
                    { 34, 18, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(4373), "Sed repudiandae est tempora minus nulla modi saepe sit tenetur. Ut et nihil molestias laudantium unde explicabo. Tempore ad porro consectetur quisquam impedit rerum et ut quisquam. Qui sunt est. Quisquam est consectetur sint. Harum officia culpa blanditiis vitae voluptatem magnam qui rerum.", 8, "omnis", ".\\resources\\images\\poster.png", new DateOnly(2021, 4, 27), 30, 8, 0f, 5, "Z6", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(4568), 0 },
                    { 35, 30, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(4582), "Nostrum est molestias et voluptatem aliquam amet voluptates. Maxime suscipit in. Facilis ipsa itaque maiores beatae perferendis beatae ut.", 4, "accusantium", ".\\resources\\images\\poster.png", new DateOnly(2019, 1, 22), 23, 7, 0f, 5, "D3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(4663), 0 },
                    { 36, 26, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(4722), "Dolorem omnis debitis voluptas voluptates. Magnam ipsam facilis ab non esse et quia laudantium. Nihil pariatur voluptatem odio sunt quia rerum itaque voluptatum. Placeat asperiores dolorem itaque pariatur sed quasi aliquid aut. Rem maiores doloribus eum enim iste enim eius ullam dignissimos. Voluptate maiores sapiente cupiditate asperiores voluptas placeat.", 17, "occaecati", ".\\resources\\images\\poster.png", new DateOnly(2002, 7, 10), 18, 10, 0f, 0, "D3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(4868), 0 },
                    { 37, 12, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(4930), "Et saepe necessitatibus id ut velit. Est et omnis. Id alias error. Sunt quia fugiat suscipit ut nihil aut numquam expedita expedita.", 28, "error", ".\\resources\\images\\poster.png", new DateOnly(2009, 8, 5), 2, 6, 0f, 1, "M9", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(5023), 0 },
                    { 38, 29, new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(5038), "Totam sunt culpa omnis maiores est qui. Eaque quia asperiores vitae id est. Doloremque qui minima maxime consequatur veritatis. Repellat dignissimos inventore quasi. Et aut dignissimos. Accusamus et suscipit ipsum ratione.", 27, "rerum", ".\\resources\\images\\poster.png", new DateOnly(2006, 11, 6), 32, 10, 0f, 1, "D3", new DateTime(2024, 12, 1, 14, 14, 36, 449, DateTimeKind.Local).AddTicks(5204), 0 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBook",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 7, 3 },
                    { 34, 5 }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 31, "Completed", 2, new DateTime(2024, 12, 1, 6, 57, 56, 736, DateTimeKind.Local).AddTicks(6504), new DateTime(2024, 12, 6, 2, 18, 34, 550, DateTimeKind.Local).AddTicks(2672), new DateTime(2024, 11, 29, 2, 18, 34, 550, DateTimeKind.Local).AddTicks(2672), new DateTime(2024, 11, 30, 20, 35, 24, 420, DateTimeKind.Local).AddTicks(9302) },
                    { 2, 8, "Completed", 14, new DateTime(2024, 11, 27, 5, 15, 49, 291, DateTimeKind.Local).AddTicks(7166), new DateTime(2024, 12, 8, 11, 31, 28, 744, DateTimeKind.Local).AddTicks(9752), new DateTime(2024, 12, 1, 11, 31, 28, 744, DateTimeKind.Local).AddTicks(9752), new DateTime(2024, 12, 1, 3, 36, 22, 323, DateTimeKind.Local).AddTicks(8008) },
                    { 3, 17, "Canceled", 11, null, null, new DateTime(2024, 11, 29, 9, 11, 22, 304, DateTimeKind.Local).AddTicks(2656), null },
                    { 4, 36, "Completed", 2, new DateTime(2024, 11, 26, 18, 38, 53, 868, DateTimeKind.Local).AddTicks(256), new DateTime(2024, 12, 2, 12, 30, 37, 834, DateTimeKind.Local).AddTicks(9945), new DateTime(2024, 11, 25, 12, 30, 37, 834, DateTimeKind.Local).AddTicks(9945), new DateTime(2024, 11, 29, 17, 7, 35, 760, DateTimeKind.Local).AddTicks(775) },
                    { 5, 36, "Canceled", 11, null, null, new DateTime(2024, 12, 1, 5, 26, 46, 433, DateTimeKind.Local).AddTicks(9653), null },
                    { 6, 37, "Canceled", 10, null, null, new DateTime(2024, 11, 24, 15, 17, 59, 401, DateTimeKind.Local).AddTicks(3263), null },
                    { 7, 5, "Pending", 15, null, null, new DateTime(2024, 11, 30, 14, 33, 54, 205, DateTimeKind.Local).AddTicks(3434), null },
                    { 8, 10, "Pending", 14, null, null, new DateTime(2024, 11, 26, 16, 15, 24, 246, DateTimeKind.Local).AddTicks(7970), null },
                    { 9, 38, "Canceled", 3, null, null, new DateTime(2024, 11, 29, 0, 41, 24, 777, DateTimeKind.Local).AddTicks(4702), null },
                    { 10, 2, "Borrowed", 16, new DateTime(2024, 11, 26, 13, 40, 18, 960, DateTimeKind.Local).AddTicks(4601), new DateTime(2024, 12, 2, 15, 51, 45, 0, DateTimeKind.Local).AddTicks(6814), new DateTime(2024, 11, 25, 15, 51, 45, 0, DateTimeKind.Local).AddTicks(6814), null },
                    { 11, 38, "Pending", 10, null, null, new DateTime(2024, 11, 28, 21, 41, 38, 264, DateTimeKind.Local).AddTicks(9495), null },
                    { 12, 15, "Completed", 2, new DateTime(2024, 11, 28, 8, 13, 30, 974, DateTimeKind.Local).AddTicks(7130), new DateTime(2024, 12, 5, 4, 19, 22, 538, DateTimeKind.Local).AddTicks(491), new DateTime(2024, 11, 28, 4, 19, 22, 538, DateTimeKind.Local).AddTicks(491), new DateTime(2024, 11, 30, 12, 58, 25, 666, DateTimeKind.Local).AddTicks(6964) },
                    { 13, 12, "Pending", 1, null, null, new DateTime(2024, 11, 30, 8, 36, 47, 746, DateTimeKind.Local).AddTicks(331), null },
                    { 14, 10, "Pending", 13, null, null, new DateTime(2024, 11, 25, 8, 12, 52, 713, DateTimeKind.Local).AddTicks(8211), null },
                    { 15, 4, "Canceled", 6, null, null, new DateTime(2024, 11, 26, 21, 41, 3, 732, DateTimeKind.Local).AddTicks(2341), null },
                    { 16, 33, "Pending", 1, null, null, new DateTime(2024, 11, 30, 5, 6, 55, 429, DateTimeKind.Local).AddTicks(5119), null },
                    { 17, 25, "Pending", 2, null, null, new DateTime(2024, 11, 27, 14, 10, 51, 906, DateTimeKind.Local).AddTicks(7836), null },
                    { 18, 10, "Completed", 3, new DateTime(2024, 11, 29, 22, 57, 14, 274, DateTimeKind.Local).AddTicks(7093), new DateTime(2024, 12, 7, 17, 50, 44, 224, DateTimeKind.Local).AddTicks(5500), new DateTime(2024, 11, 30, 17, 50, 44, 224, DateTimeKind.Local).AddTicks(5500), new DateTime(2024, 12, 1, 10, 40, 47, 773, DateTimeKind.Local).AddTicks(7094) },
                    { 19, 15, "Completed", 12, new DateTime(2024, 11, 29, 23, 0, 35, 258, DateTimeKind.Local).AddTicks(2236), new DateTime(2024, 12, 6, 6, 27, 1, 41, DateTimeKind.Local).AddTicks(373), new DateTime(2024, 11, 29, 6, 27, 1, 41, DateTimeKind.Local).AddTicks(373), new DateTime(2024, 11, 29, 12, 19, 42, 186, DateTimeKind.Local).AddTicks(5217) },
                    { 20, 34, "Canceled", 6, null, null, new DateTime(2024, 11, 28, 8, 40, 29, 287, DateTimeKind.Local).AddTicks(7176), null },
                    { 21, 29, "Completed", 4, new DateTime(2024, 11, 26, 13, 57, 28, 53, DateTimeKind.Local).AddTicks(3281), new DateTime(2024, 12, 1, 22, 42, 17, 183, DateTimeKind.Local).AddTicks(9610), new DateTime(2024, 11, 24, 22, 42, 17, 183, DateTimeKind.Local).AddTicks(9610), new DateTime(2024, 11, 30, 21, 13, 30, 310, DateTimeKind.Local).AddTicks(4366) },
                    { 22, 3, "Pending", 5, null, null, new DateTime(2024, 11, 28, 10, 23, 58, 183, DateTimeKind.Local).AddTicks(4543), null },
                    { 23, 18, "Borrowed", 4, new DateTime(2024, 11, 27, 4, 53, 59, 848, DateTimeKind.Local).AddTicks(1879), new DateTime(2024, 12, 8, 6, 34, 22, 584, DateTimeKind.Local).AddTicks(1505), new DateTime(2024, 12, 1, 6, 34, 22, 584, DateTimeKind.Local).AddTicks(1505), null },
                    { 24, 30, "Completed", 9, new DateTime(2024, 12, 1, 1, 17, 24, 812, DateTimeKind.Local).AddTicks(2334), new DateTime(2024, 12, 1, 19, 9, 48, 100, DateTimeKind.Local).AddTicks(9188), new DateTime(2024, 11, 24, 19, 9, 48, 100, DateTimeKind.Local).AddTicks(9188), new DateTime(2024, 11, 29, 9, 39, 7, 20, DateTimeKind.Local).AddTicks(5524) },
                    { 25, 11, "Pending", 15, null, null, new DateTime(2024, 11, 30, 19, 7, 23, 112, DateTimeKind.Local).AddTicks(4513), null },
                    { 26, 2, "Pending", 15, null, null, new DateTime(2024, 11, 30, 6, 35, 3, 549, DateTimeKind.Local).AddTicks(2067), null },
                    { 27, 34, "Borrowed", 11, new DateTime(2024, 11, 27, 15, 26, 24, 626, DateTimeKind.Local).AddTicks(4921), new DateTime(2024, 12, 4, 14, 31, 54, 976, DateTimeKind.Local).AddTicks(6339), new DateTime(2024, 11, 27, 14, 31, 54, 976, DateTimeKind.Local).AddTicks(6339), null },
                    { 28, 18, "Canceled", 14, null, null, new DateTime(2024, 12, 1, 12, 39, 21, 394, DateTimeKind.Local).AddTicks(9218), null },
                    { 29, 19, "Canceled", 6, null, null, new DateTime(2024, 11, 28, 7, 44, 42, 322, DateTimeKind.Local).AddTicks(3879), null },
                    { 30, 15, "Borrowed", 4, new DateTime(2024, 11, 28, 6, 16, 30, 345, DateTimeKind.Local).AddTicks(9703), new DateTime(2024, 12, 8, 5, 59, 46, 41, DateTimeKind.Local).AddTicks(9132), new DateTime(2024, 12, 1, 5, 59, 46, 41, DateTimeKind.Local).AddTicks(9132), null },
                    { 31, 8, "Canceled", 9, null, null, new DateTime(2024, 11, 29, 21, 33, 55, 644, DateTimeKind.Local).AddTicks(2139), null },
                    { 32, 10, "Canceled", 10, null, null, new DateTime(2024, 12, 1, 5, 51, 7, 147, DateTimeKind.Local).AddTicks(8823), null },
                    { 33, 11, "Borrowed", 14, new DateTime(2024, 11, 26, 12, 29, 50, 731, DateTimeKind.Local).AddTicks(4422), new DateTime(2024, 12, 4, 21, 29, 54, 762, DateTimeKind.Local).AddTicks(1559), new DateTime(2024, 11, 27, 21, 29, 54, 762, DateTimeKind.Local).AddTicks(1559), null },
                    { 34, 17, "Pending", 7, null, null, new DateTime(2024, 11, 27, 8, 55, 40, 319, DateTimeKind.Local).AddTicks(3129), null },
                    { 35, 16, "Borrowed", 2, new DateTime(2024, 11, 27, 19, 55, 50, 94, DateTimeKind.Local).AddTicks(1018), new DateTime(2024, 12, 8, 12, 2, 24, 174, DateTimeKind.Local).AddTicks(6018), new DateTime(2024, 12, 1, 12, 2, 24, 174, DateTimeKind.Local).AddTicks(6018), null },
                    { 36, 16, "Pending", 1, null, null, new DateTime(2024, 11, 28, 0, 20, 19, 767, DateTimeKind.Local).AddTicks(4108), null },
                    { 37, 15, "Canceled", 5, null, null, new DateTime(2024, 11, 30, 2, 34, 34, 686, DateTimeKind.Local).AddTicks(993), null },
                    { 38, 31, "Borrowed", 13, new DateTime(2024, 11, 30, 15, 18, 30, 693, DateTimeKind.Local).AddTicks(5557), new DateTime(2024, 12, 4, 3, 27, 7, 811, DateTimeKind.Local).AddTicks(8132), new DateTime(2024, 11, 27, 3, 27, 7, 811, DateTimeKind.Local).AddTicks(8132), null },
                    { 39, 13, "Canceled", 16, null, null, new DateTime(2024, 11, 27, 7, 18, 15, 381, DateTimeKind.Local).AddTicks(8403), null },
                    { 40, 13, "Canceled", 12, null, null, new DateTime(2024, 11, 29, 8, 40, 51, 648, DateTimeKind.Local).AddTicks(7099), null }
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
