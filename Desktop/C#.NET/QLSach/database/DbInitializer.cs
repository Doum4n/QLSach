using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.database
{

    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Book>().HasData(
                    new Book(1,"book1"),
                    new Book(2, "book2"),
                    new Book(3, "book3"),
                    new Book(4, "book4"),
                    new Book(5, "book5"),
                    new Book(6, "book6"),
                    new Book(7, "book7"),
                    new Book(8, "book8")
            );
        }
    }
}