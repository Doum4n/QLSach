using QLSach.dbContext.models;
using System.ComponentModel.DataAnnotations;

namespace QLSach.database.models
{
    public enum Role
    {
        Admin,
        User
    }
    public class User
    {
        public User()
        {

        }
        public User(string name, string password, string userName, Role right)
        {
            Name = name;
            Password = password;
            UserName = userName;
            Role = right;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        public Role Role { get; set; }
        public DateOnly create_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly update_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        //navigation properties
        public List<Book> Books { get; set; } = [];
        public List<BookInteraction> Interactions { get; set; } = [];
    }
}
