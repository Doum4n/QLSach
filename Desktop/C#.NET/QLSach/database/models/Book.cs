using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLSach.database.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bogus.DataSets.Name;

namespace QLSach.dbContext.models
{
    public enum Status
    {
        available,
        borrowed,
    }
    public class Book
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        //[Column(TypeName = "nvarchar(30)")]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int author_id { get; set; }
        public int genre_id { get; set; }
        [DefaultValue(0)]
        public byte rating { get; set; }
        public int year_public { get; set; }
        [DefaultValue(0)]
        public int views {  get; set; }
        [NotMapped]
        public Status status
        {
            get { 
                if(this.remaining > 1)
                {
                    return Status.borrowed;
                }
                return Status.available;
            }
        }
        public byte quantity { get; set; }
        public byte remaining { get; set; }
        [Required]
        public DateTime created_at { get; set; } = DateTime.Now;
        [Required]
        public DateTime updated_at { get; set; } = DateTime.Now;

        //foreign key
        [Browsable(false)]
        public author author { get; set; } = null!;

        //navigation properties
        [Browsable(false)]
        public List<User> Users { get; set; } = [];
        [Browsable(false)]
        public Photo? photo { get; set; }
        [Browsable(false)]
        public List<Comment> Comments { get; set; }
        [Browsable(false)]
        public Genre Genre { get; set; }
    }
}
