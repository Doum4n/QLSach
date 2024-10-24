﻿using Bogus;
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
                .RuleFor(o => o.id, f => AuthorId++)
                .RuleFor(o => o.description, f => f.Lorem.Sentence());

            var authors = fakeAuthor.Generate(16);

            var BookId = 1;
            var id = 0;
            var fakeBook = new Faker<Book>()
                .RuleFor(o => o.name, f => f.Lorem.Sentence())
                .RuleFor(o => o.id, f => BookId++)
                .RuleFor(o => o.author_id, f => authors[id++].id);

            var books = fakeBook.Generate(16);

            var photoId = 1;
            String imagePath = ".\\resources\\images\\poster.png";
            var fakePath = "fake path";
            var fakeImage = new Faker<Photo>()
                .RuleFor(o => o.book_id, f => photoId++)
                .RuleFor(o => o.path, f => photoId + fakePath);

            var images = fakeImage.Generate(16);

            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<author>().HasData(authors);
            modelBuilder.Entity<Photo>().HasData(images);
        }
    }
}