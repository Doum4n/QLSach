using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.database
{
    public class Context : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UseSerialColumns();
            NpgsqlModelBuilderExtensions.UseIdentityColumns(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=qlsach; Port=5432; Username=admin; Password=pw;");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<author> Authors { get; set; }
    }
}
