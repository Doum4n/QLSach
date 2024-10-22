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
    public class Photo
    {
        [Key]
        public string path { get; set; }
        [Required]
        public int book_id { get; set; }

        public Book Book { get; set; }
    }
}
