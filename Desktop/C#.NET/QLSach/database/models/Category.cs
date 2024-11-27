using QLSach.dbContext.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSach.database.models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Required]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
        public List<Book> Books { get; set; }
        public DateOnly create_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly update_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
