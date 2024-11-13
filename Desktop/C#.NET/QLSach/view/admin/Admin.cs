using QLSach.component;
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
            Singleton.getInstance.AdminHelper.mainPane.Controls.Clear();
            BookManagement manager = new BookManagement();
            Singleton.getInstance.AdminHelper.mainPane.Controls.Add(manager);
        }

        private void btn_category_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.AdminHelper.mainPane.Controls.Clear();
            PaneCategory category = new PaneCategory();
            Singleton.getInstance.AdminHelper.mainPane.Controls.Add(category);
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            Singleton.getInstance.AdminHelper.mainPane = pane_main;
        }
    }
}
