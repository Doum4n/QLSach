using Guna.UI2.AnimatorNS;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using QLSach.Base;
using QLSach.component;
using QLSach.database.models;
using QLSach.database.query;
using QLSach.view.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLSach.Controller
{
    public class addTocategoryController : ManagerBase
    {
        private CategoryQuery query = new CategoryQuery();
        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();

        public addTocategoryController(DataGridView data, BindingSource binding, Guna.UI2.WinForms.Guna2TextBox tb_search, Guna.UI2.WinForms.Guna2ComboBox cbb_fillter, DataGridViewCheckBoxColumn checkbox)
        {
            base.data = data;
            base.binding = binding;
            //base.tb_search = tb_search;
            //base.cbb_fillter = cbb_fillter;
            this.checkbox = checkbox;

        }
        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            List<Category> categories = query.getCategories();

            binding.DataSource = Singleton.getInstance.Data.Books.Select(o => new { o.Id, o.name, genre = o.Genre.name, o.description }).ToDataTable();
            data.DataSource = binding;
            checkbox.HeaderText = "Thêm";
            checkbox.FalseValue = false;
            checkbox.TrueValue = true;

            data.Columns.Add(checkbox);


            List<Columns> columnNames = new List<Columns>();

            foreach (DataGridViewColumn column in data.Columns)
            {
                columnNames.Add(new Columns(column.HeaderText, column.Name));
            }

            //cbb_fillter.DataSource = columnNames;
            //cbb_fillter.DisplayMember = "Headertext";
            //cbb_fillter.ValueMember = "Name";
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

    }
}
