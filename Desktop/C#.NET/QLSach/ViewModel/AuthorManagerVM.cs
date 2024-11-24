using MoreLinq.Extensions;
using QLSach.Base;
using QLSach.component;
using QLSach.dbContext.models;
using QLSach.view.admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.ViewModel
{
    public class AuthorManagerVM : ManagerBase, INotifyPropertyChanged
    {
        private BindingSource _authors = new BindingSource();

        private author _selectedAuthor;
        public AuthorManagerVM(DataGridView data)
        {
            Authors.DataSource = Singleton.getInstance.Data.Authors.Select(o => new {o.Id, o.name, o.description}) .ToDataTable();
            SelectedAuthor = Singleton.getInstance.Data.Authors.First();
            base.data = data;
        }

        public BindingSource Authors
        {
            get => _authors;
            set { _authors = value; OnPropertyChanged(); }
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

        public author SelectedAuthor
        {
            get => _selectedAuthor;
            set { _selectedAuthor = value; OnPropertyChanged(); }
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

        // Sự kiện PropertyChanged để thông báo View cập nhật
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddAuthor(string name, string description)
        {
            var newAuthor = new author { name = name, description = description };

            DataTable dataTable = (DataTable)Authors.DataSource;
            DataRow row = dataTable.NewRow();
            row["Id"] = dataTable.Rows.Count + 2;
            row["name"] = newAuthor.name;
            row["description"] = newAuthor.description;
            dataTable.Rows.Add(row);

            Singleton.getInstance.Data.Authors.Add(newAuthor);

            MessageBox.Show("Thêm tác giả thành công");
        }

        public void UpdateAuthor(int id, string name, string description, int index)
        {
            author author = Singleton.getInstance.Data.Authors.Find(id);
            author.name = name;
            author.description = description;

            DataTable dataTable = (DataTable)Authors.DataSource;
            DataRow row = dataTable.NewRow();
            row["Id"] = author.Id;
            row["name"] = author.name;
            row["description"] = author.description;
            dataTable.Rows.Remove(dataTable.Rows[index]);
            dataTable.Rows.InsertAt(row, index);

            Singleton.getInstance.Data.Authors.Update(author);

            MessageBox.Show("Thêm tác giả thành công");
        }

        public void DeleteSelectedAuthor()
        {
            
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            base.binding = Authors;
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
                    Singleton.getInstance.Data.Authors.Remove(Singleton.getInstance.Data.Authors.Where(o => o.Id == Id).First());
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
