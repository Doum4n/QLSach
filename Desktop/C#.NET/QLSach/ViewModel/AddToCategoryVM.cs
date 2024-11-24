using Guna.UI2.AnimatorNS;
using MoreLinq;
using QLSach.Base;
using QLSach.component;
using QLSach.database.models;
using QLSach.database.query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.ViewModel
{
    public class AddToCategoryVM : ManagerBase, INotifyPropertyChanged
    {
        private BindingSource _bookCategory = new BindingSource();
        private string _categoryName;

        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();

        public AddToCategoryVM(DataGridView data, DataGridViewCheckBoxColumn checkbox)
        {
            BookCategory.DataSource = Singleton.getInstance.Data.Books.Select(o => new { o.Id, o.name, genre = o.Genre.name, o.description }).ToDataTable();
            base.data = data;
            this.checkbox = checkbox;
        }

        public BindingSource BookCategory
        {
            get => _bookCategory;
            set { _bookCategory = value; OnPropertyChanged(); }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                base.Search();
            }
        }

        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                OnPropertyChanged();
            }
        }

        public string SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                if (_selectedFilter != value)
                {
                    _selectedFilter = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public void AddBookToCategory(string name, string description)
        //{
        //    foreach (DataGridViewRow row in data.Rows)
        //    {
        //        var resultBool = Convert.ToBoolean(row.Cells[checkboxAdd.Name].Value);
        //        if (row.Cells[checkboxAdd.Name].Value != null && resultBool == true)
        //        {
        //            var value = row.Cells[checkboxAdd.Name].Value;
        //            bool isChecked = value != null && (bool)value;
        //            CategoryBook categoryBook = new CategoryBook();
        //            categoryBook.CategoryId = category_id;
        //            categoryBook.BookId = Convert.ToInt32(row.Cells["Id"].Value);
        //            Singleton.getInstance.Data.CategoriesBook.Add(categoryBook);
        //        }
        //    }
        //    MessageBox.Show($"Thêm danh mục danh mục {combobox_category_name.Text} thành công");
        //}

        public void updateCategory(int id, string name, string description, int bookCount, DateOnly create_at, int index)
        {
            
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            base.binding = BookCategory;

            checkbox.HeaderText = "Thêm";
            checkbox.FalseValue = false;
            checkbox.TrueValue = true;

            data.Columns.Add(checkbox);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            var DataTable = (DataTable)binding.DataSource;

            foreach (int index in prevDataRow.Keys)
            {
                DataTable.Rows.RemoveAt(index);
            }
            foreach (int Id in seletedId)
            {
                try
                {
                    Singleton.getInstance.Data.Categories.Remove(Singleton.getInstance.Data.Categories.Where(o => o.Id == Id).First());
                }
                catch
                {
                    //MessageBox.Show();
                }
            }
            MessageBox.Show("Xóa dữ liệu thành công");

            seletedIndex.Clear();
            seletedId.Clear();
        }

        public void Ondeletehandler(int id)
        {
            binding.DataSource = Singleton.getInstance.Data.Categories
             .Where(o => o.Id == id)
             .SelectMany(o => o.Books)
             .Select(o => new { o.Id, o.name, genre = o.Genre.name, o.description })
             .ToDataTable();
        }

        public new void Search(List<int> BooksId)
        {
            binding.Filter = $"CONVERT({_selectedFilter}, System.String) LIKE '%{_searchText}%'";
            if (_searchText == "")
            {
                binding.RemoveFilter();
                SaveCheckboxStates(checkbox, BooksId);
            }
            RestoreCheckboxStates(checkbox);
        }
    }
}
