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
        }

        public override void SaveChange()
        {
            adapter.Update(Singleton.getInstance.DataSet, "Publishers");
            publisherDataTable.AcceptChanges();
            MessageBox.Show("Cập nhật thành công", "");
        }
    }
}