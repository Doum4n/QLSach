using QLSach.component;
using QLSach.view.admin;
using System.ComponentModel;

namespace QLSach.view
{
    public partial class Admin : Form
    {
        private BindingList<string> bindingList = new BindingList<string>();
        private UserManager userManager = new UserManager();
        public Admin()
        {
            InitializeComponent();
        }

        private void btn_book_management_Click(object sender, EventArgs e)
        {
            pane_main.Controls.Clear();
            pane_main.Controls.Add(new BookManager());
        }

        private void btn_category_Click(object sender, EventArgs e)
        {
            pane_main.Controls.Clear();
            pane_main.Controls.Add(new CategoryNavigation());
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            pane_main.Controls.Add(new BookManager());
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            
            pane_main.Controls.Clear();
            pane_main.Controls.Add(new UserManager());
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            pane_main.Controls.Clear();
            pane_main.Controls.Add(new BorrowRegisterManager());
        }
    }
}
