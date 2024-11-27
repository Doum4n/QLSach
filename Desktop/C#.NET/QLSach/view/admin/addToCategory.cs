using Microsoft.EntityFrameworkCore;
using MoreLinq;
using QLSach.component;
using QLSach.database;
using QLSach.database.models;
using QLSach.database.query;
using QLSach.ViewModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace QLSach.view.admin
{
    public partial class addToCategory : UserControl
    {
        private CategoryQuery query = new CategoryQuery();
        private BookQuery bookQuery = new BookQuery();
        DataGridViewCheckBoxColumn checkboxAdd = new DataGridViewCheckBoxColumn();
        DataGridViewCheckBoxColumn checkboxDelete = new DataGridViewCheckBoxColumn();

        private int category_id;

        private AddToCategoryVM viewModel;

        private readonly Context context = new Context();

        List<int> BooksId;

        public addToCategory()
        {
            InitializeComponent();
            viewModel = new AddToCategoryVM(data);
        }

        private void addToCategory_Load(object sender, EventArgs e)
        {

            Singleton.getInstance.CategoryManagerHelper.Unsubscribe();

            data.DataSource = viewModel.BookCategory;
            viewModel.Load();
            viewModel.AssignFillterList(combobox_fillter);

            combobox_category_name.DataSource = context.Categories.ToList();
            combobox_category_name.DisplayMember = "Name";
            combobox_category_name.ValueMember = "Id";


            List<Columns> columnNames = new List<Columns>();

            foreach (DataGridViewColumn column in data.Columns)
            {
                columnNames.Add(new Columns(column.HeaderText, column.Name));
            }

            combobox_fillter.DataSource = columnNames;
            combobox_fillter.DisplayMember = "Headertext";
            combobox_fillter.ValueMember = "Name";

            checkboxDelete.HeaderText = "Xóa";
            checkboxDelete.Visible = false;
            data.Columns.Add(checkboxDelete);

            BooksId = context.CategoriesBook
                   .Where(o => o.CategoryId == 1)
                   .Select(o => o.BookId)
                   .ToList();

            combobox_category_name.SelectedIndexChanged += (sender, e) =>
            {
                category_id = query.getIdByName(combobox_category_name.Text);
                tb_count.Text = query.getCategoryBookCount(category_id).ToString();
                rtb_description.Text = query.getDiscriptionById(category_id).ToString();
                BooksId = context.CategoriesBook
                    .Where(o => o.CategoryId == category_id)
                    .Select(o => o.BookId)
                    .ToList();
                viewModel.SaveCheckboxStates(checkboxAdd, BooksId);
            };

            data.CellContentClick += (sender, e) =>
            {
                if (e.RowIndex >= -1)
                {
                    var selectedItem = data.Rows[e.RowIndex];

                    bool isCheckedAdd = Convert.ToBoolean(selectedItem.Cells[checkboxAdd.Name].Value);
                    if (isCheckedAdd && e.RowIndex >= 0)
                    {
                        viewModel.addSelectedId(e.RowIndex, "Id");
                    }

                    bool isCheckedDelete = Convert.ToBoolean(selectedItem.Cells[checkboxDelete.Name].Value);
                    if (isCheckedDelete && e.RowIndex >= 0)
                    {
                        viewModel.addSelectedId(e.RowIndex, "Id");

                    }

                }
            };

            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_fillter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in data.Rows)
            {
                var resultBool = Convert.ToBoolean(row.Cells[checkboxAdd.Name].Value);
                if (row.Cells[checkboxAdd.Name].Value != null && resultBool == true)
                {
                    var value = row.Cells[checkboxAdd.Name].Value;
                    bool isChecked = value != null && (bool)value;
                    if (isChecked)
                    {
                        CategoryBook categoryBook = new CategoryBook();
                        categoryBook.CategoryId = Convert.ToInt32(combobox_category_name.SelectedValue);
                        categoryBook.BookId = Convert.ToInt32(row.Cells["Id"].Value);
                        context.CategoriesBook.Add(categoryBook);
                    }

                }
            }
            MessageBox.Show($"Thêm danh mục danh mục {combobox_category_name.Text} thành công");
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            viewModel.Search();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in data.Rows)
            {
                var resultBool = Convert.ToBoolean(row.Cells[checkboxAdd.Name].Value);
                if (row.Cells[checkboxAdd.Name].Value != null && resultBool == true)
                {
                    var BookId = Convert.ToInt32(row.Cells["Id"].Value);
                    var deletedBook = context.CategoriesBook.Where(o => o.BookId == BookId).Where(o => o.CategoryId == Convert.ToInt32(combobox_category_name.SelectedValue)).First();

                    context.CategoriesBook.Remove(deletedBook);
                }
            }

            MessageBox.Show($"Xóa sách từ danh mục {combobox_category_name.Text} thành công");

        }

        private void btn_deletePane_Click(object sender, EventArgs e)
        {
            viewModel.Ondeletehandler(Convert.ToInt32(combobox_category_name.SelectedValue));
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            viewModel.Rollback("Categories");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }
    }
}
