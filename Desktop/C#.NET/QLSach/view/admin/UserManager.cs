using MoreLinq;
using QLSach.component;
using QLSach.database;
using QLSach.database.models;
using QLSach.ViewModel;
using System.Data;
using System.Windows.Forms;

namespace QLSach.view.admin
{
    public partial class UserManager : UserControl
    {
        private bool isAdduser = false;
        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
        private bool isDelete = false;

        private UserManagerVM viewModel;

        private bool isModify = false;

        private int updatedId;
        private int updatedIndex;
        private Context Context = new Context();

        public UserManager()
        {
            InitializeComponent();
            viewModel = new UserManagerVM(data);
        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            data.DataSource = viewModel.Users;
            viewModel.Load();
            viewModel.AssignFillterList(combobox_fillter);

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
                    viewModel.addSelectedId(e.RowIndex, "Id");
                }
            };

            // Khi cập nhật dữ liệu
            data.CellClick += (sender, e) => 
            {
                if (isModify)
                {
                    var selectedRow = data.Rows[e.RowIndex];

                    updatedIndex = e.RowIndex;
                    updatedId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                    MessageBox.Show(updatedId.ToString());

                    tb_modified_name.Text = selectedRow.Cells["Name"].Value.ToString();
                    tb_modified_username.Text = selectedRow.Cells["UserName"].Value.ToString();
                    cbb_modified_role.SelectedValue = Convert.ToInt32(selectedRow.Cells["Role"].Value);
                }
            };

            var roles = Enum.GetValues(typeof(Role))
            .Cast<Role>()
            .Select(r => new { Value = (int)r, Name = r.ToString() })
            .ToList();

            cbb_modified_role.DataSource = roles;
            cbb_modified_role.DisplayMember = "Name";
            cbb_modified_role.ValueMember = "Value";

            combobox_right.DataSource = Enum.GetValues(typeof(Role)).Cast<Role>();
            pane_add_user.Visible = isAdduser;
            pane_modify_user.Visible = isModify;

            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_fillter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            Role role = setRole(combobox_right.SelectedValue.ToString());
            viewModel.AddUser(tb_name.Text, tb_password.Text, tb_username.Text, role);
        }

        private Role setRole(string role)
        {
            Role _role;
            if (role == Role.Admin.ToString())
                _role = Role.Admin;
            else if (combobox_right.SelectedValue == Role.User.ToString())
                _role = Role.User;
            else
                _role = Role.Staff;
            return _role;
        }

        private void btn_pane_addUser_Click(object sender, EventArgs e)
        {
            isAdduser = !isAdduser;
            pane_add_user.Visible = isAdduser;
            checkbox.Visible = false;
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            viewModel.Search();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            isDelete = !isDelete;
            checkbox.Visible = isDelete;
        }

        private void btn_delete_data_Click(object sender, EventArgs e)
        {
            viewModel.Delete("Users", "Id");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            viewModel.Rollback("Users");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            viewModel.SaveChange();
            Context.SaveChanges();
        }

        private void btn_operation_Click(object sender, EventArgs e)
        {
            isModify = !isModify;
            pane_modify_user.Visible = isModify;
        }

        private void btn_reset_password_Click(object sender, EventArgs e)
        {
            User user = Context.Users.Where(o => o.Id == updatedId).First();
            user.Password = "123";
            Context.Users.Update(user);
        }

        private void btn_update_data_Click(object sender, EventArgs e)
        {
                User user = Context.Users.Where(o => o.Id == updatedId).First();
                user.UserName = tb_modified_username.Text;
                user.Name = tb_modified_name.Text;
                user.Role = setRole(cbb_modified_role.Text);

                viewModel.UpdateUser(user.Name, user.UserName, user.Role, updatedIndex);
        }
    }
}
