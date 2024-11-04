using QLSach.component;
using QLSach.database.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.controllers
{
    public class GenreQuery
    {
        public List<Genre> getGenre()
        {
            return Singleton.getInstance.Data.Genre.ToList();
        }
    }
}
