using QLSach.component;
using QLSach.controllers;
using QLSach.dbContext.models;
using QLSach.view.components;
using QLSach.view.components.items;
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
    public partial class recentUpdate : UserControl
    {
        private Pagination pagination;
        private BookQuery dashBoard = new();
        private BookQuery BookQuery = new();
        public recentUpdate()
        {
            InitializeComponent();
            //TableLayoutPanel have 1 column 1 row
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
            Singleton.getInstance.State = new(this);
            Singleton.getInstance.MainFrameHelper.Node.AddChild(Singleton.getInstance.State);
            pagination = new(tablePane_recentUpdate, 1, 4, 8);
            pagination.books = BookQuery.getRecentUpdateBooks();
            pagination.LoadData();
        }
    }
}
