using QLSach.Base;
using QLSach.component;
using QLSach.view.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.Controller
{
    public class BookManagerController : ManagerBase
    {
        public BookManagerController(DataGridView data, BindingSource binding, Guna.UI2.WinForms.Guna2TextBox tb_search, Guna.UI2.WinForms.Guna2ComboBox cbb_fillter)
        {
            base.data = data;
            base.binding = binding;
            //base.tb_search = tb_search;
            //base.cbb_fillter = cbb_fillter;
        }
        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            binding.DataSource = Singleton.getInstance.Data.Books
               .Select(o => new
               {
                   o.Id,
                   o.name,
                   o.description,
                   o.public_at,
                   o.author_id,
                   o.genre_id,
                   o.rating,
                   o.views,
                   AuthorName = o.author.name,
                   GenreName = o.Genre.name,
                   o.quantity,
                   o.remaining,
                   o.status,
                   o.created_at,
                   o.updated_at,
               })
               .ToFilteredDataTable();

            data.DataSource = binding;

            data.Columns["Id"].HeaderText = "Mã sách";
            data.Columns["name"].HeaderText = "Tên sách";
            data.Columns["description"].HeaderText = "Mô tả";
            data.Columns["public_at"].HeaderText = "Ngày phát hành";
            data.Columns["AuthorName"].HeaderText = "Tên tác giả";
            data.Columns["GenreName"].HeaderText = "Tên thể loại";
            data.Columns["rating"].HeaderText = "Đánh giá";
            data.Columns["views"].HeaderText = "Lược xem";
            data.Columns["quantity"].HeaderText = "Số lượng đã nhập";
            data.Columns["remaining"].HeaderText = "Số lượng còn lại";
            data.Columns["status"].HeaderText = "Trạng thái";
            data.Columns["created_at"].HeaderText = "Ngày nhập";
            data.Columns["updated_at"].HeaderText = "Ngày cập nhật";

            data.Columns[0].Visible = false;
            data.Columns["genre_id"].Visible = false;
            data.Columns["author_id"].Visible = false;

            List<Columns> columnNames = new List<Columns>();

            /*Combobox fillter*/
            foreach (DataGridViewColumn column in data.Columns)
            {
                columnNames.Add(new Columns(column.HeaderText, column.Name));
            }

            //cbb_fillter.DataSource = columnNames;
            //cbb_fillter.DisplayMember = "HeaderText";
            //cbb_fillter.ValueMember = "Name";
            /**/

            // when add a new book
            Singleton.getInstance.AdminHelper.book_data = binding;

        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
