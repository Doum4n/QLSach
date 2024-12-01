using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLSach.component;
using QLSach.database.models;
using QLSach.database.query;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLSach.view.admin
{
    public partial class MainPaneCategory : UserControl
    {
        private CategoryQuery CategoryQuery = new CategoryQuery();
        private int index = 0;

        DataGridViewButtonColumn button = new DataGridViewButtonColumn();

        private bool isDeleted = false;

        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();

        private CategoryManagerVM viewModel;

        public MainPaneCategory()
        {
            InitializeComponent();
            viewModel = new CategoryManagerVM(data);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            viewModel.AddCategory(tb_category_name.Text, tb_description.Text);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            viewModel.updateCategory(
                Convert.ToInt32(tb_category_id.Text),
                tb_categoryName.Text,
                rtb_descripton.Text,
                Convert.ToInt32(tb_books_amount.Text),
                DateOnly.Parse(data.Rows[index].Cells["create_at"].Value.ToString()),
                index
            );
        }

        private void CategoryMainPane_Load(object sender, EventArgs e)
        {
            data.DataSource = viewModel.Categories;
            dataBooks.DataSource = viewModel.Books;

            viewModel.Load();
            viewModel.AssignFillterList(combobox_fillter);

            data.CellClick += (sender, e) =>
            {
                if (e.RowIndex > -1)
                {
                    var selectedRow = data.Rows[e.RowIndex];
                    if (data.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        index = e.RowIndex;
                        tb_category_id.Text = selectedRow.Cells["Id"].Value.ToString();
                        rtb_descripton.Text = selectedRow.Cells["Description"].Value.ToString();
                        tb_categoryName.Text = selectedRow.Cells["Name"].Value.ToString();
                        tb_books_amount.Text = selectedRow.Cells["BookCount"].Value.ToString();

                        viewModel.addSelectedId(e.RowIndex, "Id");

                        pane_modify_category.Visible = true;
                        pane_add_category.Visible = false;
                    }
                    viewModel.Id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    dataBooks.Columns["Id"].HeaderText = "Mã sách";
                    dataBooks.Columns["name"].HeaderText = "Tên sách";
                    dataBooks.Columns["description"].HeaderText = "Mô tả";
                }
            };

            data.CellContentClick += (sender, e) =>
            {
                if (e.RowIndex > -1)
                {
                    var selectedRow = data.Rows[e.RowIndex];
                    if (data.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        viewModel.addSelectedId(e.RowIndex, "Id");
                    }
                }
            };

            pane_add_category.Visible = true;
            pane_modify_category.Visible = false;

            button.HeaderText = "Thao tác";
            button.UseColumnTextForButtonValue = true;
            button.Text = "Sửa";

            data.Columns.Add(button);

            checkbox.HeaderText = "Xóa";
            checkbox.TrueValue = true;
            checkbox.FalseValue = false;
            data.Columns.Add(checkbox);

            checkbox.Visible = isDeleted;

            tb_books_amount.Enabled = false;

            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_fillter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            viewModel.Search();
        }

        private void btn_delete_data_Click(object sender, EventArgs e)
        {
            viewModel.Delete("Categories", "Id");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            viewModel.SaveChange("Categories");
        }

        private void btn_addPaneAdd_Click(object sender, EventArgs e)
        {
            pane_add_category.Visible = true;
            pane_modify_category.Visible = false;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            isDeleted = !isDeleted;
            checkbox.Visible = isDeleted;
            button.Visible = !isDeleted;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            viewModel.Rollback("Categories");
        }
    }
}
