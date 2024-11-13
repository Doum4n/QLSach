using QLSach.component;
using QLSach.database.models;
using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSach.component;
using QLSach.dbContext;
using QLSach.dbContext.models;

namespace QLSach.controllers
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
