using MoreLinq;
using QLSach.component;
using QLSach.database.models;
using System.Data;
using System.Windows.Forms;

namespace QLSach.view.admin
{
    public partial class UserManager : UserControl
    {
        BindingSource bindingSource = new BindingSource();
        private bool isAdduser = false;
        public UserManager()
        {
            InitializeComponent();
        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = Singleton.getInstance.Data.Users.ToDataTable();
            data.DataSource = bindingSource;

            combobox_right.DataSource = Enum.GetValues(typeof(Role)).Cast<Role>();

            pane_add_user.Visible = isAdduser;

            List<string> columnNames = new List<string>();

            foreach (DataGridViewColumn column in data.Columns)
            {
                columnNames.Add(column.HeaderText);
            }

            conbobox_fillter.DataSource = columnNames;
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            Role role;
            if (combobox_right.Text == Role.Admin.ToString())
                role = Role.Admin;
            else
                role = Role.User;

            User user = new User(
                tb_name.Text,
                tb_password.Text,
                tb_username.Text,
                role
            );

            Singleton.getInstance.Data.Users.Add(user);
            Singleton.getInstance.Data.SaveChanges();

            DataTable dataTable = (DataTable)bindingSource.DataSource;
            DataRow dataRow = dataTable.NewRow();
            dataRow["Id"] = user.Id;
            dataRow[1] = user.Name;
            dataRow[2] = user.Password;
            dataRow[3] = user.UserName;
            dataRow[4] = user.Role;
            dataRow[5] = user.create_at;
            dataRow[6] = user.update_at;

            dataTable.Rows.Add(dataRow);
        }

        private void btn_pane_addUser_Click(object sender, EventArgs e)
        {
            isAdduser = !isAdduser;
            pane_add_user.Visible = isAdduser;
        }

        private void onVisible(object sender, EventArgs e)
        {

            //List<string> columnNames = new List<string>();

            //foreach (DataGridViewColumn column in data.Columns)
            //{
            //    columnNames.Add(column.HeaderText);
            //}

            //Singleton.getInstance.AdminHelper.fillterData.DataSource = null;
            //Singleton.getInstance.AdminHelper.fillterData.DataSource = columnNames;
            //Singleton.getInstance.AdminHelper.fillterString = columnNames.First();
            //Singleton.getInstance.AdminHelper.OnActiveSearchHanler += onActiveUser;
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = $"CONVERT({conbobox_fillter.Text.Trim()}, System.String) LIKE '%{tb_search.Text.Trim()}%'";
            if (tb_search.Text == "")
            {
                bindingSource.RemoveFilter();
            }
        }
    }
}
