using QLSach.component;
using QLSach.query;
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
    public partial class subPaneCategory : UserControl
    {
        private BindingSource BindingSource = new BindingSource();
        private CategoryQuery query = new CategoryQuery();
        public subPaneCategory()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            QLSach.database.models.Category category = new QLSach.database.models.Category();
            category.Name = tb_category_name.Text;
            category.Description = tb_description.Text;
            category.create_at = DateOnly.FromDateTime(DateTime.Now);
            category.update_at = DateOnly.FromDateTime(DateTime.Now);
            Singleton.getInstance.Data.Categories.Add(category);
            Singleton.getInstance.Data.SaveChanges();
            CategoryDetail categoryDetail = new CategoryDetail();
            categoryDetail = category;
            BindingSource.Add(categoryDetail);

            MessageBox.Show("Thêm danh mục thành công!");
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }

        private void subPaneCategory_Load(object sender, EventArgs e)
        {
            BindingSource.DataSource = query.GetDetail();
            data.DataSource = BindingSource;

            pane_add_category.Visible = Singleton.getInstance.AdminHelper.isPaneAdd;
            pane_modify_category.Visible = Singleton.getInstance.AdminHelper.isPaneModify;

            data.CellClick += (sender, e) =>
            {
                if (e.RowIndex > -1)
                {
                    var selectedRow = data.Rows[e.RowIndex];

                    tb_category_id.Text = selectedRow.Cells["Id"].Value.ToString();
                    rtb_descripton.Text = selectedRow.Cells["Description"].Value.ToString();
                    tb_categoryName.Text = selectedRow.Cells["Name"].Value.ToString();
                    tb_books_amount.Text = selectedRow.Cells["BookCount"].Value.ToString();
                }
            };
        }
    }
}
