using QLSach.component;
using QLSach.components;
using QLSach.database;
using QLSach.database.models;
using QLSach.database.query;
using QLSach.dbContext.models;
using QLSach.view.components.items;
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
        private bool isAdd = false;

        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();

        private BookManagerVM viewModel;

        public BookManager()
        {
            InitializeComponent();
            viewModel = new BookManagerVM(data);
            BindData();
        }

        private void BindData()
        {
            data.DataSource = viewModel.Books;

            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_filter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btn_add_book_Click(object sender, EventArgs e)
        {
            btn_action.Text = "Thêm";
            btn_action.Visible = true;

            tb_book_id.Text = (Convert.ToInt32(data.Rows[data.RowCount - 1].Cells["Id"].Value) + 1).ToString();
            tb_quantity.ResetText();
            tb_remaining.ResetText();
            tb_book_name.ResetText();
            tb_author_id.ResetText();
            tb_genre_id.ResetText();
            rtb_book_description.ResetText();
        }

        private void book_management_Load(object sender, EventArgs e)
        {
            LoadData();

            // Xem dữ liệu, cập nhật
            data.CellClick += (sender, e) =>
            {
                if (e.RowIndex > -1)
                {
                    assignDisplayValue(e);
                }
            };

            // Xóa dữ liệu
            data.CellContentClick += (sender, e) =>
            {
                if (e.RowIndex > -1)
                {
                    // Nếu checkbox được check
                    if (data.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        viewModel.addSelectedId(e.RowIndex, "Id");
                    }
                }
            };

            tb_book_id.Enabled = false;
        }

        // Gán dữ liệu hiển thị
        private void assignDisplayValue(DataGridViewCellEventArgs e)
        {
            var selectedRow = data.Rows[e.RowIndex];

            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;

                var bookId = selectedRow.Cells["id"].Value;
                BookId = Convert.ToInt32(bookId);
                var name = selectedRow.Cells["name"].Value;
                var quantity = selectedRow.Cells["quantity"].Value;
                var remaing = selectedRow.Cells["remaining"].Value;
                var description = selectedRow.Cells["description"].Value;
                var year_public = selectedRow.Cells["public_at"].Value;
                var genre_id = selectedRow.Cells["genre_id"].Value;
                var author_id = selectedRow.Cells["author_id"].Value;
                var publisher_id = selectedRow.Cells["publisher_id"].Value;
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
                tb_publisher_id.Text = publisher_id.ToString();
                rtb_book_description.Text = description.ToString();
                combobox_genre_name.SelectedValue = Convert.ToInt32(tb_genre_id.Text);
                cbb_author_name.SelectedValue = Convert.ToInt32(tb_author_id.Text);
                cbb_publisher.SelectedValue = Convert.ToInt32(tb_publisher_id.Text);
                datePicker.Value = DateTime.Parse(public_at.ToString());
            }
        }

        private void LoadData()
        {
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

                cbb_publisher.DataSource = context.Publisher.Select(o => new { o.Id, o.Name }).ToList();
                cbb_publisher.DisplayMember = "Name";
                cbb_publisher.ValueMember = "Id";
                cbb_publisher.SelectedValueChanged += (sender, e) =>
                {
                    tb_publisher_id.Text = cbb_publisher.SelectedValue.ToString();
                };

                btn_deleteData.Visible = isDelete;

                checkbox.HeaderText = "Xóa";
                checkbox.TrueValue = true;
                checkbox.FalseValue = false;
                data.Columns.Insert(0, checkbox);
                checkbox.Visible = false;
            }
        }

        private void btn_action_Click(object sender, EventArgs e)
        {
            if (btn_action.Text == "Cập nhật")
                Update();
            else if (btn_action.Text == "Thêm")
                Add();
        }

        private void Add()
        {
            Book book = new Book();
            book.author_id = Convert.ToInt32(combobox_genre_name.SelectedValue);
            book.name = tb_book_name.Text;
            book.description = rtb_book_description.Text;
            book.public_at = DateOnly.FromDateTime(datePicker.Value);
            book.genre_id = Convert.ToInt32(combobox_genre_name.SelectedValue);
            book.publisher_id = Convert.ToInt32(cbb_publisher.SelectedValue);
            try
            {
                byte quantity = byte.Parse(tb_quantity.Text);
                byte remaining = byte.Parse(tb_remaining.Text);
                if(quantity > 0 && remaining >= 0)
                {
                    book.quantity = quantity;
                    if (remaining > quantity)
                    {
                        MessageBox.Show("Số lượng còn phải nhỏ hơn hoặc bằng tổng số lượng!");
                        return;
                    }
                    else
                        book.remaining = byte.Parse(tb_remaining.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Số lượng phải là số!");
                return;
            }
            book.photoPath = filePath;

            viewModel.AddBook(book);
        }

        private void Update()
        {
                Book book = new Book();
                book.Id = BookId;
                book.author_id = Convert.ToInt32(combobox_genre_name.SelectedValue);
                book.name = tb_book_name.Text;
                book.description = rtb_book_description.Text;
                book.public_at = DateOnly.FromDateTime(datePicker.Value);
                book.genre_id = Convert.ToInt32(combobox_genre_name.SelectedValue);
                book.publisher_id = Convert.ToInt32(cbb_publisher.SelectedValue);
                book.quantity = byte.Parse(tb_quantity.Text);
                book.remaining = byte.Parse(tb_remaining.Text);
                book.photoPath = filePath;

                viewModel.UpdateBook(book, index);

                MessageBox.Show("Cập nhật thành công!");     
        }

        // Khi thêm sách, chỉnh sửa sách
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
            btn_action.Visible = true;
            btn_action.Text = "Cập nhật";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            viewModel.Rollback("Books");
        }

        private void btn_update_data_Click(object sender, EventArgs e)
        {
            viewModel.SaveChange();
        }

        private void btn_deleteData_Click(object sender, EventArgs e)
        {
            viewModel.Delete("Books", "Id");
        }

        private void tb_quantity_TextChanged(object sender, EventArgs e)
        {
            tb_remaining.Text = tb_quantity.Text;
        }
    }
}
