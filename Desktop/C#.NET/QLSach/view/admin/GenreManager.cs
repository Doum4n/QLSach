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
    public partial class GenreManager : UserControl
    {
        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
        private GenreManagerVM viewModel;

        public GenreManager()
        {
            InitializeComponent();
            viewModel = new GenreManagerVM(data);
            BindData();
        }

        private void GenreManager_Load(object sender, EventArgs e)
        {
            data.DataSource = viewModel.Genres;
            dataBook.DataSource = viewModel.Books;

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
                    viewModel.addSelectedId(e.RowIndex, "id");

                }

            };

            data.CellClick += (sender, e) =>
            {
                var selectedRow = data.Rows[e.RowIndex];
                viewModel.Id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                dataBook.Columns["Id"].HeaderText = "Mã sách";
                dataBook.Columns["name"].HeaderText = "Tên sách";
                dataBook.Columns["description"].HeaderText = "Mô tả";
                dataBook.Columns["genre_id"].Visible = false;
            };
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
            viewModel.Rollback("Genres");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            viewModel.SaveChange("Genres");
        }

        private void btn_add_genre_Click(object sender, EventArgs e)
        {
            MessageBox.Show((Convert.ToInt32(data.Rows[data.RowCount - 2].Cells["id"].Value) + 1).ToString());
            viewModel.addGenre(tb_genre_name.Text);
        }

        private void btn_delete_data_Click(object sender, EventArgs e)
        {
            viewModel.Delete("Genres", "id");
        }
    }
}
