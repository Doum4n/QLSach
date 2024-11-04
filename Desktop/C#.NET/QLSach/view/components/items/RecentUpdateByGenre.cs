using QLSach.component;
using QLSach.controllers;
using QLSach.view.components;
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
            pagination.books = query.getBookByGenre(GenreId);
            //pagination.books.ForEach(book => { MessageBox.Show(book.genre_id.ToString()); });
            //MessageBox.Show(Singleton.getInstance.BookHelper.genreId.ToString());
            pagination.LoadData();
        }
    }
}
