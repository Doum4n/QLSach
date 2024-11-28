using MoreLinq.Extensions;
using MySqlConnector;
using QLSach.Base;
using QLSach.component;
using QLSach.database;
using QLSach.dbContext.models;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;

namespace QLSach.ViewModel
{
    public class BookManagerVM : ManagerBase, INotifyPropertyChanged
    {
        private BindingSource _books = new BindingSource();

        DataTable booksDataTable;
        public BookManagerVM(DataGridView data) : base(data)
        {
            using (Context context = new Context())
            {
                Books.DataSource = context.Books
                   .Select(o => new
                   {
                       o.Id,
                       o.name,
                       o.description,
                       o.public_at,
                       o.author_id,
                       o.genre_id,
                       o.publisher_id,
                       o.rating,
                       o.views,
                       AuthorName = o.author.name,
                       GenreName = o.Genre.name,
                       PublisherName = o.Publisher.Name,
                       o.storage_location,
                       o.photoPath,
                       o.quantity,
                       o.remaining,
                       o.status,
                       o.created_at,
                       o.updated_at,
                   }).ToDataTable();
            }

            booksDataTable = (DataTable)Books.DataSource;
            booksDataTable.AcceptChanges();
            booksDataTable.TableName = "Books";
            Singleton.getInstance.DataSet.Tables.Add(booksDataTable);

            configuration("SELECT * FROM Books");
        }

        public BindingSource Books
        {
            get => _books;
            set { _books = value; OnPropertyChanged(); }
        }

        public void AddBook(Book book)
        {
            DataTable dataTable = (DataTable)Books.DataSource;
            DataRow row = dataTable.NewRow();
            row["Id"] = Convert.ToInt32(data.Rows[data.Rows.Count - 1].Cells["Id"].Value) + 1;
            row["name"] = book.name;
            row["description"] = book.description;
            row["author_id"] = book.author_id;
            row["genre_id"] = book.genre_id;
            row["publisher_id"] = book.publisher_id;
            using (Context context = new Context())
            {
                row["GenreName"] = context.Genre.Where(c => c.id == book.genre_id).Select(o => o.name).First();
                row["AuthorName"] = context.Authors.Where(o => o.Id == book.author_id).Select(o => o.name).First();
                row["PublisherName"] = context.Publisher.Where(o => o.Id == book.publisher_id).Select(o => o.Name).First();
            }
            row["public_at"] = book.public_at;
            row["quantity"] = book.quantity;
            row["remaining"] = book.remaining;
            row["rating"] = book.rating;
            row["views"] = book.views;
            row["created_at"] = book.created_at;
            row["updated_at"] = book.updated_at;
            row["status"] = book.status;
            row["photoPath"] = book.photoPath;
            row["storage_location"] = book.storage_location;

            Singleton.getInstance.DataSet.Tables["Books"].Rows.Add(row);

            MessageBox.Show("Thêm sách thành công");
        }

        public void UpdateBook(Book book, int index)
        {
            DataRow row = Singleton.getInstance.DataSet.Tables["Books"].Rows[index];
            row["name"] = book.name;
            row["description"] = book.description;
            row["author_id"] = book.author_id;
            row["public_at"] = book.public_at;
            row["genre_id"] = book.genre_id;
            row["publisher_id"] = book.publisher_id;
            row["quantity"] = book.quantity;
            row["remaining"] = book.remaining;
            row["rating"] = book.rating;
            row["views"] = book.views;
            row["created_at"] = book.created_at;
            row["updated_at"] = book.updated_at;
            row["status"] = book.status;
            row["photoPath"] = book.photoPath;
            row["storage_location"] = book.storage_location;

            MessageBox.Show("Cập nhật sách thành công");
        }

        public override void Load()
        {
            base.binding = Books;

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
            data.Columns["PublisherName"].HeaderText = "Tên nhà xuất bản";
            data.Columns["storage_location"].HeaderText = "Vị trí";

            data.Columns["genre_id"].Visible = false;
            data.Columns["author_id"].Visible = false;
            data.Columns["photoPath"].Visible = false;
            data.Columns["publisher_id"].Visible = false;

            data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            data.AllowUserToAddRows = false;
            data.AllowUserToDeleteRows = false;
        }

        public override void SaveChange()
        {
            try
            {
                //booksDataTable.AcceptChanges();
                adapter.Update(Singleton.getInstance.DataSet, "Books");
                MessageBox.Show("Cập nhật sách thành công");
                booksDataTable.AcceptChanges();
                //adapter.Fill(Singleton.getInstance.DataSet.Tables["Books"]);
                prevDataRow.Clear();
                seletedId.Clear();
            }catch(DBConcurrencyException e)
            {
                DialogResult result = MessageBox.Show("Dữ liệu đã bị thay đổi bởi người khác. Bạn có muốn tải lại dữ liệu?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Làm sạch dữ liệu cũ trong DataTable
                        Singleton.getInstance.DataSet.Tables["Books"].Clear();

                        // Tải lại dữ liệu từ cơ sở dữ liệu
                        adapter.Fill(Singleton.getInstance.DataSet.Tables["Books"]);

                        MessageBox.Show("Dữ liệu đã được làm mới.");
                    }
                    catch (Exception ex)
                    {
                        // Xử lý nếu có lỗi xảy ra
                        MessageBox.Show($"Lỗi khi tải lại dữ liệu: {ex.Message}");
                    }
                }

            }
        }
    }
}
