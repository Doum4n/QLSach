using Microsoft.EntityFrameworkCore;
using QLSach.database.models;
using QLSach.dbContext.models;

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

            //1 book belong to 1 genre, 1 genre have many books
            modelBuilder.Entity<Book>()
                .HasOne(o => o.Genre)
                .WithMany(o => o.Books)
                .HasForeignKey(o => o.genre_id)
                .IsRequired(); //not null

            modelBuilder.Entity<Book>()
              .HasOne(o => o.Publisher)
              .WithOne(o => o.Book)
              .HasForeignKey<Book>(o => o.publisher_id)
              .IsRequired(); //not null

            //

            //Feedback
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Users)
                .WithMany(u => u.Books)
                .UsingEntity<Feedback>();

            //

            modelBuilder.Entity<Book>()
              .HasMany(b => b.Categories)
              .WithMany(u => u.Books)
              .UsingEntity<CategoryBook>();

            //Register
            modelBuilder.Entity<User>()
                .HasMany(o => o.Books)
                .WithMany(u => u.Users)
                .UsingEntity<Register>();

            modelBuilder.Entity<Register>()
                .Property(o => o.Status)
                .HasConversion<String>();

            //Category
            modelBuilder.Entity<Category>()
                .HasMany(o => o.Books)
                .WithMany(o => o.Categories)
                .UsingEntity<CategoryBook>();

            modelBuilder.Entity<User>()
                .Property(o => o.Role)
                .HasConversion<String>();
        }
    }
}
