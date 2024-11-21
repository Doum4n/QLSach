using QLSach.component;
using QLSach.components;
using QLSach.Controller;
using QLSach.database.models;
using QLSach.database.query;
using QLSach.dbContext.models;
using System.Data;

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

        Dictionary<int, DataRow> prevDataRow = new Dictionary<int, DataRow>();

        private bool isModify = false;
        private bool isDelete = false;

        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
        private List<int> seletedIndex = new List<int>();
        private List<int> seletedBookId = new List<int>();

        private BookManagerController controller;

        public BookManager()
        {
            InitializeComponent();
            controller = new BookManagerController(data, binding, tb_search, combobox_filter);
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

            data.CellContentClick += (sender, e) =>
            {
                if (e.RowIndex > -1)
                {
                    var selectedRow = data.Rows[e.RowIndex];
                    if (selectedRow.Cells[0].ColumnIndex == e.ColumnIndex)
                    {
                        var bookDataTable = (DataTable)binding.DataSource;

                        seletedBookId.Add(BookId);

                        controller.addPrevRows(e.RowIndex, bookDataTable.Rows[e.RowIndex]);
                        seletedIndex.Add(e.RowIndex);
                    }
                }
            };

            data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            data.AllowUserToAddRows = false;
            data.AllowUserToDeleteRows = false;
            btn_update.Visible = isModify;
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
                    loadImage.ShowImage(picture, filePath, 149, 179);
                }
                catch (Exception ex){}

                tb_book_id.Text = bookId.ToString();
                tb_book_name.Text = name.ToString();
                tb_quantity.Text = quantity.ToString();
                tb_remaining.Text = remaing.ToString();
                tb_genre_id.Text = genre_id.ToString();
                tb_author_id.Text = author_id.ToString();
                rtb_book_description.Text = description.ToString();
                combobox_genre_name.SelectedValue = Convert.ToInt32(tb_genre_id.Text);
                cbb_author_name.SelectedValue = Convert.ToInt32(tb_author_id.Text);

                datePicker.Value = DateTime.Now;
            }

        }

        private void LoadData()
        {
            combobox_genre_name.DataSource = Singleton.getInstance.Data.Genre.ToList();
            combobox_genre_name.DisplayMember = "Name";
            combobox_genre_name.ValueMember = "Id";
            combobox_genre_name.SelectedValueChanged += (sender, e) =>
            {
                tb_genre_id.Text = combobox_genre_name.SelectedValue.ToString();
            };

            cbb_author_name.DataSource = Singleton.getInstance.Data.Authors.Select(o => new { o.Id, o.name }).ToList();
            cbb_author_name.DisplayMember = "name";
            cbb_author_name.ValueMember = "Id";
            cbb_author_name.SelectedValueChanged += (sender, e) =>
            {
                tb_author_id.Text = cbb_author_name.SelectedValue.ToString();
            };

            btn_deleteData.Visible = isDelete;

            checkbox.HeaderText = "Xóa";
            checkbox.TrueValue = true;
            checkbox.FalseValue = false;
            data.Columns.Insert(0, checkbox);

            controller.Load();

            controller.setRollbackList(seletedIndex, seletedBookId);
            controller.setPrevRows(prevDataRow);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            Book book = BookQuery.getBook(BookId);
            Photo? photo = imageQuery.GetImageBookId(BookId);

            book.author_id = Convert.ToInt32(combobox_genre_name.SelectedValue);
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
                photo.book_id = BookId;
            }
            else
            {
                photo = new Photo();
                photo.path = filePath;
                photo.book_id = BookId;
            }

            UpdateDataTable(book, photo);

            Singleton.getInstance.Data.Books.Update(book);
            Singleton.getInstance.Data.Photos.Update(photo);

            MessageBox.Show("Cập nhật thành công!");
        }

        private void UpdateDataTable(Book book, Photo? photo)
        {
            var bookDataTable = (DataTable)binding.DataSource;

            DataRow dataRow = bookDataTable.NewRow();
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

            controller.addPrevRows(index, dataRow);

            bookDataTable.Rows.RemoveAt(index);
            bookDataTable.Rows.InsertAt(dataRow, index);
        }

        private void picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                loadImage.ShowImage(picture, filePath, 149, 179);
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
            isDelete = !isDelete;
            checkbox.Visible = isDelete;
            btn_deleteData.Visible = isDelete;

            var bookDataTable = (DataTable)binding.DataSource;
            bookDataTable.AcceptChanges();
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            isModify = !isModify;
            btn_update.Visible = isModify;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            controller.Rollback();
        }

        private void btn_update_data_Click(object sender, EventArgs e)
        {
            controller.SaveChange();
        }

        private void btn_deleteData_Click(object sender, EventArgs e)
        {
            controller.Delete();
        }
    }
}
