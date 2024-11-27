using QLSach.dbContext.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSach.database.models
{
    [Table("Genres")]
    public class Genre
    {
        [Key]
        [Required]
        [Column(TypeName = "int")]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string name { get; set; }
        public List<Book> Books { get; set; }
    }
}
