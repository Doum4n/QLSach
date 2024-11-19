using System.Diagnostics.CodeAnalysis;

namespace QLSach.database.models
{
    public class BookInteraction
    {
        public BookInteraction() { }

        public int BookId { get; set; }
        public int UserId { get; set; }
        [AllowNull]
        public int CommentId { get; set; }
        [AllowNull]
        public int rating { get; set; }
        [AllowNull]
        public bool liked { get; set; }
        [AllowNull]
        public bool saved { get; set; }

        public Comment comment { get; set; }
    }
}
