﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoreLinq;
using MySqlConnector;
using QLSach.Base;
using QLSach.component;
using QLSach.database;
using QLSach.dbContext.models;
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
        private BindingSource _genres = new BindingSource();

        public GenreManagerVM(DataGridView data) : base(data)
        {
            Genres.DataSource = context.Genre.ToDataTable();

            genresDataTable = (DataTable)Genres.DataSource;
            genresDataTable.AcceptChanges();

            genresDataTable.TableName = "Genres";
            if (!Singleton.getInstance.DataSet.Tables.Contains(genresDataTable.TableName))
                Singleton.getInstance.DataSet.Tables.Add(genresDataTable);
            configuration("SELECT * FROM Genres");
        }


        public BindingSource Genres
        {
            get => _genres;
            set { _genres = value;}
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

        public override void LoadData()
        {
            Books.DataSource = context.Books
              .Select(o => new
              {
                  o.Id,
                  o.name,
                  o.description,
                  o.genre_id
              })
              .Where(o => o.genre_id == Id)
              .ToDataTable();
        }

        public override void Load()
        {
            base.binding = Genres;

            data.Columns["id"].HeaderText = "Mã thể loại";
            data.Columns["name"].HeaderText = "Tên thể loại";
        }
    }
}
