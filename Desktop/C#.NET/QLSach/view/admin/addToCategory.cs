using Microsoft.EntityFrameworkCore;
using MoreLinq;
using QLSach.component;
using QLSach.Controller;
using QLSach.database.models;
using QLSach.database.query;
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

        private BindingSource bindingSource = new BindingSource();
        private int category_id;

        private addTocategoryController controller;

        Dictionary<int, DataRow> prevDataRow = new Dictionary<int, DataRow>();
        private List<int> seletedIndex = new List<int>();
        private List<int> seletedCategoryId = new List<int>();

        List<int> BooksId;

        public addToCategory()
        {
            InitializeComponent();
            controller = new addTocategoryController(data, bindingSource, tb_search, combobox_fillter, checkboxAdd);
        }

        private void addToCategory_Load(object sender, EventArgs e)
        {
            Singleton.getInstance.CategoryManagerHelper.Unsubscribe();

            controller.Load();
            controller.setRollbackList(seletedIndex, seletedCategoryId);
            controller.setPrevRows(prevDataRow);
            combobox_category_name.DataSource = Singleton.getInstance.Data.Categories.ToList();
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

            BooksId = Singleton.getInstance.Data.CategoriesBook
                   .Where(o => o.CategoryId == 1)
                   .Select(o => o.BookId)
                   .ToList();

            combobox_category_name.SelectedIndexChanged += (sender, e) =>
            {
                category_id = query.getIdByName(combobox_category_name.Text);
                tb_count.Text = query.getCategoryBookCount(category_id).ToString();
                rtb_description.Text = query.getDiscriptionById(category_id).ToString();
                BooksId = Singleton.getInstance.Data.CategoriesBook
                    .Where(o => o.CategoryId == category_id)
                    .Select(o => o.BookId)
                    .ToList();
                controller.SaveCheckboxStates(checkboxAdd, BooksId);
            };

            data.CellContentClick += (sender, e) =>
            {
                if (e.RowIndex >= -1)
                {
                    var selectedItem = data.Rows[e.RowIndex];
                    var dataTable = (DataTable)bindingSource.DataSource;

                    bool isCheckedAdd = Convert.ToBoolean(selectedItem.Cells[checkboxAdd.Name].Value);
                    if (isCheckedAdd && e.RowIndex >= 0)
                    {
                        controller.addPrevRows(e.RowIndex, "Id");
                        seletedIndex.Add(e.RowIndex);
                        seletedCategoryId.Add(Convert.ToInt32(selectedItem.Cells["Id"].Value));
                    }

                    bool isCheckedDelete = Convert.ToBoolean(selectedItem.Cells[checkboxDelete.Name].Value);
                    if (isCheckedDelete && e.RowIndex >= 0)
                    {
                        controller.addPrevRows(e.RowIndex, "Id");
                        seletedIndex.Add(e.RowIndex);
                        seletedCategoryId.Add(Convert.ToInt32(selectedItem.Cells["Id"].Value));
                    }

                }
            };


            Singleton.getInstance.CategoryManagerHelper.OnSave += OnSaveHandler;
            Singleton.getInstance.CategoryManagerHelper.OnCancel += OnCancelHandler;
            Singleton.getInstance.CategoryManagerHelper.OnDelete += OnDeleteHandler;
        }

        private void OnSaveHandler()
        {
            controller.SaveChange();
        }

        private void OnCancelHandler()
        {
            controller.Rollback();
        }


        private void OnDeleteHandler()
        {
            checkboxDelete.Visible = true;
            checkboxAdd.Visible = false;

            bindingSource.DataSource = Singleton.getInstance.Data.Categories
                .Where(o => o.Id == Convert.ToInt32(combobox_category_name.SelectedValue))
                .SelectMany(o => o.Books)
                .Select(o => new { o.Id, o.name, genre = o.Genre.name, o.description })
                .ToDataTable();
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
                    CategoryBook categoryBook = new CategoryBook();
                    categoryBook.CategoryId = category_id;
                    categoryBook.BookId = Convert.ToInt32(row.Cells["Id"].Value);
                    Singleton.getInstance.Data.CategoriesBook.Add(categoryBook);
                }
            }
            MessageBox.Show($"Thêm danh mục danh mục {combobox_category_name.Text} thành công");
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = $"CONVERT({combobox_fillter.Text.Trim()}, System.String) LIKE '%{tb_search.Text.Trim()}%'";
            if (tb_search.Text == "")
            {
                bindingSource.RemoveFilter();
                controller.SaveCheckboxStates(checkboxAdd, BooksId);
            }
            controller.RestoreCheckboxStates(checkboxAdd);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            controller.Delete();
            foreach (DataGridViewRow row in data.Rows)
            {
                var resultBool = Convert.ToBoolean(row.Cells[checkboxAdd.Name].Value);
                if (row.Cells[checkboxAdd.Name].Value != null && resultBool == true)
                {
                    var BookId = Convert.ToInt32(row.Cells["Id"].Value);
                    var deletedBook = Singleton.getInstance.Data.CategoriesBook.Where(o => o.BookId == BookId).Where(o => o.CategoryId == Convert.ToInt32(combobox_category_name.SelectedValue)).First();
                    
                    Singleton.getInstance.Data.CategoriesBook.Remove(deletedBook);
                }
            }

            MessageBox.Show($"Xóa sách từ danh mục {combobox_category_name.Text} thành công");
        }
    }
}
