using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSach.dbContext.models
{
    public class author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String description { get; set; }

        [NotMapped]
        [Browsable(false)]
        public Book? Book { get; set; }
    }
}
