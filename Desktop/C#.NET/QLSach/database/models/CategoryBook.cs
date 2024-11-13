using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.database.models
{
    public class CategoryBook
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId {  get; set; }
        public int BookId { get; set; }
    }
}
