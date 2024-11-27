using Guna.UI2.AnimatorNS;
using MoreLinq;
using MySqlConnector;
using QLSach.Base;
using QLSach.component;
using QLSach.database;
using QLSach.database.models;
using QLSach.database.query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace QLSach.ViewModel
{
    public class AddToCategoryVM : ManagerBase, INotifyPropertyChanged
    {
        private BindingSource _bookCategory = new BindingSource();
        private string _categoryName;
        DataTable booksDataTable;
        private MySqlDataAdapter adapter = new MySqlDataAdapter();
        private MySqlConnection connection = new MySqlConnection(Singleton.getInstance.connectionString);

        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();

        public AddToCategoryVM(DataGridView data)
        {
            connection.Open();

            booksDataTable = (DataTable)BookCategory.DataSource;

            using (var context = new Context())
            {
                BookCategory.DataSource = context.Books.Select(o => new { o.Id, o.name, genre = o.Genre.name, o.description }).ToDataTable();
                base.data = data;
            }

            Configuration();
        }
        private void Configuration()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Categories", connection);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
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

        //public override void Delete()
        //{
        //    booksDataTable.AcceptChanges();

        //    foreach (int index in prevDataRow.Keys)
        //    {
        //        Singleton.getInstance.DataSet.Tables["Books"].Rows[index].Delete();

        //    }
        //    adapter.Update(Singleton.getInstance.DataSet, "Books");

        //    MessageBox.Show("Xóa sách thành công");
        //}

        public void Ondeletehandler(int id)
        {
            using (var context = new Context())
                binding.DataSource = context.Categories
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
