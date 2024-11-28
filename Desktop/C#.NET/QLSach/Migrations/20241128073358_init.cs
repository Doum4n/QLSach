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
                    public_at = table.Column<DateTime>(type: "date", nullable: false),
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
                    { 1, "Odit nihil aspernatur odit facilis eos.", "Bailee" },
                    { 2, "Qui a ducimus.", "Antwon" },
                    { 3, "Est molestiae aliquam nemo in.", "Nicklaus" },
                    { 4, "Dolores voluptate ut sint iste voluptatem deleniti.", "Willy" },
                    { 5, "Facere ea est sint quia unde veritatis.", "Kathryn" },
                    { 6, "Pariatur alias enim ab tenetur ut labore.", "Desiree" },
                    { 7, "Itaque ex sequi ullam blanditiis enim voluptatum perspiciatis rem culpa.", "Bernadette" },
                    { 8, "Enim et atque nihil iste molestias doloribus.", "Kendra" },
                    { 9, "Velit laboriosam in labore est ratione rerum ipsa hic.", "Liliana" },
                    { 10, "Sit optio dolores rem sit eaque veritatis perspiciatis excepturi.", "Maia" },
                    { 11, "Qui consequatur eum maxime.", "Hortense" },
                    { 12, "Sed consequuntur odit reprehenderit atque voluptatibus placeat rerum vel repellendus.", "Dedric" },
                    { 13, "Maiores optio voluptates nam magni ratione et id tempora deleniti.", "Kathlyn" },
                    { 14, "Eligendi ipsa a.", "Claudine" },
                    { 15, "Sed consequatur ipsa vel id qui unde minima autem.", "Miguel" },
                    { 16, "Eum saepe possimus quia eaque in modi.", "Morton" },
                    { 17, "Vel aut consequuntur ea.", "Nakia" },
                    { 18, "Consequuntur ea aut doloremque aliquid.", "Graham" },
                    { 19, "Id alias ut delectus.", "Lourdes" },
                    { 20, "Ut cumque optio quas eos doloribus impedit et labore.", "Reta" },
                    { 21, "Repudiandae id sit eos iste corrupti laudantium dignissimos quia.", "Rebeka" },
                    { 22, "Minima sequi quia.", "Alejandra" },
                    { 23, "Perspiciatis voluptas enim.", "Chester" },
                    { 24, "Quaerat porro vitae sit et molestias doloribus.", "Hoyt" },
                    { 25, "Vel in mollitia doloribus consequatur maiores odit qui officia.", "Kamille" },
                    { 26, "Est suscipit aspernatur.", "Ervin" },
                    { 27, "Non sit quod sunt quidem voluptatum et.", "Kayley" },
                    { 28, "Non tempore quia ratione et tenetur officiis a sit et.", "Kasandra" },
                    { 29, "Est sed ea amet fugiat numquam.", "Silas" },
                    { 30, "Commodi fugiat amet voluptas aut.", "Enid" },
                    { 31, "Sint assumenda tenetur dolor quo est vel aliquam nulla veritatis.", "Philip" },
                    { 32, "Cupiditate non cum nemo rerum sint magnam vero.", "Kristopher" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Soluta sapiente reprehenderit illum temporibus nam odit delectus temporibus qui quam et vel id eum exercitationem nisi illum amet nobis.", "earum", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 2, "Aut id similique quia eos laboriosam minima non libero qui deserunt modi quis cum in molestiae eligendi est ut suscipit.", "provident", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 3, "Nostrum consectetur voluptatum deleniti animi harum magnam nobis aliquam molestias reiciendis eius eum ut cumque aperiam magnam labore eaque ab.", "rerum", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 4, "Odit neque sint ratione est cupiditate cupiditate et non quo unde quia consequatur laudantium modi quaerat modi rerum recusandae dolorum.", "non", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 5, "Expedita ipsam ipsa dolores ducimus dolorem debitis repellendus accusantium aut esse et dolor non nulla natus libero quibusdam non excepturi.", "voluptas", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "dicta" },
                    { 2, "omnis" },
                    { 3, "et" },
                    { 4, "enim" },
                    { 5, "consequatur" },
                    { 6, "quam" },
                    { 7, "ea" },
                    { 8, "consequuntur" },
                    { 9, "magni" },
                    { 10, "autem" },
                    { 11, "voluptatem" },
                    { 12, "perferendis" },
                    { 13, "voluptates" },
                    { 14, "eveniet" },
                    { 15, "hic" },
                    { 16, "accusantium" },
                    { 17, "ut" },
                    { 18, "cupiditate" },
                    { 19, "dolor" },
                    { 20, "temporibus" },
                    { 21, "enim" },
                    { 22, "quia" },
                    { 23, "voluptatum" },
                    { 24, "delectus" },
                    { 25, "consequatur" },
                    { 26, "quis" },
                    { 27, "aspernatur" },
                    { 28, "est" },
                    { 29, "quos" },
                    { 30, "cupiditate" },
                    { 31, "corrupti" },
                    { 32, "quia" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "eum" },
                    { 2, "illo" },
                    { 3, "dolores" },
                    { 4, "quod" },
                    { 5, "consequuntur" },
                    { 6, "dolorem" },
                    { 7, "aliquam" },
                    { 8, "totam" },
                    { 9, "magni" },
                    { 10, "ut" },
                    { 11, "enim" },
                    { 12, "assumenda" },
                    { 13, "ut" },
                    { 14, "illo" },
                    { 15, "quo" },
                    { 16, "omnis" },
                    { 17, "nobis" },
                    { 18, "qui" },
                    { 19, "explicabo" },
                    { 20, "id" },
                    { 21, "delectus" },
                    { 22, "soluta" },
                    { 23, "quia" },
                    { 24, "qui" },
                    { 25, "consequatur" },
                    { 26, "error" },
                    { 27, "dolorum" },
                    { 28, "consectetur" },
                    { 29, "quia" },
                    { 30, "fugiat" },
                    { 31, "aliquam" },
                    { 32, "cumque" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Lilian Metz", "optio", "User", "Rasheed", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 2, "Ruben Jacobs", "et", "Admin", "Jana", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 3, "Erik Pollich", "animi", "User", "Vallie", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 4, "Jada Feeney", "dicta", "Staff", "Daisha", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 5, "Hipolito Schinner", "suscipit", "Staff", "Danielle", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 6, "Gabe Ortiz", "qui", "Admin", "Ervin", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 7, "Gregoria Emmerich", "neque", "Admin", "Haleigh", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 8, "Alvis Cormier", "est", "User", "Kennedi", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 9, "Jazmyne Crist", "et", "Staff", "Myrtice", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 10, "Jada Pfannerstill", "odio", "Staff", "Joyce", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 11, "Grover Goodwin", "et", "Staff", "Brandon", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 12, "Emmie Kilback", "et", "User", "King", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 13, "Camron Gerlach", "expedita", "Admin", "Assunta", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 14, "Destiney Kshlerin", "voluptatem", "Staff", "Glen", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 15, "Gunner Ziemann", "sed", "Admin", "Guy", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) },
                    { 16, "Aubree Paucek", "earum", "Admin", "Philip", new DateOnly(2024, 11, 28), new DateOnly(2024, 11, 28) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "photoPath", "public_at", "publisher_id", "quantity", "rating", "remaining", "updated_at", "views" },
                values: new object[,]
                {
                    { 1, 23, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(8030), "Totam labore consectetur fugit provident. Eos minima sed vitae laborum dicta consequatur officia sed numquam. Veritatis ex voluptas sit qui suscipit fuga dicta. Amet eligendi quo. Est itaque suscipit.", 28, "maxime", ".\\resources\\images\\poster.png", new DateTime(2004, 4, 20, 3, 13, 28, 737, DateTimeKind.Unspecified).AddTicks(8198), 6, 7, 0f, 2, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(8932), 0 },
                    { 2, 2, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9004), "Repellendus id veritatis velit. Atque et et sit id corrupti. Et veritatis quo optio quam consequuntur consequatur aut. Quia est cum.", 4, "quam", ".\\resources\\images\\poster.png", new DateTime(2011, 1, 21, 5, 56, 12, 507, DateTimeKind.Unspecified).AddTicks(7875), 14, 7, 0f, 2, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9124), 0 },
                    { 3, 4, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9139), "Ut nihil minus porro sint libero repudiandae eligendi. Rem officiis odio voluptates. Minus cumque necessitatibus quia.", 30, "quia", ".\\resources\\images\\poster.png", new DateTime(2001, 10, 19, 15, 29, 37, 463, DateTimeKind.Unspecified).AddTicks(7321), 7, 8, 0f, 2, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9225), 0 },
                    { 4, 1, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9238), "Facere quos exercitationem et. Fugit earum non et molestiae laudantium explicabo itaque ipsam. Qui velit aut consequatur. Tenetur enim magnam amet totam magnam. Quo porro alias eos sapiente similique aut aut rerum. Accusantium velit est repellat saepe nihil et ut autem adipisci.", 30, "tempore", ".\\resources\\images\\poster.png", new DateTime(2013, 9, 3, 9, 56, 25, 626, DateTimeKind.Unspecified).AddTicks(8051), 13, 6, 0f, 3, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9383), 0 },
                    { 5, 29, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9395), "Illo eligendi voluptates esse repudiandae et qui. Et aut consectetur unde. Molestiae libero dignissimos sit enim sit non velit nulla vel.", 31, "odit", ".\\resources\\images\\poster.png", new DateTime(2021, 2, 6, 6, 32, 3, 658, DateTimeKind.Unspecified).AddTicks(7906), 7, 6, 0f, 2, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9479), 0 },
                    { 6, 28, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9492), "Quia non non qui laborum accusantium officiis ab. Officia qui odio explicabo. Quas ut magni cupiditate velit nostrum. Animi quis quaerat. Omnis dolorem non.", 18, "sit", ".\\resources\\images\\poster.png", new DateTime(2006, 6, 10, 7, 13, 45, 148, DateTimeKind.Unspecified).AddTicks(4536), 28, 7, 0f, 2, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9642), 0 },
                    { 7, 4, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9654), "Magnam debitis quasi magni ex quas adipisci molestias officia pariatur. Ducimus quis placeat. Suscipit repellendus sunt corrupti neque.", 3, "totam", ".\\resources\\images\\poster.png", new DateTime(2022, 4, 8, 0, 6, 9, 164, DateTimeKind.Unspecified).AddTicks(6342), 18, 10, 0f, 0, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9726), 0 },
                    { 8, 23, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9738), "Nulla commodi at molestiae enim. Officiis dolor ipsum. Ut ut sit fuga aut.", 19, "ipsam", ".\\resources\\images\\poster.png", new DateTime(2001, 5, 23, 21, 16, 52, 791, DateTimeKind.Unspecified).AddTicks(3555), 16, 8, 0f, 1, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9811), 0 },
                    { 9, 15, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9822), "Nemo autem et nobis repellat qui quam ut. Repudiandae sed vero voluptatem quo est necessitatibus magni. Recusandae voluptatem quis dolore nihil facere cum. Tenetur officiis omnis deleniti voluptatibus voluptate libero veritatis.", 5, "excepturi", ".\\resources\\images\\poster.png", new DateTime(2007, 5, 21, 0, 36, 55, 697, DateTimeKind.Unspecified).AddTicks(2742), 9, 5, 0f, 3, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9926), 0 },
                    { 10, 23, new DateTime(2024, 11, 28, 14, 33, 58, 484, DateTimeKind.Local).AddTicks(9937), "Quo voluptatem vel et veniam quia velit similique. Adipisci odio corrupti voluptas et voluptatem autem totam soluta voluptas. Molestias praesentium repellat explicabo veritatis aperiam officia.", 22, "optio", ".\\resources\\images\\poster.png", new DateTime(2003, 4, 18, 19, 18, 3, 273, DateTimeKind.Unspecified).AddTicks(7712), 7, 10, 0f, 1, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(29), 0 },
                    { 11, 21, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(41), "Voluptas cumque nam minus omnis in dolores perferendis voluptatem assumenda. Ex eos eos ab sint. Aut mollitia labore esse qui eos. Cumque enim nulla consequuntur impedit labore.", 15, "in", ".\\resources\\images\\poster.png", new DateTime(2005, 5, 7, 0, 9, 11, 475, DateTimeKind.Unspecified).AddTicks(6325), 24, 8, 0f, 4, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(135), 0 },
                    { 12, 28, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(148), "Sed animi provident aut dignissimos qui officia mollitia quo magnam. Hic id ut et facere nemo modi ipsum modi. Dolores nobis laudantium magni quas blanditiis. Eum rerum corrupti ad maxime deleniti atque qui sint.", 25, "repellendus", ".\\resources\\images\\poster.png", new DateTime(2019, 2, 16, 9, 22, 14, 152, DateTimeKind.Unspecified).AddTicks(9823), 7, 9, 0f, 1, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(310), 0 },
                    { 13, 18, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(322), "Mollitia sit sed assumenda quam. Cum illo aut error. Dolorem rerum distinctio nihil voluptatem.", 22, "ut", ".\\resources\\images\\poster.png", new DateTime(2019, 10, 14, 5, 53, 26, 738, DateTimeKind.Unspecified).AddTicks(7756), 28, 10, 0f, 3, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(399), 0 },
                    { 14, 14, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(411), "Nemo aspernatur distinctio recusandae ut dolorum aut quaerat vitae dolore. Rerum illo commodi possimus unde. Et voluptatem doloremque neque voluptas nihil nulla nesciunt unde.", 32, "consequatur", ".\\resources\\images\\poster.png", new DateTime(2019, 7, 10, 10, 36, 30, 589, DateTimeKind.Unspecified).AddTicks(2616), 14, 8, 0f, 0, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(497), 0 },
                    { 15, 26, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(509), "Non et qui ut et architecto magni non possimus assumenda. Et et aliquam rerum aut voluptas perspiciatis. Quo qui ipsam ullam ipsum distinctio fugiat natus quisquam. Vel nihil ducimus minima sunt quas voluptatem aut ut illo. Iure consequuntur voluptas ex unde quos. Sit velit temporibus vel nulla unde quod ad quae.", 13, "voluptatem", ".\\resources\\images\\poster.png", new DateTime(2005, 8, 18, 15, 25, 11, 613, DateTimeKind.Unspecified).AddTicks(883), 16, 9, 0f, 5, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(654), 0 },
                    { 16, 4, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(666), "Fugiat rerum sequi doloribus non voluptas itaque. Laboriosam blanditiis quas. Et omnis quis ab fuga reprehenderit ut. Velit sunt corrupti praesentium. Occaecati quaerat non voluptatem. Facere et est.", 3, "soluta", ".\\resources\\images\\poster.png", new DateTime(2021, 2, 2, 3, 59, 18, 350, DateTimeKind.Unspecified).AddTicks(5290), 12, 6, 0f, 1, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(769), 0 },
                    { 17, 28, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(781), "Aut non fugiat quia in temporibus dignissimos amet rerum. Est nesciunt natus sint. Minus eum veritatis ex. Nesciunt temporibus vitae minus. Libero dignissimos ea possimus itaque sit fugiat dolores dolores.", 11, "temporibus", ".\\resources\\images\\poster.png", new DateTime(2019, 2, 18, 2, 12, 32, 248, DateTimeKind.Unspecified).AddTicks(7951), 22, 7, 0f, 5, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(917), 0 },
                    { 18, 2, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(933), "Eum qui dignissimos suscipit reiciendis. Corrupti provident in facere cupiditate consectetur incidunt. Quibusdam minus explicabo. Sed ut at omnis. Eum eos natus et. Explicabo velit fugiat dolorem velit ea.", 9, "atque", ".\\resources\\images\\poster.png", new DateTime(2014, 7, 16, 22, 32, 40, 674, DateTimeKind.Unspecified).AddTicks(2178), 12, 6, 0f, 4, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1053), 0 },
                    { 19, 11, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1066), "Soluta non minus laborum ut debitis vel pariatur doloribus in. Distinctio voluptatibus enim sint. Voluptatum corporis magni iste. Possimus repellat reprehenderit ratione voluptatem sapiente dolorem ad. Corporis ab et est omnis hic. Quam qui quisquam quo ea temporibus eum.", 21, "aliquid", ".\\resources\\images\\poster.png", new DateTime(2023, 8, 27, 13, 20, 15, 37, DateTimeKind.Unspecified).AddTicks(7285), 19, 5, 0f, 0, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1191), 0 },
                    { 20, 31, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1203), "Sed incidunt voluptas. Qui enim dicta tempora. Natus ut quia mollitia inventore porro. Aperiam non nihil dolorem adipisci sit fugit asperiores vitae quia.", 26, "enim", ".\\resources\\images\\poster.png", new DateTime(2005, 9, 8, 19, 37, 32, 606, DateTimeKind.Unspecified).AddTicks(3696), 24, 5, 0f, 1, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1295), 0 },
                    { 21, 14, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1307), "Quidem alias voluptatem deleniti debitis cum ullam. Tenetur sed quam. Ut eos qui excepturi velit autem voluptas.", 23, "ut", ".\\resources\\images\\poster.png", new DateTime(2015, 6, 23, 20, 26, 10, 670, DateTimeKind.Unspecified).AddTicks(4235), 13, 10, 0f, 4, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1378), 0 },
                    { 22, 16, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1391), "Necessitatibus quia doloribus eveniet quibusdam. Incidunt inventore quasi provident molestiae. Rerum itaque non quia quo beatae porro. Autem rerum dicta molestiae est reiciendis laborum ipsa.", 15, "dignissimos", ".\\resources\\images\\poster.png", new DateTime(2007, 6, 9, 19, 4, 51, 823, DateTimeKind.Unspecified).AddTicks(373), 21, 7, 0f, 2, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1484), 0 },
                    { 23, 14, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1504), "Quia et enim est. Qui aperiam necessitatibus molestiae nulla quas voluptates ut in. Consequatur quasi vero doloribus ex animi et. Ut et veritatis. Rerum dolor similique nam autem nemo labore suscipit ipsam et.", 25, "ut", ".\\resources\\images\\poster.png", new DateTime(2003, 8, 1, 13, 26, 8, 740, DateTimeKind.Unspecified).AddTicks(6095), 3, 5, 0f, 0, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1659), 0 },
                    { 24, 7, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1672), "Aperiam et nobis iste non aliquam quia accusamus ut non. Similique rem vero perspiciatis dolor exercitationem reiciendis. Quae deserunt sunt id. Nesciunt nihil voluptate voluptatum inventore. Beatae minima totam.", 16, "nihil", ".\\resources\\images\\poster.png", new DateTime(2021, 12, 12, 15, 45, 25, 231, DateTimeKind.Unspecified).AddTicks(4828), 7, 9, 0f, 0, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1779), 0 },
                    { 25, 10, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1793), "Dolores explicabo aspernatur ipsam. Ad in sed distinctio aut sed et. Aperiam doloribus a sit veritatis aliquid laboriosam sit cupiditate culpa.", 16, "perspiciatis", ".\\resources\\images\\poster.png", new DateTime(2023, 4, 3, 0, 0, 26, 511, DateTimeKind.Unspecified).AddTicks(5919), 7, 7, 0f, 5, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1885), 0 },
                    { 26, 2, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1899), "Ut deleniti exercitationem minus qui qui maiores rerum aut dolores. Ullam eveniet et fugit omnis. Facere consequatur et natus illo enim aut. Voluptatibus iste at delectus.", 7, "ut", ".\\resources\\images\\poster.png", new DateTime(2010, 3, 31, 22, 25, 51, 73, DateTimeKind.Unspecified).AddTicks(9319), 28, 6, 0f, 2, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(1995), 0 },
                    { 27, 16, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2009), "Sit voluptatem eligendi. Iste consequatur rerum minima quas voluptatem. Distinctio illum laudantium quidem magnam omnis quo molestiae corporis nihil. Quas explicabo voluptate quia enim ipsa. Doloribus atque placeat officia maxime odit. Ab nemo in.", 28, "tempora", ".\\resources\\images\\poster.png", new DateTime(1999, 2, 8, 19, 23, 16, 523, DateTimeKind.Unspecified).AddTicks(9967), 2, 6, 0f, 0, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2129), 0 },
                    { 28, 13, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2149), "Ut ea aperiam voluptate et distinctio eum dicta. Distinctio sapiente minima itaque aperiam sed magnam soluta nobis. Accusamus quos natus temporibus facilis natus facere sequi id. Amet at ea dignissimos voluptatibus velit quam alias. Laboriosam perspiciatis ad rem voluptatem consectetur ullam quis placeat. Aut velit maxime exercitationem et laborum dolorum.", 27, "aspernatur", ".\\resources\\images\\poster.png", new DateTime(2004, 4, 19, 19, 15, 24, 611, DateTimeKind.Unspecified).AddTicks(5868), 20, 5, 0f, 3, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2347), 0 },
                    { 29, 6, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2362), "Id suscipit nisi et eos et voluptate. Non eos numquam consequatur ut ipsam. Non molestiae suscipit ipsa eos atque sunt qui commodi. Saepe iure facere. Illum odit ipsam.", 3, "sunt", ".\\resources\\images\\poster.png", new DateTime(2024, 10, 5, 21, 1, 26, 485, DateTimeKind.Unspecified).AddTicks(7264), 4, 10, 0f, 4, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2469), 0 },
                    { 30, 12, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2483), "Eius omnis tempore sit tempore ut ipsam. Doloribus incidunt et modi dolorem sed. A dolore repellendus quaerat voluptate rerum et unde non inventore. Sunt id modi. Qui maxime laboriosam dolorem recusandae nostrum. Rerum rerum impedit rerum.", 6, "delectus", ".\\resources\\images\\poster.png", new DateTime(2019, 9, 12, 11, 39, 20, 128, DateTimeKind.Unspecified).AddTicks(6724), 29, 8, 0f, 4, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2598), 0 },
                    { 31, 5, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2611), "Sed et nobis nihil itaque. Autem non sunt voluptas facilis aut id. Reiciendis esse vel ex temporibus saepe hic. Tempora ab numquam optio est aliquam temporibus. Voluptatem inventore in autem enim asperiores eaque et dolorem ea.", 3, "explicabo", ".\\resources\\images\\poster.png", new DateTime(2018, 11, 8, 0, 49, 13, 661, DateTimeKind.Unspecified).AddTicks(7838), 28, 8, 0f, 0, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2730), 0 },
                    { 32, 12, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2744), "Eos voluptatem sed. Autem est neque. Enim asperiores numquam eveniet quae tempore minus odio totam. Voluptatibus omnis eveniet dolorum inventore suscipit rerum et. In est perspiciatis et eius voluptas est totam quaerat.", 6, "earum", ".\\resources\\images\\poster.png", new DateTime(2010, 8, 12, 21, 52, 43, 923, DateTimeKind.Unspecified).AddTicks(4856), 31, 9, 0f, 1, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2902), 0 },
                    { 33, 3, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(2920), "Eum et possimus. Earum totam aut odit quasi. Repellat sit nesciunt eos pariatur voluptas qui nihil.", 27, "est", ".\\resources\\images\\poster.png", new DateTime(2011, 10, 5, 23, 24, 38, 158, DateTimeKind.Unspecified).AddTicks(3134), 14, 5, 0f, 5, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(3002), 0 },
                    { 34, 18, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(3017), "Sed in nobis harum. Illum doloremque nisi commodi eos qui blanditiis debitis ut ab. Saepe non illum impedit et itaque facilis distinctio. Aut quia enim ipsum id. Eius impedit ipsam.", 32, "ex", ".\\resources\\images\\poster.png", new DateTime(2004, 8, 8, 15, 2, 48, 632, DateTimeKind.Unspecified).AddTicks(7236), 4, 9, 0f, 0, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(3127), 0 },
                    { 35, 4, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(3141), "Eveniet et eius voluptas et molestiae neque. Fugit voluptatem tempora dolorem porro voluptas et voluptas maiores aut. Distinctio neque voluptatibus tenetur est quia quo. Earum et ipsum aperiam officia sed aperiam. Ut omnis eos. Ab ex non aut commodi nostrum vel dolores aut veritatis.", 21, "nisi", ".\\resources\\images\\poster.png", new DateTime(2011, 2, 4, 14, 1, 36, 476, DateTimeKind.Unspecified).AddTicks(2074), 21, 5, 0f, 3, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(3277), 0 },
                    { 36, 24, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(3291), "Numquam quae iure fugiat eius et. Dolor fuga animi et aspernatur. Aspernatur esse rerum dignissimos esse.", 30, "quae", ".\\resources\\images\\poster.png", new DateTime(2017, 10, 31, 14, 28, 17, 23, DateTimeKind.Unspecified).AddTicks(3683), 28, 6, 0f, 2, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(3367), 0 },
                    { 37, 31, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(3382), "Esse minus sed qui non officiis veniam id repellendus temporibus. Nulla dolorem sunt ex fugiat qui deserunt. Commodi voluptatem ab iure quia blanditiis eum.", 8, "dolor", ".\\resources\\images\\poster.png", new DateTime(2017, 4, 17, 16, 28, 23, 115, DateTimeKind.Unspecified).AddTicks(7024), 29, 9, 0f, 3, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(3657), 0 },
                    { 38, 9, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(3672), "Sit amet porro iusto dolores ut consectetur numquam rem quis. Architecto eos dolorum blanditiis sequi velit qui perspiciatis. Tempore corrupti unde incidunt et omnis iure et voluptatem aspernatur.", 29, "voluptatem", ".\\resources\\images\\poster.png", new DateTime(2002, 12, 29, 12, 2, 31, 53, DateTimeKind.Unspecified).AddTicks(1142), 12, 9, 0f, 2, new DateTime(2024, 11, 28, 14, 33, 58, 485, DateTimeKind.Local).AddTicks(3768), 0 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBook",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 8, 4 },
                    { 20, 2 }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 5, "Canceled", 7, null, null, new DateTime(2024, 11, 25, 9, 18, 42, 648, DateTimeKind.Local).AddTicks(6599), null },
                    { 2, 26, "Borrowed", 5, new DateTime(2024, 11, 25, 9, 38, 51, 384, DateTimeKind.Local).AddTicks(3146), new DateTime(2024, 11, 29, 4, 59, 42, 37, DateTimeKind.Local).AddTicks(5131), new DateTime(2024, 11, 22, 4, 59, 42, 37, DateTimeKind.Local).AddTicks(5131), null },
                    { 3, 6, "Canceled", 8, null, null, new DateTime(2024, 11, 23, 0, 31, 36, 663, DateTimeKind.Local).AddTicks(3158), null },
                    { 4, 21, "Completed", 4, new DateTime(2024, 11, 26, 15, 54, 51, 714, DateTimeKind.Local).AddTicks(5713), new DateTime(2024, 12, 4, 9, 35, 10, 765, DateTimeKind.Local).AddTicks(3841), new DateTime(2024, 11, 27, 9, 35, 10, 765, DateTimeKind.Local).AddTicks(3841), new DateTime(2024, 11, 28, 4, 21, 40, 290, DateTimeKind.Local).AddTicks(1752) },
                    { 5, 2, "Completed", 10, new DateTime(2024, 11, 27, 23, 48, 23, 970, DateTimeKind.Local).AddTicks(9729), new DateTime(2024, 12, 2, 9, 27, 19, 137, DateTimeKind.Local).AddTicks(9996), new DateTime(2024, 11, 25, 9, 27, 19, 137, DateTimeKind.Local).AddTicks(9996), new DateTime(2024, 11, 27, 10, 46, 50, 162, DateTimeKind.Local).AddTicks(9515) },
                    { 6, 33, "Borrowed", 2, new DateTime(2024, 11, 27, 15, 12, 15, 12, DateTimeKind.Local).AddTicks(5116), new DateTime(2024, 11, 29, 6, 23, 30, 28, DateTimeKind.Local).AddTicks(6847), new DateTime(2024, 11, 22, 6, 23, 30, 28, DateTimeKind.Local).AddTicks(6847), null },
                    { 7, 29, "Canceled", 14, null, null, new DateTime(2024, 11, 27, 17, 6, 20, 491, DateTimeKind.Local).AddTicks(8580), null },
                    { 8, 24, "Completed", 14, new DateTime(2024, 11, 25, 10, 2, 51, 560, DateTimeKind.Local).AddTicks(1551), new DateTime(2024, 12, 1, 9, 53, 19, 182, DateTimeKind.Local).AddTicks(1459), new DateTime(2024, 11, 24, 9, 53, 19, 182, DateTimeKind.Local).AddTicks(1459), new DateTime(2024, 11, 26, 23, 58, 15, 792, DateTimeKind.Local).AddTicks(3138) },
                    { 9, 8, "Completed", 11, new DateTime(2024, 11, 24, 7, 23, 54, 200, DateTimeKind.Local).AddTicks(3278), new DateTime(2024, 12, 1, 12, 47, 11, 195, DateTimeKind.Local).AddTicks(6768), new DateTime(2024, 11, 24, 12, 47, 11, 195, DateTimeKind.Local).AddTicks(6768), new DateTime(2024, 11, 25, 23, 13, 41, 777, DateTimeKind.Local).AddTicks(2583) },
                    { 10, 4, "Pending", 9, null, null, new DateTime(2024, 11, 24, 22, 23, 40, 548, DateTimeKind.Local).AddTicks(7765), null },
                    { 11, 36, "Borrowed", 11, new DateTime(2024, 11, 23, 2, 54, 56, 369, DateTimeKind.Local).AddTicks(2384), new DateTime(2024, 12, 4, 21, 31, 35, 235, DateTimeKind.Local).AddTicks(5696), new DateTime(2024, 11, 27, 21, 31, 35, 235, DateTimeKind.Local).AddTicks(5696), null },
                    { 12, 3, "Pending", 12, null, null, new DateTime(2024, 11, 24, 10, 8, 23, 719, DateTimeKind.Local).AddTicks(4424), null },
                    { 13, 6, "Borrowed", 9, new DateTime(2024, 11, 27, 4, 53, 22, 709, DateTimeKind.Local).AddTicks(9315), new DateTime(2024, 11, 30, 14, 0, 57, 723, DateTimeKind.Local).AddTicks(3575), new DateTime(2024, 11, 23, 14, 0, 57, 723, DateTimeKind.Local).AddTicks(3575), null },
                    { 14, 8, "Borrowed", 13, new DateTime(2024, 11, 27, 19, 11, 36, 859, DateTimeKind.Local).AddTicks(9435), new DateTime(2024, 11, 30, 13, 51, 33, 249, DateTimeKind.Local).AddTicks(117), new DateTime(2024, 11, 23, 13, 51, 33, 249, DateTimeKind.Local).AddTicks(117), null },
                    { 15, 13, "Canceled", 8, null, null, new DateTime(2024, 11, 23, 1, 54, 40, 59, DateTimeKind.Local).AddTicks(6540), null },
                    { 16, 12, "Canceled", 15, null, null, new DateTime(2024, 11, 22, 6, 37, 40, 135, DateTimeKind.Local).AddTicks(3023), null },
                    { 17, 33, "Completed", 16, new DateTime(2024, 11, 22, 17, 20, 43, 32, DateTimeKind.Local).AddTicks(6766), new DateTime(2024, 11, 30, 7, 9, 12, 220, DateTimeKind.Local).AddTicks(3792), new DateTime(2024, 11, 23, 7, 9, 12, 220, DateTimeKind.Local).AddTicks(3792), new DateTime(2024, 11, 27, 14, 19, 2, 544, DateTimeKind.Local).AddTicks(7222) },
                    { 18, 34, "Borrowed", 2, new DateTime(2024, 11, 25, 13, 59, 31, 425, DateTimeKind.Local).AddTicks(135), new DateTime(2024, 12, 2, 20, 48, 13, 216, DateTimeKind.Local).AddTicks(7190), new DateTime(2024, 11, 25, 20, 48, 13, 216, DateTimeKind.Local).AddTicks(7190), null },
                    { 19, 37, "Borrowed", 8, new DateTime(2024, 11, 27, 3, 35, 34, 954, DateTimeKind.Local).AddTicks(3180), new DateTime(2024, 12, 2, 11, 58, 6, 918, DateTimeKind.Local).AddTicks(7438), new DateTime(2024, 11, 25, 11, 58, 6, 918, DateTimeKind.Local).AddTicks(7438), null },
                    { 20, 24, "Canceled", 6, null, null, new DateTime(2024, 11, 26, 20, 49, 25, 637, DateTimeKind.Local).AddTicks(2862), null },
                    { 21, 30, "Borrowed", 11, new DateTime(2024, 11, 28, 1, 54, 25, 666, DateTimeKind.Local).AddTicks(4169), new DateTime(2024, 12, 5, 8, 50, 52, 918, DateTimeKind.Local).AddTicks(7501), new DateTime(2024, 11, 28, 8, 50, 52, 918, DateTimeKind.Local).AddTicks(7501), null },
                    { 22, 24, "Borrowed", 3, new DateTime(2024, 11, 25, 12, 0, 1, 609, DateTimeKind.Local).AddTicks(9874), new DateTime(2024, 11, 30, 12, 43, 49, 528, DateTimeKind.Local).AddTicks(3398), new DateTime(2024, 11, 23, 12, 43, 49, 528, DateTimeKind.Local).AddTicks(3398), null },
                    { 23, 7, "Canceled", 1, null, null, new DateTime(2024, 11, 26, 23, 0, 24, 667, DateTimeKind.Local).AddTicks(2990), null },
                    { 24, 5, "Pending", 6, null, null, new DateTime(2024, 11, 22, 20, 53, 41, 149, DateTimeKind.Local).AddTicks(1339), null },
                    { 25, 11, "Canceled", 7, null, null, new DateTime(2024, 11, 28, 2, 46, 35, 869, DateTimeKind.Local).AddTicks(6895), null },
                    { 26, 37, "Pending", 8, null, null, new DateTime(2024, 11, 21, 16, 5, 31, 213, DateTimeKind.Local).AddTicks(3600), null },
                    { 27, 31, "Pending", 6, null, null, new DateTime(2024, 11, 27, 19, 42, 42, 927, DateTimeKind.Local).AddTicks(4376), null },
                    { 28, 23, "Completed", 16, new DateTime(2024, 11, 27, 17, 16, 55, 442, DateTimeKind.Local).AddTicks(7942), new DateTime(2024, 11, 29, 7, 55, 17, 733, DateTimeKind.Local).AddTicks(359), new DateTime(2024, 11, 22, 7, 55, 17, 733, DateTimeKind.Local).AddTicks(359), new DateTime(2024, 11, 27, 22, 7, 23, 977, DateTimeKind.Local).AddTicks(1087) },
                    { 29, 36, "Canceled", 3, null, null, new DateTime(2024, 11, 21, 15, 52, 35, 734, DateTimeKind.Local).AddTicks(5239), null },
                    { 30, 11, "Pending", 15, null, null, new DateTime(2024, 11, 22, 2, 11, 52, 387, DateTimeKind.Local).AddTicks(9151), null },
                    { 31, 20, "Pending", 15, null, null, new DateTime(2024, 11, 22, 8, 55, 27, 368, DateTimeKind.Local).AddTicks(291), null },
                    { 32, 12, "Borrowed", 14, new DateTime(2024, 11, 23, 20, 26, 59, 828, DateTimeKind.Local).AddTicks(2937), new DateTime(2024, 12, 5, 7, 29, 0, 730, DateTimeKind.Local).AddTicks(3018), new DateTime(2024, 11, 28, 7, 29, 0, 730, DateTimeKind.Local).AddTicks(3018), null },
                    { 33, 33, "Pending", 9, null, null, new DateTime(2024, 11, 28, 9, 54, 44, 322, DateTimeKind.Local).AddTicks(1909), null },
                    { 34, 10, "Borrowed", 1, new DateTime(2024, 11, 23, 14, 26, 50, 697, DateTimeKind.Local).AddTicks(9149), new DateTime(2024, 12, 3, 13, 20, 50, 881, DateTimeKind.Local).AddTicks(9636), new DateTime(2024, 11, 26, 13, 20, 50, 881, DateTimeKind.Local).AddTicks(9636), null },
                    { 35, 20, "Borrowed", 1, new DateTime(2024, 11, 28, 4, 48, 33, 965, DateTimeKind.Local).AddTicks(5272), new DateTime(2024, 12, 5, 4, 8, 42, 772, DateTimeKind.Local).AddTicks(2441), new DateTime(2024, 11, 28, 4, 8, 42, 772, DateTimeKind.Local).AddTicks(2441), null },
                    { 36, 25, "Pending", 4, null, null, new DateTime(2024, 11, 28, 13, 37, 16, 187, DateTimeKind.Local).AddTicks(3781), null },
                    { 37, 35, "Completed", 12, new DateTime(2024, 11, 24, 18, 55, 38, 571, DateTimeKind.Local).AddTicks(4877), new DateTime(2024, 12, 3, 4, 49, 23, 906, DateTimeKind.Local).AddTicks(5565), new DateTime(2024, 11, 26, 4, 49, 23, 906, DateTimeKind.Local).AddTicks(5565), new DateTime(2024, 11, 27, 19, 49, 17, 135, DateTimeKind.Local).AddTicks(347) },
                    { 38, 26, "Completed", 14, new DateTime(2024, 11, 24, 19, 3, 8, 246, DateTimeKind.Local).AddTicks(6065), new DateTime(2024, 12, 3, 19, 35, 50, 157, DateTimeKind.Local).AddTicks(5842), new DateTime(2024, 11, 26, 19, 35, 50, 157, DateTimeKind.Local).AddTicks(5842), new DateTime(2024, 11, 27, 8, 52, 24, 725, DateTimeKind.Local).AddTicks(6749) },
                    { 39, 18, "Completed", 16, new DateTime(2024, 11, 25, 9, 52, 17, 508, DateTimeKind.Local).AddTicks(3382), new DateTime(2024, 11, 30, 14, 57, 30, 646, DateTimeKind.Local).AddTicks(7898), new DateTime(2024, 11, 23, 14, 57, 30, 646, DateTimeKind.Local).AddTicks(7898), new DateTime(2024, 11, 25, 17, 44, 38, 558, DateTimeKind.Local).AddTicks(3685) },
                    { 40, 24, "Completed", 14, new DateTime(2024, 11, 22, 20, 46, 46, 588, DateTimeKind.Local).AddTicks(9022), new DateTime(2024, 12, 3, 10, 39, 20, 682, DateTimeKind.Local).AddTicks(7827), new DateTime(2024, 11, 26, 10, 39, 20, 682, DateTimeKind.Local).AddTicks(7827), new DateTime(2024, 11, 25, 16, 18, 5, 625, DateTimeKind.Local).AddTicks(9217) }
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
