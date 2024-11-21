using QLSach.component;
using QLSach.components;
using QLSach.database.models;
using QLSach.database.query;
using Status = QLSach.dbContext.models.Status;

namespace QLSach.view.components.items
{
    public partial class BookMostPopular : UserControl
    {
        public string bookName { get; set; }
        public string author { get; set; }
        private int id;
        public string index { get; set; }
        public string info { get; set; }
        public dbContext.models.Status status { get; set; }
        public BookMostPopular(int id)
        {
            this.id = id;
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            ImageQuery query = new ImageQuery();

            String? imagePath = query.GetPhoto(id);
            loadImage.ShowImage(picture, imagePath, 153, 203);
        }

        private void onClick(object sender, EventArgs e)
        {
            //Singleton.getInstance.MainFrameHelper.Id = id;
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(new BookDetail(id));
        }

        private void BookMostPopular_Load(object sender, EventArgs e)
        {
            this.lb_author.Text = author;
            this.lb_bookName.Text = bookName;
            this.lb_index.Text = index;
            this.lb_status.Text = status.ToString();
            this.tb_info.Text = info;

            if (status == Status.borrowed)
                btn_register.Text = "Đăng ký";
            else
                btn_register.Text = "Mượn";
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (status == Status.borrowed)
            {
                Register register = new Register();
                register.BookId = id;
                register.UserId = Singleton.getInstance.UserId;
                register.Status = Status_borrow.Pending;
                register.register_at = DateTime.Now;
                Singleton.getInstance.Data.Register.Add(register);
                Singleton.getInstance.Data.SaveChanges();
                MessageBox.Show("Đăng ký thành công!");

                Singleton.getInstance.RegisterHelper.registration_data.Add(new { register.BookId, register.register_at, register.Status });
            }
            else
            {

            }
        }
    }
}
