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
            if (Singleton.getInstance.Role == Role.Staff)
            {
                cbb_modified_role.Visible = false;
                lb_role.Visible = false;
            }

            data.DataSource = viewModel.Users;
            viewModel.Load();
            viewModel.AssignFillterList(combobox_fillter);

            checkbox.HeaderText = "Xóa";
            checkbox.TrueValue = true;
            checkbox.FalseValue = false;
            checkbox.Visible = isDelete;
            data.Columns.Add(checkbox);

            tb_age.Enabled = false;
            tb_modified_name.Enabled = false;
            tb_modified_username.Enabled = false;
            cbb_gender.Enabled = false;

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
                var selectedRow = data.Rows[e.RowIndex];

                if (isModify)
                {
                    updatedIndex = e.RowIndex;
                    updatedId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    tb_modified_name.Text = selectedRow.Cells["Name"].Value.ToString();
                    tb_modified_username.Text = selectedRow.Cells["UserName"].Value.ToString();
                    cbb_modified_role.SelectedValue = Convert.ToInt32(selectedRow.Cells["Role"].Value);
                    tb_age.Text = selectedRow.Cells["Age"].Value.ToString();
                    cbb_gender.SelectedItem = selectedRow.Cells["Gender"].Value.ToString();
                }
            };

            var roles = Enum.GetValues(typeof(Role))
                        .Cast<Role>()
                        .Select(r => new { Value = (int)r, Name = r.ToString()})
                        .ToList();

            cbb_modified_role.DataSource = roles;
            cbb_modified_role.DisplayMember = "Name";
            cbb_modified_role.ValueMember = "Value";

            string[] gender = new string[] { "Male", "Female", "Other" };
            cbb_gender.DataSource = gender;
            cbb_added_gender.DataSource = gender;

            combobox_right.DataSource = Enum.GetValues(typeof(Role)).Cast<Role>();
            pane_add_user.Visible = isAdduser;
            pane_modify_user.Visible = isModify;

            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_fillter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
            //cbb_sex.DataBindings.Add("SelectedItem", viewModel, "selectedUser.Gender", true, DataSourceUpdateMode.OnPropertyChanged);
            tb_age.DataBindings.Add("Text", viewModel, "selectedUser.Age", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            Role role = setRole(combobox_right.Text.ToString());
            viewModel.AddUser(tb_name.Text, tb_password.Text, tb_username.Text,Convert.ToInt32(tb_added_age.Text), cbb_added_gender.Text, role);
        }

        private Role setRole(string role)
        {
            MessageBox.Show(Role.Admin.ToString());
            Role _role;
            if (role == Role.Admin.ToString())
                _role = Role.Admin;
            else if (role == Role.User.ToString())
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
            pane_modify_user.Visible = false;
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
            viewModel.SaveChange("Users");
            Context.SaveChanges();
        }

        private void btn_operation_Click(object sender, EventArgs e)
        {
            isModify = !isModify;
            pane_modify_user.Visible = isModify;
            pane_add_user.Visible = false;
        }

        private void btn_reset_password_Click(object sender, EventArgs e)
        {
            try
            {
                User user = Context.Users.Where(o => o.Id == updatedId).First();
                user.Password = "123";
                Context.Users.Update(user);

                MessageBox.Show("Đặt lại mặt khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {}
        }

        private void btn_update_data_Click(object sender, EventArgs e)
        {
            try
            {
                User user = Context.Users.Where(o => o.Id == updatedId).First();
                if (user != null)
                {
                    user.UserName = tb_modified_username.Text;
                    user.Name = tb_modified_name.Text;

                    user.Role = (Role)Enum.Parse(typeof(Role), cbb_modified_role.Text);
                }

                viewModel.UpdateUser(user.Name, user.UserName, user.Role, updatedIndex);
            }catch (Exception ex) {}
        }
    }
}
