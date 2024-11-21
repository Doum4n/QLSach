using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLSach.component;
using QLSach.Controller;
using QLSach.database.models;
using QLSach.database.query;
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
        private CategoryManagerController controller;
        CategoryNavigation navigation = new CategoryNavigation();
        Dictionary<int, DataRow> prevDataRow = new Dictionary<int, DataRow>();
        private List<int> seletedIndex = new List<int>();
        private List<int> seletedCategoryId = new List<int>();

        private bool isDeleted = false;

        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();

        public MainPaneCategory()
        {
            InitializeComponent();
            controller = new CategoryManagerController(BindingSource, data, tb_search, combobox_fillter);

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Category category = new Category(
                tb_category_name.Text,
                tb_description.Text,
                DateOnly.FromDateTime(DateTime.Now),
                DateOnly.FromDateTime(DateTime.Now)

            );

            Singleton.getInstance.Data.Categories.Add(category);

            DataTable categoryDataTable = (DataTable)BindingSource.DataSource;

            DataRow newRow = categoryDataTable.NewRow();
            newRow["Id"] = categoryDataTable.Rows.Count + 1;
            newRow["Name"] = category.Name;
            newRow["Description"] = category.Description;
            newRow["BookCount"] = 0;
            newRow["create_at"] = category.create_at;
            newRow["update_at"] = category.update_at;

            categoryDataTable.Rows.Add(newRow);

            MessageBox.Show("Thêm danh mục thành công!");
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }

        private void CategoryMainPane_Load(object sender, EventArgs e)
        {
            controller.Load();
            controller.setPrevRows(prevDataRow);
            controller.setRollbackList(seletedIndex, seletedCategoryId);

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

                        var dataTable = (DataTable)BindingSource.DataSource;

                        btn_update.Click += (sender, ev) =>
                        {
                            Update(selectedRow, dataTable);
                            controller.addPrevRows(e.RowIndex, dataTable.Rows[e.RowIndex]);
                        };

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

                        seletedCategoryId.Add(Convert.ToInt32(selectedRow.Cells["Id"].Value));

                        controller.addPrevRows(e.RowIndex, dataTable.Rows[e.RowIndex]);
                        seletedIndex.Add(e.RowIndex);
                    }
                }
            };

            pane_add_category.Visible = true;
            pane_modify_category.Visible = false;


            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
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

            Singleton.getInstance.CategoryManagerHelper.OnSave += () =>
            {
                controller.SaveChange();
            };

            Singleton.getInstance.CategoryManagerHelper.OnCancel += () =>
            {
                controller.Rollback();
            };

            Singleton.getInstance.CategoryManagerHelper.OnModifyCategory += () =>
            {
                pane_add_category.Visible = false;
                pane_modify_category.Visible = true;
            };

            Singleton.getInstance.CategoryManagerHelper.OnAddCategory += () =>
            {
                //controller.SaveChange();
                pane_add_category.Visible = true;
                pane_modify_category.Visible = false;
            };

            Singleton.getInstance.CategoryManagerHelper.OnDelete += () =>
            {
                isDeleted = !isDeleted;
                checkbox.Visible = isDeleted;
                button.Visible = !isDeleted;
            };
        }

        private void Update(DataGridViewRow selectedRow, DataTable dataTable)
        {
            Category category = CategoryQuery.GetCategoryById(int.Parse(tb_category_id.Text));
            category.Name = tb_categoryName.Text;
            category.Description = rtb_descripton.Text;
            category.update_at = DateOnly.FromDateTime(DateTime.Now);
            Singleton.getInstance.Data.Categories.Update(category);
            DataTable categoryDataTable = (DataTable)BindingSource.DataSource;

            DataRow newRow = dataTable.NewRow();
            newRow["Id"] = tb_category_id.Text;
            newRow["Name"] = tb_categoryName.Text;
            newRow["Description"] = rtb_descripton.Text;
            newRow["BookCount"] = tb_books_amount.Text;
            newRow["create_at"] = DateOnly.Parse(selectedRow.Cells["create_at"].Value.ToString());
            newRow["update_at"] = DateOnly.FromDateTime(DateTime.Now);

            dataTable.Rows.RemoveAt(index);
            dataTable.Rows.InsertAt(newRow, index);

            MessageBox.Show("Thay đổi dữ liệu thành công");
        }

        private void onVisible(object sender, EventArgs e)
        {

            //List<string> columnNames = new List<string>();

            //foreach (DataGridViewColumn column in data.Columns)
            //{
            //    columnNames.Add(column.HeaderText);
            //}
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            BindingSource.Filter = $"CONVERT({combobox_fillter.Text.Trim()}, System.String) LIKE '%{tb_search.Text.Trim()}%'";
            if (tb_search.Text == "")
            {
                BindingSource.RemoveFilter();
            }
        }

        private void btn_delete_data_Click(object sender, EventArgs e)
        {
            controller.Delete();
        }
    }
}
