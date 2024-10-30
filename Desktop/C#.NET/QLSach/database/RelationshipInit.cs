using Microsoft.EntityFrameworkCore;
using QLSach.database.models;
using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.database
{
    public class RelationshipInit
    {
        private readonly ModelBuilder modelBuilder;

        public RelationshipInit(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void init()
        {
            //Author
            modelBuilder.Entity<author>()
              .HasOne(e => e.Book)
              .WithOne(e => e.author)
              .HasForeignKey<Book>(e => e.author_id)
              .IsRequired();
            //

            modelBuilder.Entity<Photo>().Ignore(e => e.Book);

            //Book
            modelBuilder.Entity<Book>()
                .HasOne(e => e.photo)
                .WithOne(e => e.Book)
                .HasForeignKey<Photo>(e => e.book_id)
                .IsRequired();

            //from Book join Comment on comment.book_id = book.id
            modelBuilder.Entity<Book>()
               .HasMany(b => b.Comments)
               .WithOne(c => c.book)
               .HasForeignKey(c => c.BookId)
               .IsRequired();
            //

            //Book Interaction
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Users)
                .WithMany(u => u.Books)
                .UsingEntity<BookInteraction>();

            modelBuilder.Entity<BookInteraction>()
               .HasOne(i => i.comment)
               .WithOne(c => c.bookInteraction)
               .HasForeignKey<BookInteraction>(b => b.CommentId);
            //

            //Comment
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.parent)
                .WithMany(c => c.childrents)
                .HasForeignKey(c => c.parent_id);
        }
    }
}
