using QLSach.dbContext.models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSach.database.models
{
    public enum Status_borrow
    {
        Pending,
        Borrowed,
        Canceled,
        Completed
    }
    public class Register
    {
        [Key]
        [Required]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int BookId { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime register_at { get; set; }
        private DateTime? _borrow_at;
        private DateTime? _return_at;
        private DateTime? _expected_at { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? borrow_at
        {
            get
            {
                if (this.Status == Status_borrow.Borrowed || this.Status == Status_borrow.Completed)
                    return _borrow_at;
                return null;
            }
            set
            {
                _borrow_at = value;
            }
        }

        [Column(TypeName = "datetime")]
        public DateTime? expected_at
        {
            get
            {
                if (this.Status == Status_borrow.Canceled || this.Status == Status_borrow.Pending)
                    return null;
                return register_at.AddDays(7);
            }
            set
            {
                _expected_at = value;
            }
        }
        [Column(TypeName = "datetime")]
        public DateTime? return_at
        {
            get
            {
                if (this.Status == Status_borrow.Completed)
                    return _return_at;
                return null;
            }
            set
            {
                _return_at = value;
            }
        }

        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public Status_borrow Status { get; set; }

        [Browsable(false)]
        public User User { get; set; }
        [Browsable (false)]
        public Book Book { get; set; }
    }
}
