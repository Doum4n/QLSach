using QLSach.database.models;
using QLSach.ViewModel;
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
    public partial class ReaderManager : UserControl
    {
        private ReaderManagerVM viewModel;
        public ReaderManager()
        {
            InitializeComponent();
            viewModel = new ReaderManagerVM(dataReader);

            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_fillter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void ReaderManager_Load(object sender, EventArgs e)
        {
            dataBook.DataSource = viewModel.Books;
            viewModel.Load();
            dataReader.DataSource = viewModel.Reader;
            viewModel.AssignFillterList(combobox_fillter);

            string[] Status = new string[] { "Đã mượn", "Đang đăng ký" };
            cbb_history.DataSource = Enum.GetNames(typeof(Status_borrow));
            cbb_history.SelectedIndexChanged += (sender, e) =>
            {
                viewModel.Status = (Status_borrow)Enum.Parse(typeof(Status_borrow), cbb_history.SelectedItem.ToString());
            };

            dataReader.CellClick += (sender, e) =>
            {
                if (e.RowIndex > 0)
                {
                    var selectedRow = dataReader.Rows[e.RowIndex];
                    viewModel.UserId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    viewModel.LoadData();

                    dataBook.Columns[0].Visible = true;

                    dataBook.Columns["id"].HeaderText = "Mã sách";
                    dataBook.Columns["UserId"].Visible = false;
                    dataBook.Columns["Status"].Visible = false;
                    dataBook.Columns["name"].HeaderText = "Tên sách";
                    dataBook.Columns["description"].HeaderText = "Mô tả";
                    dataBook.Columns["genreName"].HeaderText = "Tên thể loại";
                    dataBook.Columns["authorName"].HeaderText = "Tên tác giả";
                    dataBook.Columns["publisherName"].HeaderText = "Tên nhà cung cấp";
                }
            };

            dataReader.Columns["Id"].HeaderText = "Mã đọc giả";
            dataReader.Columns["Name"].HeaderText = "Tên đọc giả";
            dataReader.Columns["Age"].HeaderText = "Tuổi";
            dataReader.Columns["Gender"].HeaderText = "Giới tính";
            dataReader.Columns["create_at"].HeaderText = "Ngày đăng ký";
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            viewModel.Search();
        }
    }
}
