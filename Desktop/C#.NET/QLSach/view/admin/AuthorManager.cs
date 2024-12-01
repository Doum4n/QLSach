using QLSach.component;
using QLSach.dbContext.models;
using QLSach.ViewModel;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLSach.view.admin
{
    public partial class AuthorManager : UserControl
    {
        private AuthorManagerVM viewModel;

        DataGridViewButtonColumn button = new DataGridViewButtonColumn();
        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();

        private int SelectedIndex;

        private bool isDelete = false;
        private bool isAdd = false;
        private bool isUpdate = false;

        public AuthorManager()
        {
            InitializeComponent();
            viewModel = new AuthorManagerVM(data);
            BindData();
        }

        private void BindData()
        {
            // Gán DataSource cho DataGridView


            // Gán DataBinding cho TextBox và ComboBox
            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            tb_author_id.DataBindings.Add("Text", viewModel, "SelectedAuthor.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            tb_author_name.DataBindings.Add("Text", viewModel, "SelectedAuthor.Name", true, DataSourceUpdateMode.OnPropertyChanged);
            rtb_description.DataBindings.Add("Text", viewModel, "SelectedAuthor.Description", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_fillter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            button.Visible = false;
            checkbox.Visible = true;
            isDelete = !isDelete;
            btn_delete_data.Visible = isDelete;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            viewModel.SaveChange("Authors");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            viewModel.Rollback("Authors");
        }

        private void btn_add_author_Click(object sender, EventArgs e)
        {
            isAdd = !isAdd;
            pane_add_author.Visible = isAdd;
            pane_modify_author.Visible = false;

            button.Visible = true;
            checkbox.Visible = false;

            btn_update.Text = "Thêm";
        }

        private void btn_delete_data_Click(object sender, EventArgs e)
        {
            viewModel.Delete("Authors", "Id");
        }

        private void AuthorManager_Load(object sender, EventArgs e)
        {
            data.DataSource = viewModel.Authors;
            dataBooks.DataSource = viewModel.Books;

            viewModel.Load();
            viewModel.AssignFillterList(combobox_fillter);

            // Thêm cột sửa
            button.Text = "Sửa";
            button.HeaderText = "Thao tác";
            button.UseColumnTextForButtonValue = true;
            data.Columns.Add(button);

            // Thêm cột xóa
            checkbox.TrueValue = true;
            checkbox.FalseValue = false;
            checkbox.HeaderText = "Xóa";
            data.Columns.Add(checkbox);

            // Xem dữ liệu
            data.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var selectedRow = data.Rows[e.RowIndex];
                    author author = new author();
                    author.Id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                    author.name = selectedRow.Cells["name"].Value.ToString();
                    author.description = selectedRow.Cells["description"].Value.ToString();
                    viewModel.SelectedAuthor = author;

                    viewModel.AuthorId = author.Id;

                    // Vì lúc mới load chưa dòng tác giả nào được chọn, nên sẽ lỗi
                    dataBooks.Columns["Id"].HeaderText = "Mã sách";
                    dataBooks.Columns["name"].HeaderText = "Tên sách";
                    dataBooks.Columns["description"].HeaderText = "Mô tả";
                    dataBooks.Columns["author_id"].Visible = false;
                }
            };

            // Khi nút hoặc checkbox được nhấn
            data.CellContentClick += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var selectedRow = data.Rows[e.RowIndex];
                    if (data.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        pane_add_author.Visible = false;
                        isUpdate = !isUpdate;
                        pane_modify_author.Visible = isUpdate;
                        // Khi cập nhật
                        SelectedIndex = e.RowIndex;
                    }

                    if (data.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        viewModel.addSelectedId(e.RowIndex, "Id");
                    }
                }
            };

            pane_add_author.Visible = isAdd;
            pane_modify_author.Visible = isUpdate;
            checkbox.Visible = false;

            btn_delete_data.Visible = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            viewModel.UpdateAuthor(Convert.ToInt32(tb_author_id.Text), tb_author_name.Text, rtb_description.Text, SelectedIndex);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            viewModel.AddAuthor(tb_name_added.Text, rtb_description_added.Text);
        }

    }
}
