//using QLSach.component;
//using QLSach.database.models;

//namespace QLSach.database.query
//{
//    public class ImageQuery
//    {
//        public ImageQuery() { }

//        public string? GetPhoto(int id)
//        {
//            using (var context = new Context())
//                return context?.Photos.Where(photo => photo.book_id == id).Select(o => o.path).FirstOrDefault();
//        }

//        //public Photo? GetImageBookId(int id)
//        //{
//        //    using (var context = new Context())
//        //        return context.Photos.Where(o => o.book_id == id).FirstOrDefault();
//        //}
//    }
//}
