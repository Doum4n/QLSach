using Guna.UI2.WinForms.Suite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoreLinq;
using MySqlConnector;
using QLSach.Base;
using QLSach.component;
using QLSach.database;
using QLSach.database.models;
using QLSach.database.query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDevHtmlRenderer.Adapters;

namespace QLSach.ViewModel
{
    public class CategoryManagerVM : ManagerBase, INotifyPropertyChanged
    {
        private CategoryQuery CategoryQuery = new CategoryQuery();

        private BindingSource _categories = new BindingSource();
        DataTable catogoryDataTable;

        public CategoryManagerVM(DataGridView data) : base(data)
        {
            Categories.DataSource = CategoryQuery.GetDetail().ToDataTable();

            catogoryDataTable = (DataTable)Categories.DataSource;
            catogoryDataTable.AcceptChanges();
            catogoryDataTable.TableName = "Categories";
            Singleton.getInstance.DataSet.Tables.Add(catogoryDataTable);

            configuration("SELECT * FROM Categories");
        }

        public BindingSource Categories
        {
            get => _categories;
            set { _categories = value; OnPropertyChanged(); }
        }


        public void AddCategory(string name, string description)
        {
                DataTable dataTable = (DataTable)Categories.DataSource;

                DataRow newRow = dataTable.NewRow();
                newRow["Id"] = Convert.ToInt32(data.Rows[dataTable.Rows.Count - 1].Cells["Id"].Value) + 1;
                newRow["Name"] = name;
                newRow["Description"] = description;
                newRow["BookCount"] = 0;
                newRow["create_at"] = DateOnly.FromDateTime(DateTime.Now);
                newRow["update_at"] = DateOnly.FromDateTime(DateTime.Now);

                Singleton.getInstance.DataSet.Tables["Categories"].Rows.Add(newRow);

                MessageBox.Show("Thêm danh mục thành công");
        }

        public void updateCategory(int id, string name, string description, int bookCount, DateOnly create_at, int index)
        {
            DataTable dataTable = (DataTable)Categories.DataSource;
            DataRow row = Singleton.getInstance.DataSet.Tables["Categories"].Rows[index];
            row["Id"] = id;
            row["Name"] = name;
            row["Description"] = description;
            row["BookCount"] = bookCount;
            row["create_at"] = create_at;
            row["update_at"] = DateOnly.FromDateTime(DateTime.Now);

            MessageBox.Show("Cập nhật danh mục thành công");
        }

        public override void Load()
        {
            base.binding = Categories;
        }

        public override void SaveChange()
        {
            adapter.Update(Singleton.getInstance.DataSet, "Categories");
            MessageBox.Show("Cập nhật danh mục thành công");
            catogoryDataTable.AcceptChanges();
            prevDataRow.Clear();
        }
    }
}
