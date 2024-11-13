using Kimtoo.BindingProvider;
using QLSach.component;
using QLSach.components;
using QLSach.controllers;
using QLSach.database.models;
using QLSach.dbContext.models;
using QLSach.view.components.items;
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
using Utilities.BunifuCheckBox.Transitions;
using static Jenga.Theme;

namespace QLSach.view.admin
{
    public partial class BookManagement : UserControl
    {
        private AuthorQuery authorQuery = new AuthorQuery();
        private GenreQuery genreQuery = new GenreQuery();
        private ImageQuery imageQuery = new ImageQuery();
        private BookQuery BookQuery = new BookQuery();
        private bool isModify = false;
        Dictionary<int, string> genres;
        private int BookId;
        private int index;
        private string filePath = "";

        private bool isUpdate = false;
        public BookManagement()
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
            genres = genreQuery.getGenre_name_id();
            combobox_genre_name.DataSource = genres.Values.ToList();

            BindingSource binding = new BindingSource();
            binding.DataSource = Singleton.getInstance.Data.Books.ToList();
            data.DataSource = binding;
            Singleton.getInstance.AdminHelper.book_data = binding;
            data.Columns[3].Visible = false;
            data.Columns[4].Visible = false;

            data.CellClick += (sender, e) =>
            {
                btn_update.Click += (sender, ev) =>
                {
                    Singleton.getInstance.AdminHelper.book_data.RemoveAt(e.RowIndex);
                    return;
                };

                if (e.RowIndex > -1)
                {
                    index = e.RowIndex;

                    int author_id = (int)data.Rows[e.RowIndex].Cells["author_id"].Value;
                    author author = authorQuery.getAuthorById(author_id);
                    tb_author_id.Text = author.Id.ToString();
                    tb_author_name.Text = author.name.ToString();
                    tb_author_description.Text = author.description.ToString();

                    int genre_id = (int)data.Rows[e.RowIndex].Cells["genre_id"].Value;


                    var selectedRow = data.Rows[e.RowIndex];

                    if (e.RowIndex >= 0)
                    {
                        var bookId = selectedRow.Cells["id"].Value;
                        BookId = (int)bookId;
                        var name = selectedRow.Cells["name"].Value;
                        var quantity = selectedRow.Cells["quantity"].Value;
                        var remaing = selectedRow.Cells["remaining"].Value;
                        var description = selectedRow.Cells["description"].Value;
                        var year_public = selectedRow.Cells["year_public"].Value;

                        loadImage loadImage = new loadImage();
                        try
                        {
                            filePath = imageQuery.GetPhoto((int)bookId);
                            loadImage.ShowMyImage(picture, filePath, 149, 179);
                        }
                        catch (Exception ex)
                        {

                        }

                        tb_book_id.Text = bookId.ToString();
                        tb_book_name.Text = name.ToString();
                        tb_quantity.Text = quantity.ToString();
                        tb_remaining.Text = remaing.ToString();
                        rtb_book_description.Text = description.ToString();

                        Genre genre = genreQuery.getGenrebyId(genre_id);
                        tb_genre_id.Text = genre.id.ToString();
                        combobox_genre_name.SelectedItem = genre.name.ToString();
                        
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

        private void btn_update_Click(object sender, EventArgs e)
        {
            Book book = BookQuery.getBook(BookId);
            book.Id = BookId;
            book.author_id = int.Parse(tb_author_id.Text);
            book.name = tb_book_name.Text;
            book.description = rtb_book_description.Text;
            book.year_public = datePicker.Value.Year;
            int genre_id = genres.First(o => o.Value == combobox_genre_name.Text).Key;
            book.genre_id = genre_id;
            book.quantity = byte.Parse(tb_quantity.Text);
            book.remaining = byte.Parse(tb_remaining.Text);

            Photo? photo = imageQuery.GetImageBookId(BookId);
            if (photo != null)
            {
                photo.path = filePath;
            }
            else
            {
                photo = new Photo();
                photo.path = filePath;
                photo.book_id = BookId;
            }

            Singleton.getInstance.Data.Books.Update(book);
            Singleton.getInstance.Data.Photos.Update(photo);
            Singleton.getInstance.Data.SaveChanges();

            Singleton.getInstance.AdminHelper.book_data.Insert(index, book);

            MessageBox.Show("Cập nhật thành công!");
        }

        private void picture_Click(object sender, EventArgs e)
        {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PNG Files (*.png)|*.png|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    Singleton.getInstance.LoadImg.ShowMyImage(picture, filePath, 149, 179);
                }
        }
    }
}
