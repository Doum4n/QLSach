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
    public partial class BookByGenre : UserControl
    {
        private Pagination pagination;
        private BookQuery query = new BookQuery();
        public int genreId { get; set; }
        public string genreName { get; set; }
        public BookByGenre()
        {
            InitializeComponent();
        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            pagination.btn_first_Click();
            lb_index.Text = (pagination.currentIndex + 1).ToString();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            pagination.btn_previous_Click();
            lb_index.Text = (pagination.currentIndex + 1).ToString();
        }

        private void btn_last_Click_Click(object sender, EventArgs e)
        {
            pagination.btn_last_Click();
            lb_index.Text = (pagination.currentIndex + 1).ToString();
        }

        private void btn_next_Click_Click(object sender, EventArgs e)
        {
            pagination.btn_next_Click();
            lb_index.Text = (pagination.currentIndex + 1).ToString();
        }

        private void BookByGenre_Load(object sender, EventArgs e)
        {
            tablePane_genre.RowCount = 0;
            tablePane_genre.ColumnCount = 0;

            lb_index.Text = 1.ToString(); 
            lb_genreName.Text = genreName;
            Singleton.getInstance.State = new(this);
            Singleton.getInstance.MainFrameHelper.Node.AddChild(Singleton.getInstance.State);
            pagination = new Pagination(tablePane_genre, 1, 4, 8);
            pagination.books = query.getBooksByGenre(this.genreId);
            pagination.LoadData();
        }
    }
}
