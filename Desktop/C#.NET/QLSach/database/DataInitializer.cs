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

            var authors = fakeAuthor.Generate(32);

            var BookId = 1;
            var id = 0;
            var fakeBook = new Faker<Book>()
                .RuleFor(o => o.name, f => f.Lorem.Sentence())
                .RuleFor(o => o.Id, f => BookId++)
                .RuleFor(o => o.description, f => f.Lorem.Paragraph())
                .RuleFor(o => o.author_id, f => f.PickRandom(authors.Select(o => o.Id)));

            var books = fakeBook.Generate(32);

            var photoId = 1;
            String imagePath = ".\\resources\\images\\poster.png";
            var fakePath = "fake path";
            var fakeImage = new Faker<Photo>()
                .RuleFor(o => o.path, f => (photoId++) + fakePath)
                .RuleFor(o => o.book_id, f => f.PickRandom(books.Select(o => o.Id)));


            var images = fakeImage.Generate(16);

            var user_id = 1;
            var fakeUser = new Faker<models.User>()
                .RuleFor(o => o.Id, f => user_id++)
                .RuleFor(o => o.Password, f => f.Lorem.Text())
                .RuleFor(o => o.UserName, f => f.Name.FullName());

            var users = fakeUser.Generate(16);


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
            fakeComment.RuleFor(o => o.parent_id, f => f.PickRandom(comments.Select(o => o.Id)));
            var comments_0 = fakeComment.Generate(16);

            // Gán childrents cho mỗi comment
            //foreach (var comment in comments_0)
            //{
            //    if (comment.parent_id.HasValue)
            //    {
            //        var parentComment = comments.FirstOrDefault(c => c.Id == comment.parent_id.Value);
            //        if (parentComment != null)
            //        {
            //            parentComment.childrents.Add(comment); // Thêm vào danh sách childrents
            //            comment.parent = parentComment; // Thiết lập parent nếu cần
            //        }
            //    }
            //}

            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<author>().HasData(authors);
            modelBuilder.Entity<Photo>().HasData(images);
            modelBuilder.Entity<models.User>().HasData(users);
            modelBuilder.Entity<Comment>().HasData(comments);
            modelBuilder.Entity<Comment>().HasData(comments_0);
        }
    }
}