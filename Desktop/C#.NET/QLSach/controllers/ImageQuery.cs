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

        public Photo? GetPhoto(int id)
        {
            return Singleton.getInstance.Data?.Photo.Where(photo => photo.book_id == id).FirstOrDefault();
        }
    }
}
