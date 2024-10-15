using QLSach.controllers;
using QLSach.dbContext.models;
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
        private int currentIndex = 0;
        private controllers.DashBoard dashBoard = new controllers.DashBoard();
        public recentUpdate()
        {
            InitializeComponent();
            LoadData();
        }

        private void Load(book bookItem)
        {
            tablePane_recentUpdate.ColumnCount += 1;
            tablePane_recentUpdate.SetColumn(bookItem, tablePane_recentUpdate.ColumnCount - 1);
            tablePane_recentUpdate.Controls.Add(bookItem);
        }

        private void LoadData()
        {
            foreach (var book in dashBoard.getBooks())
            {
                book book1 = new book();
                book1.Name = book.name;
                book1.Author = "Entein";
                book1.Source = "Internet";
                Load(book1);
            }
        }

        private void loadByIndex()
        {
            List<Book> Books = dashBoard.getBooks();
            for (int i = 4 * currentIndex; i < 4 * currentIndex + 4; i++)
            {
                book book1 = new book();
                book1.Name = Books[i].name;
                book1.Author = "Entein";
                book1.Source = "Internet";
                Load(book1);
            }
        }


        private void btn_first_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (currentIndex != dashBoard.getBooks().Count)
            {
                currentIndex += 1;

                tablePane_recentUpdate.Controls.Clear();
                loadByIndex();
            }
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0) 
                currentIndex -= 1;
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            currentIndex = 999;
        }
    }
}
