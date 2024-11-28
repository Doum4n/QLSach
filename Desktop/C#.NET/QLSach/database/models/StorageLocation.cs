using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.database.models
{
    public class StorageLocation
    {
        [Key]
        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
        [NotMapped]
        public List<Book> Books { get; set; }
    }
}
