using QLSach.component;
using System.Data;

namespace QLSach.view.user
{
    public partial class BorrowedBooks : UserControl
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public BorrowedBooks()
        {
            InitializeComponent();
        }

        private void BorrowedBooks_Load(object sender, EventArgs e)
        {
            Singleton.getInstance.RegisterHelper.borrowed_data.DataSource = Singleton.getInstance.Data.Register
                .Where(o => o.UserId == UserId)
                .Where(o => o.borrow_at != null)
                .Select(o => new
                {
                    o.BookId,
                    o.borrow_at,
                    expected_return = o.borrow_at.Value.AddDays(7)
                }).ToList();

            data.DataSource = Singleton.getInstance.RegisterHelper.borrowed_data;

            Node cur = Singleton.getInstance.State;
            Node node = new Node(this);
            cur.AddChild(node);
            Singleton.getInstance.State = node;
            //Singleton.getInstance.MainFrameHelper.Node.AddChild(Singleton.getInstance.State);
        }
    }
}
