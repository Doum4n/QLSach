using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using QLSach.component;
using QLSach.controllers;
using QLSach.database.models;
using QLSach.query;

namespace QLSach.view.admin
{
    public partial class addToCategory : UserControl
    {
        private CategoryQuery query = new CategoryQuery();
        private BookQuery bookQuery = new BookQuery();
        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
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

            data.DataSource = Singleton.getInstance.Data.Books.Include(o => o.Genre).Select(o => new { o.Id, o.name, genre = o.Genre.name, o.description }).ToList();
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
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in data.Rows)
            {
                if(row.Cells[checkbox.Name].Value != null)
                {
                    var value = row.Cells[checkbox.Name].Value;
                    bool isChecked = value != null && (bool)value;
                    CategoryBook categoryBook = new CategoryBook();
                    categoryBook.CategoryId = category_id;
                    categoryBook.BookId = (int)row.Cells["Id"].Value;
                    Singleton.getInstance.Data.CategoriesBook.Add(categoryBook);
                    Singleton.getInstance.Data.SaveChanges();

                    MessageBox.Show($"Thêm vào danh mục {combobox_category_name.Text} thành công");
                }
            }
        }
    }
}
