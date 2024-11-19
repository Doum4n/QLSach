using QLSach.component;

namespace QLSach.view
{
    public partial class DashBoard : UserControl
    {
        //Node node;
        private controllers.BookQuery dashBoard = new controllers.BookQuery();
        private int currentIndex = 0;

        public DashBoard()
        {
            InitializeComponent();
            Singleton.getInstance.MainFrameHelper.Path = "Trang chủ";
        }

        private void Init()
        {

        }
        private void DashBoard_Load(object sender, EventArgs e)
        {
            Singleton.getInstance.State = new Node(new DashBoard());
            Singleton.getInstance.MainFrameHelper.Node.AddChild(Singleton.getInstance.State);
        }

        private void btn_newlyUpdate_Click(object sender, EventArgs e)
        {
            pane.Controls.Clear();
            pane.Controls.Add(Singleton.getInstance.Initilize.PaneRecent);
        }


        private void btn_popula_Click(object sender, EventArgs e)
        {
            pane.Controls.Clear();
            pane.Controls.Add(Singleton.getInstance.Initilize.PanePopular);
        }

        private void btn_mostView_Click(object sender, EventArgs e)
        {
            pane.Controls.Clear();
            pane.Controls.Add(Singleton.getInstance.Initilize.PaneMostView);
        }
    }
}
