using System.ComponentModel.DataAnnotations;

namespace QLSach.database.models
{
    public class CategoryBook
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BookId { get; set; }
    }
}
