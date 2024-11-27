﻿using Bogus;
using Microsoft.EntityFrameworkCore;
using QLSach.database.models;
using QLSach.dbContext.models;

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

            //Category
            var categoryId = 1;
            var fakeCategory = new Faker<Category>()
                .RuleFor(o => o.Name, f => f.Lorem.Word())
                .RuleFor(o => o.Id, f => categoryId++)
                .RuleFor(o => o.Description, f => f.Lorem.Sentence(20));

            var category = fakeCategory.Generate(5);

            var PublisherId = 1;
            var fakePublisher = new Faker<Publisher>()
                .RuleFor(o => o.Name, f => f.Lorem.Word())
                .RuleFor(o => o.Id, f => PublisherId++);
            var publisher = fakePublisher.Generate(32);

            //Book
            String imagePath = ".\\resources\\images\\poster.png";

            var BookId = 1;
            var id = 0;
            Faker faker = new Faker();
            int fake_quantity = faker.Random.Byte(0, 10);
            var fakeBook = new Faker<Book>()
                .RuleFor(o => o.name, f => f.Lorem.Text())
                .RuleFor(o => o.Id, f => BookId++)
                .RuleFor(o => o.description, f => f.Lorem.Paragraph())
                .RuleFor(o => o.remaining, f => f.Random.Byte(0, 5))
                .RuleFor(o => o.photoPath, f => imagePath)
                .RuleFor(o => o.quantity, f => f.Random.Byte(5, 10))
                .RuleFor(o => o.publisher_id, f => f.PickRandom(publisher.Select(o => o.Id)))
                .RuleFor(o => o.author_id, f => f.PickRandom(authors.Select(o => o.Id)))
                .RuleFor(o => o.public_at, f => f.Date.BetweenDateOnly(DateOnly.Parse("1999-01-01"), DateOnly.FromDateTime(DateTime.Now)))
                .RuleFor(o => o.updated_at, f => DateTime.Now)
                .RuleFor(o => o.genre_id, f => f.PickRandom(genres.Select(o => o.id)));

            var books = fakeBook.Generate(38);

            //Image
            var photoId = 1;
            //var fakePath = "fake path";
            //var fakeImage = new Faker<Photo>()
            //    .RuleFor(o => o.Id, f => photoId++)
            //    .RuleFor(o => o.path, f => imagePath)
            //    .RuleFor(o => o.book_id, f => f.PickRandom(books.Select(o => o.Id)));

            //var images = fakeImage.Generate(16);

            //User
            var user_id = 1;
            var fakeUser = new Faker<models.User>()
                .RuleFor(o => o.Id, f => user_id++)
                .RuleFor(o => o.Password, f => f.Lorem.Word())
                .RuleFor(o => o.Name, f => f.Name.FullName())
                .RuleFor(o => o.Role, f => f.PickRandom<Role>())
                .RuleFor(o => o.UserName, f => f.Name.FirstName());

            var users = fakeUser.Generate(16);

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
                    if (o.Status == Status_borrow.Canceled || o.Status == Status_borrow.Pending)
                        return null;
                    return o.register_at.AddDays(7);
                })
                .RuleFor(o => o.return_at, (f, o) =>
                {
                    if (o.Status == Status_borrow.Completed)
                        return f.Date.Recent(3); 
                    return null;
                });

            var register = fakeRegister.Generate(40);


            var fakeCategoryBook = new Faker<CategoryBook>()
                .RuleFor(o => o.BookId, f => f.PickRandom(books.Select(o => o.Id)))
                .RuleFor(o => o.CategoryId, f => f.PickRandom(category.Select(o => o.Id)));

            var categoryBook = fakeCategoryBook.Generate(2);

            //assign data
            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<author>().HasData(authors);
            //modelBuilder.Entity<Photo>().HasData(images);
            modelBuilder.Entity<models.User>().HasData(users);
            modelBuilder.Entity<Register>().HasData(register);
            modelBuilder.Entity<Category>().HasData(category);
            modelBuilder.Entity<CategoryBook>().HasData(categoryBook);
            modelBuilder.Entity<Publisher>().HasData(publisher);
        }
    }
}