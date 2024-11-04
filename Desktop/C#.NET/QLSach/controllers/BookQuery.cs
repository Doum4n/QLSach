using Guna.UI2.AnimatorNS;
using Microsoft.EntityFrameworkCore;
using QLSach.component;
using QLSach.dbContext;
using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.controllers
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

        public string getBookGenre(int genreId)
        {
            return Singleton.getInstance.Data.Genre.Where(o => o.id == genreId).Select(o => o.name).FirstOrDefault();
        }

        public string getBookAuthor(int authorId)
        {
            return Singleton.getInstance.Data.Authors.Where(o => o.Id == authorId).Select(o => o.name).FirstOrDefault();
        }

        public List<Book> getBookByGenre(int genreId)
        {
            return Singleton.getInstance.Data.Books.Where(o => o.genre_id == genreId).Take(10).ToList();
        }

        public List<Book> getMostViewBooks()
        {
            return Singleton.getInstance.Data.Books.OrderByDescending(o => o.views).Take(50).ToList();
        }
    }
}
