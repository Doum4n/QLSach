using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLSach.database.models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public string description { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int author_id { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int genre_id { get; set; }
        [Required]
        [Column (TypeName = "int")]
        public int publisher_id{ get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string photoPath {  get; set; }
        [DefaultValue(0)]
        [Column(TypeName = "float")]
        public float rating { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string storage_location { get; set; }
        [Column(TypeName = "date")]
        public DateOnly public_at { get; set; }
        [DefaultValue(0)]
        [Column(TypeName = "int")]
        public int views { get; set; }
        [NotMapped]
        public Status status
        {
            get
            {
                if (this.remaining > 1)
                {
                    return Status.available;
                }
                return Status.borrowed;
            }
        }
        [Required]
        [Column(TypeName = "int")]
        public byte quantity { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public byte remaining { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime created_at { get; set; } = DateTime.Now;
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime updated_at { get; set; } = DateTime.Now;

        //foreign key
        [Browsable(false)]
        public author author { get; set; } = null!;

        //navigation properties
        [Browsable(false)]
        public List<User> Users { get; set; } = [];
        //[Browsable(false)]
        //public Photo? photo { get; set; }
        [Browsable(false)]
        public Genre Genre { get; set; }
        [Browsable(false)]
        public List<Category> Categories { get; set; }
        public Publisher Publisher { get; set; }
        [NotMapped]
        [Browsable(false)]
        public StorageLocation storageLocation { get; set; }
    }
}
