

namespace QLSach.view.admin
{
    public partial class BorrowRegisterManager : UserControl
    {

        public BorrowRegisterManager()
        {
            InitializeComponent();
        }

        private void RegisterManager_Load(object sender, EventArgs e)
        {
            pane_main.Controls.Add(new BorrowedManager());
        }
     

        private void btn_borrowed_Click(object sender, EventArgs e)
        {
            pane_main.Controls.Clear();
            pane_main.Controls.Add(new BorrowedManager());
        }

        private void btn_registed_Click(object sender, EventArgs e)
        {
            pane_main.Controls.Clear();
            pane_main.Controls.Add(new RegisterManager());
        }
    }
}
