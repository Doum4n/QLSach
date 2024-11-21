using Microsoft.EntityFrameworkCore;
using MoreLinq;
using QLSach.component;
using QLSach.database.models;
using QLSach.database.query;

namespace QLSach.view.admin
{
    public partial class addToCategory : UserControl
    {
        private CategoryQuery query = new CategoryQuery();
        private BookQuery bookQuery = new BookQuery();
        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();

        private BindingSource bindingSource = new BindingSource();
        private int category_id;
        public addToCategory()
        {
            InitializeComponent();
        }

        private void addToCategory_Load(object sender, EventArgs e)
        {
            List<Category> categories = query.getCategories();
            combobox_category_name.DataSource = categories.Select(c => c.Name).ToList();

            combobox_category_name.SelectedIndexChanged += (sender, e) =>
            {
                category_id = query.getIdByName(combobox_category_name.Text);
                tb_count.Text = query.getCategoryBookCount(category_id).ToString();
                rtb_description.Text = query.getDiscriptionById(category_id).ToString();
            };

            bindingSource.DataSource = Singleton.getInstance.Data.Books.Include(o => o.Genre).Select(o => new { o.Id, o.name, genre = o.Genre.name, o.description }).ToDataTable();
            data.DataSource = bindingSource;
            checkbox.HeaderText = "Thêm";
            checkbox.FalseValue = false;
            checkbox.TrueValue = true;

            data.Columns.Add(checkbox);

            data.CellContentClick += (sender, e) =>
            {
                if (e.RowIndex >= -1)
                {
                    var selectedItem = data.Rows[e.RowIndex];
                    bool isChecked = Convert.ToBoolean(selectedItem.Cells[checkbox.Name].Value);
                    if (isChecked && e.RowIndex >= 0)
                    {
                        MessageBox.Show("Checkbox đã chọn");
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Cells[checkbox.Name].Value != null)
                {
                    var value = row.Cells[checkbox.Name].Value;
                    bool isChecked = value != null && (bool)value;
                    CategoryBook categoryBook = new CategoryBook();
                    categoryBook.CategoryId = category_id;
                    categoryBook.BookId =  Convert.ToInt32(row.Cells["Id"].Value);
                    Singleton.getInstance.Data.CategoriesBook.Add(categoryBook);
                    Singleton.getInstance.Data.SaveChanges();

                    MessageBox.Show($"Thêm vào danh mục {combobox_category_name.Text} thành công");
                }
            }
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
            bindingSource.Filter = $"CONVERT({combobox_fillter.Text.Trim()}, System.String) LIKE '%{tb_search.Text.Trim()}%'";
            if (tb_search.Text == "")
            {
                bindingSource.RemoveFilter();
            }
        }
    }
}
