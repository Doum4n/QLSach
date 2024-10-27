using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.database.models
{
    public class BookInteraction
    {
        public BookInteraction() { }

        public int BookId { get; set; }
        public int UserId { get; set; }
        [AllowNull]
        public int comment { get; set; }
        [AllowNull]
        public int rating { get; set; }
        [AllowNull]
        public bool liked { get; set; }
        [AllowNull]
        public bool saved { get; set; }
    }
}
