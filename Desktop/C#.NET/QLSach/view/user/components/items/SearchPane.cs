using QLSach.component;
using QLSach.controllers;
using QLSach.dbContext.models;
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

namespace QLSach.view.user.components.items
{
    public partial class SearchPane : UserControl
    {
        private string SearchString;
        private int AuthorId;
        private Pagination pagination { get; set; }
        private BookQuery BookQuery = new BookQuery();
        private AuthorQuery AuthorQuery = new AuthorQuery();
        public SearchPane(string SearchString, int AuthorId)
        {
            this.SearchString = SearchString;
            this.AuthorId = AuthorId;
            InitializeComponent();
        }

        private void SearchPane_Load(object sender, EventArgs e)
        {
            lb_SearchString.Text = SearchString;
            pagination = new(tablePane_recentUpdate, 1, 4, 8);
            pagination.books = BookQuery.getBookByAuthorId(AuthorId);
            pagination.LoadData();
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

        private void btn_next_Click(object sender, EventArgs e)
        {
            pagination.btn_next_Click();
            lb_index.Text = (pagination.currentIndex + 1).ToString();
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            pagination.btn_last_Click();
            lb_index.Text = (pagination.currentIndex + 1).ToString();
        }
    }
}
