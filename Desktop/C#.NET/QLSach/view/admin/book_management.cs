using Kimtoo.BindingProvider;
using QLSach.component;
using QLSach.components;
using QLSach.controllers;
using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.BunifuCheckBox.Transitions;
using static Jenga.Theme;

namespace QLSach.view.admin
{
    public partial class book_management : UserControl
    {
        private AuthorQuery authorQuery = new AuthorQuery();
        private GenreQuery genreQuery = new GenreQuery();
        private bool isModify = false;
        public book_management()
        {
            InitializeComponent();
        }

        private void btn_add_book_Click(object sender, EventArgs e)
        {
            addBook addBook = new addBook();
            addBook.ShowDialog();
        }

        private void book_management_Load(object sender, EventArgs e)
        {
            BindingSource binding = new BindingSource();
            binding.DataSource = Singleton.getInstance.Data.Books.ToList();
            data.DataSource = binding;
            Singleton.getInstance.AdminHelper.book_data = binding;
            data.Columns[3].Visible = false;
            data.Columns[4].Visible = false;

            data.CellClick += (sender, e) =>
            {
                if (e.RowIndex > -1)
                {
                    int author_id = (int)data.Rows[e.RowIndex].Cells["author_id"].Value;
                    author author = authorQuery.getAuthorById(author_id);
                    tb_author_id.Text = author.Id.ToString();
                    tb_author_name.Text = author.name.ToString();
                    tb_author_description.Text = author.description.ToString();

                    int genre_id = (int)data.Rows[e.RowIndex].Cells["genre_id"].Value;
                    author genre = authorQuery.getAuthorById(genre_id);
                    tb_genre_id.Text = genre.Id.ToString();
                    tb_genre_name.Text = genre.name.ToString();

                    var selectedRow = data.Rows[e.RowIndex];
                    //if (isModify)
                    //{
                        if (e.RowIndex >= 0)
                        {
                            var bookId = selectedRow.Cells["id"].Value;
                            var name = selectedRow.Cells["name"].Value;
                            var quantity = selectedRow.Cells["quantity"].Value;
                            var remaing = selectedRow.Cells["remaining"].Value;
                            var description = selectedRow.Cells["description"].Value;
                            var year_public = selectedRow.Cells["year_public"].Value;

                            tb_book_id.Text = bookId.ToString();
                            tb_book_name.Text = name.ToString();
                            tb_quantity.Text = quantity.ToString();
                            tb_remaining.Text = remaing.ToString();
                            tb_book_description.Text = description.ToString();
                            datePicker.Value = DateTime.Now;
                        }
                    //}
                }
            };
            panel_modify.Visible = isModify;
        }

        private void tb_modify_Click(object sender, EventArgs e)
        {
            isModify = !isModify;
            panel_modify.Visible = isModify;
        }
    }
}
