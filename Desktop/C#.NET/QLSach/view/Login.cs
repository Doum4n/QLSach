using Microsoft.EntityFrameworkCore;
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

                try
                {
                    var user = context.Users
                            .Where(o => o.UserName == tb_name.Text)
                            .First();

                    if (user != null)
                    {
                        if (user.Password != tb_pw.Text)
                        {
                            MessageBox.Show("Mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {   
                            Singleton.getInstance.UserId = user.Id;

                            if (user.Role == database.models.Role.Admin)
                            {
                                Admin admin = new Admin();
                                admin.Show();
                            }
                            else if (user.Role == database.models.Role.User)
                            {
                                Mainframe mainframe = new Mainframe();
                                mainframe.Show();
                            }
                            else
                            {
                                Singleton.getInstance.Role = database.models.Role.Staff;
                                Admin admin = new Admin();
                                admin.Show();
                            }
                            this.Hide();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
    }
}
