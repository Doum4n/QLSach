using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSach.database.models
{
    public class CategoryBook
    {
        [Required]
        [Column(TypeName = "int")]
        public int CategoryId { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int BookId { get; set; }
    }
}
