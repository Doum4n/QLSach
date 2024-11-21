using MoreLinq;
using QLSach.Base;
using QLSach.component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.Controller
{
    public class UserManagerController : ManagerBase
    {
        public UserManagerController(BindingSource binding, DataGridView data)
        {
            base.binding = binding;
            base.data = data;
        }
        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            binding.DataSource = Singleton.getInstance.Data.Users.ToDataTable();
            data.DataSource = binding;
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
            }
            foreach (int Id in seletedId)
            {
                try
                {
                    Singleton.getInstance.Data.Users.Remove(Singleton.getInstance.Data.Users.Where(o => o.Id == Id).First());
                }catch(Exception e) { }
            }
            MessageBox.Show("Xóa dữ liệu thành công");

            seletedIndex.Clear();
            seletedId.Clear();
        }
    }
}
