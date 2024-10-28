using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.database.models
{
    // 1 comment of (many) user belong to 1 book
    [Table("Comments")]
    public class Comment
    {

        public Comment()
        {
            
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
        public int BookId {  get; set; }
        [AllowNull]
        public int parent_id { get; set; }

        public User user { get; set; }
        public Book book { get; set; }

        public BookInteraction bookInteraction { get; set; }
        public Comment parent { get; set; }
        public List<Comment> childrents { get; set; }
    }
}
