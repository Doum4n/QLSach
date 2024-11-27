using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSach.dbContext.models
{
    public class author
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public String name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public String description { get; set; }

        [NotMapped]
        [Browsable(false)]
        public Book? Book { get; set; }
    }
}
