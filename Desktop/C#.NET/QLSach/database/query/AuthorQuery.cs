using QLSach.component;
using QLSach.dbContext.models;

namespace QLSach.database.query
{
    public class AuthorQuery
    {
        
        public author getAuthorById(int id)
        {
            using (var context = new Context())          
                return context.Authors.Find(id);
        }

        public List<string> getAuthorName()
        {
            using (var context = new Context())
                return context.Authors.Select(o => o.name).ToList();
        }

        public List<author> getAuthors()
        {
            using (var context = new Context())            
                return context.Authors.ToList();
        }
    }
}
