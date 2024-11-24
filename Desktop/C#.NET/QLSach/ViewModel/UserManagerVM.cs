using MoreLinq;
using QLSach.Base;
using QLSach.component;
using QLSach.database.models;
using QLSach.dbContext.models;
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
    public class UserManagerVM : ManagerBase, INotifyPropertyChanged
    {
        private BindingSource _users = new BindingSource();

        public UserManagerVM(DataGridView data)
        {
            Users.DataSource = Singleton.getInstance.Data.Users.ToDataTable();
            base.data = data;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddUser(string name, string password, string username, Role role)
        {
            User user = new User(
                name,
                password,
                username,
                role
            );
            DataTable dataTable = (DataTable)Users.DataSource;
            DataRow row = dataTable.NewRow();
            row["Id"] = dataTable.Rows.Count + 1;
            row[1] = user.Name;
            row[2] = user.Password;
            row[3] = user.UserName;
            row[4] = user.Role;
            row[5] = user.create_at;
            row[6] = user.update_at;

            dataTable.Rows.Add(row);
            Singleton.getInstance.Data.Users.Add(user);

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
            var DataTable = (DataTable)binding.DataSource;

            foreach (int index in prevDataRow.Keys)
            {
                DataTable.Rows.RemoveAt(index);
            }
            foreach (int Id in seletedId)
            {
                try
                {
                    Singleton.getInstance.Data.Users.Remove(Singleton.getInstance.Data.Users.Where(o => o.Id == Id).First());
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
