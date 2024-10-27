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
using QLSach.database;
using QLSach.component;
using QLSach.dbContext.models;

namespace QLSach.view
{
    public partial class DashBoard : UserControl
    {
        Node node;

        private controllers.BookQuery dashBoard = new controllers.BookQuery();
        private int currentIndex = 0;

        private enum bookStatus
        {
            newly_udated,
            popula,
            most_view
        }

        public DashBoard()
        {
            InitializeComponent();
            Singleton.getInstance.MainFrameHelper.Path = "Trang chủ";
            node = new Node(this);
            Singleton.getInstance.MainFrameHelper.Node = node;
            tablePane_book.RowCount = 0;
            tablePane_book.ColumnCount = 0;
            LoadData();
        }

        private void Init()
        {

        }
        private void DashBoard_Load(object sender, EventArgs e)
        {
            //Singleton.getInstance.MainFrameHelper.States.Push(State.DashBoard);
            Singleton.getInstance.State = node;
            Singleton.getInstance.MainFrameHelper.Node.AddChild(node);
        }

        private void LoadData_Btn(bookStatus status, book bookItem)
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
            LoadData();
        }

        private void more_newlyBook_Click(object sender, EventArgs e)
        {
            recentUpdate rc = new recentUpdate();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(rc);
        }

        private void setData(book bookItem)
        {
            if (tablePane_book.ColumnCount > 3)
            {
                tablePane_book.ColumnCount = 0;
                tablePane_book.RowCount = 1;
            }

            if (tablePane_book.RowCount == 1)
            {
                tablePane_book.RowCount = 0;
            }


            tablePane_book.SetCellPosition(bookItem,
                new TableLayoutPanelCellPosition(
                    tablePane_book.ColumnCount
                    , tablePane_book.RowCount
                    )
                );

            tablePane_book.ColumnCount += 1;
            tablePane_book.Controls.Add(bookItem);

        }

        private void LoadData()
        {

            List<Book> Books = dashBoard.getBooks();

            for (int i = 8 * currentIndex; i < 8 * currentIndex + 8; i++)
            {
                book book1 = new book();
                //Singleton.getInstance.MainFrameHelper.Id = Books[i].id;
                book1.Id = Books[i].Id;
                book1.Name = Books[i].name;
                book1.Author = "Entein";
                book1.Source = "Internet";
                setData(book1);
            }
        }

        private void btn_popula_Click(object sender, EventArgs e)
        {
            //pane_tool.Controls.Clear();
            //pane_tool.Controls.Add(new popula());
        }
    }
}
