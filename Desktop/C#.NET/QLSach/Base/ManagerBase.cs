using MoreLinq;
using QLSach.component;
using QLSach.database;
using QLSach.dbContext.models;
using QLSach.interfaces;
using QLSach.view.admin;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace QLSach.Base
{
    public abstract class ManagerBase : IManager
    {
        protected Dictionary<int, DataRow> prevDataRow = new Dictionary<int, DataRow>();
        protected List<int> seletedIndex = new List<int>();
        protected List<int> seletedId = new List<int>();

        protected BindingSource binding = new BindingSource();
        protected DataGridView data = new DataGridView();

        private List<int> CheckboxState = new List<int>();

        protected string _searchText;
        protected string _selectedFilter;

        public abstract void Add();
        public virtual void Delete()
        {
            var DataTable = (DataTable)binding.DataSource;

            foreach (int index in seletedIndex)
            {
                DataTable.Rows.RemoveAt(index);
            }
            foreach (int bookId in seletedId)
            {
                try
                {
                    using (var context = new Context())
                    {

                        context.Books.Remove(context.Books.Where(o => o.Id == bookId).First());
                    }
                }
                catch
                {
                    //MessageBox.Show();
                }
            }
            MessageBox.Show("Xóa dữ liệu thành công");

            seletedIndex.Clear();
            seletedId.Clear();
        }

        public abstract void Load();

        public virtual void Rollback()
        {
            var bookDataTable = (DataTable)binding.DataSource;
            //bookDataTable.RejectChanges();
            //if (prevDataRow.Count > 0)
            //{
            //    prevDataRow.ForEach(row =>
            //    {
            //        bookDataTable.Rows.InsertAt(row.Value, row.Key);
            //    });
            //}

            //prevDataRow.Clear();

            bookDataTable.RejectChanges();
            MessageBox.Show("Hoàn tác thành công");
        }

        public virtual void SaveChange()
        {
            
        }
        public abstract void Update();

        public virtual void setRollbackList(List<int> selectedIndex, List<int> seletedBookId)
        {
            this.seletedIndex = selectedIndex;
            this.seletedId = seletedBookId;
        }

        public virtual void setPrevRows(Dictionary<int, DataRow> prevDataRow)
        {
            this.prevDataRow = prevDataRow;
        }

        // Hoàn tác dữ liệu
        public virtual void addPrevRows(int index, string IdColumnsName)
        {
            var bookDataTable = (DataTable)binding.DataSource;
            if (!prevDataRow.ContainsKey(index))
            {

                DataRow prevRow = bookDataTable.NewRow();
                foreach (DataColumn column in bookDataTable.Columns)
                {
                    prevRow[column.ColumnName] = bookDataTable.Rows[index][column];
                }

                seletedId.Add(Convert.ToInt32(data.Rows[index].Cells[IdColumnsName].Value));
                prevDataRow.Add(index, prevRow);
            }
        }

        public virtual void Search()
        {
            binding.Filter = $"CONVERT({_selectedFilter}, System.String) LIKE '%{_searchText}%'";
            if (_searchText == "")
            {
                binding.RemoveFilter();
            }
        }

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
