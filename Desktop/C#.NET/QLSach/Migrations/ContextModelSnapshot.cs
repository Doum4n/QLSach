﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLSach.database;

#nullable disable

namespace QLSach.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<bool>("liked")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.Property<bool>("saved")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("BookId", "UserId");

                    b.HasIndex("CommentId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("BookInteractions");
                });

            modelBuilder.Entity("QLSach.database.models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("parent_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.HasIndex("parent_id");

                    b.ToTable("Comments");
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "Maxime voluptatem voluptatem quidem illo facere.\nLabore non libero consequatur eaque.",
                            UserName = "Morgan Pacocha"
                        },
                        new
                        {
                            Id = 2,
                            Password = "Neque inventore incidunt voluptate sequi dolorum neque necessitatibus at placeat.\nDistinctio consequatur perferendis ullam velit.",
                            UserName = "Julius Hickle"
                        },
                        new
                        {
                            Id = 3,
                            Password = "Blanditiis at dolores rerum blanditiis quas magni dolores placeat quis. Rerum sed voluptas. Quasi natus at veritatis ab unde enim. Perferendis velit est a necessitatibus animi dolores doloribus.",
                            UserName = "Brain Muller"
                        },
                        new
                        {
                            Id = 4,
                            Password = "est",
                            UserName = "Emmy Mitchell"
                        },
                        new
                        {
                            Id = 5,
                            Password = "et",
                            UserName = "Leora Gislason"
                        },
                        new
                        {
                            Id = 6,
                            Password = "libero",
                            UserName = "Rosanna Macejkovic"
                        },
                        new
                        {
                            Id = 7,
                            Password = "Voluptatem ut assumenda sed corporis eum tenetur.\nSit neque autem et rem temporibus assumenda.\nAccusantium qui deserunt distinctio atque et.\nNon eaque adipisci quo et accusantium sapiente illum dicta praesentium.",
                            UserName = "Linda Schumm"
                        },
                        new
                        {
                            Id = 8,
                            Password = "non",
                            UserName = "Obie Mohr"
                        },
                        new
                        {
                            Id = 9,
                            Password = "Eos dolore id quod velit.",
                            UserName = "Laverna Hilpert"
                        },
                        new
                        {
                            Id = 10,
                            Password = "Culpa adipisci iusto velit aliquam tenetur repudiandae iure vero neque. Fugit dolores illum. Quis praesentium et.",
                            UserName = "Reese Cruickshank"
                        },
                        new
                        {
                            Id = 11,
                            Password = "Et facere est aut necessitatibus possimus enim voluptatibus. Quibusdam nihil id odio voluptatem dolorem id ipsam saepe. Nostrum qui omnis voluptas quis quae rerum sunt architecto debitis. Non architecto quasi sunt possimus provident nam laborum nihil. Et quia rerum ut provident sunt occaecati est id voluptate.",
                            UserName = "Susanna Kerluke"
                        },
                        new
                        {
                            Id = 12,
                            Password = "veritatis",
                            UserName = "Asa Feeney"
                        },
                        new
                        {
                            Id = 13,
                            Password = "Labore voluptatem voluptatem modi.\nDucimus qui vel voluptatem rem rem.\nNon animi optio in.",
                            UserName = "Luisa Predovic"
                        },
                        new
                        {
                            Id = 14,
                            Password = "Quia ut et sequi quod magni qui ut inventore necessitatibus.\nUllam sapiente rerum aut ut.\nAutem voluptates rerum explicabo.\nAd eius dolore.\nSequi est facere minus deserunt ut voluptas eligendi rerum.",
                            UserName = "Hector Russel"
                        },
                        new
                        {
                            Id = 15,
                            Password = "Eveniet laudantium nulla dicta dicta.\nEt autem quo eius libero et.\nAut neque sequi sint.",
                            UserName = "Lila Ernser"
                        },
                        new
                        {
                            Id = 16,
                            Password = "Error eaque laboriosam voluptatibus facilis aut et architecto quam.\nA porro non commodi nulla.",
                            UserName = "Benton Reichert"
                        });
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
                        .HasColumnType("longtext");

                    b.Property<byte>("rating")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("author_id")
                        .IsUnique();

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            author_id = 1,
                            description = "Amet suscipit magnam culpa ad eos nisi. Non tempore quaerat. Dolore sunt nisi officiis necessitatibus.",
                            name = "Et et quis dolore consectetur quia non itaque.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 2,
                            author_id = 2,
                            description = "Fugiat rem ullam aut veniam aliquid. Officiis quos et odio mollitia. Officiis ducimus eos quia velit dolor nostrum a adipisci odit. Sed consequatur eligendi. Non ut sed nihil quo et omnis perferendis in. Quaerat sint alias asperiores ut et.",
                            name = "Impedit sed non ipsa maxime assumenda.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 3,
                            author_id = 3,
                            description = "Natus amet sint voluptatem officia. Occaecati enim cumque vitae ut qui ut molestiae corrupti. Repellat consequuntur est perspiciatis ut nihil iste dolorum expedita ipsum. Ex et atque esse quod voluptates dolorem. Delectus eos sunt a tempora veniam id ea.",
                            name = "Voluptatum ut ut quo non non rerum quo molestiae.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 4,
                            author_id = 4,
                            description = "Eaque qui ipsum rem occaecati qui praesentium consequuntur corporis. Ipsam et repellendus et voluptas. Asperiores ea ea et sint cumque incidunt atque. Sed accusantium voluptatibus blanditiis. Aut velit possimus nobis consequatur velit excepturi facere.",
                            name = "Maiores qui autem porro rerum velit officia necessitatibus corrupti quo.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 5,
                            author_id = 5,
                            description = "Eos aliquam a nam sed odio natus praesentium. Mollitia aperiam quod quam ratione tempore corrupti voluptatem commodi rerum. Odit quis accusantium pariatur molestiae quis voluptatem unde quidem. Facilis enim veniam in. Et hic aut vel molestiae labore tempora reprehenderit. Omnis ipsa hic rerum voluptatem non eum.",
                            name = "Nesciunt numquam eum.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 6,
                            author_id = 6,
                            description = "Numquam aliquam rem dolorem velit quo. Unde alias cumque sint. Enim qui quam eos aut porro in ex et voluptatibus. Et sed molestias et est dicta. Ipsa et corrupti et molestiae.",
                            name = "Atque a at quia.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 7,
                            author_id = 7,
                            description = "At corrupti quidem ducimus saepe et distinctio ut. Voluptatem minima eligendi tenetur dolorem soluta quo nobis non. Adipisci sequi illum eaque nesciunt eos. Impedit vero et architecto tempora placeat. Explicabo veniam est officia cupiditate ut dolores architecto et. Explicabo totam quia ipsum exercitationem occaecati ab eum nobis.",
                            name = "Quo minima porro voluptas harum harum magni odit.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 8,
                            author_id = 8,
                            description = "Est iste doloribus ipsa. Est incidunt ipsum laborum labore. Voluptate natus unde debitis harum ratione nihil quis maxime. Esse reprehenderit corrupti eaque excepturi porro. Deleniti numquam eligendi.",
                            name = "Dolores suscipit aut culpa cumque.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 9,
                            author_id = 9,
                            description = "Voluptate repellendus fugit at. Voluptatem nesciunt ut molestias cumque est. Quis labore tempore dignissimos et et optio sit.",
                            name = "Deserunt et animi repellat dolore consequatur consectetur distinctio officiis.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 10,
                            author_id = 10,
                            description = "Minima atque maiores esse error. Iure temporibus quia. Voluptatum hic praesentium omnis reiciendis. Ad neque cupiditate aliquid. Quasi laudantium quia illo quas incidunt impedit. Doloremque necessitatibus quisquam nobis illo.",
                            name = "Ducimus culpa est impedit dolores quia totam porro sed.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 11,
                            author_id = 11,
                            description = "Est ipsum veritatis quia inventore quia et eum ratione. Sit voluptas eum consequatur et odit. Optio aut temporibus voluptatibus necessitatibus molestiae saepe. Modi reiciendis ut eius. Dicta ab qui exercitationem accusamus hic et perferendis. Et dolores et sapiente repellat et.",
                            name = "Eaque explicabo id.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 12,
                            author_id = 12,
                            description = "Explicabo quo autem veritatis et fugiat dignissimos consequuntur. Et necessitatibus a soluta. Nulla qui dolor vero esse sapiente quo dolor reiciendis voluptas.",
                            name = "Repudiandae sit provident tempore.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 13,
                            author_id = 13,
                            description = "Aliquam eveniet ullam culpa molestiae maiores rerum consequuntur qui eligendi. Aut quo nesciunt delectus earum. Odit dignissimos non harum amet voluptatem nostrum quae sit sunt. Et sunt alias.",
                            name = "Similique voluptatem omnis laudantium dolorem.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 14,
                            author_id = 14,
                            description = "Quis veniam quia id voluptatem nulla accusantium. Ipsum vel nostrum tenetur illum magnam et voluptatibus quis est. Iste dolor est sunt aut. Facere et optio. Quis placeat suscipit et quaerat aut enim fugit aut non. Quo dolores eum.",
                            name = "Vero possimus culpa rerum quia qui.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 15,
                            author_id = 15,
                            description = "Animi impedit qui delectus excepturi voluptas accusamus. Enim atque ut nemo. Modi quod ut dolorem dolorem aut ut quia voluptatem eum. Velit asperiores dolorem. Voluptas corporis esse libero aspernatur nulla aut sapiente quasi.",
                            name = "Fuga sequi ex aut dolores.",
                            rating = (byte)0
                        },
                        new
                        {
                            Id = 16,
                            author_id = 16,
                            description = "Modi non qui pariatur dignissimos quisquam doloribus. Ea et occaecati aut incidunt officiis dicta. Deserunt dolorem beatae et nam similique iusto dolore perspiciatis reprehenderit. Delectus deleniti commodi magnam praesentium harum odio quisquam.",
                            name = "Atque voluptatem officiis illum vitae.",
                            rating = (byte)0
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
                            description = "Velit accusamus unde laudantium explicabo error qui cupiditate veritatis recusandae.",
                            name = "Julio"
                        },
                        new
                        {
                            Id = 2,
                            description = "Eaque non quasi qui nostrum deleniti porro est illo.",
                            name = "Constantin"
                        },
                        new
                        {
                            Id = 3,
                            description = "Corporis fugiat consectetur doloremque.",
                            name = "Jeff"
                        },
                        new
                        {
                            Id = 4,
                            description = "Ut ut quidem dolor molestias eos.",
                            name = "Roslyn"
                        },
                        new
                        {
                            Id = 5,
                            description = "Possimus perspiciatis veritatis delectus corrupti itaque iste.",
                            name = "Randal"
                        },
                        new
                        {
                            Id = 6,
                            description = "Itaque dicta expedita vitae neque ducimus architecto et in.",
                            name = "Jazmyne"
                        },
                        new
                        {
                            Id = 7,
                            description = "Enim velit doloribus beatae.",
                            name = "Cedrick"
                        },
                        new
                        {
                            Id = 8,
                            description = "Deserunt doloribus quibusdam.",
                            name = "Yoshiko"
                        },
                        new
                        {
                            Id = 9,
                            description = "Facilis et cum aliquam rerum quis non delectus.",
                            name = "Karolann"
                        },
                        new
                        {
                            Id = 10,
                            description = "Tenetur ad voluptatibus rerum dolorem.",
                            name = "Irwin"
                        },
                        new
                        {
                            Id = 11,
                            description = "Rerum sit repellendus numquam consequatur sapiente.",
                            name = "Daron"
                        },
                        new
                        {
                            Id = 12,
                            description = "Ut alias totam ad corrupti voluptatem beatae libero.",
                            name = "Gladyce"
                        },
                        new
                        {
                            Id = 13,
                            description = "Magnam numquam ad ducimus et aperiam fugit harum aut.",
                            name = "Lazaro"
                        },
                        new
                        {
                            Id = 14,
                            description = "Quisquam eos laudantium quis recusandae dolore.",
                            name = "Carson"
                        },
                        new
                        {
                            Id = 15,
                            description = "Quibusdam minima nesciunt ut nam consequuntur.",
                            name = "Julia"
                        },
                        new
                        {
                            Id = 16,
                            description = "Tempora ut consequatur iusto nesciunt.",
                            name = "Clyde"
                        });
                });

            modelBuilder.Entity("QLSach.database.models.BookInteraction", b =>
                {
                    b.HasOne("QLSach.dbContext.models.Book", null)
                        .WithMany("Interactions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLSach.database.models.Comment", "comment")
                        .WithOne("bookInteraction")
                        .HasForeignKey("QLSach.database.models.BookInteraction", "CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLSach.database.models.User", null)
                        .WithMany("Interactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("comment");
                });

            modelBuilder.Entity("QLSach.database.models.Comment", b =>
                {
                    b.HasOne("QLSach.dbContext.models.Book", "book")
                        .WithMany("Comments")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLSach.database.models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLSach.database.models.Comment", "parent")
                        .WithMany("childrents")
                        .HasForeignKey("parent_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("parent");

                    b.Navigation("user");
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

            modelBuilder.Entity("QLSach.database.models.Comment", b =>
                {
                    b.Navigation("bookInteraction")
                        .IsRequired();

                    b.Navigation("childrents");
                });

            modelBuilder.Entity("QLSach.database.models.User", b =>
                {
                    b.Navigation("Interactions");
                });

            modelBuilder.Entity("QLSach.dbContext.models.Book", b =>
                {
                    b.Navigation("Comments");

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
