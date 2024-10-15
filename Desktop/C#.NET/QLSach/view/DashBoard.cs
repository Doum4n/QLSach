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
            //LoadBooks(bookStatus.newly_udated);
        }

        private void LoadData(bookStatus status, book bookItem)
        {
            switch (status)
            {
                case bookStatus.newly_udated:
                    {
                        //tablePane_book.PerformLayout();
                        tablePane_book.ColumnCount += 1;
                        //tablePane_book.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
                        tablePane_book.SetColumn(bookItem, tablePane_book.ColumnCount - 1);
                        tablePane_book.Controls.Add(bookItem);
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
            controllers.DashBoard dashBoard = new controllers.DashBoard();

            foreach (var book in dashBoard.getBooks())
            {
                book book1 = new book();
                book1.Name = book.name;
                book1.Author = "Entein";
                book1.Source = "Internet";
                LoadData(bookStatus.newly_udated, book1);

                book book2 = new book();
                book2.Name = "Vật lý";
                book2.Author = "Entein";
                book2.Source = "Internet";
                LoadData(bookStatus.newly_udated, book2);

                book book3 = new book();
                book3.Name = "Vật lý";
                book3.Author = "Entein";
                book3.Source = "Internet";
                LoadData(bookStatus.newly_udated, book3);
            }
        }

        private void more_newlyBook_Click(object sender, EventArgs e)
        {
            recentUpdate rc = new recentUpdate();
            Singleton.getInstance.MainPane.Controls.Clear();
            Singleton.getInstance.MainPane.Controls.Add(rc);
        }
    }
}
