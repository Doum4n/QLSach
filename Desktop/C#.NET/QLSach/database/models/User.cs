using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.database.models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }

        //navigation properties
        public List<Book> Books { get; set; } = [];
        public List<BookInteraction> Interactions { get; set; } = [];
    }
}
