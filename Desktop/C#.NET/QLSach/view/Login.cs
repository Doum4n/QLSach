using QLSach.component;
using QLSach.database;
using QLSach.view;

namespace QLSach
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void SignIn_click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                Singleton.getInstance.Username = tb_name.Text;
                Singleton.getInstance.Password = tb_pw.Text;

                if (tb_name.Text == "admin")
                {
                    Admin admin = new Admin();
                    admin.Show();
                }
                else
                {
                    Singleton.getInstance.UserId = context.Users.Where(o => o.Name == tb_name.Text).Select(o => o.Id).First();
                    Mainframe mainframe = new Mainframe();
                    mainframe.Show();
                }

                this.Hide();
            }
        }
    }
}
