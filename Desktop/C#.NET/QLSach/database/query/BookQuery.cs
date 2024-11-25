using Microsoft.EntityFrameworkCore;
using QLSach.component;
using QLSach.dbContext.models;

namespace QLSach.database.query
{
    public class BookQuery
    {
        public List<Book> getBooks()
        {
            using (var context = new Context())
                return context?.Books?.ToList();
        }

        public List<Book> getRecentUpdateBooks()
        {
            using (var context = new Context())
                return context.Books.OrderByDescending(x => x.created_at).ToList();
        }

        public Book? getBook(int id)
        {
            using (var context = new Context())
                return context?.Books?.Where(book => book.Id == id).FirstOrDefault();
        }

        public string getBookGenre(int bookId)
        {
            using (var context = new Context())
                return context.Books.Include(o => o.Genre).Where(o => o.Id == bookId).Select(o => o.Genre.name).FirstOrDefault();
        }

        public string getBookAuthor(int bookId)
        {
            using (var context = new Context())
                return context.Books.Include(o => o.author).Where(o => o.Id == bookId).Select(o => o.author.name).FirstOrDefault();
        }

        public List<Book> get10BooksByGenre(int genreId)
        {
            using (var context = new Context())
                return context.Books.Where(o => o.genre_id == genreId).Take(10).ToList();
        }

        public List<Book> getBooksByGenre(int genreId)
        {
            using (var context = new Context())
                return context.Books.Where(o => o.genre_id == genreId).ToList();
        }

        public List<Book> getMostViewBooks()
        {
            using (var context = new Context())
                return context.Books.OrderByDescending(o => o.views).Take(50).ToList();
        }
        public Book getBookByName(string name)
        {
            using (var context = new Context())
                return context.Books.Where(o => o.name == name).FirstOrDefault();
        }

        public List<Book> getBookByAuthorId(int AuthorId)
        {
            using (var context = new Context())
                return context.Books
                .Where(o => o.author_id == AuthorId).ToList();
        }
    }
}
