using QLSach.component;
using QLSach.database.query;
using QLSach.view.components;

namespace QLSach.view
{
    public partial class recentUpdate : UserControl
    {
        private Pagination pagination;
        private BookQuery dashBoard = new();
        private BookQuery BookQuery = new();
        public recentUpdate()
        {
            InitializeComponent();
            //VERY IMPORTANT!!!
            tablePane_recentUpdate.RowCount = 0;
            tablePane_recentUpdate.ColumnCount = 0;

            Singleton.getInstance.MainFrameHelper.Path += " > Book";
        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            pagination.btn_first_Click();
            lb_index.Text = (pagination.currentIndex + 1).ToString();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            pagination.btn_next_Click();
            lb_index.Text = (pagination.currentIndex + 1).ToString();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            pagination.btn_previous_Click();
            lb_index.Text = (pagination.currentIndex + 1).ToString();
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            pagination.btn_last_Click();
            lb_index.Text = (pagination.currentIndex + 1).ToString();
        }

        private void recentUpdate_Load(object sender, EventArgs e)
        {
            pagination = new(tablePane_recentUpdate, 1, 4, 8);
            pagination.books = BookQuery.getRecentUpdateBooks();
            pagination.LoadData();
        }

        private void recentUpdate_visible(object sender, EventArgs e)
        {
            Node cur = Singleton.getInstance.State;
            Node node = new(new recentUpdate());
            cur.AddChild(node);

            Singleton.getInstance.State = node;
        }
    }
}
