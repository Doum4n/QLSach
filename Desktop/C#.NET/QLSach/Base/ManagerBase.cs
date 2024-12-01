using MoreLinq;
using MySqlConnector;
using QLSach.component;
using QLSach.database;
using QLSach.dbContext.models;
using QLSach.view.admin;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TheArtOfDevHtmlRenderer.Adapters;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace QLSach.Base
{
    public abstract class ManagerBase : INotifyPropertyChanged
    {
        protected Dictionary<int, DataRow> prevDataRow = new Dictionary<int, DataRow>();
        protected List<int> seletedIndex = new List<int>();
        protected List<int> seletedId = new List<int>();

        protected BindingSource binding = new BindingSource();
        protected DataGridView data = new DataGridView();

        private List<int> CheckboxState = new List<int>();

        protected string _searchText;
        protected string _selectedFilter;

        protected MySqlDataAdapter adapter = new MySqlDataAdapter();
        protected Context context = new Context();
        protected MySqlConnection connection = new MySqlConnection(Singleton.getInstance.connectionString);

        // Sự kiện khi một thuộc tính đăng ký thay đổi
        public event PropertyChangedEventHandler? PropertyChanged;

        // Hiện thị sách khi nhấn vào một mục cụ thể (id)
        public BindingSource Books = new BindingSource();
        private int _id;
        public int Id { get { return _id; } set { _id = value; LoadData(); } }

        public virtual void LoadData()
        {
            
        }

        protected ManagerBase(DataGridView data)
        {
            this.data = data;

            data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            data.AllowUserToAddRows = false;
            data.AllowUserToDeleteRows = false;

            connection.Open();
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                Search();
            }
        }

        public string SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                if (_selectedFilter != value)
                {
                    _selectedFilter = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Delete(string tableName, string idColumn)
        {
            List<DataRow> toDelete = new List<DataRow>();

            foreach (int id in seletedId)
            {
                foreach (DataRow row in Singleton.getInstance.DataSet.Tables[tableName].Rows)
                {
                    if (row.RowState != DataRowState.Deleted && Convert.ToInt32(row[idColumn]) == id)
                    {
                        toDelete.Add(row);
                    }
                }
            }

            foreach (DataRow dr in toDelete)
            {
                dr.Delete();
            }

            if (adapter.DeleteCommand == null)
            {
                MySqlCommand deleteCommand = new MySqlCommand(
                    $"DELETE FROM {tableName} WHERE {idColumn} = @id", connection);
                deleteCommand.Parameters.Add("@id", MySqlDbType.Int32, 4).SourceColumn = idColumn;
                adapter.DeleteCommand = deleteCommand;
            }
        }

        protected void configuration(string selectString)
        {
            adapter = new MySqlDataAdapter(selectString, connection);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

            // loại bỏ cơ chế Optimistic Concurrency
            builder.ConflictOption = ConflictOption.OverwriteChanges;
        }

        public abstract void Load();

        public virtual void Rollback(string tableName)
        {
            // Hoàn tác các thay đổi hiện tại
            //Singleton.getInstance.DataSet.Tables[tableName].RejectChanges();

            if (prevDataRow.Count > 0)
            {
                foreach (var row in prevDataRow)
                {
                    Singleton.getInstance.DataSet.Tables[tableName].Rows.InsertAt(row.Value, row.Key);
                }
            }

            Singleton.getInstance.DataSet.Tables[tableName].AcceptChanges();

            MessageBox.Show("Hoàn tác thành công");
            prevDataRow.Clear();
            seletedId.Clear();
        }

        public virtual void SaveChange(string tableName)
        {
            try
            {
                binding.ResetBindings(true);
                adapter.Update(Singleton.getInstance.DataSet, tableName);
                prevDataRow.Clear();
                seletedId.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Hoàn tác dữ liệu
        public virtual void addSelectedId(int index, string IdColumnsName)
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

            if (!seletedId.Contains(Convert.ToInt32(data.Rows[index].Cells[IdColumnsName].Value)))
                seletedId.Add(Convert.ToInt32(data.Rows[index].Cells[IdColumnsName].Value));
        }

        public virtual void Search()
        {
            binding.Filter = $"CONVERT({_selectedFilter}, System.String) LIKE '%{_searchText}%'";
            if (_searchText == "")
            {
                binding.RemoveFilter();
            }
        }

        // Sử dụng trong chức năng thêm sách cho danh mục
        // lưu trạng thái của checkbox
        // Phục vụ mục đích tìm kiếm
        public virtual void SaveCheckboxStates(DataGridViewCheckBoxColumn checkbox, List<int> EntitiesId)
        {
            CheckboxState.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i].Cells["Id"].Value != null)
                {
                    int id = Convert.ToInt32(data.Rows[i].Cells["Id"].Value);

                    if (EntitiesId.Contains(id))
                    {
                        data.Rows[i].Cells[checkbox.Name].Value = true;
                        CheckboxState.Add(id);
                    }
                    else
                    {
                        data.Rows[i].Cells[checkbox.Name].Value = false;
                    }
                }
            }
        }

        // Phục hồi trạng thái của checkbox khi tìm kiếm
        public virtual void RestoreCheckboxStates(DataGridViewCheckBoxColumn checkbox)
        {
            for (int i = 0; i < binding.Count; i++)
            {
                if (CheckboxState.Contains(Convert.ToInt32(data.Rows[i].Cells["Id"].Value)))
                {
                    data.Rows[i].Cells[checkbox.Name].Value = true;
                }
                else
                {
                    data.Rows[i].Cells[checkbox.Name].Value = false;
                }
            }
        }

        public virtual void AssignFillterList(Guna.UI2.WinForms.Guna2ComboBox cbb_fillter)
        {
            List<Columns> Columns = new List<Columns>();
            foreach (DataGridViewColumn column in data.Columns)
            {
                Columns.Add(new Columns(column.HeaderText, column.Name));
            }
            cbb_fillter.DataSource = Columns;
            cbb_fillter.DisplayMember = "HeaderText";
            cbb_fillter.ValueMember = "Name";
        }
    }
}
