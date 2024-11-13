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
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; }
        public DateOnly create_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly update_at { get; set;} = DateOnly.FromDateTime(DateTime.Now);
    }
}
