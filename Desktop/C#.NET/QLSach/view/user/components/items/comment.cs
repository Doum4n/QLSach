namespace QLSach.view.components.items
{
    public partial class comment : UserControl
    {
        public string Content { get; set; }
        public string Name { get; set; }
        public comment()
        {
            InitializeComponent();
        }

        private void btn_reply_Click(object sender, EventArgs e)
        {

        }

        private void comment_Load(object sender, EventArgs e)
        {
            textBox_comment.Text = Content;
            lb_name.Text = Name;
        }
    }
}
