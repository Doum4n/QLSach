using QLSach.controllers;
using QLSach.view.components;

namespace QLSach.view
{
    public partial class RecentUpdateByGenre : UserControl
    {
        public int GenreId { get; set; }
        public string Genre {  get; set; }
        private Pagination pagination;
        private BookQuery query = new();
        public RecentUpdateByGenre()
        {
            InitializeComponent();
            //VERY IMPORTANT!!!
            tablePane_recentUpdate.RowCount = 0;
            tablePane_recentUpdate.ColumnCount = 0;
        }

        private void RecentUpdateByGenre_Load(object sender, EventArgs e)
        {
            this.lb_genre.Text = Genre;
            pagination = new(tablePane_recentUpdate, 0, 10, 10);
            pagination.books = query.get10BooksByGenre(GenreId);
            pagination.LoadData();
        }

        public bool isHasChild()
        {
            pagination.books = query.get10BooksByGenre(GenreId);
            return pagination.books.Count > 0;
        }
    }
}
