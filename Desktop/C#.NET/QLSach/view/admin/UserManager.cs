using MoreLinq;
using QLSach.component;
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

            combobox_right.DataSource = Enum.GetValues(typeof(Role)).Cast<Role>();
            pane_add_user.Visible = isAdduser;

            
            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_fillter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            Role role;
            if (combobox_right.SelectedValue == Role.Admin.ToString())
                role = Role.Admin;
            else if(combobox_right.SelectedValue == Role.User.ToString())
                role = Role.User;
            else
                role = Role.Staff;

            viewModel.AddUser(tb_name.Text, tb_password.Text, tb_username.Text, role);    
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
        }
    }
}
