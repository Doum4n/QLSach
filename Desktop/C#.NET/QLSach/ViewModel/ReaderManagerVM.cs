using MoreLinq;
using MySqlConnector;
using QLSach.Base;
using QLSach.component;
using QLSach.database.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.ViewModel
{
    public class ReaderManagerVM : ManagerBase
    {
        public BindingSource Books = new BindingSource();
        public BindingSource Reader = new BindingSource();

        DataTable BooksDataTable = new DataTable();
        DataTable ReaderDataTable = new DataTable();

        private Status_borrow _status = Status_borrow.Borrowed;
        public int UserId { get; set; }

        public ReaderManagerVM(DataGridView BookData) : base(BookData)
        {
            Reader.DataSource = context.Users
                .Where(o=> o.Role == database.models.Role.User)
                .Select(o => new { o.Id, o.Name, o.Age, o.Gender, o.create_at })
                .ToDataTable();

            BooksDataTable.TableName = "BooksReader";
            Singleton.getInstance.DataSet.Tables.Add(BooksDataTable);
            Books.DataSource = BooksDataTable;
        }

        public void LoadData()
        {
            //string query =
            //  @"SELECT b.id, b.name, b.description, g.name AS 'genreName', 
            // a.name AS 'authorName', p.Name AS 'publisherName' " +
            //  "FROM Books AS b " +
            //  "JOIN Register AS r ON b.Id = r.BookId " +
            //  "JOIN Genres AS g ON b.genre_id = g.id " +
            //  "JOIN Authors AS a ON a.Id = b.author_id " +
            //  "JOIN Publishers AS p ON p.Id = b.publisher_id " +
            //  $"WHERE UserId = {UserId}";

            Books.DataSource = context.Register
                .Select(o => new
                {
                    id = o.Book.Id,
                    o.UserId,
                    o.Status,
                    name = o.Book.name,
                    description = o.Book.description,
                    genreName = o.Book.Genre.name,
                    authorName = o.Book.author.name,
                    publisherName = o.Book.Publisher.Name
                })
                .Where(o => o.UserId == UserId)
                .Where(o => o.Status == Status)
                .ToDataTable();

            //MySqlCommand cmd = new MySqlCommand(query, connection);
            //adapter = new MySqlDataAdapter(cmd);
            //adapter.Fill(Singleton.getInstance.DataSet, "BooksReader");
        }

        public Status_borrow Status { get {return _status;} set { _status = value; LoadData();} }

        public override void Load()
        {
            data.Columns["id"].HeaderText = "Mã sách";
            data.Columns["name"].HeaderText = "Tên sách";
            data.Columns["description"].HeaderText = "Mô tả";
            data.Columns["genreName"].HeaderText = "Tên thể loại";
            data.Columns["authorName"].HeaderText = "Tên tác giả";
            data.Columns["publisherName"].HeaderText = "Tên nhà xuất bản";
        }
    }
}
