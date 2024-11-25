using QLSach.component;
using QLSach.components;
using QLSach.Controller;
using QLSach.database;
using QLSach.database.models;
using QLSach.database.query;
using QLSach.dbContext.models;
using QLSach.ViewModel;
using System.Data;
using System.Globalization;

namespace QLSach.view.admin
{
    public partial class BookManager : UserControl
    {
        private BookQuery BookQuery = new BookQuery();

        private int BookId;
        private int index;
        private string filePath = "";

        private bool isModify = false;
        private bool isDelete = false;

        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();

        private BookManagerVM viewModel;

        public BookManager()
        {
            InitializeComponent();
            viewModel = new BookManagerVM(data);
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
                index = e.RowIndex;

                if (e.RowIndex > -1)
                {
                    var selectedRow = data.Rows[e.RowIndex];
                    if (selectedRow.Cells[0].ColumnIndex == e.ColumnIndex)
                    {
                        viewModel.addPrevRows(e.RowIndex, "Id");
                    }
                }
            };

            btn_update.Visible = isModify;

            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_filter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void assignDisplayValue(DataGridViewCellEventArgs e)
        {
            var selectedRow = data.Rows[e.RowIndex];

            if (e.RowIndex >= 0)
            {
                var bookId = selectedRow.Cells["id"].Value;
                BookId = Convert.ToInt32(bookId);
                var name = selectedRow.Cells["name"].Value;
                var quantity = selectedRow.Cells["quantity"].Value;
                var remaing = selectedRow.Cells["remaining"].Value;
                var description = selectedRow.Cells["description"].Value;
                var year_public = selectedRow.Cells["public_at"].Value;
                var genre_id = selectedRow.Cells["genre_id"].Value;
                var author_id = selectedRow.Cells["author_id"].Value;
                var author_name = selectedRow.Cells["AuthorName"].Value;
                var public_at = selectedRow.Cells["public_at"].Value;
                var photoPath = selectedRow.Cells["photoPath"].Value;

                loadImage.ShowImage(picture, photoPath.ToString(), 149, 179);

                tb_book_id.Text = bookId.ToString();
                tb_book_id.Enabled = false;
                tb_book_name.Text = name.ToString();
                tb_quantity.Text = quantity.ToString();
                tb_remaining.Text = remaing.ToString();
                tb_genre_id.Text = genre_id.ToString();
                tb_genre_id.Enabled = false;
                tb_author_id.Enabled = false;
                tb_author_id.Text = author_id.ToString();
                rtb_book_description.Text = description.ToString();
                combobox_genre_name.SelectedValue = Convert.ToInt32(tb_genre_id.Text);
                cbb_author_name.SelectedValue = Convert.ToInt32(tb_author_id.Text);
                datePicker.Value = DateTime.Parse(public_at.ToString());
            }

        }

        private void LoadData()
        {
            data.DataSource = viewModel.Books;
            viewModel.Load();
            viewModel.AssignFillterList(combobox_filter);

            using (var context = new Context())
            {
                combobox_genre_name.DataSource = context.Genre.ToList();
                combobox_genre_name.DisplayMember = "Name";
                combobox_genre_name.ValueMember = "Id";
                combobox_genre_name.SelectedValueChanged += (sender, e) =>
                {
                    tb_genre_id.Text = combobox_genre_name.SelectedValue.ToString();
                };

                cbb_author_name.DataSource = context.Authors.Select(o => new { o.Id, o.name }).ToList();
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
                checkbox.Visible = false;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
                Book book = BookQuery.getBook(BookId);

                book.author_id = Convert.ToInt32(combobox_genre_name.SelectedValue);
                book.name = tb_book_name.Text;
                book.description = rtb_book_description.Text;
                book.public_at = DateOnly.FromDateTime(datePicker.Value);
                book.genre_id = Convert.ToInt32(combobox_genre_name.SelectedValue);
                book.quantity = byte.Parse(tb_quantity.Text);
                book.remaining = byte.Parse(tb_remaining.Text);

                viewModel.UpdateBook(book, index);

                MessageBox.Show("Cập nhật thành công!");
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
            viewModel.Search();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            isDelete = !isDelete;
            checkbox.Visible = isDelete;
            btn_deleteData.Visible = isDelete;
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            isModify = !isModify;
            btn_update.Visible = isModify;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            viewModel.Rollback();
        }

        private void btn_update_data_Click(object sender, EventArgs e)
        {
            viewModel.SaveChange();
        }

        private void btn_deleteData_Click(object sender, EventArgs e)
        {
            viewModel.Delete();
        }
    }
}
