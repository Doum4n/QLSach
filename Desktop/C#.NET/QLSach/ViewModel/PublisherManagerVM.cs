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
    public class PublisherManagerVM : ManagerBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        DataTable publisherDataTable;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private Context context = new Context();
        private BindingSource _genres = new BindingSource();
        private MySqlConnection connection = new MySqlConnection(Singleton.getInstance.connectionString);

        public PublisherManagerVM(DataGridView data)
        {
            base.data = data;
            Publishers.DataSource = context.Publisher.Select(o => new { o.Id, o.Name }) .ToDataTable();

            publisherDataTable = (DataTable)Publishers.DataSource;
            publisherDataTable.AcceptChanges();

            if (!Singleton.getInstance.DataSet.Tables.Contains("Publishers"))
            {
                publisherDataTable.TableName = "Publishers";
                Singleton.getInstance.DataSet.Tables.Add(publisherDataTable);
            }
            connection.Open();
            configuration();
        }

        private void configuration()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Publishers", connection);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
        }

        public BindingSource Publishers
        {
            get => _genres;
            set { _genres = value; OnPropertyChanged(); }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                base.Search();
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

        public void addPublisher(string genreName)
        {
            DataTable dataTable = (DataTable)Publishers.DataSource;
            DataRow row = dataTable.NewRow();
            row["Id"] = Convert.ToInt32(data.Rows[data.Rows.Count - 1].Cells["Id"].Value) + 1;
            row["Name"] = genreName;

            Singleton.getInstance.DataSet.Tables["Publishers"].Rows.Add(row);

            MessageBox.Show("Thêm nhà cung cấp thành công!");
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            base.binding = Publishers;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void SaveChange()
        {
            adapter.Update(Singleton.getInstance.DataSet, "Publishers");
            publisherDataTable.AcceptChanges();
            MessageBox.Show("Cập nhật thành công");
        }
    }
}
