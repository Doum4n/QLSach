using QLSach.component;
using QLSach.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Singleton.getInstance.Username = tb_name.Text;
            Singleton.getInstance.Password = tb_pw.Text;

            if(tb_name.Text == "admin")
            {
                Admin admin = new Admin();
                admin.Show();
            }
            else
            {
                Mainframe mainframe = new Mainframe();
                Singleton.getInstance.UserId = 5;
                mainframe.Show();
            }

            this.Hide();
        }
    }
}
