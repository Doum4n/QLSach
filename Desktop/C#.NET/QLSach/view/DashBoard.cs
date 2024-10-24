﻿using QLSach.controllers;
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

namespace QLSach.view
{
    public partial class DashBoard : UserControl
    {
        Node node;
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
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            //Singleton.getInstance.MainFrameHelper.States.Push(State.DashBoard);
            Singleton.getInstance.State = node;
            Singleton.getInstance.MainFrameHelper.Node.AddChild(node);
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
            controllers.BookQuery BookQuery = new controllers.BookQuery();

            foreach (var book in BookQuery.getBooks())
            {
                book book1 = new book();
                book1.Id = book.id;
                book1.Name = book.name;
                book1.Author = "Entein";
                book1.Source = "Internet";
                LoadData(bookStatus.newly_udated, book1);
            }
        }

        private void more_newlyBook_Click(object sender, EventArgs e)
        {
            recentUpdate rc = new recentUpdate();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(rc);
        }

  
    }
}
