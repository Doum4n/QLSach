using QLSach.dbContext.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSach.database.models
{
    public enum Role
    {
        Admin,
        Staff,
        User
    }
    public class User
    {

        [Key]
        [Required]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }
        //public string Email { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string UserName { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateOnly create_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Required]
        [Column(TypeName = "date")]
        public DateOnly update_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        //navigation properties
        public List<Book> Books { get; set; } = [];
        public List<Feedback> Interactions { get; set; } = [];
    }
}
