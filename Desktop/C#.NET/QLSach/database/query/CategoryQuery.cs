﻿using QLSach.component;
using Category = QLSach.database.models.Category;

namespace QLSach.database.query
{
    public record CategoryDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BookCount { get; set; }
        public DateOnly create_at { get; set; }
        public DateOnly update_at { get; set; }

        public static implicit operator CategoryDetail(Category category)
        {
            return new CategoryDetail
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                BookCount = 0,
                create_at = category.create_at,
                update_at = category.update_at
            };
        }
    }
    public class CategoryQuery
    {
        public List<CategoryDetail> GetDetail()
        {
            using (var context = new Context())
            {
                return context.Categories
          .GroupJoin(
              context.CategoriesBook,
              category => category.Id,
              categoryBook => categoryBook.CategoryId,
              (category, categoryBooks) => new CategoryDetail
              {
                  Id = category.Id,
                  Name = category.Name,
                  Description = category.Description,
                  create_at = category.create_at,
                  update_at = category.update_at,
                  BookCount = categoryBooks.Count()
              }
          )
          .ToList();
            }
          
        }

        public int getCategoryBookCount(int categoryId)
        {
            using (var context = new Context())
                return context.Categories
                .GroupJoin(
                    context.CategoriesBook,
                    category => category.Id,
                    categoryBook => categoryBook.CategoryId,
                    (category, categoryBooks) => new
                    {
                        category.Id,
                        BookCount = categoryBooks.Count()
                    }
                ).Where(o => o.Id == categoryId).Select(o => o.BookCount).FirstOrDefault();
        }

        public List<Category> getCategories()
        {
            using (var context = new Context())
                return context.Categories.ToList();
        }

        public List<string> getNameById(int id)
        {
            using (var context = new Context())
                return context.Categories.Where(o => o.Id == id).Select(o => o.Name).ToList();
        }

        public string getDiscriptionById(int id)
        {
            using (var context = new Context())
                return context.Categories.Where(o => o.Id == id).Select(o => o.Description).First();
        }

        public int getIdByName(string name)
        {
            using (var context = new Context())
                return context.Categories.Where(o => o.Name == name).Select(o => o.Id).First();
        }

        public Category GetCategoryById(int id)
        {
            using (var context = new Context())
                return context.Categories.Where(o => o.Id == id).FirstOrDefault();
        }
    }
}