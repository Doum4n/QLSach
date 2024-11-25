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

namespace QLSach.ViewModel
{
    public class UserManagerVM : ManagerBase, INotifyPropertyChanged
    {
        private BindingSource _users = new BindingSource();
        private readonly Context context = new Context();
        DataTable usersDataTable;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlConnection connection = new MySqlConnection(Singleton.getInstance.connectionString);
        public UserManagerVM(DataGridView data)
        {
            Users.DataSource = context.Users.ToDataTable();
            base.data = data;

            usersDataTable = (DataTable)Users.DataSource;

            // Gán tên cho DataTable trước khi thêm vào DataSet
            usersDataTable.TableName = "Users";  // Đặt tên cho DataTable là "Authors"
            Singleton.getInstance.DataSet.Tables.Add(usersDataTable);
            connection.Open();
            configuration();
        }

        public BindingSource Users
        {
            get => _users;
            set { _users = value; OnPropertyChanged(); }
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

        private void configuration()
        {
       
                adapter.InsertCommand = new MySqlCommand("INSERT INTO Users (Name, Password, UserName, Role, create_at, update_at) VALUES (@Name, @Password, @Username, @Role, @Create_at, @Update_at)", connection);
                adapter.InsertCommand.Parameters.Add("@Name", MySqlDbType.LongText).SourceColumn = "Name";
                adapter.InsertCommand.Parameters.Add("@Password", MySqlDbType.LongText).SourceColumn = "Password";
                adapter.InsertCommand.Parameters.Add("@Username", MySqlDbType.LongText).SourceColumn = "Username";
                adapter.InsertCommand.Parameters.Add("@Role", MySqlDbType.LongText).SourceColumn = "Role";
                adapter.InsertCommand.Parameters.Add("@Create_at", MySqlDbType.Date).SourceColumn = "create_at";
                adapter.InsertCommand.Parameters.Add("@Update_at", MySqlDbType.Date).SourceColumn = "update_at";


                //adapter.UpdateCommand = new MySqlCommand("UPDATE Users set Name = @name, Password = @Password, UserName = @UserName, Role = @Role where Id = @id", Singleton.getInstance.connection);
                //adapter.UpdateCommand.Parameters.Add("@Name", MySqlDbType.LongText).SourceColumn = "Name";
                //adapter.UpdateCommand.Parameters.Add("@Password", MySqlDbType.LongText).SourceColumn = "Password";
                //adapter.UpdateCommand.Parameters.Add("@Username", MySqlDbType.LongText).SourceColumn = "Username";
                //adapter.UpdateCommand.Parameters.Add("@Role", MySqlDbType.LongText).SourceColumn = "Role";

                adapter.DeleteCommand = new MySqlCommand("DELETE from Users where Id = @deletedId", connection);
                adapter.DeleteCommand.Parameters.Add("@deletedId", MySqlDbType.LongText).SourceColumn = "id";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddUser(string name, string password, string username, Role role)
        {
            usersDataTable.AcceptChanges();

            DataRow row = Singleton.getInstance.DataSet.Tables["Users"].NewRow();
            row["Id"] = usersDataTable.Rows.Count + 1;
            row[1] = name;
            row[2] = password;
            row[3] = username;
            row[4] = role;
            row[5] = DateOnly.FromDateTime(DateTime.Now);
            row[6] = DateOnly.FromDateTime(DateTime.Now);

            Singleton.getInstance.DataSet.Tables["Users"].Rows.Add(row);

            MessageBox.Show("Thêm bạn đọc thành công");
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            base.binding = Users;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            usersDataTable.AcceptChanges();

            foreach (int index in prevDataRow.Keys)
            {
                Singleton.getInstance.DataSet.Tables["Users"].Rows[index].Delete();

            }
            adapter.Update(Singleton.getInstance.DataSet, "Users");
        }

        public override void SaveChange()
        {
            adapter.Update(Singleton.getInstance.DataSet, "Users");
        }
    }
}
