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
        DataTable usersDataTable;
        private User _selectedUser;
        public User selectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; OnPropertyChanged(); }
        }

        public UserManagerVM(DataGridView data) : base(data)
        {
            Users.DataSource = context.Users.ToDataTable();

            usersDataTable = (DataTable)Users.DataSource;
            usersDataTable.AcceptChanges();

            // Gán tên cho DataTable trước khi thêm vào DataSet
            usersDataTable.TableName = "Users";  // Đặt tên cho DataTable là "Authors"
            Singleton.getInstance.DataSet.Tables.Add(usersDataTable);
            configuration("SELECT * FROM Users");

            selectedUser = context.Users.First();
        }

        public BindingSource Users
        {
            get => _users;
            set { _users = value; OnPropertyChanged(); }
        }

        public void AddUser(string name, string password, string username, int age, string gender, Role role)
        {
            DataTable dataTable = (DataTable)Users.DataSource;
            DataRow row = dataTable.NewRow();
            row["Id"] = usersDataTable.Rows.Count + 1;
            row["Name"] = name;
            row["Password"] = password;
            row["UserName"] = username;
            row["Age"] = age;
            row["Gender"] = gender;
            row["Role"] = role;
            row["create_at"] = DateOnly.FromDateTime(DateTime.Now);
            row["update_at"] = DateOnly.FromDateTime(DateTime.Now);

            Singleton.getInstance.DataSet.Tables["Users"].Rows.Add(row);
            MessageBox.Show("Thêm tài khoản thành công");
        }

        public void UpdateUser(string name, string username, Role role, int index)
        {
            DataRow row = Singleton.getInstance.DataSet.Tables["Users"].Rows[index];
            row["Name"] = name;
            row["UserName"] = username;
            row["Role"] = role;
            row["update_at"] = DateOnly.FromDateTime(DateTime.Now);

            MessageBox.Show("Cập nhật thành tài khoản thành công công");
        }

        public override void Load()
        {
            base.binding = Users;

            data.Columns["Password"].Visible = false;
        }

        public override void SaveChange()
        {
            adapter.Update(Singleton.getInstance.DataSet, "Users");
            usersDataTable.AcceptChanges();
            context.SaveChanges();
        }
    }
}
