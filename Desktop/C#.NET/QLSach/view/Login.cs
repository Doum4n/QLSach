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
            Mainframe mainframe = new Mainframe();
            mainframe.Show();

            this.Hide();
        }
    }
}
