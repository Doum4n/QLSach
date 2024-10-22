﻿using QLSach.database.models;
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
        public string? description { get; set; }
        public int author_id { get; set; }

        public author author { get; set; } = null!;
        public Photo? photo { get; set; }
    }
}
