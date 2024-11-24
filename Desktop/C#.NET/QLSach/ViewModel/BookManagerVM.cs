using MoreLinq.Extensions;
using QLSach.Base;
using QLSach.component;
using QLSach.dbContext.models;
using QLSach.view.components.items;
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
    public class BookManagerVM : ManagerBase, INotifyPropertyChanged
    {
        private BindingSource _books = new BindingSource();

        private Book _selectedBook;
        public BookManagerVM(DataGridView data)
        {
            Books.DataSource = Singleton.getInstance.Data.Books
               .Select(o => new
               {
                   o.Id,
                   o.name,
                   o.description,
                   o.public_at,
                   o.author_id,
                   o.genre_id,
                   o.rating,
                   o.views,
                   AuthorName = o.author.name,
                   GenreName = o.Genre.name,
                   o.quantity,
                   o.remaining,
                   o.status,
                   o.created_at,
                   o.updated_at,
               }).ToDataTable();


            SelectedAuthor = Singleton.getInstance.Data.Books.First();
            base.data = data;
        }

        public BindingSource Books
        {
            get => _books;
            set { _books = value; OnPropertyChanged(); }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterAuthors();
            }
        }

        public Book SelectedAuthor
        {
            get => _selectedBook;
            set { _selectedBook = value; OnPropertyChanged(); }
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

        public void AddAuthor(Book book)
        {
            DataTable dataTable = (DataTable)Books.DataSource;
            DataRow row = dataTable.NewRow();
            row["Id"] = book.Id;
            row["name"] = book.name;
            row["description"] = book.description;
            row["author_id"] = book.author_id;
            row["public_at"] = book.public_at;
            row["genre_id"] = book.genre_id;
            row["quantity"] = book.quantity;
            row["remaining"] = book.remaining;
            row["rating"] = book.rating;
            row["views"] = book.views;
            row["created_at"] = book.created_at;
            row["updated_at"] = book.updated_at;
            row["status"] = book.status;
            dataTable.Rows.Add(row);

            Singleton.getInstance.Data.Books.Add(book);

            MessageBox.Show("Thêm sách thành công");
        }

        public void UpdateBook(Book book, int index)
        { 
            DataTable dataTable = (DataTable)Books.DataSource;
            DataRow row = dataTable.NewRow();
            row["Id"] = book.Id;
            row["name"] = book.name;
            row["description"] = book.description;
            row["author_id"] = book.author_id;
            row["public_at"] = book.public_at;
            row["genre_id"] = book.genre_id;
            row["quantity"] = book.quantity;
            row["remaining"] = book.remaining;
            row["rating"] = book.rating;
            row["views"] = book.views;
            row["created_at"] = book.created_at;
            row["updated_at"] = book.updated_at;
            row["status"] = book.status;
            dataTable.Rows.Remove(dataTable.Rows[index]);
            dataTable.Rows.InsertAt(row, index);

            Singleton.getInstance.Data.Books.Update(book);

            MessageBox.Show("Cập nhật sách thành công");
        }

        public void DeleteSelectedAuthor()
        {

        }

        private void FilterAuthors()
        {
            Books.Filter = $"CONVERT({SelectedFilter}, System.String) LIKE '%{SearchText}%'";
            if (SearchText == "")
            {
                Books.RemoveFilter();
            }
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            base.binding = Books;

            data.Columns["Id"].HeaderText = "Mã sách";
            data.Columns["name"].HeaderText = "Tên sách";
            data.Columns["description"].HeaderText = "Mô tả";
            data.Columns["public_at"].HeaderText = "Ngày phát hành";
            data.Columns["AuthorName"].HeaderText = "Tên tác giả";
            data.Columns["GenreName"].HeaderText = "Tên thể loại";
            data.Columns["rating"].HeaderText = "Đánh giá";
            data.Columns["views"].HeaderText = "Lược xem";
            data.Columns["quantity"].HeaderText = "Số lượng đã nhập";
            data.Columns["remaining"].HeaderText = "Số lượng còn lại";
            data.Columns["status"].HeaderText = "Trạng thái";
            data.Columns["created_at"].HeaderText = "Ngày nhập";
            data.Columns["updated_at"].HeaderText = "Ngày cập nhật";

            data.Columns["genre_id"].Visible = false;
            data.Columns["author_id"].Visible = false;
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
                    Singleton.getInstance.Data.Books.Remove(Singleton.getInstance.Data.Books.Where(o => o.Id == Id).First());
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
