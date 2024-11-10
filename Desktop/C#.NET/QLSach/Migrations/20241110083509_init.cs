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
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
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
                    { 1, "Quas distinctio aut ex quas.", "Alexis" },
                    { 2, "Laboriosam molestias quis et dicta incidunt voluptas repellendus.", "Jamaal" },
                    { 3, "Quibusdam a molestiae autem aut distinctio exercitationem et in.", "Vicky" },
                    { 4, "Quisquam perspiciatis repellat ea sed sunt.", "Keely" },
                    { 5, "Voluptatem enim non id nam enim praesentium et.", "Major" },
                    { 6, "Doloremque aut aut amet ut ut.", "Randi" },
                    { 7, "Doloremque expedita dignissimos nisi quaerat nihil nostrum voluptas.", "Duane" },
                    { 8, "Molestias natus quisquam.", "June" },
                    { 9, "Harum distinctio hic et maiores qui cum velit.", "Roslyn" },
                    { 10, "Vitae fugiat modi aut id eos maiores autem.", "Jacey" },
                    { 11, "Magni a eum quia omnis in.", "Don" },
                    { 12, "Modi et unde repellat reiciendis at alias quae.", "Domenic" },
                    { 13, "Cumque vel et aut nulla.", "Jerrell" },
                    { 14, "Mollitia architecto atque et est sint sed assumenda modi.", "Enoch" },
                    { 15, "Perspiciatis ullam nisi.", "Ressie" },
                    { 16, "Vel qui assumenda dolor ea laudantium velit impedit similique.", "Madelyn" },
                    { 17, "Animi rerum dolorum.", "Lera" },
                    { 18, "Et quo et et veritatis repellat enim nihil neque.", "Charley" },
                    { 19, "Dolores quis asperiores voluptatem.", "Freddy" },
                    { 20, "Soluta neque et nostrum.", "Alvis" },
                    { 21, "Eos velit odit aut labore nostrum exercitationem vero.", "Gillian" },
                    { 22, "Enim recusandae praesentium sit amet sequi eos quos quidem repudiandae.", "Fidel" },
                    { 23, "Qui recusandae consequatur velit rerum quo repudiandae accusantium dolores.", "Brown" },
                    { 24, "Consectetur esse voluptatem.", "Skyla" },
                    { 25, "Quasi ipsa aut eius voluptas sint quaerat quia dicta.", "Modesta" },
                    { 26, "Sunt possimus repellat.", "Elmore" },
                    { 27, "Velit hic dignissimos.", "Xavier" },
                    { 28, "Voluptatum inventore omnis possimus magnam et itaque provident rerum.", "Gilda" },
                    { 29, "Laborum nam dolores hic cumque explicabo qui vero quidem quasi.", "Milford" },
                    { 30, "Omnis similique eum at minus odit occaecati incidunt rerum.", "Heber" },
                    { 31, "Sit dolor illum consectetur quis error enim et a quia.", "Bernard" },
                    { 32, "Qui sunt beatae quia velit vitae eaque necessitatibus cumque praesentium.", "Raheem" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "dolorem" },
                    { 2, "ea" },
                    { 3, "corporis" },
                    { 4, "et" },
                    { 5, "eos" },
                    { 6, "id" },
                    { 7, "eos" },
                    { 8, "odio" },
                    { 9, "ipsum" },
                    { 10, "vitae" },
                    { 11, "repellendus" },
                    { 12, "qui" },
                    { 13, "qui" },
                    { 14, "numquam" },
                    { 15, "quos" },
                    { 16, "quos" },
                    { 17, "quo" },
                    { 18, "aut" },
                    { 19, "quia" },
                    { 20, "non" },
                    { 21, "similique" },
                    { 22, "mollitia" },
                    { 23, "voluptates" },
                    { 24, "sed" },
                    { 25, "suscipit" },
                    { 26, "at" },
                    { 27, "molestias" },
                    { 28, "et" },
                    { 29, "ipsam" },
                    { 30, "suscipit" },
                    { 31, "dolores" },
                    { 32, "veniam" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "ex", "General Daniel" },
                    { 2, "Sed delectus consequatur nulla autem voluptatem voluptatum maxime aut. Nisi corrupti est quia. Adipisci consequatur non consequatur omnis nihil. Dicta doloribus ad dolores consectetur quam similique. Suscipit enim blanditiis veritatis pariatur molestiae.", "Jayda Stark" },
                    { 3, "non", "Don Hegmann" },
                    { 4, "Quis maiores reiciendis.\nQuo culpa in deserunt labore officia nulla voluptatem occaecati.\nReprehenderit ut sunt esse.", "Sienna Mills" },
                    { 5, "Nulla eum officiis sit voluptas qui ea.\nTempora et velit cupiditate.\nSequi odit ut non qui delectus voluptatem nam ut nobis.\nLaborum pariatur modi autem qui assumenda consequatur alias sint.\nRatione rerum ut et numquam est.", "Chadrick Tromp" },
                    { 6, "Quia ut eos voluptas illo nemo quo rerum et assumenda.\nQuia cum incidunt reiciendis est veniam dolore enim harum.\nIn dolor inventore distinctio et.\nEnim eligendi quaerat laudantium cumque hic porro soluta.\nOmnis dolorem et est incidunt quaerat occaecati nobis autem.", "Tamara Jerde" },
                    { 7, "Rerum voluptatem corporis. Maxime et vitae quis quos iure recusandae dolore molestiae unde. Quod ipsam officiis et tempore libero veniam perspiciatis soluta. Esse distinctio aliquid.", "Krystina Runolfsdottir" },
                    { 8, "Necessitatibus et totam recusandae. Modi rem placeat qui asperiores debitis et veniam impedit qui. Laudantium veritatis qui voluptatibus vel adipisci sint sint.", "Nia Moore" },
                    { 9, "In atque dolore doloremque. Nobis placeat ipsa magni. Laboriosam voluptatibus ut ex. Pariatur facilis autem error cum odit facilis nesciunt.", "Tad Treutel" },
                    { 10, "Tempora sunt voluptatem qui unde aut pariatur alias. Illo ab quia rerum est iste. Voluptas accusantium quibusdam animi saepe accusamus sequi.", "Princess Reilly" },
                    { 11, "Vitae mollitia tempora odio ut esse a deleniti. Voluptatem necessitatibus ut debitis nostrum aut nulla ex. Ab amet aperiam modi magni quo id ducimus. Voluptatem quos laudantium dolor quam.", "Clementina Wehner" },
                    { 12, "Laboriosam nihil neque dolore ut molestiae consequatur totam.\nPariatur dolor libero quo pariatur.\nQuibusdam delectus voluptates voluptates eum facilis nisi sed.\nVoluptatem aut enim minus.\nUt placeat deserunt quibusdam adipisci et facere eveniet.\nRerum animi eos omnis consectetur eos est.", "Tristian Zieme" },
                    { 13, "Rerum adipisci impedit dolor est autem reiciendis.", "Breanne Wuckert" },
                    { 14, "Ad nesciunt similique.\nAccusantium at voluptas optio doloremque perferendis placeat ut in.\nUt consequuntur omnis rerum voluptatem veniam quis sint.", "Jamir Hoppe" },
                    { 15, "Quo nulla ut tenetur eum quia fugiat. Ad doloremque aliquam accusamus. Rerum dolores consectetur accusantium ullam magni hic labore ut rerum. Et expedita vel.", "Mertie Yost" },
                    { 16, "Tempora eum iure.", "Golda Gibson" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "created_at", "description", "genre_id", "name", "quantity", "rating", "remaining", "updated_at", "views", "year_public" },
                values: new object[,]
                {
                    { 1, 19, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(2674), "Ea ut et non. Et quidem consequuntur dolores voluptate. Ipsam non eveniet assumenda aut est. Enim ab occaecati deleniti corporis eius est. Voluptatem voluptatem ullam mollitia alias dolor pariatur porro. Aut debitis sit unde.", 14, "Eos cumque rerum dicta est qui expedita et earum porro.", (byte)10, (byte)0, (byte)4, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(3197), 0, 2003 },
                    { 2, 21, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(3934), "Officia quasi dolores autem animi enim deserunt impedit eveniet voluptatem. Unde aliquam ut tempora nesciunt et quae. Qui iusto illum id repellat commodi optio.", 9, "Expedita ut illo ipsam eaque quidem tempora.", (byte)8, (byte)0, (byte)4, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4072), 0, 1958 },
                    { 3, 7, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4084), "Exercitationem hic neque cum qui dolores laboriosam accusamus perspiciatis quae. Nihil voluptates in et qui ut dolores veniam accusantium quia. Quos nihil qui ipsam et vitae accusamus enim nulla. Doloribus culpa enim voluptatem qui labore. Modi architecto dolorem temporibus. Nulla esse sed.", 20, "Deserunt vero non placeat deleniti quis nihil voluptas.", (byte)6, (byte)0, (byte)2, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4232), 0, 1971 },
                    { 4, 31, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4243), "Cumque dolor enim ut eos qui nihil neque. Quia dicta voluptatibus atque eum. Sed et odit ducimus aut modi iste libero debitis.", 7, "In harum illum inventore dolorum ut.", (byte)6, (byte)0, (byte)1, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4327), 0, 1996 },
                    { 5, 7, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4338), "Occaecati est ut illo nihil tempora itaque sit est pariatur. Ut nulla provident delectus quam ut. Sint ipsum ex. Impedit quam dolores facere quis occaecati doloribus reiciendis. Id illo tenetur distinctio.", 3, "Excepturi numquam quis illo quae autem sed tempora.", (byte)9, (byte)0, (byte)0, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4448), 0, 2022 },
                    { 6, 10, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4459), "Nam hic officia aliquam consequatur officiis magnam. Vitae vel alias. Placeat quaerat suscipit dolor. Vitae quo illo reprehenderit rerum quia voluptatibus dicta impedit voluptates. Unde natus in. Qui ipsa quia maiores nisi et odit error maiores.", 12, "Illo quisquam aspernatur vitae et fugiat ea corporis libero et.", (byte)5, (byte)0, (byte)4, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4575), 0, 1902 },
                    { 7, 7, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4586), "Fugiat asperiores ipsam sequi quasi. Molestias omnis eligendi pariatur commodi expedita delectus amet sit distinctio. Fugiat ut nemo. Eligendi minus porro quae. Perspiciatis aut dolores iure animi sit laudantium ut delectus officia. Sed cupiditate maxime eligendi illum voluptatem ab id autem.", 26, "Qui distinctio vero eaque nihil.", (byte)9, (byte)0, (byte)1, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4699), 0, 2019 },
                    { 8, 16, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4712), "Voluptatem quo consectetur aperiam consequatur ipsum unde animi animi. Occaecati temporibus qui laborum. Corrupti veritatis cum dolores eaque. Omnis voluptatem magnam sit magni eveniet unde aut. Architecto at laborum quidem vero quia soluta porro tempore.", 11, "Eveniet sequi sit consequatur tempore.", (byte)10, (byte)0, (byte)5, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4814), 0, 1948 },
                    { 9, 22, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4825), "Quo consequatur rerum dolor ut neque praesentium voluptatem eius. Iure suscipit tempora omnis commodi dignissimos id est. Veritatis dolorum aliquid neque quis et recusandae. Perferendis assumenda ea dolores eligendi qui eius ipsum optio. Qui doloremque et. Recusandae eos eos voluptatem explicabo fugit corrupti sequi recusandae.", 29, "Qui cumque beatae quisquam et et ducimus molestiae.", (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4953), 0, 2017 },
                    { 10, 25, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(4964), "Nulla quo et reiciendis possimus ad similique officiis. Sit sapiente culpa ab sed dolor ducimus. Cum voluptas voluptatibus voluptatem doloribus nostrum. Omnis iste culpa corrupti.", 27, "Dolorem minus eum pariatur consequatur rerum.", (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5054), 0, 1985 },
                    { 11, 18, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5064), "Sed eos reprehenderit recusandae repellendus autem. Vel nobis et sapiente tempore sed corrupti harum eos. Nobis impedit quia occaecati voluptas perferendis.", 20, "Autem quidem ducimus pariatur est reiciendis.", (byte)5, (byte)0, (byte)0, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5145), 0, 1996 },
                    { 12, 23, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5156), "Rerum cumque repellat. Autem sint vero neque ut sunt nobis sequi. Velit quam laborum dolores placeat debitis. Culpa cumque amet.", 6, "Molestias sunt ea a voluptas aut.", (byte)10, (byte)0, (byte)1, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5232), 0, 1991 },
                    { 13, 16, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5242), "Unde vel placeat. Dolorum inventore ratione saepe voluptatum voluptatibus. Tenetur odio accusamus quo iste ipsa. Doloremque quia dicta. Veniam sunt incidunt ea deserunt possimus est.", 29, "Accusamus quo tenetur eos necessitatibus dolor.", (byte)7, (byte)0, (byte)5, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5333), 0, 1917 },
                    { 14, 15, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5343), "Quod nihil expedita in deleniti molestiae expedita. Debitis voluptatem maiores voluptatem. Dolore ut itaque provident sunt alias porro.", 8, "Non consequatur cupiditate nam.", (byte)10, (byte)0, (byte)3, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5408), 0, 1985 },
                    { 15, 1, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5418), "Maiores quia minus animi et quas vero ex. Totam nobis repellendus. Quaerat vitae animi tempora autem minus officia vitae. Aut magni sit sed a ut fuga. Et tenetur soluta impedit perspiciatis fuga. Alias ullam est est deleniti quo quod voluptatem odio aut.", 23, "Facere neque reprehenderit aut sed est sit id.", (byte)7, (byte)0, (byte)1, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5539), 0, 1981 },
                    { 16, 6, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5549), "Aliquam reiciendis qui veniam recusandae est voluptatem. Error natus omnis et quia maiores temporibus est consequatur beatae. Commodi error est temporibus et. Accusantium dolore provident.", 4, "Excepturi at iusto asperiores expedita dolore non.", (byte)6, (byte)0, (byte)5, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5643), 0, 2014 },
                    { 17, 14, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5653), "Nihil vel exercitationem repudiandae et tempora aliquam quaerat. Corrupti sunt quibusdam aliquam. Earum enim asperiores.", 19, "Ipsa atque quis quam.", (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5714), 0, 1940 },
                    { 18, 22, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5731), "Ab dolorum dolor deleniti pariatur ipsa quam sit neque. Sed rerum sed ut et nemo et. Quia dignissimos placeat omnis fugiat quibusdam iusto voluptatem et ea. Autem saepe excepturi quo voluptatibus eos et nihil vitae.", 31, "Cumque est et exercitationem illo vel porro culpa nisi.", (byte)9, (byte)0, (byte)0, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5831), 0, 2023 },
                    { 19, 17, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5842), "Aut amet sit veniam eveniet. Magnam minima eius est numquam sint qui rem veritatis iste. Dolor voluptatibus neque. Dolores ea sunt dolorum facilis rerum debitis a eveniet. Dolores optio fuga est quaerat quisquam et molestiae.", 19, "Exercitationem sunt ut aut tempora quo reprehenderit.", (byte)8, (byte)0, (byte)2, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5948), 0, 1940 },
                    { 20, 31, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(5958), "Non saepe praesentium dolorem magnam. Quibusdam aut dolor molestias nam aspernatur. Debitis culpa omnis libero qui molestiae. Ullam ipsum qui sunt nihil aliquid id velit ipsa nobis.", 3, "Rerum quibusdam totam exercitationem autem facilis doloribus reprehenderit.", (byte)6, (byte)0, (byte)0, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6050), 0, 1985 },
                    { 21, 19, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6060), "Nulla mollitia perferendis non. Facilis id qui vel voluptatem. Consequatur libero velit reprehenderit quisquam minima adipisci saepe. In possimus ut doloribus quae et quo quidem.", 10, "Quos praesentium voluptatem sit vero architecto facilis.", (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6144), 0, 1968 },
                    { 22, 22, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6158), "Ut deserunt incidunt nam tempora dolorem. Mollitia minima provident. Reprehenderit aut dolores. Error eum ut.", 14, "Quia eum illo.", (byte)10, (byte)0, (byte)2, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6220), 0, 1931 },
                    { 23, 1, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6230), "Et maiores esse. Rerum dolore quibusdam cum eos voluptates aut ab sed tenetur. Suscipit reprehenderit dolores dolore temporibus aut fuga et ducimus.", 6, "Dolor atque sed omnis est inventore laborum placeat.", (byte)7, (byte)0, (byte)0, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6310), 0, 1953 },
                    { 24, 12, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6320), "Sit voluptas voluptatem magnam. Est dolorum laudantium. Velit maxime qui ipsum temporibus praesentium animi.", 31, "Qui quasi amet voluptatum commodi molestias.", (byte)5, (byte)0, (byte)5, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6384), 0, 1922 },
                    { 25, 17, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6395), "Non repellat non eum sed. Deserunt occaecati blanditiis. Magni facilis culpa sit et aspernatur. Culpa ipsam voluptas blanditiis id quia. Voluptatum accusamus molestiae perspiciatis repudiandae repellendus expedita ullam omnis.", 8, "Animi unde et et velit nulla.", (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6490), 0, 1926 },
                    { 26, 20, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6500), "Ducimus optio quia mollitia vel nemo est. Et non reprehenderit minus sint. Optio et eligendi impedit ipsum dolor autem tenetur doloremque. Sit animi itaque est sint voluptatem dicta ab ut laudantium. Consectetur sit delectus.", 25, "Alias ut saepe voluptatem consequatur aspernatur.", (byte)9, (byte)0, (byte)4, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6607), 0, 1933 },
                    { 27, 24, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6617), "Sed in natus aliquid quis rerum iusto iure quia. Animi saepe nisi rerum. Quis minus sequi est quasi. Beatae non maxime aperiam. Explicabo sit mollitia fugiat quae.", 5, "Ut laudantium quaerat.", (byte)7, (byte)0, (byte)2, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6701), 0, 1916 },
                    { 28, 26, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6711), "Culpa qui natus. Ab neque omnis qui. Dolores nihil corporis ea. Voluptatem nostrum velit esse. Inventore similique aut aut eius.", 14, "Quo voluptas facere omnis.", (byte)9, (byte)0, (byte)3, new DateTime(2024, 11, 10, 15, 35, 9, 614, DateTimeKind.Local).AddTicks(6791), 0, 1961 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 1, 7, 15, "A dolorem recusandae suscipit quia repudiandae nulla aut.", null },
                    { 2, 23, 13, "Rerum ut aut distinctio quia.", null },
                    { 3, 10, 6, "Et doloremque eum qui.", null },
                    { 4, 16, 4, "Vel non sunt autem pariatur alias sit fuga.", null },
                    { 5, 21, 16, "Atque sit numquam.", null },
                    { 6, 10, 4, "Eos incidunt deleniti sit quidem non quia doloribus vel voluptates.", null },
                    { 7, 13, 9, "Reiciendis fugiat ut consequatur eaque et quo et esse.", null },
                    { 8, 9, 14, "Pariatur sapiente enim debitis libero.", null },
                    { 9, 14, 6, "Vero expedita qui placeat quo repudiandae doloribus tenetur dolor id.", null },
                    { 10, 17, 2, "Omnis eligendi voluptate quaerat sunt ad minus veritatis.", null },
                    { 11, 6, 12, "Sint temporibus accusamus est deserunt odit at ut.", null },
                    { 12, 4, 16, "Quis voluptatum sunt sit.", null },
                    { 13, 13, 6, "Impedit error eum mollitia.", null },
                    { 14, 6, 11, "Dolor quas ut minima qui non quasi porro et velit.", null },
                    { 15, 16, 2, "Impedit fuga et.", null },
                    { 16, 27, 7, "Sed nobis blanditiis dolorem vel nesciunt.", null }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "path", "book_id" },
                values: new object[,]
                {
                    { "10fake path", 26 },
                    { "11fake path", 4 },
                    { "12fake path", 17 },
                    { "13fake path", 4 },
                    { "14fake path", 7 },
                    { "15fake path", 8 },
                    { "16fake path", 20 },
                    { "1fake path", 23 },
                    { "2fake path", 24 },
                    { "3fake path", 12 },
                    { "4fake path", 18 },
                    { "5fake path", 26 },
                    { "6fake path", 18 },
                    { "7fake path", 16 },
                    { "8fake path", 15 },
                    { "9fake path", 26 }
                });

            migrationBuilder.InsertData(
                table: "Register",
                columns: new[] { "Id", "BookId", "Status", "UserId", "borrow_at", "expected_at", "register_at", "return_at" },
                values: new object[,]
                {
                    { 1, 10, "Canceled", 5, null, null, new DateTime(2024, 11, 8, 0, 17, 43, 431, DateTimeKind.Local).AddTicks(2193), null },
                    { 2, 4, "Canceled", 8, null, null, new DateTime(2024, 11, 8, 21, 0, 5, 54, DateTimeKind.Local).AddTicks(3343), null },
                    { 3, 21, "Borrowed", 2, new DateTime(2024, 11, 6, 23, 45, 29, 196, DateTimeKind.Local).AddTicks(6124), new DateTime(2024, 11, 15, 5, 45, 56, 186, DateTimeKind.Local).AddTicks(1456), new DateTime(2024, 11, 8, 5, 45, 56, 186, DateTimeKind.Local).AddTicks(1456), null },
                    { 4, 11, "Canceled", 4, null, null, new DateTime(2024, 11, 6, 0, 49, 58, 614, DateTimeKind.Local).AddTicks(2100), null },
                    { 5, 2, "Borrowed", 3, new DateTime(2024, 11, 7, 7, 8, 11, 162, DateTimeKind.Local).AddTicks(1419), new DateTime(2024, 11, 13, 5, 17, 2, 673, DateTimeKind.Local).AddTicks(7676), new DateTime(2024, 11, 6, 5, 17, 2, 673, DateTimeKind.Local).AddTicks(7676), null },
                    { 6, 27, "Borrowed", 1, new DateTime(2024, 11, 6, 7, 42, 52, 387, DateTimeKind.Local).AddTicks(3855), new DateTime(2024, 11, 11, 7, 58, 57, 159, DateTimeKind.Local).AddTicks(1290), new DateTime(2024, 11, 4, 7, 58, 57, 159, DateTimeKind.Local).AddTicks(1290), null },
                    { 7, 25, "Completed", 9, new DateTime(2024, 11, 4, 16, 27, 17, 588, DateTimeKind.Local).AddTicks(1245), new DateTime(2024, 11, 11, 9, 29, 55, 510, DateTimeKind.Local).AddTicks(27), new DateTime(2024, 11, 4, 9, 29, 55, 510, DateTimeKind.Local).AddTicks(27), new DateTime(2024, 11, 8, 20, 30, 54, 89, DateTimeKind.Local).AddTicks(5207) },
                    { 8, 17, "Pending", 12, null, new DateTime(2024, 11, 15, 3, 48, 31, 993, DateTimeKind.Local).AddTicks(3760), new DateTime(2024, 11, 8, 3, 48, 31, 993, DateTimeKind.Local).AddTicks(3760), null },
                    { 9, 1, "Pending", 12, null, new DateTime(2024, 11, 11, 1, 7, 10, 698, DateTimeKind.Local).AddTicks(728), new DateTime(2024, 11, 4, 1, 7, 10, 698, DateTimeKind.Local).AddTicks(728), null },
                    { 10, 15, "Borrowed", 1, new DateTime(2024, 11, 6, 0, 52, 17, 71, DateTimeKind.Local).AddTicks(4904), new DateTime(2024, 11, 16, 18, 5, 0, 214, DateTimeKind.Local).AddTicks(588), new DateTime(2024, 11, 9, 18, 5, 0, 214, DateTimeKind.Local).AddTicks(588), null },
                    { 11, 24, "Completed", 6, new DateTime(2024, 11, 7, 18, 34, 45, 851, DateTimeKind.Local).AddTicks(1040), new DateTime(2024, 11, 12, 19, 52, 10, 123, DateTimeKind.Local).AddTicks(6329), new DateTime(2024, 11, 5, 19, 52, 10, 123, DateTimeKind.Local).AddTicks(6329), new DateTime(2024, 11, 8, 4, 14, 11, 313, DateTimeKind.Local).AddTicks(9238) },
                    { 12, 14, "Canceled", 2, null, null, new DateTime(2024, 11, 7, 14, 1, 2, 927, DateTimeKind.Local).AddTicks(4258), null },
                    { 13, 10, "Canceled", 15, null, null, new DateTime(2024, 11, 5, 8, 44, 29, 764, DateTimeKind.Local).AddTicks(5450), null },
                    { 14, 10, "Canceled", 3, null, null, new DateTime(2024, 11, 4, 6, 52, 57, 669, DateTimeKind.Local).AddTicks(3167), null },
                    { 15, 10, "Completed", 2, new DateTime(2024, 11, 9, 15, 18, 25, 894, DateTimeKind.Local).AddTicks(4629), new DateTime(2024, 11, 15, 6, 50, 6, 546, DateTimeKind.Local).AddTicks(7043), new DateTime(2024, 11, 8, 6, 50, 6, 546, DateTimeKind.Local).AddTicks(7043), new DateTime(2024, 11, 9, 6, 6, 23, 891, DateTimeKind.Local).AddTicks(9485) },
                    { 16, 17, "Borrowed", 12, new DateTime(2024, 11, 10, 12, 8, 12, 427, DateTimeKind.Local).AddTicks(8546), new DateTime(2024, 11, 14, 4, 4, 20, 873, DateTimeKind.Local).AddTicks(7029), new DateTime(2024, 11, 7, 4, 4, 20, 873, DateTimeKind.Local).AddTicks(7029), null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 17, 23, 11, "Voluptatibus suscipit magnam ex numquam ea qui exercitationem.", 1 },
                    { 18, 18, 9, "Quidem molestiae voluptas id.", 7 },
                    { 19, 23, 2, "Ut nulla accusamus enim.", 4 },
                    { 20, 11, 4, "Minima minima quidem qui deserunt.", 1 },
                    { 21, 20, 10, "Dolores occaecati alias dolor aut.", 1 },
                    { 22, 21, 16, "Et corporis dolorem inventore aut odit quo cupiditate et.", 3 },
                    { 23, 4, 12, "Dignissimos autem reprehenderit vel.", 8 },
                    { 24, 27, 14, "Aut consectetur officiis nobis aliquam quisquam in quibusdam.", 16 },
                    { 25, 10, 15, "Ut itaque sed totam.", 1 },
                    { 26, 13, 3, "Sapiente officiis est ducimus ut.", 12 },
                    { 27, 16, 14, "Est minus suscipit eum in.", 15 },
                    { 28, 24, 9, "Voluptatibus est voluptates.", 1 },
                    { 29, 12, 4, "Minus consequuntur amet deleniti omnis ex.", 12 },
                    { 30, 25, 5, "Corrupti tempore inventore aliquid quo omnis.", 15 },
                    { 31, 25, 11, "Et possimus ut quibusdam omnis aut.", 14 },
                    { 32, 20, 4, "Iure a dolorem illum vero ipsum.", 14 }
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
