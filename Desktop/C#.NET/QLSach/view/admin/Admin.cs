using QLSach.view.admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.view
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btn_book_management_Click(object sender, EventArgs e)
        {
            book_management manager = new book_management();
            pane_main.Controls.Add(manager);
        }
    }
}
