using QLSach.dbContext.models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QLSach.database.models
{
    // 1 comment of (many) user belong to 1 book
    [Table("Comments")]
    public class Comment
    {

        public Comment()
        {
            childrents = new List<Comment>();
        }
        public Comment(string content, int user_id, int book_id)
        {
            this.content = content;
            UserId = user_id;
            BookId = book_id;
        }

        //[Key]
        public int Id { get; set; }
        public string content { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        [AllowNull]
        public int? parent_id { get; set; }

        public User user { get; set; }
        public Book book { get; set; }

        public BookInteraction bookInteraction { get; set; }
        public Comment parent { get; set; }
        public List<Comment> childrents { get; set; }
        public bool hasChildrent()
        {
            return this.childrents != null && this.childrents.Count > 0;
        }
    }
}
