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
                    rating = table.Column<byte>(type: "tinyint unsigned", nullable: false)
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
                    { 1, "Qui ut et et aut.", "Esteban" },
                    { 2, "Nisi reprehenderit repellendus odit.", "Audreanne" },
                    { 3, "Id autem a qui.", "Lisa" },
                    { 4, "Sapiente praesentium repellat recusandae aut eos rerum est eaque velit.", "Joy" },
                    { 5, "Et aut sed.", "Josiane" },
                    { 6, "Laboriosam explicabo rem sit dolorem commodi nihil quos assumenda a.", "Constantin" },
                    { 7, "Rem sed quis.", "Lizzie" },
                    { 8, "Sit nihil et aut laborum necessitatibus veritatis ut quis.", "Danyka" },
                    { 9, "Alias explicabo et in porro quidem unde.", "Blake" },
                    { 10, "Atque nobis rerum.", "Lila" },
                    { 11, "Fuga aut aspernatur autem sed dignissimos fuga facere aspernatur aspernatur.", "Garrett" },
                    { 12, "Placeat nemo quasi rerum eum vero atque esse.", "Damaris" },
                    { 13, "Esse aut expedita sunt a nobis est voluptatum.", "Darlene" },
                    { 14, "In minus quia nam voluptatem dolorem.", "Isaias" },
                    { 15, "Ipsam mollitia laboriosam labore at consequatur aperiam.", "Lacey" },
                    { 16, "Ipsa qui dicta aut quis.", "Mariano" },
                    { 17, "Dolor temporibus praesentium inventore quia quibusdam.", "Antoinette" },
                    { 18, "Ut occaecati consequatur totam velit ducimus autem quis et.", "Weston" },
                    { 19, "Atque eum aut.", "Loraine" },
                    { 20, "Natus voluptatem aut dolores.", "Emmanuel" },
                    { 21, "Sunt nulla illum eum aut quisquam blanditiis omnis.", "Alexzander" },
                    { 22, "Esse laborum corporis.", "Carole" },
                    { 23, "Distinctio atque vitae facilis unde quae optio.", "Jordane" },
                    { 24, "Quisquam perspiciatis ipsa.", "Fredrick" },
                    { 25, "Aut reprehenderit in.", "Eulah" },
                    { 26, "Dignissimos deleniti amet libero tenetur.", "Fern" },
                    { 27, "Ut et eos molestiae eum aut modi.", "Eliza" },
                    { 28, "Ea minus et.", "Brody" },
                    { 29, "Deleniti et qui ea aliquam sequi deserunt voluptatibus nostrum iusto.", "Camden" },
                    { 30, "Quod vel dignissimos exercitationem nostrum rerum quasi ut.", "Kristy" },
                    { 31, "Occaecati esse sequi atque perferendis voluptas magni.", "Malvina" },
                    { 32, "A iste cumque veritatis ex exercitationem quas ut voluptatibus qui.", "Ulises" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "nihil", "Lori Heidenreich" },
                    { 2, "Et voluptas suscipit voluptatibus id cumque repellat ut ipsum sint. Consectetur ea delectus nihil natus. Consequatur et enim officia. Eaque laborum incidunt odio voluptatem sed quia sit quia a. Aut aut quasi reprehenderit quasi. Quisquam totam harum non tenetur.", "Sidney Wintheiser" },
                    { 3, "et", "Lincoln Greenholt" },
                    { 4, "Enim vel sapiente dolorum qui quia natus.", "Minnie Simonis" },
                    { 5, "Voluptas sit eligendi magnam rerum. Eos et culpa architecto quia eos ut modi. Temporibus unde magni et. Similique occaecati architecto expedita reiciendis praesentium ab. Eius error similique vero dicta laudantium consectetur rerum nihil esse. Quia repellendus tempore et enim totam exercitationem quae est neque.", "Roselyn Berge" },
                    { 6, "Et rerum id fugit. Quia ipsa veritatis dolorem ut quia quidem eos voluptatibus blanditiis. Nihil qui ex doloremque eaque asperiores nobis doloribus alias consequatur. Necessitatibus veniam numquam et autem expedita. Ipsum at consequatur voluptates ab molestias.", "Laverne Labadie" },
                    { 7, "Quisquam id consequatur amet.\nItaque ut aut eveniet enim sit et velit expedita.", "Roxanne Bahringer" },
                    { 8, "quis", "Evert Corwin" },
                    { 9, "occaecati", "Roderick Johnston" },
                    { 10, "Sed quidem ut explicabo repellendus.", "Dena Turner" },
                    { 11, "Quasi libero sit autem omnis. Ipsum accusamus provident ad quia porro libero nisi blanditiis. Maiores blanditiis velit est qui ducimus odit libero.", "Aron Mayer" },
                    { 12, "Aut ad quia enim consectetur tempore est inventore dolorum numquam.", "Kadin McCullough" },
                    { 13, "Dolore omnis et dolores et earum.\nNam alias nobis iure facere recusandae veritatis id modi.\nRepudiandae quas dignissimos voluptas rerum qui.", "Lorna Harris" },
                    { 14, "Pariatur quis occaecati ipsa. Error laudantium eum et minus ut occaecati. Maiores dolores nam reiciendis. Velit dolorem temporibus ut iure et aut. Quis nisi veniam officiis iure et eligendi deleniti consequatur. Sunt debitis eaque optio dolores sunt itaque.", "Gerald Spinka" },
                    { 15, "Velit nihil nesciunt sint accusamus tempora aut sunt velit quis. Quaerat iste dolorum ea eum est quae quas. Quia exercitationem vero sit. Eum similique iusto dolores et aut.", "America Graham" },
                    { 16, "Sint tempore necessitatibus.", "Brad Thiel" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "author_id", "description", "name", "rating" },
                values: new object[,]
                {
                    { 1, 1, "Laudantium qui vitae eos eos nisi facilis nulla nam. Doloremque beatae labore ut voluptatibus autem consequuntur atque et. Eum vel facere architecto eum non reprehenderit. Ea maiores consectetur aut nihil ullam.", "Odit voluptatem facere.", (byte)0 },
                    { 2, 7, "Exercitationem molestias in fugit voluptatem nemo. Dolor rem dolores molestias cumque vitae eos ipsum reprehenderit. Quo sit provident atque. Quis quisquam mollitia et tenetur quisquam sed incidunt.", "Ut distinctio aliquid omnis voluptate distinctio aut consectetur soluta.", (byte)0 },
                    { 3, 32, "Voluptatem ut vero ipsam ea qui sit. Provident excepturi culpa praesentium beatae sed quasi. Ipsum aperiam voluptatem quae sit nisi architecto iusto. Non qui inventore et sed dolorem non.", "Reiciendis sed qui quos veniam et repellendus.", (byte)0 },
                    { 4, 19, "Dicta aperiam ipsum necessitatibus vitae quia praesentium asperiores nemo. Aliquam sint consectetur. Eos pariatur rem ut totam magnam soluta. Molestias voluptatem aut facere adipisci ipsa maiores repellat. Provident laboriosam aperiam. Non facere rem aliquid voluptas et rerum consequatur.", "Magnam hic quia.", (byte)0 },
                    { 5, 28, "Aut dolorem sit assumenda non blanditiis et deserunt. Tenetur autem accusamus qui. Dolorem aliquid dolore qui. Maiores officiis temporibus.", "Ut aliquid asperiores natus officia est at distinctio eveniet.", (byte)0 },
                    { 6, 15, "Ab facere quod aliquam aut. Et laudantium aliquid excepturi eum optio rerum. Tempore est quia possimus.", "Explicabo ipsa doloribus repellat excepturi cum.", (byte)0 },
                    { 7, 12, "Inventore accusamus alias reiciendis alias et ut. Incidunt consectetur odio. Autem vero et voluptatem qui rerum.", "Aut ex delectus.", (byte)0 },
                    { 8, 11, "Blanditiis rem illo aspernatur. Sequi eaque necessitatibus perferendis ipsum. Non facere iusto. Odio laboriosam nisi quibusdam facilis quis ea et omnis error. Ut aut laudantium aliquam sit porro.", "Et illum non esse.", (byte)0 },
                    { 9, 6, "Rerum distinctio enim nobis non dolor sit et nihil suscipit. Id enim sint consequatur nihil sed quia et numquam. Aut fugiat ab minima. Accusantium dolores veniam officia aut dolor. Magnam dolores explicabo illum. Dolores asperiores odit non.", "Minima temporibus et quis incidunt maxime exercitationem autem quia.", (byte)0 },
                    { 10, 4, "Et itaque aut omnis blanditiis provident. Quaerat saepe illo odit qui rem qui quaerat ab. Accusamus aliquam rerum suscipit nisi voluptatem magnam.", "Maxime labore modi incidunt recusandae ut voluptate ut.", (byte)0 },
                    { 11, 25, "Quis quidem sequi est. Eaque distinctio consequatur. Rerum nihil et.", "Ex dignissimos eveniet.", (byte)0 },
                    { 12, 17, "Reprehenderit et aut et voluptatem aut vel. Nemo aut molestias consequatur quam dolorem odit. Nisi ut quia repudiandae reprehenderit porro repudiandae aut. Soluta molestiae repellendus ut numquam quia aut omnis optio. Debitis suscipit voluptatem laudantium dolor. Nisi vel ipsam corporis suscipit cum in illo inventore at.", "Nobis omnis laudantium iusto.", (byte)0 },
                    { 13, 9, "Reprehenderit deleniti quia quibusdam veniam excepturi sed sint iure. Soluta consequuntur dolorem odio inventore et ut inventore at labore. Labore adipisci quod magni minus labore quo. Deserunt aut distinctio quo quaerat consequatur a quis qui.", "Unde qui sint ut animi fugiat odio in.", (byte)0 },
                    { 14, 6, "Velit dolorem neque. Necessitatibus repudiandae fuga qui autem veritatis. Corporis non incidunt cumque ad doloremque quod. Sunt ratione vel aut totam.", "Sequi dolor adipisci perspiciatis maxime rerum molestiae.", (byte)0 },
                    { 15, 30, "Quo tempora velit quaerat non ex est laudantium error. Ea dignissimos nobis qui et. Commodi beatae quas quam. Doloremque minima ducimus dolor.", "Omnis voluptatem consectetur iste mollitia.", (byte)0 },
                    { 16, 1, "Assumenda expedita fugiat. Est vitae sunt explicabo quia temporibus magnam minima. Deleniti unde quia autem necessitatibus est qui. Sit et repellendus voluptate eum nihil dolorem quas est unde.", "Suscipit aut omnis iusto reprehenderit nihil.", (byte)0 },
                    { 17, 23, "Veritatis voluptatem odio sapiente mollitia voluptas rerum rerum quia aut. Similique beatae quidem omnis rerum saepe voluptates rerum itaque at. Aut autem voluptatem eum quis provident aut eum reprehenderit sapiente. Reprehenderit tenetur ex illo.", "Laborum sint ex quaerat ea repudiandae nulla ut aut.", (byte)0 },
                    { 18, 12, "Laboriosam eius aut sequi praesentium voluptatibus qui. Dolorem est doloremque sed nihil aut. Maiores et voluptate est quidem ut blanditiis quia. Est rerum maxime.", "Asperiores error accusamus dolore dignissimos non.", (byte)0 },
                    { 19, 28, "Qui eveniet quo eos expedita vero. Consequatur veniam nostrum. Assumenda eos qui nemo nam tenetur minima molestiae. Non voluptatibus et doloribus et vel. Sed culpa est accusantium et rerum delectus veniam. Hic accusamus et.", "Enim quis alias exercitationem.", (byte)0 },
                    { 20, 22, "Explicabo perspiciatis quod rerum ea nemo. Quos autem rerum nobis ipsum qui. Et suscipit numquam quis quaerat enim esse rem.", "Architecto vero dolorem vel fugiat eius fugit.", (byte)0 },
                    { 21, 21, "Laudantium excepturi esse ut sunt unde ut alias. Ut et ab sit enim dolor atque non dolore. Nemo ratione quia consequatur voluptatem et omnis asperiores soluta. Dolorum amet sapiente sint. Sint ratione necessitatibus perferendis soluta. Rem ad quisquam.", "Nemo ipsam libero culpa ut dolor suscipit maxime praesentium ut.", (byte)0 },
                    { 22, 2, "Consequatur enim provident est sed dolorem. Laborum quisquam quod voluptatem ea. Veritatis nemo repellendus. Earum exercitationem atque provident cupiditate. Occaecati quia architecto voluptatibus doloremque. Voluptatem cumque rem qui consequuntur nulla.", "Vel eos error a ut incidunt nisi laborum qui.", (byte)0 },
                    { 23, 26, "Ad porro ea. Consequuntur in ex voluptatum eligendi ut totam distinctio voluptatem. Reprehenderit pariatur iusto qui mollitia similique ut placeat minima quas. Ut et voluptates nostrum omnis labore dolorem et voluptas quasi. Nihil placeat quia. Deleniti totam facilis expedita.", "Laborum est cupiditate dolores esse et sed voluptatem ipsam.", (byte)0 },
                    { 24, 29, "Ut nemo consectetur reprehenderit non qui. Beatae dolores explicabo inventore. Quod a exercitationem amet illo accusamus. Cupiditate voluptate libero. Sit labore sed.", "Fugit repellat et.", (byte)0 },
                    { 25, 3, "Id ut explicabo est culpa. Magni inventore quia dolore numquam. Nostrum sit omnis at sit. Quae aut et sunt vel.", "Distinctio sint nesciunt laudantium accusamus fuga nisi.", (byte)0 },
                    { 26, 19, "Quam eaque quam voluptates doloribus dolores consequuntur. Excepturi et ut nobis. Veritatis molestias dignissimos praesentium rerum iure sunt et aut at.", "Provident et et.", (byte)0 },
                    { 27, 1, "Tenetur omnis perspiciatis aliquid consequatur quo doloribus facilis. Et delectus enim. Dolorum at et blanditiis deleniti maiores. Molestiae dolor enim deleniti. Consequatur minima aut esse natus omnis vel sit nesciunt et.", "Error dolore odit non maiores provident ipsum explicabo aliquid.", (byte)0 },
                    { 28, 29, "Autem totam repellendus numquam non. Quod aliquid maiores dolorem voluptas nemo ut est. Voluptatem eaque autem ipsa possimus maxime optio ut. In totam aut eius pariatur sit eum magnam quia. Est itaque totam ut id cupiditate. Numquam et aut tempore ab ab laboriosam.", "Enim iure odio dolores numquam qui sed.", (byte)0 },
                    { 29, 17, "Et nesciunt corporis repudiandae. Harum ut repudiandae dignissimos. Facere cum quia. Molestiae ducimus ea pariatur accusantium quia et et. Omnis voluptatem repellat et odit sunt fugit tempore eius.", "Delectus dolores vero soluta totam molestiae dignissimos.", (byte)0 },
                    { 30, 10, "Illum nam totam velit quas officiis qui rerum magni. Tempore voluptatem veritatis excepturi. At deleniti debitis accusamus autem mollitia. Voluptatem rerum adipisci enim iste non. Maiores est qui quia modi animi eum ut eos. Dolorem corrupti minus voluptatem nesciunt velit voluptatem voluptas expedita molestiae.", "Error amet porro officia et.", (byte)0 },
                    { 31, 24, "Vitae explicabo dolor. Aspernatur optio est hic excepturi ducimus et enim. Voluptas laudantium quidem ex amet accusamus itaque autem.", "Eum aperiam dolorem sapiente dolorum nostrum repellat est ea voluptas.", (byte)0 },
                    { 32, 3, "Qui sit odio neque ipsa ipsam aspernatur magni qui reiciendis. Assumenda sit reprehenderit sint quisquam non voluptatum consequuntur. Recusandae ea qui. Voluptatem ut vel saepe est alias earum cumque repudiandae atque.", "Facilis et enim iure veniam recusandae quod nam.", (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 1, 13, 7, "Rem labore ex.", null },
                    { 2, 13, 8, "Vitae quas a ipsum qui consectetur.", null },
                    { 3, 5, 6, "Laboriosam velit eligendi temporibus minima non dicta.", null },
                    { 4, 12, 6, "Est nam aperiam similique.", null },
                    { 5, 15, 14, "Et ipsum eligendi rerum.", null },
                    { 6, 18, 14, "Nisi vero quos qui corrupti repellendus et aspernatur alias.", null },
                    { 7, 13, 16, "Quia aut doloribus aliquam velit rerum impedit quidem enim.", null },
                    { 8, 4, 4, "Dicta debitis et quam ut itaque et accusamus occaecati eaque.", null },
                    { 9, 28, 10, "Reprehenderit quo consequuntur labore ut recusandae explicabo laudantium asperiores minus.", null },
                    { 10, 3, 15, "Sit natus aut et.", null },
                    { 11, 28, 4, "Non eaque suscipit error natus provident nulla nulla modi quos.", null },
                    { 12, 21, 12, "Qui unde sequi quia doloremque sit ad.", null },
                    { 13, 30, 16, "Minima sed provident asperiores magni consequuntur.", null },
                    { 14, 7, 11, "Iusto dolor est.", null },
                    { 15, 5, 13, "Aut optio adipisci hic tenetur assumenda aut placeat suscipit ut.", null },
                    { 16, 18, 11, "A illo explicabo veritatis est corrupti quae.", null }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "path", "book_id" },
                values: new object[,]
                {
                    { "10fake path", 6 },
                    { "11fake path", 15 },
                    { "12fake path", 29 },
                    { "13fake path", 3 },
                    { "14fake path", 22 },
                    { "15fake path", 15 },
                    { "16fake path", 14 },
                    { "1fake path", 12 },
                    { "2fake path", 9 },
                    { "3fake path", 14 },
                    { "4fake path", 7 },
                    { "5fake path", 3 },
                    { "6fake path", 16 },
                    { "7fake path", 22 },
                    { "8fake path", 27 },
                    { "9fake path", 10 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "UserId", "content", "parent_id" },
                values: new object[,]
                {
                    { 17, 22, 9, "Quod perspiciatis occaecati possimus voluptatum consequatur architecto dolor amet et.", 14 },
                    { 18, 5, 10, "Fuga veniam nesciunt.", 15 },
                    { 19, 28, 5, "Est tempore natus totam velit facere eum vitae.", 14 },
                    { 20, 6, 12, "Minima sit neque totam laborum illo pariatur odio dignissimos voluptas.", 14 },
                    { 21, 27, 4, "Incidunt et asperiores laudantium non ab sunt doloribus omnis dolorem.", 10 },
                    { 22, 23, 16, "Fugiat incidunt molestiae magni excepturi dolorem fuga est omnis voluptas.", 2 },
                    { 23, 27, 2, "Magnam quae natus harum quos sint.", 1 },
                    { 24, 25, 15, "Perferendis non et consequatur autem quam quod nobis veniam cumque.", 14 },
                    { 25, 13, 2, "Perferendis quos reiciendis voluptatem ea facilis sed aliquam enim.", 5 },
                    { 26, 18, 9, "Illo quo omnis deserunt sit reprehenderit.", 15 },
                    { 27, 12, 13, "Ab perferendis exercitationem et.", 1 },
                    { 28, 10, 10, "Aperiam rerum amet.", 3 },
                    { 29, 27, 7, "Repudiandae sed aliquam inventore expedita deleniti sint et sed magnam.", 6 },
                    { 30, 15, 8, "Soluta praesentium dolores qui qui.", 3 },
                    { 31, 15, 14, "Ea laudantium quia libero perspiciatis cum.", 4 },
                    { 32, 19, 5, "Aliquam possimus omnis cumque eos minus cumque rem aut unde.", 10 }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookInteractions");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
