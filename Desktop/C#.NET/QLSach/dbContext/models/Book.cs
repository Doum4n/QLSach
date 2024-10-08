using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.dbContext.models
{
    public class Book
    {
        [Key]
        public int id {  get; set; }
        [Required]
        public string name { get; set; }
    }
}
