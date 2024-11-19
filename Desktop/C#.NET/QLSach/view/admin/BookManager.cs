using Microsoft.EntityFrameworkCore;
using MoreLinq;
using QLSach.component;
using QLSach.components;
using QLSach.controllers;
using QLSach.database.models;
using QLSach.dbContext.models;
using ServiceStack;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace QLSach.view.admin
{
    public partial class BookManager : UserControl
    {
        private ImageQuery imageQuery = new ImageQuery();
        private BookQuery BookQuery = new BookQuery();

        private int BookId;
        private int index;
        private string filePath = "";

        BindingSource binding = new BindingSource();



        public BookManager()
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
            LoadData();

            data.CellClick += (sender, e) =>
            {
                if (e.RowIndex > -1)
                {
                    assignDisplayValue(e);
                }
            };
        }

        private void assignDisplayValue(DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;

            var selectedRow = data.Rows[e.RowIndex];

            if (e.RowIndex >= 0)
            {
                var bookId = selectedRow.Cells["id"].Value;
                BookId = Convert.ToInt32(bookId);
                var name = selectedRow.Cells["name"].Value;
                var quantity = selectedRow.Cells["quantity"].Value;
                var remaing = selectedRow.Cells["remaining"].Value;
                var description = selectedRow.Cells["description"].Value;
                var year_public = selectedRow.Cells["year_public"].Value;
                var genre_id = selectedRow.Cells["genre_id"].Value;
                var author_id = selectedRow.Cells["author_id"].Value;
                var author_name = selectedRow.Cells["AuthorName"].Value;

                loadImage loadImage = new loadImage();
                try
                {
                    filePath = imageQuery.GetPhoto(Convert.ToInt32(bookId));
                    loadImage.ShowMyImage(picture, filePath, 149, 179);
                }
                catch (Exception ex)
                {

                }

                tb_book_id.Text = bookId.ToString();
                tb_book_name.Text = name.ToString();
                tb_quantity.Text = quantity.ToString();
                tb_remaining.Text = remaing.ToString();
                tb_genre_id.Text = genre_id.ToString();
                tb_author_id.Text = author_id.ToString();
                tb_author_name.Text = author_name.ToString();
                rtb_book_description.Text = description.ToString();

                datePicker.Value = DateTime.Now;
            }
        }

        private void LoadData()
        {
            combobox_genre_name.DataSource = Singleton.getInstance.Data.Genre.ToList();
            combobox_genre_name.DisplayMember = "Name";
            combobox_genre_name.ValueMember = "Id";

            binding.DataSource = Singleton.getInstance.Data.Books
                //.Include(o => o.Genre)
                //.Include(o => o.author)
                .Select(o => new
                {
                    o.Id,
                    o.name,
                    o.description,
                    o.year_public,
                    o.author_id,
                    o.genre_id,
                    o.rating,
                    o.views,
                    AuthorName = o.author.name,
                    GenreName = o.Genre.name,
                    o.quantity,
                    o.remaining,
                    o.status,
                    o.created_at,
                    o.updated_at,
                })
                .ToFilteredDataTable();

            data.DataSource = binding;

            data.Columns["genre_id"].Visible = false;
            data.Columns["author_id"].Visible = false;

            Singleton.getInstance.AdminHelper.book_data = binding;

            List<string> columnNames = new List<string>();

            /*Combobox fillter*/
            foreach (DataGridViewColumn column in data.Columns)
            {
                columnNames.Add(column.HeaderText);
            }

            combobox_filter.DataSource = columnNames;
            /**/

            data.Columns["Id"].HeaderText = "Mã sách";
            data.Columns["name"].HeaderText = "Tên sách";
            data.Columns["description"].HeaderText = "Mô tả";
            data.Columns["year_public"].HeaderText = "Năm phát hành";
            data.Columns["AuthorName"].HeaderText = "Tên tác giả";
            data.Columns["GenreName"].HeaderText = "Tên thể loại";
            data.Columns["rating"].HeaderText = "Đánh giá";
            data.Columns["views"].HeaderText = "Lược xem";
            data.Columns["quantity"].HeaderText = "Số lượng đã nhập";
            data.Columns["remaining"].HeaderText = "Số lượng còn lại";
            data.Columns["status"].HeaderText = "Trạng thái";
            data.Columns["created_at"].HeaderText = "Ngày nhập";
            data.Columns["updated_at"].HeaderText = "Ngày cập nhật";

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            Book book = BookQuery.getBook(BookId);
            Photo? photo = imageQuery.GetImageBookId(BookId);

            book.Id = BookId;
            book.author_id = int.Parse(tb_author_id.Text);
            book.name = tb_book_name.Text;
            book.description = rtb_book_description.Text;
            book.year_public = datePicker.Value.Year;          
            book.genre_id = Convert.ToInt32(combobox_genre_name.SelectedValue);
            book.quantity = byte.Parse(tb_quantity.Text);
            book.remaining = byte.Parse(tb_remaining.Text);

            photo = imageQuery.GetImageBookId(BookId);
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

            UpdateBook(book, photo);

            Singleton.getInstance.Data.Books.Update(book);
            Singleton.getInstance.Data.Photos.Update(photo);
            //Singleton.getInstance.Data.SaveChanges();

            MessageBox.Show("Cập nhật thành công!");
        }

        private void UpdateBook(Book book, Photo? photo)
        {
            DataTable categoryDataTable = (DataTable)binding.DataSource;

            DataRow dataRow = categoryDataTable.NewRow();
            dataRow["Id"] = BookId;
            dataRow["name"] = book.name;
            dataRow["description"] = book.description;
            dataRow["author_id"] = book.author_id;
            dataRow["year_public"] = book.year_public;
            dataRow["genre_id"] = book.genre_id;
            dataRow["quantity"] = book.quantity;
            dataRow["remaining"] = book.remaining;
            dataRow["rating"] = book.rating;
            dataRow["views"] = book.views;
            dataRow["created_at"] = book.created_at;
            dataRow["updated_at"] = book.updated_at;
            dataRow["status"] = book.status;

            categoryDataTable.Rows.RemoveAt(index);
            categoryDataTable.Rows.InsertAt(dataRow, index);

    
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

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            binding.Filter = $"CONVERT({combobox_filter.Text.Trim()}, System.String) LIKE '%{tb_search.Text.Trim()}%'";
            if (tb_search.Text == "")
            {
                binding.RemoveFilter();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_modify_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }

        private void btn_update_data_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.Data.SaveChanges();
            MessageBox.Show("Đã lưu vào cơ sở dữ liệu");
        }
    }
}
