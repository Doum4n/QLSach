using Microsoft.EntityFrameworkCore;
using QLSach.component;
using QLSach.dbContext.models;

namespace QLSach.database.query
{
    public class BookQuery
    {
        public List<Book> getBooks()
        {
            return Singleton.getInstance.Data?.Books?.ToList();
        }

        public List<Book> getRecentUpdateBooks()
        {
            return Singleton.getInstance.Data.Books.OrderByDescending(x => x.created_at).ToList();
        }

        public Book? getBook(int id)
        {
            return Singleton.getInstance.Data?.Books?.Where(book => book.Id == id).FirstOrDefault();
        }

        public string getBookGenre(int bookId)
        {
            return Singleton.getInstance.Data.Books.Include(o => o.Genre).Where(o => o.Id == bookId).Select(o => o.Genre.name).FirstOrDefault();
        }

        public string getBookAuthor(int bookId)
        {
            return Singleton.getInstance.Data.Books.Include(o => o.author).Where(o => o.Id == bookId).Select(o => o.author.name).FirstOrDefault();
        }

        public List<Book> get10BooksByGenre(int genreId)
        {
            return Singleton.getInstance.Data.Books.Where(o => o.genre_id == genreId).Take(10).ToList();
        }

        public List<Book> getBooksByGenre(int genreId)
        {
            return Singleton.getInstance.Data.Books.Where(o => o.genre_id == genreId).ToList();
        }

        public List<Book> getMostViewBooks()
        {
            return Singleton.getInstance.Data.Books.OrderByDescending(o => o.views).Take(50).ToList();
        }
        public Book getBookByName(string name)
        {
            return Singleton.getInstance.Data.Books.Where(o => o.name == name).FirstOrDefault();
        }

        public List<Book> getBookByAuthorId(int AuthorId)
        {
            return Singleton.getInstance.Data.Books
                .Where(o => o.author_id == AuthorId).ToList();
        }
    }
}
