using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic.ApplicationServices;
using QLSach.database.models;
using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.database
{

    public class DataInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DataInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {   
            //Author
            var AuthorId = 1;
            var fakeAuthor = new Faker<author>()
                .RuleFor(o => o.name, f => f.Name.FirstName())
                .RuleFor(o => o.Id, f => AuthorId++)
                .RuleFor(o => o.description, f => f.Lorem.Sentence());

            var authors = fakeAuthor.Generate(32);

            //Genre
            var GenreId = 1;
            var fakeGenre = new Faker<Genre>()
                .RuleFor(o => o.name, f => f.Lorem.Word())
                .RuleFor(o => o.id, f => GenreId++);
            var genres = fakeGenre.Generate(32);

            //Book
            modelBuilder.Entity<Book>()
                    .Property(b => b.created_at)
                    .ValueGeneratedOnAdd()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            var BookId = 1;
            var id = 0;
            Faker faker = new Faker();
            int fake_quantity = faker.Random.Byte(0, 10);
            var fakeBook = new Faker<Book>()
                .RuleFor(o => o.name, f => f.Lorem.Sentence())
                .RuleFor(o => o.Id, f => BookId++)
                .RuleFor(o => o.description, f => f.Lorem.Paragraph())
                .RuleFor(o => o.remaining, f => f.Random.Byte(0, 5))
                .RuleFor(o => o.quantity, f => f.Random.Byte(5, 10))
                .RuleFor(o => o.author_id, f => f.PickRandom(authors.Select(o => o.Id)))
                .RuleFor(o => o.year_public, f => f.Random.Int(1900, DateTime.Now.Year))
                .RuleFor(o => o.updated_at, f => DateTime.Now)
                .RuleFor(o => o.genre_id, f => f.PickRandom(genres.Select(o => o.id)));
            
            var books = fakeBook.Generate(28);

            //Image
            var photoId = 1;
            String imagePath = ".\\resources\\images\\poster.png";
            var fakePath = "fake path";
            var fakeImage = new Faker<Photo>()
                .RuleFor(o => o.path, f => (photoId++) + fakePath)
                .RuleFor(o => o.book_id, f => f.PickRandom(books.Select(o => o.Id)));

            var images = fakeImage.Generate(16);

            //User
            var user_id = 1;
            var fakeUser = new Faker<models.User>()
                .RuleFor(o => o.Id, f => user_id++)
                .RuleFor(o => o.Password, f => f.Lorem.Text())
                .RuleFor(o => o.UserName, f => f.Name.FullName());

            var users = fakeUser.Generate(16);

            //Comment
            modelBuilder.Entity<Comment>()
              .Property(o => o.parent_id)
              .IsRequired(false);

            var comment_id = 1;
            var fakeComment = new Faker<models.Comment>()
                .RuleFor(o => o.Id, f => comment_id++)
                .RuleFor(o => o.content, f => f.Lorem.Sentence())
                .RuleFor(o => o.BookId, f => f.PickRandom(books.Select(o => o.Id)))
                .RuleFor(o => o.UserId, f => f.PickRandom(users.Select(o => o.Id)));

            var comments = fakeComment.Generate(16);
            //for comment parent
            fakeComment.RuleFor(o => o.parent_id, f => f.PickRandom(comments.Select(o => o.Id)));
            var comments_0 = fakeComment.Generate(16);

            //register
            var register_id = 1;
            var fakeRegister = new Faker<models.Register>()
               .RuleFor(o => o.Id, f => register_id++)
               .RuleFor(o => o.BookId, f => f.PickRandom(books.Select(o => o.Id)))
               .RuleFor(o => o.UserId, f => f.PickRandom(users.Select(o => o.Id)))
               .RuleFor(o => o.Status, f => f.PickRandom<Status_borrow>())
               .RuleFor(o => o.register_at, f => f.Date.Recent(7))
               .RuleFor(o => o.borrow_at, (f, o) =>
                {
                    if (o.Status == Status_borrow.Borrowed || o.Status == Status_borrow.Completed)
                        return f.Date.Recent(6);
                    return null;
                })
                .RuleFor(o => o.expected_at, (f, o) => 
                {
                    if (o.Status == Status_borrow.Canceled)
                        return null;
                    return o.register_at.AddDays(7); 
                })
                .RuleFor(o => o.return_at, (f, o) =>
                {
                    if (o.Status == Status_borrow.Completed)
                        return f.Date.Recent(3);
                    return null;
                });

            var register = fakeRegister.Generate(16);

            //assign data
            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<author>().HasData(authors);
            modelBuilder.Entity<Photo>().HasData(images);
            modelBuilder.Entity<models.User>().HasData(users);
            modelBuilder.Entity<Comment>().HasData(comments);
            modelBuilder.Entity<Comment>().HasData(comments_0);
            modelBuilder.Entity<Register>().HasData(register);
        }
    }
}