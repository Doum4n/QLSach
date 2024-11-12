using QLSach.component;
using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.controllers
{
    public class AuthorQuery
    {
        public author getAuthorById(int id)
        {
            return Singleton.getInstance.Data.Authors.Find(id);
        }

        public List<String> getAuthorName()
        {
            return Singleton.getInstance.Data.Authors.Select(o => o.name).ToList();
        }

        public List<author> getAuthors()
        {
            return Singleton.getInstance.Data.Authors.ToList();
        }
    }
}
