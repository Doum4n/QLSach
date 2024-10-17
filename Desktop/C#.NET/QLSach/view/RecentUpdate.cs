﻿using QLSach.component;
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
            tablePane_recentUpdate.RowCount = 0;
            tablePane_recentUpdate.ColumnCount = 0;
            Load();

            Singleton.getInstance.MainFrameHelper.Path += " > Book";

            if(!Singleton.getInstance.MainFrameHelper.States.Contains(State.RecentUpdate))
                Singleton.getInstance.MainFrameHelper.States.Push(State.RecentUpdate);
        }

        private void Load(book bookItem)
        {
            if (tablePane_recentUpdate.ColumnCount > 3)
            {
                tablePane_recentUpdate.ColumnCount = 0;
                tablePane_recentUpdate.RowCount = 1;
            }

            if (tablePane_recentUpdate.RowCount == 1)
            {
                tablePane_recentUpdate.RowCount = 0;
            }


            tablePane_recentUpdate.SetCellPosition(bookItem,
                new TableLayoutPanelCellPosition(
                    tablePane_recentUpdate.ColumnCount
                    , tablePane_recentUpdate.RowCount
                    )
                );

            tablePane_recentUpdate.ColumnCount += 1;
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

        private void Load()
        {
       
            List<Book> Books = dashBoard.getBooks();

            for (int i = 8 * currentIndex; i < 8 * currentIndex + 8; i++)
            {
                book book1 = new book();
                book1.Name = Books[i].name;
                book1.Author = "Entein";
                book1.Source = "Internet";
                Load(book1);
            }

            lb_index.Text = (currentIndex + 1).ToString();
        }


        private void btn_first_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            lb_index.Text = currentIndex.ToString();
            tablePane_recentUpdate.Controls.Clear();
            Load();
           
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (currentIndex <= dashBoard.getBooks().Count && (8 * currentIndex + 8) < dashBoard.getBooks().Count)
            {
                currentIndex += 1;
                lb_index.Text = currentIndex.ToString();

                tablePane_recentUpdate.Controls.Clear();
                Load();
            }
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex -= 1;
                lb_index.Text = currentIndex.ToString();

                tablePane_recentUpdate.Controls.Clear();
                Load();
            }
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            currentIndex = (int)Math.Floor(dashBoard.getBooks().Count / 8.0) - 1;
            lb_index.Text = currentIndex.ToString();
            tablePane_recentUpdate.Controls.Clear();
            Load();
        }
    }
}
