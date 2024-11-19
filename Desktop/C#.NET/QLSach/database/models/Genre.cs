using QLSach.dbContext.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSach.database.models
{
    [Table("Genres")]
    public class Genre
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public List<Book> Books { get; set; }
    }
}
