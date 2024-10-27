using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLSach.database.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.dbContext.models
{
    public class Book
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string name { get; set; }
        [Required]
        public string? description { get; set; }
        [Required]
        public int author_id { get; set; }

        //foreign key
        public author author { get; set; } = null!;
        public Photo? photo { get; set; }

        //navigation properties
        public List<User> Users { get; set; } = [];
        public List<BookInteraction> Interactions { get; set; } = [];
    }
}
