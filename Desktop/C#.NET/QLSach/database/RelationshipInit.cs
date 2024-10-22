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
            modelBuilder.Entity<author>()
              .HasOne(e => e.Book)
              .WithOne(e => e.author)
              .HasForeignKey<Book>(e => e.author_id)
              .IsRequired();

            modelBuilder.Entity<Photo>().Ignore(e => e.Book);

            modelBuilder.Entity<Book>()
                .HasOne(e => e.photo)
                .WithOne(e => e.Book)
                .HasForeignKey<Photo>(e => e.book_id)
                .IsRequired();
        }
    }
}
