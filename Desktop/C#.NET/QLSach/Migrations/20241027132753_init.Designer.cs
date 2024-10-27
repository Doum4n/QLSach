﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLSach.database;

#nullable disable

namespace QLSach.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241027132753_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("QLSach.database.models.BookInteraction", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("comment")
                        .HasColumnType("int");

                    b.Property<bool>("liked")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.Property<bool>("saved")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("BookId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("BookInteractions");
                });

            modelBuilder.Entity("QLSach.database.models.Photo", b =>
                {
                    b.Property<string>("path")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("book_id")
                        .HasColumnType("int");

                    b.HasKey("path");

                    b.HasIndex("book_id")
                        .IsUnique();

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            path = "2fake path",
                            book_id = 1
                        },
                        new
                        {
                            path = "3fake path",
                            book_id = 2
                        },
                        new
                        {
                            path = "4fake path",
                            book_id = 3
                        },
                        new
                        {
                            path = "5fake path",
                            book_id = 4
                        },
                        new
                        {
                            path = "6fake path",
                            book_id = 5
                        },
                        new
                        {
                            path = "7fake path",
                            book_id = 6
                        },
                        new
                        {
                            path = "8fake path",
                            book_id = 7
                        },
                        new
                        {
                            path = "9fake path",
                            book_id = 8
                        },
                        new
                        {
                            path = "10fake path",
                            book_id = 9
                        },
                        new
                        {
                            path = "11fake path",
                            book_id = 10
                        },
                        new
                        {
                            path = "12fake path",
                            book_id = 11
                        },
                        new
                        {
                            path = "13fake path",
                            book_id = 12
                        },
                        new
                        {
                            path = "14fake path",
                            book_id = 13
                        },
                        new
                        {
                            path = "15fake path",
                            book_id = 14
                        },
                        new
                        {
                            path = "16fake path",
                            book_id = 15
                        },
                        new
                        {
                            path = "17fake path",
                            book_id = 16
                        });
                });

            modelBuilder.Entity("QLSach.database.models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QLSach.dbContext.models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("author_id")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("author_id")
                        .IsUnique();

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            author_id = 1,
                            description = "Expedita sit qui quaerat est blanditiis dolorum eveniet amet voluptas. Dolorem nemo illum quaerat esse. Deleniti quibusdam ea libero ut quas ipsam. Repellat suscipit aliquid.",
                            name = "In omnis tenetur maiores qui ea fugiat quia."
                        },
                        new
                        {
                            Id = 2,
                            author_id = 2,
                            description = "Optio totam est voluptatem animi dolores quidem et. Eos aut omnis consectetur ut qui tempora beatae. Est nisi aut voluptates excepturi voluptas doloribus nemo qui.",
                            name = "Sunt nam quo ad magni nihil quam magni."
                        },
                        new
                        {
                            Id = 3,
                            author_id = 3,
                            description = "Sed aut quidem necessitatibus nihil vero. Consequatur reprehenderit minus doloremque enim est enim veritatis. Et eveniet non tenetur fugit est. Nihil natus temporibus odio excepturi iure necessitatibus et earum laboriosam. Alias non architecto facere et. Quo cupiditate reprehenderit accusamus ut.",
                            name = "In voluptates facere aut sint optio officia voluptas est corporis."
                        },
                        new
                        {
                            Id = 4,
                            author_id = 4,
                            description = "Iusto in quas. Quis rem placeat repudiandae provident rerum recusandae. Ullam minus culpa optio. Nobis at asperiores et sit. Et ea qui.",
                            name = "Ut voluptates eveniet quibusdam."
                        },
                        new
                        {
                            Id = 5,
                            author_id = 5,
                            description = "Repudiandae dolorem non ipsam. Perspiciatis qui blanditiis laudantium possimus autem aut. Qui sint aut fugiat et. Maxime animi quam qui esse sit exercitationem sunt impedit. Aut et et.",
                            name = "Quidem placeat nam modi eos ea voluptatem in nemo consequuntur."
                        },
                        new
                        {
                            Id = 6,
                            author_id = 6,
                            description = "Nulla repudiandae rerum dolorem voluptatem temporibus amet alias et rem. Et veritatis nihil natus aut rerum. Sed deserunt aut ut expedita.",
                            name = "Perspiciatis sequi architecto aut a cupiditate sit veniam."
                        },
                        new
                        {
                            Id = 7,
                            author_id = 7,
                            description = "Nulla itaque eius sequi explicabo corrupti autem odit. Ipsam doloremque in. Aut voluptates consectetur voluptates molestiae. Dolore qui et.",
                            name = "Rem nam pariatur illum asperiores libero molestias asperiores."
                        },
                        new
                        {
                            Id = 8,
                            author_id = 8,
                            description = "Nihil tenetur nihil est ea. In libero natus architecto iste enim sapiente. Qui ut rerum mollitia dolorem rem similique fugiat nulla aut. Temporibus soluta vero aut. Vel repellat assumenda recusandae excepturi quia deleniti magni perferendis.",
                            name = "Deserunt autem eos."
                        },
                        new
                        {
                            Id = 9,
                            author_id = 9,
                            description = "Molestias a eos officia soluta veniam rerum cumque. Et qui qui laudantium nobis voluptas sed eos. Et accusamus reprehenderit ipsum. Labore rem provident dolores. Quis quis expedita quo dolores explicabo quis. Voluptatem sed ut autem sint unde nulla.",
                            name = "Commodi ut voluptatem dolor quos quasi inventore."
                        },
                        new
                        {
                            Id = 10,
                            author_id = 10,
                            description = "Cum iusto voluptatem voluptatem maxime earum. Quod quo quod incidunt inventore a. Nihil quos aut dolore beatae alias autem eveniet. Autem id voluptas quia eaque. Possimus dolorum perspiciatis harum nisi sunt sit at. Recusandae debitis sed aperiam consequatur.",
                            name = "Voluptatem laudantium rerum et."
                        },
                        new
                        {
                            Id = 11,
                            author_id = 11,
                            description = "Qui qui labore vitae et maiores sunt ut sed libero. Laborum incidunt iure quibusdam veniam hic. Odit quia recusandae quisquam corporis in. Rerum doloremque quo. Mollitia veniam provident aut veniam cum a doloremque.",
                            name = "Quidem veritatis sapiente et provident maiores a."
                        },
                        new
                        {
                            Id = 12,
                            author_id = 12,
                            description = "Sed vel quibusdam at illo eum. Vero quia qui et. Id doloribus dignissimos incidunt ut et autem et iure eos. Ut est voluptatem sequi omnis vitae itaque est. Vero alias sunt vitae sequi dolorum et.",
                            name = "Eos culpa doloribus quaerat facere quis officia sed repellendus."
                        },
                        new
                        {
                            Id = 13,
                            author_id = 13,
                            description = "Veniam reiciendis non quae nostrum. Qui reprehenderit culpa soluta ipsa eius voluptates temporibus. Quia dolorem repellat quos. Eum aut consequuntur et consectetur rem nisi.",
                            name = "Fuga consequatur doloribus reprehenderit voluptates."
                        },
                        new
                        {
                            Id = 14,
                            author_id = 14,
                            description = "Fugiat aut recusandae hic magnam nulla et. Quam magni voluptas nesciunt optio qui amet iure. Aut unde aliquid laborum ut est et. Cum similique repudiandae. A excepturi esse aut iusto ea eveniet non deserunt.",
                            name = "Fuga nihil maxime est nesciunt ipsum reprehenderit."
                        },
                        new
                        {
                            Id = 15,
                            author_id = 15,
                            description = "Nisi accusamus aliquam. Recusandae dolorem saepe rerum neque nam nobis eum. Dolor sit voluptatem dolorum velit facilis. Pariatur rerum eaque vel rerum qui eius.",
                            name = "Vitae numquam et nam ut."
                        },
                        new
                        {
                            Id = 16,
                            author_id = 16,
                            description = "Tempore architecto ea. Ut recusandae ipsum temporibus. Voluptas cupiditate laborum. Repellendus earum eum inventore.",
                            name = "Et maiores id molestiae tenetur adipisci minus et repellat."
                        });
                });

            modelBuilder.Entity("QLSach.dbContext.models.author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            description = "Molestias atque reprehenderit odio quae non explicabo.",
                            name = "Willa"
                        },
                        new
                        {
                            Id = 2,
                            description = "Labore ducimus aliquam culpa praesentium quo facilis.",
                            name = "Filomena"
                        },
                        new
                        {
                            Id = 3,
                            description = "Voluptatem eos non.",
                            name = "Aurelie"
                        },
                        new
                        {
                            Id = 4,
                            description = "Et autem odio ut assumenda recusandae.",
                            name = "Brannon"
                        },
                        new
                        {
                            Id = 5,
                            description = "Ducimus minima corporis vel omnis.",
                            name = "Kurt"
                        },
                        new
                        {
                            Id = 6,
                            description = "Veniam aut quaerat neque sequi aut.",
                            name = "Bette"
                        },
                        new
                        {
                            Id = 7,
                            description = "Autem nulla quibusdam eveniet veritatis.",
                            name = "Lee"
                        },
                        new
                        {
                            Id = 8,
                            description = "Et voluptatem fuga numquam.",
                            name = "Corene"
                        },
                        new
                        {
                            Id = 9,
                            description = "Sunt deleniti et et eos.",
                            name = "Tamara"
                        },
                        new
                        {
                            Id = 10,
                            description = "Quod officia reiciendis eveniet et laboriosam est quo assumenda.",
                            name = "Johan"
                        },
                        new
                        {
                            Id = 11,
                            description = "At quas cupiditate dolores sunt voluptatem est sunt vel.",
                            name = "Mariano"
                        },
                        new
                        {
                            Id = 12,
                            description = "Dignissimos quasi ut aliquam nam soluta sit cupiditate placeat illo.",
                            name = "Pattie"
                        },
                        new
                        {
                            Id = 13,
                            description = "Deserunt dolore dolore laudantium dignissimos earum quae aspernatur doloremque sit.",
                            name = "Braden"
                        },
                        new
                        {
                            Id = 14,
                            description = "In nemo vel.",
                            name = "Chanel"
                        },
                        new
                        {
                            Id = 15,
                            description = "Doloremque recusandae est unde necessitatibus aliquid et id eligendi ut.",
                            name = "Horacio"
                        },
                        new
                        {
                            Id = 16,
                            description = "Voluptatem aut consequatur est autem.",
                            name = "Vern"
                        });
                });

            modelBuilder.Entity("QLSach.database.models.BookInteraction", b =>
                {
                    b.HasOne("QLSach.dbContext.models.Book", null)
                        .WithMany("Interactions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLSach.database.models.User", null)
                        .WithMany("Interactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLSach.database.models.Photo", b =>
                {
                    b.HasOne("QLSach.dbContext.models.Book", "Book")
                        .WithOne("photo")
                        .HasForeignKey("QLSach.database.models.Photo", "book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("QLSach.dbContext.models.Book", b =>
                {
                    b.HasOne("QLSach.dbContext.models.author", "author")
                        .WithOne("Book")
                        .HasForeignKey("QLSach.dbContext.models.Book", "author_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");
                });

            modelBuilder.Entity("QLSach.database.models.User", b =>
                {
                    b.Navigation("Interactions");
                });

            modelBuilder.Entity("QLSach.dbContext.models.Book", b =>
                {
                    b.Navigation("Interactions");

                    b.Navigation("photo");
                });

            modelBuilder.Entity("QLSach.dbContext.models.author", b =>
                {
                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}