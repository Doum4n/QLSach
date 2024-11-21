using QLSach.component;
using QLSach.database.models;

namespace QLSach.database.query
{
    public class ImageQuery
    {
        public ImageQuery() { }

        public string? GetPhoto(int id)
        {
            return Singleton.getInstance.Data?.Photos.Where(photo => photo.book_id == id).Select(o => o.path).FirstOrDefault();
        }

        public Photo? GetImageBookId(int id)
        {
            return Singleton.getInstance.Data.Photos.Where(o => o.book_id == id).FirstOrDefault();
        }
    }
}
