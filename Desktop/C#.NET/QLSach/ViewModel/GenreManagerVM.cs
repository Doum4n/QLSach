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
    public class GenreManagerVM : ManagerBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        DataTable genresDataTable;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private Context context = new Context();
        private BindingSource _genres = new BindingSource();
        private MySqlConnection connection = new MySqlConnection(Singleton.getInstance.connectionString);

        public GenreManagerVM(DataGridView data)
        {
            base.data = data;
            Genres.DataSource = context.Genre.ToDataTable();

            genresDataTable = (DataTable)Genres.DataSource;
            genresDataTable.AcceptChanges();

            genresDataTable.TableName = "Genres";
            Singleton.getInstance.DataSet.Tables.Add(genresDataTable);
            connection.Open();
            configuration();
        }

        private void configuration()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Genres", connection);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
        }

        public BindingSource Genres
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

        public void addGenre(string genreName)
        {
            DataTable dataTable = (DataTable)Genres.DataSource;
            DataRow row = dataTable.NewRow();
            row["id"] = Convert.ToInt32(data.Rows[data.Rows.Count - 2].Cells["id"].Value) + 1;
            row["name"] = genreName;

            Singleton.getInstance.DataSet.Tables["Genres"].Rows.Add(row);

            MessageBox.Show("Thêm thể loại thành công!");
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
            base.binding = Genres;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void SaveChange()
        {
            adapter.Update(Singleton.getInstance.DataSet, "Genres");
        }
    }
}
