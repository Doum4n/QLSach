using Microsoft.EntityFrameworkCore;
using MoreLinq;
using QLSach.component;
using QLSach.database.models;
using QLSach.database.query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.view.admin
{
    public partial class RegisterManager : UserControl
    {
        private BindingSource bindingSource = new BindingSource();
        private RegisterQuery registerQuery = new RegisterQuery();
        // when update
        private int selectedBookId;

        public RegisterManager()
        {
            InitializeComponent();
        }

        private void RegisterManager_Load(object sender, EventArgs e)
        {
            LoadTableData();
            setColumnHeaderText();
            addButtonColumn();
            LoadComboboxData();

            data.Columns["BookId"].Visible = false;
        }

        private void LoadTableData()
        {
            bindingSource.DataSource = Singleton.getInstance.Data.Register
                            .Where(o => o.Status == Status_borrow.Pending)
                            .Select(o => new { o.UserId, Username = o.User.Name, o.BookId, BookName = o.Book.name, o.register_at, o.Status }).ToFilteredDataTable();
            data.DataSource = bindingSource;
        }

        private void addButtonColumn()
        {
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.HeaderText = "Cập nhật";
            button.Text = "Đã mượn";
            button.UseColumnTextForButtonValue = true;

            data.Columns.Add(button);

            // when button column is clicked
            data.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var selectedItem = data.Rows[e.RowIndex];
                    selectedBookId = Convert.ToInt32(selectedItem.Cells["BookId"].Value);
                    var selectedUserId = Convert.ToInt32(selectedItem.Cells["UserId"].Value);

                    if (data.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        var register = registerQuery.getByUserIdBookId(Convert.ToInt32(selectedItem.Cells["UserId"].Value), Convert.ToInt32(selectedItem.Cells["BookId"].Value));
                        register.Status = Status_borrow.Borrowed;
                        register.borrow_at = DateTime.Now;

                        Singleton.getInstance.Data.Update(register);
                        Singleton.getInstance.Data.SaveChanges();

                        DataTable dataTable = (DataTable)bindingSource.DataSource;

                        //bindingSource.Insert(e.RowIndex, register);
                        dataTable.Rows.RemoveAt(e.RowIndex);

                        MessageBox.Show("cập nhật thành công");

                        Update();
                    }
                }
            };
        }

        private void setColumnHeaderText()
        {
            data.Columns["UserId"].HeaderText = "Mã bạn đọc";
            data.Columns["Username"].HeaderText = "Tên bạn đọc";
            data.Columns["register_at"].HeaderText = "Ngày đăng ký";
            data.Columns["status"].HeaderText = "Trạng thái";
            data.Columns["BookName"].HeaderText = "Tên sách";
        }

        private void LoadComboboxData()
        {
            List<Columns> columnNames = new List<Columns>();

            foreach (DataGridViewColumn column in data.Columns)
            {
                columnNames.Add(new Columns(column.HeaderText, column.Name));
            }

            combobox_filter.DataSource = columnNames;
            combobox_filter.DisplayMember = "HeaderText";
            combobox_filter.ValueMember = "Name";
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = $"CONVERT({combobox_filter.SelectedValue}, System.String) LIKE '%{tb_search.Text.Trim()}%'";
            if (tb_search.Text == "")
            {
                bindingSource.RemoveFilter();
            }
        }
    }
}
