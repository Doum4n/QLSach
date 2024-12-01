using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoreLinq;
using MySqlConnector;
using QLSach.Base;
using QLSach.component;
using QLSach.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace QLSach.ViewModel
{
    public class PublisherManagerVM : ManagerBase
    {
        DataTable publisherDataTable;

        private BindingSource _genres = new BindingSource();
        public BindingSource Books = new BindingSource();

        private int _publisher;
        public int PublisherId { get { return _publisher; } set { _publisher = value; LoadData(); } }

        public PublisherManagerVM(DataGridView data) : base(data)
        {

            Publishers.DataSource = context.Publisher.Select(o => new { o.Id, o.Name }) .ToDataTable();

            publisherDataTable = (DataTable)Publishers.DataSource;
            publisherDataTable.AcceptChanges();

            if (!Singleton.getInstance.DataSet.Tables.Contains("Publishers"))
            {
                publisherDataTable.TableName = "Publishers";
                Singleton.getInstance.DataSet.Tables.Add(publisherDataTable);
            }
            configuration("select * from Publishers");
        }

        public BindingSource Publishers
        {
            get => _genres;
            set { _genres = value; OnPropertyChanged(); }
        }

        public void addPublisher(string genreName)
        {
            DataTable dataTable = (DataTable)Publishers.DataSource;
            DataRow row = dataTable.NewRow();
            row["Id"] = Convert.ToInt32(data.Rows[data.Rows.Count - 1].Cells["Id"].Value) + 1;
            row["Name"] = genreName;

            Singleton.getInstance.DataSet.Tables["Publishers"].Rows.Add(row);

            MessageBox.Show("Thêm nhà cung cấp thành công!");
        }

        public override void Load()
        {
            base.binding = Publishers;

            data.Columns["Id"].HeaderText = "Mã nhà xuất bản";
            data.Columns["Name"].HeaderText = "Tên nhà xuất bản";
        }

        public void LoadData()
        {
            Books.DataSource = context.Books
              .Select(o => new
              {
                  o.Id,
                  o.name,
                  o.description,
                  o.publisher_id
              })
              .Where(o => o.publisher_id == PublisherId)
              .ToDataTable();
        }

        public override void SaveChange(string tableName)
        {
            base.SaveChange(tableName);
            publisherDataTable.AcceptChanges();
            MessageBox.Show("Cập nhật thành công", "");
        }
    }
}