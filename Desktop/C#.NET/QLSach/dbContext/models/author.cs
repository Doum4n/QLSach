using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.dbContext.models
{
    public class author
    {
        [Key]
        public String id { get; set; }
        [Required]
        public String name { get; set; }
        public String description { get; set; }
    }
}
