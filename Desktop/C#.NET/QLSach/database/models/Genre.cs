using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.database.models
{
    [Table("Genres")]
    public class Genre
    {
        [Key]
        public int id {  get; set; }
        [Required]
        public string name { get; set; }
        public List<Book> Books { get; set; }
    }
}
