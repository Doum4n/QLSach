using MoreLinq;
using QLSach.component;
using QLSach.interfaces;
using System.Data;


namespace QLSach.Base
{
    public abstract class ManagerBase : IManager
    {
        protected Dictionary<int, DataRow> prevDataRow = new Dictionary<int, DataRow>();
        protected List<int> seletedIndex = new List<int>();
        protected List<int> seletedId = new List<int>();

        protected BindingSource binding = new BindingSource();
        protected DataGridView data = new DataGridView();
        protected Guna.UI2.WinForms.Guna2TextBox tb_search;
        protected Guna.UI2.WinForms.Guna2ComboBox cbb_fillter;

        public abstract void Add();
        public virtual void Delete()
        {
            var bookDataTable = (DataTable)binding.DataSource;

            foreach (int index in seletedIndex)
            {
                bookDataTable.Rows.RemoveAt(index);
            }
            foreach (int bookId in seletedId)
            {
                Singleton.getInstance.Data.Books.Remove(Singleton.getInstance.Data.Books.Where(o => o.Id == bookId).First());
            }
            MessageBox.Show("Xóa dữ liệu thành công");

            seletedIndex.Clear();
            seletedId.Clear();
        }

        public abstract void Load();

        public virtual void Rollback()
        {
            if (prevDataRow.Count > 0)
            {
                var bookDataTable = (DataTable)binding.DataSource;

                prevDataRow.ForEach(row =>
                {
                    bookDataTable.Rows.InsertAt(row.Value, row.Key);
                });

                prevDataRow.Clear();

                MessageBox.Show("Hoàn tác thành công");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hoàn tác");
            }
        }

        public virtual void SaveChange()
        {
            Singleton.getInstance.Data.SaveChanges();
            MessageBox.Show("Đã cập nhật vào cơ sở dữ liệu");
            prevDataRow.Clear();
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

        public virtual void addPrevRows(int index, DataRow dataRow)
        {
            if (!prevDataRow.ContainsKey(index))
            {
                //bookDataTable.AcceptChanges();
                var bookDataTable = (DataTable)binding.DataSource;

                // rollback when cancel is clicked
                bookDataTable = (DataTable)binding.DataSource;
                DataRow prevRow = bookDataTable.NewRow();
                foreach (DataColumn column in bookDataTable.Columns)
                {
                    prevRow[column.ColumnName] = bookDataTable.Rows[index][column];
                }
                prevDataRow.Add(index, prevRow);
            }
        }
    }
}
