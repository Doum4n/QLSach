using Microsoft.EntityFrameworkCore;
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
            return Singleton.getInstance.Data.Genre
                .FromSql($"SELECT * FROM `Genres` WHERE id in (SELECT b.genre_id FROM `Books` as b GROUP BY genre_id)")
                .ToList();
        }

        public Dictionary<int, string> getGenre_name_id()
        {
            return Singleton.getInstance.Data.Genre.ToDictionary(
                g => g.id, g => g.name
            );
        }

        public Genre getGenrebyId(int id)
        {
            return Singleton.getInstance.Data.Genre.Find(id);
        }
    }
}
