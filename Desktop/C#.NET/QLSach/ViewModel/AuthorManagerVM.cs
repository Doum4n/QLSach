using Bogus;
using MoreLinq;
using MySqlConnector;
using QLSach.Base;
using QLSach.component;
using QLSach.database;
using QLSach.database.models;
using QLSach.dbContext.models;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using TheArtOfDevHtmlRenderer.Adapters;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace QLSach.ViewModel
{
    public class AuthorManagerVM : ManagerBase, INotifyPropertyChanged
    {
        private BindingSource _authors = new BindingSource();
        public BindingSource Books = new BindingSource();

        private int _author;
        public int AuthorId { get { return _author; } set { _author = value; LoadData(); } }

        DataTable authorsDataTable;
        private author _selectedAuthor;
        public AuthorManagerVM(DataGridView data) : base(data)
        {
            Authors.DataSource = context.Authors.Select(o => new { o.Id, o.name, o.description }).ToDataTable();
            SelectedAuthor = context.Authors.First();
            authorsDataTable = (DataTable)Authors.DataSource;
            authorsDataTable.AcceptChanges();

            // Gán tên cho DataTable trước khi thêm vào DataSet
            authorsDataTable.TableName = "Authors";  // Đặt tên cho DataTable là "Authors"
            if (!Singleton.getInstance.DataSet.Tables.Contains(authorsDataTable.TableName))
                Singleton.getInstance.DataSet.Tables.Add(authorsDataTable);

            configuration("SELECT * FROM Authors");
        }

        public BindingSource Authors
        {
            get => _authors;
            set { _authors = value; OnPropertyChanged(); }
        }

        public author SelectedAuthor
        {
            get => _selectedAuthor;
            set { _selectedAuthor = value; OnPropertyChanged(); }
        }

        public void AddAuthor(string name, string description)
        {
            authorsDataTable = (DataTable)Authors.DataSource;
            //authorsDataTable.AcceptChanges();

            var newAuthor = new author { name = name, description = description };

            DataTable dataTable = (DataTable)Authors.DataSource;
            DataRow row = dataTable.NewRow();
            row["Id"] = dataTable.Rows.Count + 2;
            row["name"] = newAuthor.name;
            row["description"] = newAuthor.description;
            Singleton.getInstance.DataSet.Tables["Authors"].Rows.Add(row);

            MessageBox.Show("Thêm tác giả thành công");
        }

        public void UpdateAuthor(int id, string name, string description, int index)
        {
            authorsDataTable = (DataTable)Authors.DataSource;
            //authorsDataTable.AcceptChanges();

            DataRow row = Singleton.getInstance.DataSet.Tables[0].Rows[index];
            row["name"] = name;
            row["description"] = description;

            MessageBox.Show("Cập nhật tác giả thành công");
        }

        public void LoadData()
        {
            Books.DataSource = context.Books
              .Select(o => new
              {
                  o.Id,
                  o.name,
                  o.description,
                  o.author_id
              })
              .Where(o => o.author_id == AuthorId)
              .ToDataTable();
        }

        public override void Load()
        {
            base.binding = Authors;
            data.Columns["Id"].HeaderText = "Mã tác giả";
            data.Columns["name"].HeaderText = "Tên tác giả";
            data.Columns["description"].HeaderText = "Mô tả";
        }
    }
}
