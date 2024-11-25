//using MoreLinq;
//using QLSach.Base;
//using QLSach.component;
//using QLSach.database;
//using QLSach.database.query;
//using QLSach.view.admin;
//using System;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace QLSach.Controller
//{
//    public class CategoryManagerController : ManagerBase
//    {
//        private CategoryQuery CategoryQuery = new CategoryQuery();
//        public CategoryManagerController(BindingSource binding, DataGridView data, Guna.UI2.WinForms.Guna2TextBox tb_search, Guna.UI2.WinForms.Guna2ComboBox cbb_fillter)
//        {
//            base.binding = binding;
//            base.data = data;
//            //base.tb_search = tb_search;
//            //base.cbb_fillter = cbb_fillter;
//        }

//        public override void Add()
//        {
//            throw new NotImplementedException();
//        }

//        public override void Load()
//        {
//            binding.DataSource = CategoryQuery.GetDetail().ToDataTable();
//            data.DataSource = binding;

//            data.Columns["Id"].HeaderText = "Mã sách";
//            data.Columns["Name"].HeaderText = "Tên sách";
//            data.Columns["Description"].HeaderText = "Mô tả";
//            data.Columns["BookCount"].HeaderText = "Số lượng sách";
//            data.Columns["create_at"].HeaderText = "Ngày tạo";
//            data.Columns["update_at"].HeaderText = "Ngày cập nhật";

//            List<Columns> columnNames = new List<Columns>();

//            foreach (DataGridViewColumn column in data.Columns)
//            {
//                columnNames.Add(new Columns(column.HeaderText, column.Name));
//            }

//            //cbb_fillter.DataSource = columnNames;
//            //cbb_fillter.DisplayMember = "HeaderText";
//            //cbb_fillter.ValueMember = "Name";
//        }

//        public override void Update()
//        {
//            throw new NotImplementedException();
//        }

//        public override void Delete()
//        {
//            var bookDataTable = (DataTable)binding.DataSource;

//            foreach (int index in seletedIndex)
//            {
//                bookDataTable.Rows.RemoveAt(index);
//                MessageBox.Show("index" + index);
//            }
//            foreach (int id in seletedId)
//            {
//                using (var context = new Context())
//                    context.Categories.Remove(context.Categories.Where(o => o.Id == id).First());
//            }
//            MessageBox.Show("Xóa dữ liệu thành công");

//            seletedIndex.Clear();
//            seletedId.Clear();
//        }
//    }
//}
