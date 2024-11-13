
using QLSach.component;
using QLSach.database.models;
using QLSach.query;

namespace QLSach.view.admin
{
    public partial class PaneCategory : UserControl
    {
        public PaneCategory()
        {
            InitializeComponent();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            paneMain.Controls.Clear();
            paneMain.Controls.Add(new subPaneCategory());
        }

        private void btn_add_category_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.AdminHelper.isPaneAdd = true;
            Singleton.getInstance.AdminHelper.isPaneModify = false;

            paneMain.Controls.Clear();
            paneMain.Controls.Add(new subPaneCategory());
        }

        private void btn_modify_category_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.AdminHelper.isPaneAdd = false;
            Singleton.getInstance.AdminHelper.isPaneModify = true;

            paneMain.Controls.Clear();
            paneMain.Controls.Add(new subPaneCategory());
        }

        private void btn_modify_pagination_Click(object sender, EventArgs e)
        {
            paneMain.Controls.Clear();
            paneMain.Controls.Add(new addToCategory());
        }
    }
}
