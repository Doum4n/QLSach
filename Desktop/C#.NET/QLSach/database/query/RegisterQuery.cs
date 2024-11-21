
using QLSach.component;
using QLSach.database.models;


namespace QLSach.database.query
{
    public class RegisterQuery
    {
        public List<Register> GetBorrows()
        {
            return Singleton.getInstance.Data.Register.Where(o => o.Status == Status_borrow.Borrowed).ToList();
        }

        public List<Register> GetRegister()
        {
            return Singleton.getInstance.Data.Register.Where(o => o.Status == Status_borrow.Pending).ToList();
        }

        public Register getByUserIdBookId(int userId, int bookId)
        {
            return Singleton.getInstance.Data.Register.Where(o => o.UserId == userId).Where(o => o.BookId == bookId).FirstOrDefault();
        }
        //SELECT UserId, BookId, MAX(register_at) AS `recent` FROM `Register` GROUP BY BookId, UserId 

    }
}
