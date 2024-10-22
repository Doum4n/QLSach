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

        public Book? getBook(int id)
        {
            return Singleton.getInstance.Data?.Books?.Where(book => book.id == id).FirstOrDefault();
        }
    }
}
