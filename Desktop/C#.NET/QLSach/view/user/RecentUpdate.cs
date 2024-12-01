using QLSach.component;
using QLSach.database;
using QLSach.database.query;
using QLSach.view.components;
using System.Drawing.Printing;

namespace QLSach.view
{
    public partial class recentUpdate : UserControl
    {
        private Pagination pagination;
        private BookQuery dashBoard = new();
        private BookQuery BookQuery = new();
        private Context context = new Context();
        public recentUpdate()
        {
            InitializeComponent();

            var genres = context.Genre.ToList();

            genres.ForEach(genre => {
                Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button();
                btn.Text = genre.name;
                btn.Dock = DockStyle.Left;
                btn.Margin = new Padding(10,0,0,0);
                btn.Width = 90;
                btn.FillColor = Color.FromArgb(49, 81, 30);
                flowLayou_pane.Controls.Add(btn);
            });
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
