using MoreLinq;
using QLSach.component;
using QLSach.database.models;
using QLSach.query;
using System.Data;
using System.Windows.Forms;

namespace QLSach.view.admin
{
    public partial class subPaneCategory : UserControl
    {
        private BindingSource BindingSource = new BindingSource();
        private CategoryQuery CategoryQuery = new CategoryQuery();
        private int index = 0;
        public subPaneCategory()
        {
            InitializeComponent();
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
            Singleton.getInstance.Data.SaveChanges();

            DataTable categoryDataTable = (DataTable)BindingSource.DataSource;

            DataRow newRow = categoryDataTable.NewRow();
            newRow["Id"] = category.Id;
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
            Category category = CategoryQuery.GetCategoryById(int.Parse(tb_category_id.Text));
            category.Name = tb_categoryName.Text;
            category.Description = rtb_descripton.Text;
            category.update_at = DateOnly.FromDateTime(DateTime.Now);

            Singleton.getInstance.Data.Categories.Update(category);
            Singleton.getInstance.Data.SaveChanges();

            DataTable categoryDataTable = (DataTable)BindingSource.DataSource;

            DataRow newRow = categoryDataTable.NewRow();
            newRow["Id"] = category.Id;
            newRow["Name"] = category.Name;
            newRow["Description"] = category.Description;
            newRow["BookCount"] = 0;
            newRow["create_at"] = category.create_at;
            newRow["update_at"] = category.update_at;


            categoryDataTable.Rows.RemoveAt(index);
            categoryDataTable.Rows.InsertAt(newRow, index);

            MessageBox.Show("Cập nhật danh mục thành công!");
        }

        private void subPaneCategory_Load(object sender, EventArgs e)
        {
            BindingSource.DataSource = CategoryQuery.GetDetail().ToDataTable();
            data.DataSource = BindingSource;

            pane_add_category.Visible = Singleton.getInstance.AdminHelper.isPaneAdd;
            pane_modify_category.Visible = Singleton.getInstance.AdminHelper.isPaneModify;

            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.HeaderText = "Thao tác";
            button.UseColumnTextForButtonValue = true;
            button.Text = "Sửa";

            data.Columns.Add(button);

            data.CellClick += (sender, e) =>
            {
                if (e.RowIndex > -1)
                {
                    var selectedRow = data.Rows[e.RowIndex];
                    if (data.Columns[e.ColumnIndex].Name == button.Name)
                    {
                        index = e.RowIndex;
                        Singleton.getInstance.AdminHelper.isPaneAdd = false;
                        Singleton.getInstance.AdminHelper.isPaneModify = true;
                        pane_add_category.Visible = Singleton.getInstance.AdminHelper.isPaneAdd;
                        pane_modify_category.Visible = Singleton.getInstance.AdminHelper.isPaneModify;
                        tb_category_id.Text = selectedRow.Cells["Id"].Value.ToString();
                        rtb_descripton.Text = selectedRow.Cells["Description"].Value.ToString();
                        tb_categoryName.Text = selectedRow.Cells["Name"].Value.ToString();
                        tb_books_amount.Text = selectedRow.Cells["BookCount"].Value.ToString();
                    }
                }
            };

            List<string> columnNames = new List<string>();

            foreach (DataGridViewColumn column in data.Columns)
            {
                columnNames.Add(column.HeaderText);
            }

            combobox_fillter.DataSource = columnNames;
        }

        private void onVisible(object sender, EventArgs e)
        {

            List<string> columnNames = new List<string>();

            foreach (DataGridViewColumn column in data.Columns)
            {
                columnNames.Add(column.HeaderText);
            }
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            BindingSource.Filter = $"CONVERT({combobox_fillter.Text.Trim()}, System.String) LIKE '%{tb_search.Text.Trim()}%'";
            if (tb_search.Text == "")
            {
                BindingSource.RemoveFilter();
            }
        }

    }
}
