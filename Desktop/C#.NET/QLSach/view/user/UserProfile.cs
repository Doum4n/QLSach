using QLSach.component;
using QLSach.database;
using QLSach.database.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.view.user
{
    public partial class UserProfile : Form
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            tb_age.Enabled = false;
            tb_username.Enabled = false;
            tb_name.Enabled = false;
            cbb_gender.Enabled = false;
            btn_update.Visible = false;

            using (Context context = new Context())
            {
                User user = context.Users.Find(Singleton.getInstance.UserId);
                tb_username.Text = user.UserName;
                tb_name.Text = user.Name;
                tb_age.Text = user.Age.ToString();

                string[] gender = new string[] { "Male", "Female", "Other" };

                cbb_gender.DataSource = gender;
                cbb_gender.SelectedItem = user.Gender;
            }
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            tb_age.Enabled = true;
            tb_username.Enabled = true;
            tb_name.Enabled = true;
            cbb_gender.Enabled = true;

            btn_update.Visible = true;
            btn_modify.Visible = false;

            btn_cancel.Visible = true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            tb_age.Enabled = false;
            tb_username.Enabled = false;
            tb_name.Enabled = false;
            cbb_gender.Enabled = false;

            btn_cancel.Visible = false;

            btn_update.Visible = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            using (Context context = new Context())
            {
                User user = context.Users.Find(Singleton.getInstance.UserId);
                user.Name = tb_name.Text;
                user.UserName = tb_username.Text;
                user.Age = Convert.ToInt32(tb_age.Text);
                user.Gender = cbb_gender.Text;

                context.Users.Update(user);
                context.SaveChanges();

                MessageBox.Show("Cập nhật thành công");
            }
        }
    }
}
