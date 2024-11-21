using QLSach.database.query;

namespace QLSach.view.components.items
{
    public partial class PanePopular : UserControl
    {
        public PanePopular()
        {
            InitializeComponent();
        }

        private void PanePopular_Load(object sender, EventArgs e)
        {
            tbLayoutPanel.Controls.Clear();

            BookQuery query = new BookQuery();
            int i = 1;
            foreach (var item in query.getMostViewBooks())
            {
                BookMostPopular popular = new(item.Id);
                popular.bookName = item.name;
                popular.author = query.getBookAuthor(item.author_id);
                popular.index = $"#{i++}";
                popular.info = item.description;
                popular.status = item.status;
                tbLayoutPanel.SetRow(popular, tbLayoutPanel.RowCount++);
                tbLayoutPanel.Controls.Add(popular);
            }
        }
    }
}
