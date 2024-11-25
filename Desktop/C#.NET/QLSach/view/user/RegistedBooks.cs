using QLSach.component;
using QLSach.database;
using System.Data;

namespace QLSach.view.user
{
    public partial class RegistedBooks : UserControl
    {
        public int UserId { get; set; }

        public RegistedBooks()
        {
            InitializeComponent();
        }

        private void RegistedBooks_Load(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                Singleton.getInstance.RegisterHelper.registration_data.DataSource = context.Register
                .Where(o => o.UserId == Singleton.getInstance.UserId)
                .Where(o => o.register_at != null)
                .Select(o => new
                {
                    o.BookId,
                    o.register_at,
                    o.Status,
                }).ToList();

                data.DataSource = Singleton.getInstance.RegisterHelper.registration_data;
                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                button.Name = "button";
                button.HeaderText = "button";
                button.Text = "Hủy";
                button.UseColumnTextForButtonValue = true;
                data.Columns.Add(button);

                data.CellClick += (sender, e) =>
                {
                    if (e.ColumnIndex == data.Columns["button"].Index)
                    {
                        var bookId = data.Rows[e.RowIndex].Cells["BookId"].Value;
                        var register = context.Register
                            .First(
                                o => o.BookId == (int)bookId && o.UserId == Singleton.getInstance.UserId
                             );
                        Singleton.getInstance.RegisterHelper.registration_data.RemoveAt(e.RowIndex);
                        context.Register.Remove(
                            register
                        );
                        context.SaveChanges();
                        MessageBox.Show("Hủy thành công!");
                    }
                };
                Singleton.getInstance.State = new(this);
                Singleton.getInstance.MainFrameHelper.Node.AddChild(Singleton.getInstance.State);
            }
        }
    }
}
