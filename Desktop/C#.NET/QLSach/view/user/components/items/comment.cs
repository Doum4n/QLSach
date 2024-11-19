namespace QLSach.view.components.items
{
    public partial class comment : UserControl
    {
        public string Content { get; set; }
        public comment()
        {
            InitializeComponent();

            // Tạo một instance của CustomPictureBox
            CustomPictureBox customPictureBox = new CustomPictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(10, 10),
                BackColor = Color.Blue, // Màu nền cho PictureBox
                Image = Image.FromFile(".\\resources\\images\\book.png"), // Đường dẫn tới hình ảnh
                SizeMode = PictureBoxSizeMode.StretchImage // Cách hiển thị hình ảnh
            };

            avatar.Controls.Add(customPictureBox);
        }

        private void btn_reply_Click(object sender, EventArgs e)
        {

        }

        public void subComment()
        {
            this.Margin = new Padding(50, 5, 10, 5); // Left, Top, Right, Bottom
            this.Refresh();
        }

        private void comment_Load(object sender, EventArgs e)
        {
            textBox_comment.Text = Content;
        }
    }
}
