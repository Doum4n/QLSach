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

        public AuthorManager()
        {
            InitializeComponent();
            viewModel = new AuthorManagerVM(data);
            BindData();
        }

        private void BindData()
        {
            // Gán DataSource cho DataGridView
            data.DataSource = viewModel.Authors;

            // Gán DataBinding cho TextBox và ComboBox
            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            tb_author_id.DataBindings.Add("Text", viewModel, "SelectedAuthor.Id", true, DataSourceUpdateMode.OnPropertyChanged);
            tb_author_name.DataBindings.Add("Text", viewModel, "SelectedAuthor.Name", true, DataSourceUpdateMode.OnPropertyChanged);
            rtb_description.DataBindings.Add("Text", viewModel, "SelectedAuthor.Description", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_fillter .DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            button.Visible = false;
            checkbox.Visible = true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            viewModel.SaveChange();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            viewModel.Rollback();
        }

        private void btn_add_author_Click(object sender, EventArgs e)
        {
            pane_add_author.Visible = true;
            button.Visible = true;
            checkbox.Visible = false;

            btn.Text = "Thêm";
        }

        private void btn_delete_data_Click(object sender, EventArgs e)
        {
            viewModel.Delete();
        }

        private void AuthorManager_Load(object sender, EventArgs e)
        {
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
                }
            };

            // Khi nút hoặc checkbox được nhấn
            data.CellContentClick += (sender, e) =>
            {
                if(e.RowIndex >= 0)
                {
                    var selectedRow = data.Rows[e.RowIndex];
                    if ( data.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        btn.Text = "Cập nhật";
                        // Khi cập nhật
                        SelectedIndex = e.RowIndex;
                    }

                    if (data.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        viewModel.addPrevRows(e.RowIndex, "Id");
                    }
                }
            };
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            if (btn.Text == "Thêm")
            {
                viewModel.AddAuthor(tb_author_name.Text, rtb_description.Text);
            }
            else if (btn.Text == "Cập nhật")
            {
                viewModel.UpdateAuthor(Convert.ToInt32(tb_author_id.Text), tb_author_name.Text, rtb_description.Text, SelectedIndex);
            }
        }
    }
}
