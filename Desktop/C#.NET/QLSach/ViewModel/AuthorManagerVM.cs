using Bogus;
using MoreLinq;
using MySqlConnector;
using QLSach.Base;
using QLSach.component;
using QLSach.database;
using QLSach.dbContext.models;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using TheArtOfDevHtmlRenderer.Adapters;

namespace QLSach.ViewModel
{
    public class AuthorManagerVM : ManagerBase, INotifyPropertyChanged
    {
        private BindingSource _authors = new BindingSource();
        private readonly Context context = new Context();
        DataTable authorsDataTable;
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        private author _selectedAuthor;
        public AuthorManagerVM(DataGridView data)
        {
            base.data = data;
            Authors.DataSource = context.Authors.Select(o => new { o.Id, o.name, o.description }).ToDataTable();
            SelectedAuthor = context.Authors.First();
            authorsDataTable = (DataTable)Authors.DataSource;

            // Gán tên cho DataTable trước khi thêm vào DataSet
            authorsDataTable.TableName = "Authors";  // Đặt tên cho DataTable là "Authors"
            Singleton.getInstance.DataSet.Tables.Add(authorsDataTable);

            configuration();

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

        private void configuration()
        {
            adapter.InsertCommand = new MySqlCommand("INSERT INTO Authors (name, description) VALUES (@name, @description)", Singleton.getInstance.connection);
            adapter.InsertCommand.Parameters.Add("@name", MySqlDbType.LongText).SourceColumn = "name";
            adapter.InsertCommand.Parameters.Add("@description", MySqlDbType.LongText).SourceColumn = "description";

            adapter.UpdateCommand = new MySqlCommand("UPDATE Authors set name = @name, description = @description where Id = @id", Singleton.getInstance.connection);
            adapter.UpdateCommand.Parameters.Add("@name", MySqlDbType.LongText).SourceColumn = "name";
            adapter.UpdateCommand.Parameters.Add("@description", MySqlDbType.LongText).SourceColumn = "description";
            adapter.UpdateCommand.Parameters.Add("@id", MySqlDbType.Int32).SourceColumn = "Id";

            adapter.DeleteCommand = new MySqlCommand("DELETE from Authors where Id = @deletedId", Singleton.getInstance.connection);
            adapter.DeleteCommand.Parameters.Add("@deletedId", MySqlDbType.Int32).SourceColumn = "Id";
        }

        // Sự kiện PropertyChanged để thông báo View cập nhật
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddAuthor(string name, string description)
        {
            var bookDataTable = (DataTable)binding.DataSource;
            bookDataTable.AcceptChanges();

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
            authorsDataTable.AcceptChanges();

            DataRow row = Singleton.getInstance.DataSet.Tables[0].Rows[index];
            row["name"] = name;
            row["description"] = description;

            MessageBox.Show("Cập nhật tác giả thành công");
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
            authorsDataTable.AcceptChanges();

            foreach (int index in prevDataRow.Keys)
            {
                Singleton.getInstance.DataSet.Tables["Authors"].Rows[index].Delete();

            }
            adapter.Update(Singleton.getInstance.DataSet, "Authors");

        }

        public override void SaveChange()
        {
            adapter.Update(Singleton.getInstance.DataSet, "Authors");
        }
    }
}
