using MoreLinq;
using QLSach.Base;
using QLSach.component;
using QLSach.database.query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.Controller
{
    public class CategoryManagerController : ManagerBase
    {
        private CategoryQuery CategoryQuery = new CategoryQuery();
        public CategoryManagerController(BindingSource binding, DataGridView data, Guna.UI2.WinForms.Guna2TextBox tb_search, Guna.UI2.WinForms.Guna2ComboBox cbb_fillter)
        {
            base.binding = binding;
            base.data = data;
            base.tb_search = tb_search;
            base.cbb_fillter = cbb_fillter;
        }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            binding.DataSource = CategoryQuery.GetDetail().ToDataTable();
            data.DataSource = binding;



            List<string> columnNames = new List<string>();

            foreach (DataGridViewColumn column in data.Columns)
            {
                columnNames.Add(column.HeaderText);
            }

            cbb_fillter.DataSource = columnNames;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            var bookDataTable = (DataTable)binding.DataSource;

            foreach (int index in seletedIndex)
            {
                bookDataTable.Rows.RemoveAt(index);
                MessageBox.Show("index" + index);
            }
            foreach (int id in seletedId)
            {
                Singleton.getInstance.Data.Categories.Remove(Singleton.getInstance.Data.Categories.Where(o => o.Id == id).First());
            }
            MessageBox.Show("Xóa dữ liệu thành công");

            seletedIndex.Clear();
            seletedId.Clear();
        }
    }
}
