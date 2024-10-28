using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSach.database.models;

namespace QLSach.database
{
    public class Context : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UseSerialColumns();
            //NpgsqlModelBuilderExtensions.UseIdentityColumns(modelBuilder);
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);
            new DataInitializer(modelBuilder).Seed();
            new RelationshipInit(modelBuilder).init();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String ConnectionString = "server=localhost; Database=qlsach; Port=3306; uid=root; Password=pw;";
            optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<author> Authors { get; set; }
        public DbSet<BookInteraction> BookInteractions { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
