using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLSach.component;
using QLSach.Controller;
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
        private BindingSource BindingSource = new BindingSource();
        private CategoryQuery CategoryQuery = new CategoryQuery();
        private int index = 0;
        CategoryNavigation navigation = new CategoryNavigation();

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
            data.DataSource = viewModel.Category;
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

                        viewModel.addPrevRows(e.RowIndex, "Id");

                        pane_modify_category.Visible = true;
                        pane_add_category.Visible = false;

                    }
                }
            };

            data.CellContentClick += (sender, e) =>
            {
                if (e.RowIndex > -1)
                {
                    var selectedRow = data.Rows[e.RowIndex];
                    if (data.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        var dataTable = (DataTable)BindingSource.DataSource;

                        viewModel.addPrevRows(e.RowIndex, "Id");
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

            Singleton.getInstance.CategoryManagerHelper.OnSave += OnSaveHandler;
            Singleton.getInstance.CategoryManagerHelper.OnCancel += OnCancelHandler;
            Singleton.getInstance.CategoryManagerHelper.OnModifyCategory += OnModifyCategoryHandler;
            Singleton.getInstance.CategoryManagerHelper.OnAddCategory += OnAddCategoryHandler;
            Singleton.getInstance.CategoryManagerHelper.OnDelete += OnDeleteHandler;

            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_fillter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void OnSaveHandler()
        {
            viewModel.SaveChange();
        }

        private void OnCancelHandler()
        {
            viewModel.Rollback();
        }

        private void OnModifyCategoryHandler()
        {
            pane_add_category.Visible = false;
            pane_modify_category.Visible = true;
        }

        private void OnAddCategoryHandler()
        {
            pane_add_category.Visible = true;
            pane_modify_category.Visible = false;
        }

        private void OnDeleteHandler()
        {
            isDeleted = !isDeleted;
            checkbox.Visible = isDeleted;
            button.Visible = !isDeleted;
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            viewModel.Search();
        }

        private void btn_delete_data_Click(object sender, EventArgs e)
        {
            viewModel.Delete();
        }
    }
}
