//using MoreLinq;
//using QLSach.Base;
//using QLSach.component;
//using QLSach.database;
//using QLSach.view.admin;
//using System.Data;

//namespace QLSach.Controller
//{
//    public class AuthorManagerController : ManagerBase
//    {
//        public AuthorManagerController(DataGridView data, BindingSource binding, Guna.UI2.WinForms.Guna2TextBox tb_search, Guna.UI2.WinForms.Guna2ComboBox cbb_fillter)
//        {
//            base.data = data;
//            base.binding = binding;
//            //base.tb_search = tb_search;
//            //base.cbb_fillter = cbb_fillter;
//        }
//        public override void Add()
//        {
//            //throw new NotImplementedException();
//            //AuthorManager authorManager = new AuthorManager();
//            //authorManager.
//        }

//        public override void Load()
//        {
//            using (var context = new Context())
//            {

//                binding.DataSource = context.Authors.ToDataTable();
//                data.DataSource = binding;


//                List<Columns> columnNames = new List<Columns>();
//                foreach (DataGridViewColumn column in data.Columns)
//                {
//                    columnNames.Add(new Columns(column.HeaderText, column.Name));
//                }

//                //cbb_fillter.DataSource = columnNames;
//                //cbb_fillter.DisplayMember = "HeaderText";
//                //cbb_fillter.ValueMember = "Name";
//            }
//        }

//        public override void Update()
//        {
//            throw new NotImplementedException();
//        }

//        public override void Delete()
//        {
//            var DataTable = (DataTable)binding.DataSource;

//            foreach (int index in seletedIndex)
//            {
//                DataTable.Rows.RemoveAt(index);
//            }
//            foreach (int id in seletedId)
//            {
//                try
//                {
//                    using (var context = new Context())
//                    {

//                        context.Authors.Remove(context.Authors.Where(o => o.Id == id).First());
//                    }
//                }
//                catch
//                {
//                    //MessageBox.Show();
//                }
//            }
//            MessageBox.Show("Xóa dữ liệu thành công");

//            seletedIndex.Clear();
//            seletedId.Clear();
//        }
//    }
//}
