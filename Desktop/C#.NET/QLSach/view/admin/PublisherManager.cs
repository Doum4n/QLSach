using QLSach.ViewModel;
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
    public partial class PublisherManager : UserControl
    {
        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
        private PublisherManagerVM viewModel;

        public PublisherManager()
        {
            InitializeComponent();
            viewModel = new PublisherManagerVM(data);
            BindData();
        }

        private void GenreManager_Load(object sender, EventArgs e)
        {
        }

        private void BindData()
        {


            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_fillter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pane_add.Visible = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            checkbox.Visible = true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            viewModel.Rollback("Publishers");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            viewModel.SaveChange("Publishers");
        }

        private void btn_add_genre_Click(object sender, EventArgs e)
        {
            MessageBox.Show((Convert.ToInt32(data.Rows[data.RowCount - 2].Cells["Id"].Value) + 1).ToString());
            viewModel.addPublisher(tb_publisher_name.Text);
        }

        private void btn_delete_data_Click(object sender, EventArgs e)
        {
            viewModel.Delete("Publishers", "Id");
        }

        private void PublisherManager_Load(object sender, EventArgs e)
        {
            data.DataSource = viewModel.Publishers;
            dataBooks.DataSource = viewModel.Books;

            viewModel.Load();
            viewModel.AssignFillterList(combobox_fillter);

            pane_add.Visible = false;

            checkbox.HeaderText = "Xóa";
            checkbox.Visible = false;
            checkbox.FalseValue = false;
            checkbox.TrueValue = true;
            data.Columns.Add(checkbox);

            data.CellContentClick += (sender, e) =>
            {
                var selectedRow = data.Rows[e.RowIndex];
                if (data.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    viewModel.addSelectedId(e.RowIndex, "Id");
                    viewModel.PublisherId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                }
            };

            data.CellClick += (sender, e) =>
            {
                var selectedRow = data.Rows[e.RowIndex];
                viewModel.PublisherId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                dataBooks.Columns["Id"].HeaderText = "Mã sách";
                dataBooks.Columns["name"].HeaderText = "Tên sách";
                dataBooks.Columns["description"].HeaderText = "Mô tả";
                dataBooks.Columns["publisher_id"].Visible = false;
            };
        }
    }
}
