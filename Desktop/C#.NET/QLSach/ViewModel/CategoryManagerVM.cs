using Guna.UI2.WinForms.Suite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

namespace QLSach.ViewModel
{
    public class CategoryManagerVM : ManagerBase, INotifyPropertyChanged
    {
        private CategoryQuery CategoryQuery = new CategoryQuery();

        private BindingSource _categories = new BindingSource();

        public CategoryManagerVM(DataGridView data)
        {
            Category.DataSource = CategoryQuery.GetDetail().ToDataTable();
            base.data = data;
        }

        public BindingSource Category
        {
            get => _categories;
            set { _categories = value; OnPropertyChanged(); }
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

        public void AddCategory(string name, string description)
        {
            Category category = new Category();
            category.Name = name;
            category.Description = description;
            category.create_at = DateOnly.FromDateTime(DateTime.Now);
            category.update_at = DateOnly.FromDateTime(DateTime.Now);
            Singleton.getInstance.Data.Categories.Update(category);

            DataTable dataTable = (DataTable)Category.DataSource;

            DataRow newRow = dataTable.NewRow();
            newRow["Id"] = dataTable.Rows.Count + 2;
            newRow["Name"] = name;
            newRow["Description"] = description;
            newRow["BookCount"] = 0;
            newRow["create_at"] = DateOnly.FromDateTime(DateTime.Now);
            newRow["update_at"] = DateOnly.FromDateTime(DateTime.Now);

            dataTable.Rows.Add(newRow);

            MessageBox.Show("Thêm danh mục thành công liệu thành công");
        }

        public void updateCategory(int id, string name, string description, int bookCount, DateOnly create_at, int index)
        {
            Category category = CategoryQuery.GetCategoryById((id));
            category.Name = name;
            category.Description = description;
            category.update_at = DateOnly.FromDateTime(DateTime.Now);
            Singleton.getInstance.Data.Categories.Update(category);

            DataTable dataTable = (DataTable)Category.DataSource;

            DataRow newRow = dataTable.NewRow();
            newRow["Id"] = id;
            newRow["Name"] = name;
            newRow["Description"] = description;
            newRow["BookCount"] = bookCount;
            newRow["create_at"] = create_at;
            newRow["update_at"] = DateOnly.FromDateTime(DateTime.Now);

            dataTable.Rows.RemoveAt(index);
            dataTable.Rows.InsertAt(newRow, index);

            MessageBox.Show("Thay đổi dữ liệu thành công");
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            base.binding = Category;
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
    }
}
