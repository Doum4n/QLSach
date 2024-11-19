using System.ComponentModel.DataAnnotations;

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

        public Book? Book { get; set; }
    }
}
