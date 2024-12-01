using Guna.UI2.WinForms.Suite;
using MoreLinq;
using QLSach.Base;
using QLSach.component;
using QLSach.database.models;
using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.ViewModel
{
    public class StorageLocationManagerVM : ManagerBase
    {
        private BindingSource _location = new BindingSource();
        DataTable LocationDataTable;
        private StorageLocation _selectedUser;

        private List<string> selectedName = new List<string>();
        public string _locationName {  get; set; }
        private int _author;
        public string locationName { get { return _locationName; } set { _locationName = value; LoadData(); } }

        public StorageLocationManagerVM(DataGridView data) : base(data)
        {
            StorageLocation.DataSource = context.StorageLocations.Select(o => new { o.Name, o.Description }).ToDataTable();
            LocationDataTable = (DataTable)StorageLocation.DataSource;
            LocationDataTable.TableName = "StorageLocations";

            LocationDataTable.AcceptChanges();

            if (!Singleton.getInstance.DataSet.Tables.Contains("StorageLocations"))
            {
                Singleton.getInstance.DataSet.Tables.Add(LocationDataTable);
            }

            configuration("select * from StorageLocations");
        }

        public void addLocation(string Name, string Description)
        {
            DataRow row = LocationDataTable.NewRow();
            row["Name"] = Name;
            row["Description"] = Description;

            Singleton.getInstance.DataSet.Tables["StorageLocations"].Rows.Add(row);

            MessageBox.Show("Thêm vị trí thành công");
        }

        public void UpdateLocation(string Name, string Description, int index)
        {
            DataRow row = Singleton.getInstance.DataSet.Tables["StorageLocations"].Rows[index];
            row["Name"] = Name;
            row["Description"] = Description;

            MessageBox.Show("Cập nhật vị trí thành công");
        }

        public override void Load()
        {
            base.binding = StorageLocation;
        }

        public override void LoadData()
        {
            Books.DataSource = context.Books
             .Select(o => new
             {
                 o.Id,
                 o.name,
                 o.description,
                 o.storage_location
             })
             .Where(o => o.storage_location == locationName)
             .ToDataTable();
        }

        public override void Delete(string tableName, string idColumn)
        {
            List<DataRow> toDelete = new List<DataRow>();

            foreach (string name in selectedName)
            {
                foreach (DataRow row in Singleton.getInstance.DataSet.Tables[tableName].Rows)
                {
                    if (row.RowState != DataRowState.Deleted && row[idColumn].ToString() == name)
                    {
                        toDelete.Add(row);
                    }
                }
            }

            foreach (DataRow dr in toDelete)
            {
                dr.Delete();
            }
        }

        public override void addSelectedId(int index, string IdColumnsName)
        {
   
            var bookDataTable = (DataTable)binding.DataSource;
            if (!prevDataRow.ContainsKey(index))
            {
                DataRow prevRow = bookDataTable.NewRow();
                foreach (DataColumn column in bookDataTable.Columns)
                {
                    prevRow[column.ColumnName] = bookDataTable.Rows[index][column];
                }
                prevDataRow.Add(index, prevRow);
            }

            if (!selectedName.Contains(data.Rows[index].Cells[IdColumnsName].Value.ToString()))
                selectedName.Add(data.Rows[index].Cells[IdColumnsName].Value.ToString());
        }

        public BindingSource StorageLocation { get { return _location; } }
    }
}
