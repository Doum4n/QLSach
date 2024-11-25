using Microsoft.EntityFrameworkCore;
using QLSach.component;
using QLSach.database.models;

namespace QLSach.database.query
{
    public class GenreQuery
    {
        public List<Genre> getGenre()
        {
            using (var context = new Context())
                return context.Genre
                .FromSql($"SELECT * FROM `Genres` WHERE id in (SELECT b.genre_id FROM `Books` as b GROUP BY genre_id)")
                .ToList();
        }

        public Dictionary<int, string> getGenre_name_id()
        {
            using (var context = new Context())
            {
                return context.Genre.ToDictionary(
                g => g.id, g => g.name
                );
            }
        }

        public Genre getGenrebyId(int id)
        {
            using (var context = new Context())
                return context.Genre.Find(id);
        }

        public List<string> getGenreName()
        {
            using (var context = new Context())
                return context.Genre.Select(g => g.name).ToList();
        }
    }
}
