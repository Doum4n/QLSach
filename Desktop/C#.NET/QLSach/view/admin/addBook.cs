﻿using QLSach.component;
using QLSach.controllers;
using QLSach.database.models;
using QLSach.dbContext.models;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.view.admin
{
    public partial class addBook : Form
    {
        private string filePath = "";
        private AuthorQuery authorQuery = new AuthorQuery();
        public addBook()
        {
            InitializeComponent();
        }

        private void onClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                Singleton.getInstance.LoadImg.ShowMyImage(pictureBook, filePath, 162, 240);
            }
            //ofd.ShowDialog();
        }

        private void btn_post_Click(object sender, EventArgs e)
        {
            
            var exist_author = Singleton.getInstance.Data.Authors.Where(o => o.name.Equals(combobox_author_name.Text));
            int author_id;
            if (!exist_author.Any())
            {
                author added_author = new author();
                added_author.name = combobox_author_name.Text;
                added_author.description = combobox_author_name.Text;
                Singleton.getInstance.Data.Add(added_author);
                author_id = added_author.Id;
            }
            else
            {
                author_id = exist_author.Select(o => o.Id).FirstOrDefault();
            }
            Book book = new Book();
            book.author_id = author_id;
            book.name = tb_book_name.Text;
            book.description = rtb_description.Text;
            book.year_public = date_picker.Value.Year;
            int genre_id = Singleton.getInstance.Data.Genre.Where(o => o.name == combo_box_genre.Text).Select(o => o.id).FirstOrDefault();
            book.genre_id = genre_id;
            book.quantity = byte.Parse(tb_quantity.Text);
            book.remaining = byte.Parse(tb_quantity.Text);

            Photo photo = new Photo();
            photo.path = filePath;

            Singleton.getInstance.Data.Books.Add(book);
            Singleton.getInstance.Data.SaveChanges();
            photo.book_id = Singleton.getInstance.Data.Books.Where(o => o.name == book.name).Select(o => o.Id).FirstOrDefault();
            Singleton.getInstance.Data.Photos.Add(photo);
            Singleton.getInstance.Data.SaveChanges();

            MessageBox.Show("Thêm sách thành công");

            Singleton.getInstance.AdminHelper.book_data.Add(book);
        }

        private void addBook_Load(object sender, EventArgs e)
        {
            combo_box_genre.DataSource = Singleton.getInstance.Data.Genre.Select(o => o.name).ToList();
            combobox_author_name.DataSource = authorQuery.getAuthorName();
        }
    }
}