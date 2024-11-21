using MoreLinq;
using QLSach.component;
using QLSach.Controller;
using QLSach.database.models;
using System.Data;
using System.Windows.Forms;

namespace QLSach.view.admin
{
    public partial class UserManager : UserControl
    {
        BindingSource bindingSource = new BindingSource();
        private bool isAdduser = false;
        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
        private bool isDelete = false;
        Dictionary<int, DataRow> prevDataRow = new Dictionary<int, DataRow>();
        private List<int> seletedIndex = new List<int>();
        private List<int> seletedUserId = new List<int>();

        private UserManagerController controller;

        public UserManager()
        {
            InitializeComponent();
            controller = new UserManagerController(bindingSource, data);
        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            controller.Load();
            controller.setPrevRows(prevDataRow);
            controller.setRollbackList(seletedIndex, seletedUserId);

            checkbox.HeaderText = "Xóa";
            checkbox.TrueValue = true;
            checkbox.FalseValue = false;
            checkbox.Visible = isDelete;
            data.Columns.Add(checkbox);

            data.CellContentClick += (sender, e) =>
            {
                var selectedRow = data.Rows[e.RowIndex];
                if (data.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    seletedIndex.Add(e.RowIndex);
                    seletedUserId.Add(Convert.ToInt32(selectedRow.Cells["Id"].Value));
                    DataTable dataTable = (DataTable)bindingSource.DataSource;
                    controller.addPrevRows(e.RowIndex, dataTable.Rows[e.RowIndex]);
                }
            };

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

            DataTable dataTable = (DataTable)bindingSource.DataSource;
            DataRow dataRow = dataTable.NewRow();
            dataRow["Id"] = dataTable.Rows.Count + 1;
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
            checkbox.Visible = false;
        }

        private void onVisible(object sender, EventArgs e)
        {

        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = $"CONVERT({conbobox_fillter.Text.Trim()}, System.String) LIKE '%{tb_search.Text.Trim()}%'";
            if (tb_search.Text == "")
            {
                bindingSource.RemoveFilter();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            isDelete = !isDelete;
            checkbox.Visible = isDelete;
        }

        private void btn_delete_data_Click(object sender, EventArgs e)
        {
            controller.Delete();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            controller.Rollback();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            controller.SaveChange();
        }
    }
}
