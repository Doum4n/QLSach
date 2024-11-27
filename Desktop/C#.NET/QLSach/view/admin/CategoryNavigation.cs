using MoreLinq;
using QLSach.component;
using QLSach.database.models;
using QLSach.database.query;
using System.Data;
using System.Windows.Forms;

namespace QLSach.view.admin
{
    public partial class CategoryNavigation : UserControl
    {

        public event Action OnAddCategory;
        public event Action OnModifyCategory;
        public event Action OnCancel;
        public event Action OnSave;

        private MainPaneCategory MainPaneCategory = new MainPaneCategory();
        private GenreManager GenreManager = new GenreManager();

        public CategoryNavigation()
        {
            InitializeComponent();
        }


        private void btn_add_category_Click(object sender, EventArgs e)
        {

            paneMain.Controls.Clear();
            paneMain.Controls.Add(MainPaneCategory);
        }

        private void btn_modify_pagination_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.CategoryManagerHelper.Modify();

            paneMain.Controls.Clear();
            paneMain.Controls.Add(new addToCategory());
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.CategoryManagerHelper.Cancel();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.CategoryManagerHelper.Save();
        }

        private void CategoryNavigation_Load(object sender, EventArgs e)
        {
            paneMain.Controls.Add(MainPaneCategory);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.CategoryManagerHelper.Delete();
        }

        private void btn_genre_Click(object sender, EventArgs e)
        {
            paneMain.Controls.Clear();
            paneMain.Controls.Add(GenreManager);
        }
    }
}
