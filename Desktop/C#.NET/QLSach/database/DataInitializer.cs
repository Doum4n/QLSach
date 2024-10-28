using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
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
            var AuthorId = 1;
            var fakeAuthor = new Faker<author>()
                .RuleFor(o => o.name, f => f.Name.FirstName())
                .RuleFor(o => o.Id, f => AuthorId++)
                .RuleFor(o => o.description, f => f.Lorem.Sentence());

            var authors = fakeAuthor.Generate(16);

            var BookId = 1;
            var id = 0;
            var fakeBook = new Faker<Book>()
                .RuleFor(o => o.name, f => f.Lorem.Sentence())
                .RuleFor(o => o.Id, f => BookId++)
                .RuleFor(o => o.description, f => f.Lorem.Paragraph())
                .RuleFor(o => o.author_id, f => authors[id++].Id);

            var books = fakeBook.Generate(16);

            var photoId = 1;
            String imagePath = ".\\resources\\images\\poster.png";
            var fakePath = "fake path";
            var fakeImage = new Faker<Photo>()
                .RuleFor(o => o.book_id, f => photoId++)
                .RuleFor(o => o.path, f => photoId + fakePath);

            var images = fakeImage.Generate(16);

            var user_id = 1;
            var fakeUser = new Faker<models.User>()
                .RuleFor(o => o.Id, f => user_id++)
                .RuleFor(o => o.Password, f => f.Lorem.Text())
                .RuleFor(o => o.UserName, f => f.Name.FullName());

            var users = fakeUser.Generate(16);

            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<author>().HasData(authors);
            modelBuilder.Entity<Photo>().HasData(images);
            modelBuilder.Entity<models.User>().HasData(users);
        }
    }
}