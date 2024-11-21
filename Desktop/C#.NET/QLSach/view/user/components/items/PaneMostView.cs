using QLSach.database.query;

namespace QLSach.view.components.items
{
    public partial class PaneMostView : UserControl
    {
        public PaneMostView()
        {
            InitializeComponent();
        }

        private void PaneMostView_Load(object sender, EventArgs e)
        {
            tbLayoutPanel.Controls.Clear();

            BookQuery query = new BookQuery();
            int i = 1;
            foreach (var item in query.getMostViewBooks())
            {
                BookMostView bookMostView = new BookMostView(item.Id);
                bookMostView.bookName = item.name;
                bookMostView.author = query.getBookAuthor(item.author_id);
                bookMostView.index = $"#{i++}";
                bookMostView.views = $"Lượt xem: {item.views}";
                bookMostView.status = item.status;
                tbLayoutPanel.SetRow(bookMostView, tbLayoutPanel.RowCount++);
                tbLayoutPanel.Controls.Add(bookMostView);
            }
        }

        private void btn_thisWeek_Click(object sender, EventArgs e)
        {

        }

        private void btn_thisYear_Click(object sender, EventArgs e)
        {

        }

        private void btn_thisMonth_Click(object sender, EventArgs e)
        {

        }
    }
}
