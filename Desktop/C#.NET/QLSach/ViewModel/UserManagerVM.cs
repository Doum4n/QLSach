﻿using MoreLinq;
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
            usersDataTable.AcceptChanges();

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
            adapter = new MySqlDataAdapter("SELECT * FROM Users", connection);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
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

            User user = new User();
                user.Name = name;
                user.Password = password;
                user.Role = role;
                user.UserName = username;
                context.Users.Add(user);

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

        public override void SaveChange()
        {
            //adapter.Update(Singleton.getInstance.DataSet, "Users");
            usersDataTable.AcceptChanges();
            context.SaveChanges();
        }
    }
}
