using QLSach.dbContext.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSach.database.models
{
    [Table("Categories")]
    public class Category
    {
        public Category()
        {

        }
        public Category(string name, string description, DateOnly create_at, DateOnly update_at)
        {
            Name = name;
            Description = description;
            this.create_at = create_at;
            this.update_at = update_at;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; }
        public DateOnly create_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly update_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
