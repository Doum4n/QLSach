using QLSach.dbContext.models;
using System.ComponentModel.DataAnnotations;

namespace QLSach.database.models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string path { get; set; }
        [Required]
        public int book_id { get; set; }

        public Book Book { get; set; }
    }
}
