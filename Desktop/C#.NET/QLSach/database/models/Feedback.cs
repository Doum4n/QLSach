using QLSach.dbContext.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QLSach.database.models
{
    [Table("Feedbacks")]
    public class Feedback
    {
        public Feedback() { }
        [Required]
        [Column(TypeName = "int")]
        public int BookId { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? comment { get; set; }
        [Column(TypeName = "float")]
        public float? rating { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? created_at { get; set; } = DateTime.Now;
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? updated_at { get; set; } = DateTime.Now;
    }
}
