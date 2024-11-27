using QLSach.component;
using QLSach.view.admin;
using System.ComponentModel;

namespace QLSach.view
{
    public partial class Admin : Form
    {
        private BindingList<string> bindingList = new BindingList<string>();
        private AuthorManager authorManager = new AuthorManager();
        private UserManager UserManager = new UserManager();
        private BookManager BookManager = new BookManager();
        private CategoryNavigation CategoryNavigation = new CategoryNavigation();
        private PublisherManager PublisherManager = new PublisherManager();
        public Admin()
        {
            InitializeComponent();
        }

        private void btn_book_management_Click(object sender, EventArgs e)
        {
            pane_main.Controls.Clear();
            pane_main.Controls.Add(BookManager);
        }

        private void btn_category_Click(object sender, EventArgs e)
        {
            pane_main.Controls.Clear();
            pane_main.Controls.Add(CategoryNavigation);
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            pane_main.Controls.Add(BookManager);
        }

        private void btn_user_Click(object sender, EventArgs e)
        {

            pane_main.Controls.Clear();
            pane_main.Controls.Add(UserManager);
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            pane_main.Controls.Clear();
            pane_main.Controls.Add(new BorrowRegisterManager());
        }

        private void btn_Statistacs_Click(object sender, EventArgs e)
        {
            pane_main.Controls.Clear();
            pane_main.Controls.Add(new Statistacs());
        }

        private void btn_author_Click(object sender, EventArgs e)
        {
            pane_main.Controls.Clear();
            pane_main.Controls.Add(authorManager);
        }

        private void btn_publisher_Click(object sender, EventArgs e)
        {
            pane_main.Controls.Clear();
            pane_main.Controls.Add(PublisherManager);
        }

        private void btn_reader_Click(object sender, EventArgs e)
        {

        }
    }
}
