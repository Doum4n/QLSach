using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using QLSach.component;
using QLSach.database.models;
using QLSach.query;
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
    public record Columns(string HeaderText, string Name);
    public partial class BorrowedManager : UserControl
    {
        private BindingSource bindingSource = new BindingSource();
        private RegisterQuery registerQuery = new RegisterQuery();
        // when update
        private int selectedBookId;

        public BorrowedManager()
        {
            InitializeComponent();
        }

        private void BorowedManager_Load(object sender, EventArgs e)
        {
            LoadTableData();
            setColumnHeaderText();
            addButtonColumn();
            loadComboboxData();

            data.Columns["BookId"].Visible = false;
        }

        private void addButtonColumn()
        {
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.HeaderText = "Cập nhật";
            button.Text = "Đã trả";
            button.UseColumnTextForButtonValue = true;

            data.Columns.Add(button);

            // when button column is clicked
            data.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var selectedItem = data.Rows[e.RowIndex];
                    if (data.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        selectedBookId = Convert.ToInt32(selectedItem.Cells["BookId"].Value);
                        var register = registerQuery.getByUserIdBookId(Convert.ToInt32(selectedItem.Cells["UserId"].Value), Convert.ToInt32(selectedItem.Cells["BookId"].Value));
                        register.Status = Status_borrow.Completed;
                        register.return_at = DateTime.Now;

                        Singleton.getInstance.Data.Update(register);
                        Singleton.getInstance.Data.SaveChanges();

                        DataTable dataTable = (DataTable)bindingSource.DataSource;
                        //DataRow dataRow = dataTable.NewRow();
                        //dataRow[0] = register.Id;
                        //dataRow[1] = 

                        //bindingSource.Insert(e.RowIndex, register);
                        dataTable.Rows.RemoveAt(e.RowIndex);

                        MessageBox.Show("cập nhật thành công");

                        Update();
                    }
                }
            };
        }

        private void LoadTableData()
        {
            bindingSource.DataSource = Singleton.getInstance.Data.Register
                .Include(o => o.Book)
                .Include(o => o.User)
                .Where(o => o.Status == Status_borrow.Borrowed)
                .Select(o => new { o.UserId, Username = o.User.Name, o.BookId, BookName = o.Book.name, o.register_at, o.borrow_at, o.expected_at, o.Status }).ToFilteredDataTable();
            data.DataSource = bindingSource;
        }

        private void setColumnHeaderText()
        {
            data.Columns["UserId"].HeaderText = "Mã bạn đọc";
            data.Columns["Username"].HeaderText = "Tên bạn đọc";
            data.Columns["BookName"].HeaderText = "Tên sách";
            data.Columns["register_at"].HeaderText = "Ngày đăng ký";
            data.Columns["borrow_at"].HeaderText = "Ngày mượn";
            data.Columns["expected_at"].HeaderText = "Ngày hẹn trả";
            data.Columns["status"].HeaderText = "Trạng thái";
        }

        private void loadComboboxData()
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

        private async void Update()
        {
            var result = Singleton.getInstance.Data.Register
             .Where(r => r.BookId == selectedBookId)
             .GroupBy(r => new { r.UserId, r.BookId })
             .Select(g => new
             {
                 UserId = g.Key.UserId,
                 BookId = g.Key.BookId,
                 Recent = g.Min(r => r.register_at)
             })
             .OrderBy(r => r.BookId)
             .ThenBy(r => r.Recent)
             .FirstOrDefault();

            Register register = registerQuery.getByUserIdBookId(result.UserId, result.BookId);
            register.Status = Status_borrow.Pending;
            register.borrow_at = DateTime.Now;

            Singleton.getInstance.Data.Register.Update(register);
            Singleton.getInstance.Data.SaveChanges();

            string name = Singleton.getInstance.Data.Books.Where(o => o.Id == result.BookId).Select(o => o.name).First();

            await CreateMessage(result.UserId, $"{DateTime.Now} :: Sách {name} đã có thể mượn");
        }

        public async Task CreateMessage(int userId, string input)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = userId.ToString(),
                BrokerAddressFamily = BrokerAddressFamily.V4,

            };
            using
            var producer = new ProducerBuilder<int, string>(config).Build();
            var message = new Message<int, string>
            {
                Key = userId,
                Value = input
            };
            var deliveryReport = await producer.ProduceAsync("my-topic", message);
            MessageBox.Show($"Message delivered to partition {deliveryReport.TopicPartition.Partition} at offset {deliveryReport.Offset}");
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
