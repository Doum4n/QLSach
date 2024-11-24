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
                    { 1, "Non aut adipisci.", "Ava" },
                    { 2, "Delectus dolor praesentium.", "Lavina" },
                    { 3, "Quis voluptatibus neque alias.", "Orval" },
                    { 4, "Quibusdam veritatis eligendi id impedit consectetur.", "Lawson" },
                    { 5, "Laboriosam non eum.", "Yasmeen" },
                    { 6, "Et quidem qui corrupti facere facere voluptatem ducimus iusto.", "Zachariah" },
                    { 7, "Sapiente autem ut minus.", "Karolann" },
                    { 8, "Officia soluta voluptates quos reiciendis perferendis voluptatibus.", "Kyla" },
                    { 9, "Consequatur sapiente et ut esse nulla reprehenderit.", "Destini" },
                    { 10, "Libero ut voluptatem unde repellendus consequuntur officia esse minima itaque.", "Annie" },
                    { 11, "Provident rerum occaecati consequatur provident eos voluptates id.", "Cali" },
                    { 12, "Quia voluptates dolores porro aperiam.", "Hubert" },
                    { 13, "Temporibus reiciendis laborum in aut nam.", "Gina" },
                    { 14, "Quis maiores dolorum.", "Claudine" },
                    { 15, "Est omnis occaecati autem omnis omnis quia.", "Rico" },
                    { 16, "Ullam quis reprehenderit assumenda hic.", "Ramona" },
                    { 17, "Aut hic exercitationem.", "Hailee" },
                    { 18, "Iure facilis ullam.", "Israel" },
                    { 19, "Perspiciatis ab sed impedit dignissimos vel quae quis.", "Nick" },
                    { 20, "Tenetur nisi et ut neque.", "Verlie" },
                    { 21, "Reprehenderit sit quaerat voluptas non cumque ipsa facilis laboriosam doloribus.", "Sallie" },
                    { 22, "Quia quia qui aspernatur nam et architecto quas.", "Zaria" },
                    { 23, "Quas aliquam et.", "Ursula" },
                    { 24, "Architecto quia perspiciatis beatae qui.", "Lillian" },
                    { 25, "Dolor rerum harum porro veniam voluptatem voluptatem repellat.", "Rey" },
                    { 26, "Placeat quasi quo illo ab qui.", "Mohammad" },
                    { 27, "Et sed ut totam et.", "Ryder" },
                    { 28, "Cumque magnam non est repellat est est dicta libero.", "Otho" },
                    { 29, "Atque magni quidem corporis aspernatur tempora veniam consequuntur incidunt amet.", "Bertrand" },
                    { 30, "Enim illo aliquid quo et alias labore labore sit.", "Carlie" },
                    { 31, "Qui reprehenderit deserunt dolor fugit rerum facere.", "Felipa" },
                    { 32, "Aspernatur incidunt recusandae qui.", "Deshawn" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Maxime voluptate ratione veniam. Sunt error nulla dolor odio quibusdam laboriosam. Iste molestiae libero adipisci. Placeat suscipit ducimus dolorum quaerat voluptas porro.", "aspernatur", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 2, "Voluptates iste eligendi dolorem corporis omnis dolores sequi est minima. Officiis sit consequatur aut minus excepturi voluptatem blanditiis qui non. Dolorum fugit facilis consequuntur. Et aut optio vel maiores qui. Soluta aperiam illum.", "Veniam corporis omnis voluptas iusto eos.", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 3, "Et qui aliquam nesciunt voluptatibus minima qui labore quibusdam. Ut nulla dolores sit. Labore sapiente nobis ex enim temporibus. Laborum eligendi nulla. Accusantium quia aut temporibus aspernatur maiores ullam eveniet. Rerum ratione dolores odit est eos harum quis magnam ratione.", "mollitia", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 4, "Nam temporibus iste recusandae culpa ut aut et dolore et. Aspernatur vitae est. Rerum assumenda quia atque eligendi ducimus. Magni aut eum veniam explicabo officiis. Explicabo nostrum dolorum earum aliquam fuga. Exercitationem numquam ut autem corporis officia ea quidem distinctio placeat.", "modi", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 5, "Eaque dolor beatae veritatis. Corrupti eum expedita porro vitae eaque cumque ea adipisci. Reprehenderit excepturi tempora reprehenderit repellat inventore corrupti eligendi ut.", "Sunt et incidunt velit. Expedita est voluptate eos sunt est quia tempora. Unde dolores eligendi non reiciendis quidem. Est qui dolor tempore quo recusandae sequi.", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "unde" },
                    { 2, "numquam" },
                    { 3, "deserunt" },
                    { 4, "consequatur" },
                    { 5, "cupiditate" },
                    { 6, "consectetur" },
                    { 7, "accusamus" },
                    { 8, "sint" },
                    { 9, "et" },
                    { 10, "aliquam" },
                    { 11, "expedita" },
                    { 12, "delectus" },
                    { 13, "qui" },
                    { 14, "ipsum" },
                    { 15, "sunt" },
                    { 16, "ipsa" },
                    { 17, "non" },
                    { 18, "cupiditate" },
                    { 19, "in" },
                    { 20, "voluptatem" },
                    { 21, "et" },
                    { 22, "omnis" },
                    { 23, "ratione" },
                    { 24, "omnis" },
                    { 25, "veritatis" },
                    { 26, "et" },
                    { 27, "maxime" },
                    { 28, "quasi" },
                    { 29, "facere" },
                    { 30, "distinctio" },
                    { 31, "non" },
                    { 32, "fuga" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName", "create_at", "update_at" },
                values: new object[,]
                {
                    { 1, "Marc Klocko", "Labore voluptas velit est sit et consequatur quas esse expedita. Alias perferendis facere. Quidem molestiae dolores facilis consequatur. Velit quia qui qui reprehenderit cumque aspernatur perferendis consequatur. Eos deserunt dolorem enim.", "User", "Crystel", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 2, "Breanne Pacocha", "Suscipit optio quo accusamus ut mollitia asperiores velit.\nMolestiae quidem molestiae omnis iure minima odio dolores voluptates.", "User", "Ryder", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 3, "Princess Trantow", "Et voluptas cum dolore veritatis officia cumque deserunt voluptatem dolores.", "User", "Sasha", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 4, "Adonis Franecki", "officia", "User", "Luis", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 5, "Gillian Carroll", "Ipsum eveniet voluptas ut. Incidunt unde fuga placeat commodi asperiores quam dolores ipsam. Rerum sit dolores eum facilis et. Autem quos consequatur et. Debitis qui reprehenderit cum velit voluptatem corrupti. Minus est praesentium maxime.", "User", "Bernice", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 6, "Ada Runolfsson", "Natus aperiam occaecati excepturi possimus ducimus molestiae ut vel maxime.\nMolestias sunt eum perferendis explicabo eos.\nUnde et aspernatur cumque voluptate laborum explicabo qui adipisci.\nProvident qui sed pariatur voluptate quae.\nCumque veniam dignissimos sit blanditiis nihil.", "User", "Isaac", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 7, "Joey Runolfsdottir", "Ad nihil reprehenderit earum consequatur perferendis eum maxime harum et.\nItaque quae aliquid laborum voluptates quas.\nVoluptatibus odit occaecati in itaque deserunt aut quod qui cum.\nNatus rerum nisi ipsum sed odit qui minima.\nQui id ducimus omnis odio libero.", "User", "Krystel", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 8, "Archibald Stanton", "in", "User", "Rowan", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 9, "Donnell Klein", "dolor", "Admin", "Sasha", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 10, "Arlie Quigley", "Qui id deleniti culpa repellendus eaque atque omnis maxime dolorem.\nQuas est sunt voluptatum autem ut ullam facere officia.\nDolore nihil dolore vel excepturi.\nVoluptates cum molestias dicta qui.", "Admin", "Lilian", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 11, "Madie Wyman", "Et consequuntur ullam voluptas asperiores qui sint. Sed autem repellat illo et ut et praesentium eveniet inventore. Illum ipsam praesentium sunt.", "User", "Johanna", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 12, "Wayne Cremin", "Quo accusamus ut corrupti quidem.\nIure atque doloremque deleniti.\nNon officiis voluptatem nisi voluptatem dolores quia dicta deserunt veritatis.\nAut accusantium blanditiis consequatur.\nNemo ut quam.", "User", "Yasmeen", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 13, "Ericka Denesik", "quidem", "User", "Judson", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 14, "Adrienne Heller", "Est et corrupti excepturi est.\nBlanditiis laudantium qui odit natus.\nMinus amet et quisquam voluptatem ut ab voluptates.\nQui quibusdam reprehenderit deleniti.\nAut consequatur cum amet optio ullam exercitationem dolorum.", "Admin", "Melvina", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 15, "Carter Flatley", "At consectetur cum.\nQuos quia dolore aut.\nAnimi laborum dolores expedita.", "Admin", "Aubrey", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) },
                    { 16, "Reginald Toy", "Officiis quia non neque sed et non sunt.", "Admin", "Jessie", new DateOnly(2024, 11, 23), new DateOnly(2024, 11, 23) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "public_at", "quantity", "rating", "remaining", "updated_at", "views" },
                values: new object[,]
                {
                    { 1, 19, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(6469), "Earum in velit ut saepe est quo. Nisi quia eveniet. Porro sit debitis voluptates.", 21, "Est quis temporibus et velit.", new DateOnly(2016, 6, 14), (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(7641), 0 },
                    { 2, 25, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(8240), "Deleniti quos rem accusamus ut officia eos ut. Molestias dolores earum aut quia in. Et corporis modi architecto perspiciatis sunt alias laboriosam harum. Quisquam facilis et excepturi facilis tenetur ipsam est esse. Nobis nihil est tempore rerum dolor sint quae qui.", 15, "Suscipit blanditiis voluptatem enim exercitationem non cum tempore sed.", new DateOnly(2006, 7, 5), (byte)8, (byte)0, (byte)1, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(8517), 0 },
                    { 3, 19, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(8532), "Sapiente nihil pariatur dolor dolor ad eligendi. Qui aut aut dolor tempore. Ut est et est qui ut itaque soluta.", 23, "Est eaque nulla inventore aliquid mollitia in consectetur itaque nostrum.", new DateOnly(2004, 5, 28), (byte)9, (byte)0, (byte)1, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(8672), 0 },
                    { 4, 6, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(8687), "Ut minima qui ipsam velit consequatur ab quibusdam expedita consequatur. Dolores veritatis animi. Voluptate sint doloribus vero. Sunt inventore ut facere.", 5, "Non dolorum quasi est assumenda et saepe.", new DateOnly(2006, 2, 5), (byte)6, (byte)0, (byte)3, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(8779), 0 },
                    { 5, 15, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(8793), "Maiores tenetur corrupti illum rerum aut nam distinctio libero. Laborum id reprehenderit. Doloremque sint minima eaque quaerat sit maiores aperiam dolorem sunt. Voluptatum ipsum eum qui. Minus repellat porro totam dolorum in quisquam tenetur voluptatem.", 18, "Deserunt ullam occaecati debitis est ex ducimus animi.", new DateOnly(2014, 6, 9), (byte)10, (byte)0, (byte)5, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(8944), 0 },
                    { 6, 23, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(8957), "Est qui qui. Atque quo totam blanditiis error et aliquid repudiandae unde. Tempora minima fugit accusantium. Et quaerat odio dolores id. Vel vero quis aut veniam pariatur voluptatem rerum unde velit.", 10, "Eum veritatis vitae et dolores esse.", new DateOnly(2020, 5, 29), (byte)8, (byte)0, (byte)0, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9082), 0 },
                    { 7, 15, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9096), "Maiores aspernatur optio iure beatae quas. Ipsa et ipsa nemo facere dolorem harum sit. Et enim dolor quaerat ut est sed in maiores et.", 5, "Ullam tempora nulla nam.", new DateOnly(2013, 11, 3), (byte)9, (byte)0, (byte)2, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9176), 0 },
                    { 8, 21, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9215), "Magnam quas fugiat suscipit reprehenderit blanditiis. Asperiores laboriosam nesciunt necessitatibus provident nobis. Perspiciatis sapiente quam voluptas magnam distinctio. Rerum quasi esse at non rerum sit suscipit. Facilis quaerat et et numquam qui aspernatur quod.", 19, "Ducimus possimus in.", new DateOnly(2002, 12, 3), (byte)10, (byte)0, (byte)5, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9311), 0 },
                    { 9, 1, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9325), "Deleniti maxime pariatur ab porro consequatur qui dignissimos quo dignissimos. Architecto et natus facilis impedit. Perferendis est eaque assumenda amet ut. Eos natus aut. Et placeat sit quae.", 24, "Est nihil ut sit itaque eos.", new DateOnly(2005, 10, 28), (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9443), 0 },
                    { 10, 23, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9456), "Eaque dolorem ut esse tempora perferendis officia. Odit aperiam est consequatur aut sed distinctio repellat nulla. Harum veniam officia nihil sequi quos eaque. Vel et possimus. Quidem hic aliquam laborum.", 28, "Illum velit voluptas iure.", new DateOnly(2020, 6, 4), (byte)8, (byte)0, (byte)0, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9572), 0 },
                    { 11, 29, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9586), "Quia cumque ea totam dignissimos in soluta. Velit laborum incidunt sed adipisci harum. Autem sunt consectetur. Illum error assumenda at neque.", 11, "Natus ullam iusto expedita occaecati.", new DateOnly(2021, 2, 26), (byte)9, (byte)0, (byte)2, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9663), 0 },
                    { 12, 18, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9677), "Assumenda similique quibusdam deserunt molestias quia. Sed sint est et illum est. Nulla nihil debitis deserunt voluptates quia voluptate. Rerum modi odit aut magnam qui atque aut voluptas maiores. Eligendi exercitationem explicabo in omnis sint tenetur sequi autem.", 32, "Voluptatem asperiores minima asperiores ut distinctio et.", new DateOnly(2002, 12, 10), (byte)7, (byte)0, (byte)3, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9838), 0 },
                    { 13, 12, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9852), "Nesciunt velit dolorem quo ipsam. Omnis nesciunt dolore tempora modi provident iusto quia laborum qui. Minima autem nihil harum aliquid distinctio voluptas est temporibus quia. Atque excepturi et quis eaque accusamus unde magnam.", 15, "Tenetur beatae aut.", new DateOnly(2012, 7, 28), (byte)8, (byte)0, (byte)4, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9963), 0 },
                    { 14, 22, new DateTime(2024, 11, 23, 8, 54, 52, 62, DateTimeKind.Local).AddTicks(9976), "Est consectetur est ducimus ducimus. A hic cum molestiae praesentium. Iste et architecto magnam excepturi in quis.", 2, "Id voluptatem vero maiores consectetur.", new DateOnly(2009, 8, 6), (byte)6, (byte)0, (byte)3, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(50), 0 },
                    { 15, 11, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(96), "Atque harum excepturi commodi voluptas blanditiis. Qui possimus error voluptates repellat alias. Ex deleniti nihil earum. Excepturi et qui nam ducimus mollitia. Eos vel sed deleniti cupiditate recusandae doloremque blanditiis ad. Et quas quas ut laborum soluta nesciunt nesciunt quam repudiandae.", 29, "Velit cumque veritatis consequatur.", new DateOnly(2014, 2, 12), (byte)8, (byte)0, (byte)3, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(356), 0 },
                    { 16, 31, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(369), "Iure consequatur et consequuntur. Natus enim qui itaque architecto exercitationem at non rerum accusantium. Aspernatur minima minima natus tenetur. Et explicabo voluptatum. Modi est quia illum sed voluptatem aut.", 20, "Placeat molestiae repudiandae et quisquam magni in sit delectus et.", new DateOnly(2013, 10, 17), (byte)10, (byte)0, (byte)0, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(504), 0 },
                    { 17, 21, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(517), "Et animi non architecto id voluptatem sit. Nobis nesciunt sed voluptatem. Et qui modi molestiae temporibus.", 30, "Dignissimos ut rerum repellendus ad quod suscipit.", new DateOnly(2009, 4, 24), (byte)5, (byte)0, (byte)4, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(615), 0 },
                    { 18, 21, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(628), "Velit culpa qui earum suscipit ut. Excepturi facilis totam neque. Error tempora quos sapiente.", 15, "Optio reiciendis eum maxime amet debitis dicta eum nam dolores.", new DateOnly(2022, 10, 27), (byte)5, (byte)0, (byte)3, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(700), 0 },
                    { 19, 13, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(713), "Quia deleniti odio vero quis ut dolores animi aut quia. Dolorem qui rerum ex error rem sequi. Maxime neque modi quia. Sed minima ab aut. Voluptas laboriosam ut voluptatibus ut.", 30, "Maxime est rerum reprehenderit maxime soluta ut.", new DateOnly(2010, 9, 2), (byte)6, (byte)0, (byte)2, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(838), 0 },
                    { 20, 26, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(851), "Quo animi sit dolor nesciunt ipsum. Quis porro mollitia odio nulla. Consequuntur ratione aut. Aliquam ut quae recusandae cumque vitae ratione. Praesentium qui ut.", 10, "Voluptate dolor voluptatem aliquam.", new DateOnly(2006, 1, 6), (byte)8, (byte)0, (byte)0, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(963), 0 },
                    { 21, 23, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(976), "Impedit enim expedita et dicta ut nostrum debitis. Dolor blanditiis dolores. Facilis voluptates ea. Facere quod itaque vel facilis.", 19, "Dicta dicta et odio rerum sit.", new DateOnly(2019, 4, 17), (byte)8, (byte)0, (byte)3, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1052), 0 },
                    { 22, 23, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1065), "Facere quisquam et suscipit atque repudiandae eos id quisquam non. Voluptas aut minima perspiciatis est rerum. Nam autem voluptas.", 11, "Rerum voluptatem adipisci sed quae et id iusto deleniti.", new DateOnly(2012, 4, 19), (byte)7, (byte)0, (byte)3, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1163), 0 },
                    { 23, 3, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1176), "Consequatur qui voluptate corrupti ab. Sint voluptas nostrum est iusto facilis qui quam et. Voluptatem assumenda est sequi omnis quis eaque accusamus. Culpa nam dolorem porro repellat laborum harum vitae sed ratione. Expedita ea animi cupiditate qui sit consequatur nihil accusantium eum.", 11, "Illo dolor rerum ex qui sunt incidunt dolore enim.", new DateOnly(2023, 6, 13), (byte)9, (byte)0, (byte)3, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1325), 0 },
                    { 24, 29, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1338), "Dolorem incidunt maiores quo perferendis tempore et cupiditate reiciendis eum. Officia quis ab odio ad. Cupiditate quis et ratione.", 28, "Nisi qui illum consequuntur iure ex accusamus quae quaerat.", new DateOnly(2011, 4, 18), (byte)5, (byte)0, (byte)1, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1415), 0 },
                    { 25, 9, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1429), "Mollitia et molestiae. Dolores quasi dicta dolores architecto nesciunt est. Recusandae quibusdam sed omnis quis id eum aspernatur. Architecto sequi maiores facilis maiores veniam quo quis.", 24, "Debitis explicabo consequatur consequatur recusandae eum eius reiciendis.", new DateOnly(2006, 8, 16), (byte)8, (byte)0, (byte)5, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1535), 0 },
                    { 26, 10, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1549), "Ut sunt in et eum aut. Voluptatum ea et soluta porro consequatur maiores qui dignissimos porro. Harum odio aut in et voluptatem odio. Omnis repellat asperiores nihil ut.", 1, "Atque laborum autem.", new DateOnly(2019, 12, 21), (byte)5, (byte)0, (byte)0, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1667), 0 },
                    { 27, 3, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1681), "Sequi fugiat iste est culpa aliquam occaecati minus vitae fugiat. Perferendis voluptates et error voluptatem. Repellat unde voluptatem cumque deleniti eos ipsa commodi. Sit vero iusto. Vel perferendis sit non et voluptatem.", 4, "Eligendi sed hic nihil dolore est.", new DateOnly(2018, 7, 29), (byte)9, (byte)0, (byte)1, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1776), 0 },
                    { 28, 2, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1821), "Modi et cumque non. Exercitationem sunt voluptatem quidem est perspiciatis dolorem quisquam necessitatibus. Facere voluptatem consequuntur odit quod quaerat odio itaque qui. Ab sit unde veniam corporis cumque qui voluptatibus.", 3, "Repellat itaque voluptate libero provident officiis placeat adipisci.", new DateOnly(2018, 6, 8), (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1916), 0 },
                    { 29, 14, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(1931), "Et molestias nostrum. Reiciendis aut sit ipsa id sapiente et. Error ut ex.", 3, "Minima inventore adipisci.", new DateOnly(2004, 5, 11), (byte)10, (byte)0, (byte)3, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2015), 0 },
                    { 30, 27, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2028), "Ut et consequatur repellat qui minima sunt. Ut quia odio optio non officiis accusantium quia sint et. Possimus possimus magni in veritatis est in et. Necessitatibus est iste quasi. Possimus est natus voluptatibus fugit perferendis.", 1, "Possimus ducimus voluptatem sed exercitationem et et facere.", new DateOnly(2011, 6, 29), (byte)6, (byte)0, (byte)0, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2161), 0 },
                    { 31, 28, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2176), "Qui maxime nesciunt enim quisquam minus autem. Qui tenetur distinctio occaecati pariatur aut recusandae quam reprehenderit. Sit laudantium qui. Voluptates illo est quia nesciunt commodi placeat aut rerum.", 24, "Quos autem ipsum non error.", new DateOnly(2000, 12, 19), (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2262), 0 },
                    { 32, 31, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2274), "Sint impedit voluptatem quos illum ipsam suscipit temporibus natus voluptatem. Dolores quia accusantium numquam ut beatae enim expedita. Doloribus voluptates eius voluptas nam. Architecto nihil consequatur dolores veritatis. Qui voluptatem hic deserunt.", 18, "Omnis placeat repellat doloribus quos.", new DateOnly(2000, 2, 4), (byte)10, (byte)0, (byte)4, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2396), 0 },
                    { 33, 24, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2409), "Vitae aspernatur nobis dolorem suscipit eligendi. Sed similique expedita omnis excepturi doloremque adipisci incidunt. Id voluptatibus et occaecati et qui a voluptas rerum. Iure reprehenderit tenetur ipsam ex deserunt sit animi.", 25, "Facilis voluptas non voluptatem.", new DateOnly(2007, 7, 4), (byte)7, (byte)0, (byte)4, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2525), 0 },
                    { 34, 13, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2537), "Omnis qui nostrum est velit architecto facere nam. Minus sequi quia rem fugit quia soluta. Sequi omnis quia expedita neque aliquid omnis deserunt velit. Quasi commodi sed quasi voluptatem. Laborum quos provident exercitationem id in provident quidem officiis et.", 7, "Beatae nulla soluta esse iste dolores aut temporibus.", new DateOnly(2002, 10, 23), (byte)9, (byte)0, (byte)3, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2672), 0 },
                    { 35, 6, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2684), "Unde recusandae qui. Maiores quo perferendis et voluptatem cum blanditiis vel vero. Placeat fugit ut sit. Sed quia qui numquam ipsa consequuntur nobis.", 6, "Dolorum commodi et tenetur.", new DateOnly(2021, 10, 5), (byte)7, (byte)0, (byte)3, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2764), 0 },
                    { 36, 24, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2777), "Saepe architecto error accusantium alias quo laborum. Autem doloremque explicabo quibusdam maxime. Distinctio quo nihil occaecati omnis et est. Voluptatem possimus hic est recusandae aspernatur ab. Accusamus aut animi nostrum incidunt totam occaecati et.", 30, "Voluptatem maxime ipsa.", new DateOnly(2023, 3, 17), (byte)6, (byte)0, (byte)2, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2888), 0 },
                    { 37, 31, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(2902), "Eum sunt iusto ducimus alias totam iusto. Cupiditate minus voluptas atque aliquam eos omnis itaque dolores ipsum. Quas architecto est omnis ut repellendus. Voluptates mollitia aut vitae ut quisquam ipsam omnis et. Autem aut sit beatae. Voluptas nihil similique sint.", 28, "Aperiam ut ut molestiae.", new DateOnly(1999, 8, 18), (byte)7, (byte)0, (byte)4, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(3048), 0 },
                    { 38, 8, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(3061), "In ad beatae dolor voluptatem non mollitia veniam quisquam iure. Illo autem sint fugiat. Nihil ut quis et aut et facilis aliquam omnis libero. Facere consequatur esse libero consectetur.", 23, "Debitis quaerat non nulla cupiditate dignissimos illum.", new DateOnly(2008, 3, 8), (byte)10, (byte)0, (byte)4, new DateTime(2024, 11, 23, 8, 54, 52, 63, DateTimeKind.Local).AddTicks(3193), 0 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBook",
                columns: new[] { "Id", "BookId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 6, 1 },
                    { 2, 24, 5 },
                    { 3, 27, 4 },
                    { 4, 20, 2 },
                    { 5, 21, 1 },
                    { 6, 22, 1 },
                    { 7, 33, 2 },
                    { 8, 31, 2 },
                    { 9, 29, 3 },
                    { 10, 31, 4 },
                    { 11, 23, 1 },
                    { 12, 14, 1 },
                    { 13, 22, 5 },
                    { 14, 37, 4 },
                    { 15, 7, 4 },
                    { 16, 3, 5 },
                    { 17, 25, 3 },
                    { 18, 9, 5 },
                    { 19, 15, 2 },
                    { 20, 24, 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 1, 32, 12, "Asperiores et magni sunt officia rerum facilis blanditiis sit sint.", null },
                    { 2, 36, 4, "Voluptatibus quos laboriosam repellendus.", null },
                    { 3, 26, 11, "Enim fuga molestiae numquam eaque incidunt.", null },
                    { 4, 23, 12, "Praesentium illo saepe.", null },
                    { 5, 12, 8, "Soluta accusantium ratione delectus.", null },
                    { 6, 19, 13, "Necessitatibus necessitatibus facere aut.", null },
                    { 7, 9, 7, "Quaerat aut velit commodi eos.", null },
                    { 8, 27, 16, "Quibusdam molestiae consectetur nesciunt eligendi iusto ratione officiis praesentium.", null },
                    { 9, 9, 6, "Qui eius exercitationem quo aut eveniet fugiat mollitia inventore deserunt.", null },
                    { 10, 1, 7, "Facilis animi impedit ratione atque sunt enim vero.", null },
                    { 11, 23, 11, "Ullam et consequatur cum quaerat blanditiis explicabo ab minus.", null },
                    { 12, 12, 3, "Et soluta ullam.", null },
                    { 13, 17, 8, "Enim voluptatem molestiae.", null },
                    { 14, 32, 9, "Id amet iste autem sapiente neque aut et odio ipsum.", null },
                    { 15, 2, 13, "Similique quos et sed quo sint.", null },
                    { 16, 8, 2, "Sapiente culpa placeat inventore quos accusamus nihil minus.", null }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "book_id", "path" },
                values: new object[,]
                {
                    { 1, 27, ".\\resources\\images\\poster.png" },
                    { 2, 3, ".\\resources\\images\\poster.png" },
                    { 3, 2, ".\\resources\\images\\poster.png" },
                    { 4, 18, ".\\resources\\images\\poster.png" },
                    { 5, 14, ".\\resources\\images\\poster.png" },
                    { 6, 11, ".\\resources\\images\\poster.png" },
                    { 7, 26, ".\\resources\\images\\poster.png" },
                    { 8, 6, ".\\resources\\images\\poster.png" },
                    { 9, 8, ".\\resources\\images\\poster.png" },
                    { 10, 2, ".\\resources\\images\\poster.png" },
                    { 11, 36, ".\\resources\\images\\poster.png" },
                    { 12, 11, ".\\resources\\images\\poster.png" },
                    { 13, 29, ".\\resources\\images\\poster.png" },
                    { 14, 15, ".\\resources\\images\\poster.png" },
                    { 15, 13, ".\\resources\\images\\poster.png" },
                    { 16, 19, ".\\resources\\images\\poster.png" }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 4, "Completed", 11, new DateTime(2024, 11, 20, 0, 40, 15, 461, DateTimeKind.Local).AddTicks(2909), new DateTime(2024, 11, 30, 6, 43, 3, 916, DateTimeKind.Local).AddTicks(4081), new DateTime(2024, 11, 23, 6, 43, 3, 916, DateTimeKind.Local).AddTicks(4081), new DateTime(2024, 11, 22, 19, 14, 23, 24, DateTimeKind.Local).AddTicks(6614) },
                    { 2, 2, "Borrowed", 6, new DateTime(2024, 11, 19, 22, 14, 34, 60, DateTimeKind.Local).AddTicks(8767), new DateTime(2024, 11, 30, 5, 32, 24, 848, DateTimeKind.Local).AddTicks(1570), new DateTime(2024, 11, 23, 5, 32, 24, 848, DateTimeKind.Local).AddTicks(1570), null },
                    { 3, 5, "Borrowed", 16, new DateTime(2024, 11, 18, 20, 7, 53, 297, DateTimeKind.Local).AddTicks(7993), new DateTime(2024, 11, 29, 19, 15, 15, 179, DateTimeKind.Local).AddTicks(7697), new DateTime(2024, 11, 22, 19, 15, 15, 179, DateTimeKind.Local).AddTicks(7697), null },
                    { 4, 35, "Pending", 10, null, null, new DateTime(2024, 11, 21, 12, 47, 0, 364, DateTimeKind.Local).AddTicks(6808), null },
                    { 5, 2, "Completed", 5, new DateTime(2024, 11, 21, 10, 6, 30, 279, DateTimeKind.Local).AddTicks(5064), new DateTime(2024, 11, 28, 3, 38, 32, 715, DateTimeKind.Local).AddTicks(8379), new DateTime(2024, 11, 21, 3, 38, 32, 715, DateTimeKind.Local).AddTicks(8379), new DateTime(2024, 11, 22, 23, 24, 43, 813, DateTimeKind.Local).AddTicks(3498) },
                    { 6, 11, "Pending", 2, null, null, new DateTime(2024, 11, 22, 20, 53, 40, 805, DateTimeKind.Local).AddTicks(7547), null },
                    { 7, 9, "Pending", 15, null, null, new DateTime(2024, 11, 21, 19, 38, 41, 684, DateTimeKind.Local).AddTicks(8836), null },
                    { 8, 6, "Pending", 2, null, null, new DateTime(2024, 11, 22, 1, 40, 36, 218, DateTimeKind.Local).AddTicks(1759), null },
                    { 9, 27, "Completed", 9, new DateTime(2024, 11, 22, 17, 1, 23, 422, DateTimeKind.Local).AddTicks(1621), new DateTime(2024, 11, 29, 23, 11, 24, 411, DateTimeKind.Local).AddTicks(8413), new DateTime(2024, 11, 22, 23, 11, 24, 411, DateTimeKind.Local).AddTicks(8413), new DateTime(2024, 11, 22, 16, 47, 17, 533, DateTimeKind.Local).AddTicks(5082) },
                    { 10, 26, "Borrowed", 14, new DateTime(2024, 11, 19, 19, 52, 32, 277, DateTimeKind.Local).AddTicks(8280), new DateTime(2024, 11, 29, 21, 4, 23, 185, DateTimeKind.Local).AddTicks(3610), new DateTime(2024, 11, 22, 21, 4, 23, 185, DateTimeKind.Local).AddTicks(3610), null },
                    { 11, 5, "Pending", 4, null, null, new DateTime(2024, 11, 19, 16, 46, 27, 71, DateTimeKind.Local).AddTicks(9594), null },
                    { 12, 20, "Borrowed", 13, new DateTime(2024, 11, 22, 23, 32, 13, 266, DateTimeKind.Local).AddTicks(7885), new DateTime(2024, 11, 26, 19, 27, 18, 311, DateTimeKind.Local).AddTicks(7495), new DateTime(2024, 11, 19, 19, 27, 18, 311, DateTimeKind.Local).AddTicks(7495), null },
                    { 13, 22, "Borrowed", 16, new DateTime(2024, 11, 17, 13, 33, 55, 305, DateTimeKind.Local).AddTicks(648), new DateTime(2024, 11, 25, 18, 23, 37, 118, DateTimeKind.Local).AddTicks(5858), new DateTime(2024, 11, 18, 18, 23, 37, 118, DateTimeKind.Local).AddTicks(5858), null },
                    { 14, 35, "Completed", 11, new DateTime(2024, 11, 20, 10, 40, 49, 352, DateTimeKind.Local).AddTicks(43), new DateTime(2024, 11, 27, 23, 24, 51, 412, DateTimeKind.Local).AddTicks(8921), new DateTime(2024, 11, 20, 23, 24, 51, 412, DateTimeKind.Local).AddTicks(8921), new DateTime(2024, 11, 21, 10, 46, 6, 629, DateTimeKind.Local).AddTicks(3690) },
                    { 15, 26, "Completed", 5, new DateTime(2024, 11, 17, 21, 28, 6, 241, DateTimeKind.Local).AddTicks(328), new DateTime(2024, 11, 26, 15, 48, 46, 756, DateTimeKind.Local).AddTicks(5919), new DateTime(2024, 11, 19, 15, 48, 46, 756, DateTimeKind.Local).AddTicks(5919), new DateTime(2024, 11, 20, 12, 13, 38, 96, DateTimeKind.Local).AddTicks(8503) },
                    { 16, 7, "Pending", 14, null, null, new DateTime(2024, 11, 21, 18, 40, 59, 351, DateTimeKind.Local).AddTicks(3903), null },
                    { 17, 34, "Canceled", 1, null, null, new DateTime(2024, 11, 22, 1, 39, 48, 410, DateTimeKind.Local).AddTicks(2589), null },
                    { 18, 4, "Borrowed", 8, new DateTime(2024, 11, 20, 3, 26, 22, 751, DateTimeKind.Local).AddTicks(1067), new DateTime(2024, 11, 30, 8, 46, 28, 884, DateTimeKind.Local).AddTicks(7220), new DateTime(2024, 11, 23, 8, 46, 28, 884, DateTimeKind.Local).AddTicks(7220), null },
                    { 19, 38, "Canceled", 2, null, null, new DateTime(2024, 11, 19, 9, 32, 5, 737, DateTimeKind.Local).AddTicks(7596), null },
                    { 20, 13, "Pending", 4, null, null, new DateTime(2024, 11, 19, 9, 31, 23, 479, DateTimeKind.Local).AddTicks(1010), null },
                    { 21, 13, "Borrowed", 11, new DateTime(2024, 11, 19, 9, 31, 49, 634, DateTimeKind.Local).AddTicks(2825), new DateTime(2024, 11, 23, 11, 51, 48, 61, DateTimeKind.Local).AddTicks(6994), new DateTime(2024, 11, 16, 11, 51, 48, 61, DateTimeKind.Local).AddTicks(6994), null },
                    { 22, 30, "Canceled", 12, null, null, new DateTime(2024, 11, 18, 16, 22, 32, 220, DateTimeKind.Local).AddTicks(4061), null },
                    { 23, 20, "Canceled", 4, null, null, new DateTime(2024, 11, 20, 19, 12, 53, 373, DateTimeKind.Local).AddTicks(5680), null },
                    { 24, 10, "Completed", 6, new DateTime(2024, 11, 17, 21, 26, 53, 80, DateTimeKind.Local).AddTicks(6157), new DateTime(2024, 11, 23, 16, 35, 58, 679, DateTimeKind.Local).AddTicks(6607), new DateTime(2024, 11, 16, 16, 35, 58, 679, DateTimeKind.Local).AddTicks(6607), new DateTime(2024, 11, 22, 23, 6, 8, 414, DateTimeKind.Local).AddTicks(8039) },
                    { 25, 26, "Borrowed", 16, new DateTime(2024, 11, 19, 4, 30, 47, 409, DateTimeKind.Local).AddTicks(6521), new DateTime(2024, 11, 23, 14, 6, 18, 161, DateTimeKind.Local).AddTicks(2856), new DateTime(2024, 11, 16, 14, 6, 18, 161, DateTimeKind.Local).AddTicks(2856), null },
                    { 26, 35, "Completed", 16, new DateTime(2024, 11, 21, 16, 22, 21, 200, DateTimeKind.Local).AddTicks(2779), new DateTime(2024, 11, 24, 11, 37, 59, 251, DateTimeKind.Local).AddTicks(624), new DateTime(2024, 11, 17, 11, 37, 59, 251, DateTimeKind.Local).AddTicks(624), new DateTime(2024, 11, 21, 13, 6, 1, 248, DateTimeKind.Local).AddTicks(9816) },
                    { 27, 20, "Completed", 5, new DateTime(2024, 11, 22, 20, 31, 24, 565, DateTimeKind.Local).AddTicks(8845), new DateTime(2024, 11, 25, 21, 58, 56, 306, DateTimeKind.Local).AddTicks(1395), new DateTime(2024, 11, 18, 21, 58, 56, 306, DateTimeKind.Local).AddTicks(1395), new DateTime(2024, 11, 20, 13, 44, 48, 445, DateTimeKind.Local).AddTicks(8672) },
                    { 28, 22, "Canceled", 7, null, null, new DateTime(2024, 11, 19, 9, 3, 14, 246, DateTimeKind.Local).AddTicks(9380), null },
                    { 29, 18, "Borrowed", 16, new DateTime(2024, 11, 17, 12, 12, 49, 839, DateTimeKind.Local).AddTicks(3578), new DateTime(2024, 11, 26, 19, 14, 7, 466, DateTimeKind.Local).AddTicks(9610), new DateTime(2024, 11, 19, 19, 14, 7, 466, DateTimeKind.Local).AddTicks(9610), null },
                    { 30, 27, "Borrowed", 1, new DateTime(2024, 11, 17, 14, 44, 5, 41, DateTimeKind.Local).AddTicks(6139), new DateTime(2024, 11, 29, 7, 7, 9, 805, DateTimeKind.Local).AddTicks(7079), new DateTime(2024, 11, 22, 7, 7, 9, 805, DateTimeKind.Local).AddTicks(7079), null },
                    { 31, 27, "Completed", 10, new DateTime(2024, 11, 17, 19, 10, 49, 671, DateTimeKind.Local).AddTicks(3749), new DateTime(2024, 11, 26, 16, 11, 1, 65, DateTimeKind.Local).AddTicks(8031), new DateTime(2024, 11, 19, 16, 11, 1, 65, DateTimeKind.Local).AddTicks(8031), new DateTime(2024, 11, 22, 14, 14, 11, 911, DateTimeKind.Local).AddTicks(9514) },
                    { 32, 28, "Pending", 1, null, null, new DateTime(2024, 11, 22, 22, 4, 30, 594, DateTimeKind.Local).AddTicks(6073), null },
                    { 33, 26, "Canceled", 7, null, null, new DateTime(2024, 11, 19, 1, 2, 30, 306, DateTimeKind.Local).AddTicks(6560), null },
                    { 34, 26, "Borrowed", 8, new DateTime(2024, 11, 17, 22, 48, 36, 158, DateTimeKind.Local).AddTicks(1249), new DateTime(2024, 11, 26, 19, 16, 41, 41, DateTimeKind.Local).AddTicks(5687), new DateTime(2024, 11, 19, 19, 16, 41, 41, DateTimeKind.Local).AddTicks(5687), null },
                    { 35, 13, "Pending", 7, null, null, new DateTime(2024, 11, 23, 4, 12, 21, 20, DateTimeKind.Local).AddTicks(7004), null },
                    { 36, 23, "Borrowed", 8, new DateTime(2024, 11, 19, 6, 32, 2, 395, DateTimeKind.Local).AddTicks(4470), new DateTime(2024, 11, 24, 6, 40, 16, 386, DateTimeKind.Local).AddTicks(8972), new DateTime(2024, 11, 17, 6, 40, 16, 386, DateTimeKind.Local).AddTicks(8972), null },
                    { 37, 23, "Canceled", 7, null, null, new DateTime(2024, 11, 19, 9, 4, 34, 584, DateTimeKind.Local).AddTicks(4531), null },
                    { 38, 29, "Canceled", 16, null, null, new DateTime(2024, 11, 18, 14, 38, 10, 149, DateTimeKind.Local).AddTicks(3667), null },
                    { 39, 25, "Borrowed", 8, new DateTime(2024, 11, 22, 16, 55, 21, 116, DateTimeKind.Local).AddTicks(9355), new DateTime(2024, 11, 28, 3, 18, 13, 440, DateTimeKind.Local).AddTicks(608), new DateTime(2024, 11, 21, 3, 18, 13, 440, DateTimeKind.Local).AddTicks(608), null },
                    { 40, 12, "Borrowed", 5, new DateTime(2024, 11, 20, 18, 44, 7, 486, DateTimeKind.Local).AddTicks(7820), new DateTime(2024, 11, 27, 11, 9, 29, 389, DateTimeKind.Local).AddTicks(9501), new DateTime(2024, 11, 20, 11, 9, 29, 389, DateTimeKind.Local).AddTicks(9501), null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 17, 37, 9, "Atque fugit asperiores.", 10 },
                    { 18, 25, 5, "Doloremque modi ipsam.", 5 },
                    { 19, 15, 4, "Accusamus laudantium odio corporis.", 6 },
                    { 20, 6, 14, "Reprehenderit asperiores tenetur voluptas dolore et omnis unde culpa illum.", 9 },
                    { 21, 30, 9, "Deserunt incidunt ipsum.", 7 },
                    { 22, 33, 5, "Quisquam voluptatem maiores veniam voluptas vel eum commodi vitae consequuntur.", 5 },
                    { 23, 34, 6, "Et rerum qui aut odio nisi et quod ut.", 9 },
                    { 24, 14, 16, "Ad impedit dignissimos laborum suscipit et doloremque et veniam quo.", 2 },
                    { 25, 24, 9, "Eum ut autem illo eaque dolorum.", 1 },
                    { 26, 37, 1, "Consequatur minus a ipsum ab a delectus.", 12 },
                    { 27, 9, 10, "Corporis quia qui quia aliquam aut atque enim.", 11 },
                    { 28, 17, 11, "Nobis voluptas soluta ducimus ullam officia dolorum ea magni enim.", 9 },
                    { 29, 12, 8, "Est adipisci possimus sint nostrum aperiam et.", 10 },
                    { 30, 20, 10, "Hic illum itaque.", 15 },
                    { 31, 36, 2, "Vel illum hic necessitatibus placeat.", 10 },
                    { 32, 5, 1, "Itaque autem et autem molestiae.", 13 }
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
