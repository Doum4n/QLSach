using QLSach.controllers;
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
using QLSach.controllers;

namespace QLSach.view
{
    public partial class DashBoard : UserControl
    {
        private enum bookStatus
        {
            newly_udated,
            popula,
            most_view
        }

        public DashBoard()
        {
            InitializeComponent();
            LoadBooks(bookStatus.newly_udated);
        }

        private void LoadBooks(bookStatus status)
        {
            book book = new book();
            switch (status)
            {
                case bookStatus.newly_udated:
                    {
                        tablePane_book.ColumnCount = 1;
                        tablePane_book.SetColumn(book, tablePane_book.ColumnCount - 1);
                        tablePane_book.Controls.Add(book);
                        break;
                    }
                case bookStatus.popula:
                    break;
                case bookStatus.most_view:
                    break;
                default:
                    // code block
                    break;
            }
        }

        private void btn_newlyUpdate_Click(object sender, EventArgs e)
        {
            controllers.DashBoard dashBoard = new controllers.DashBoard(Singleton.getInstance.Data);
            label4.Text = (dashBoard.List().name).ToString();
        }
    }
}
