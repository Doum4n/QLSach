using QLSach.component;
using QLSach.components;
using QLSach.database;
using QLSach.database.models;
using QLSach.database.query;
using QLSach.dbContext.models;

namespace QLSach.view.components.items
{
    public partial class BookMostView : UserControl
    {
        public string bookName { get; set; }
        public string author { get; set; }
        private int id;
        public string index { get; set; }
        public string views { get; set; }
        public Status status { get; set; }
        public BookMostView(int id)
        {
            this.id = id;
            InitializeComponent();
            using (Context context = new Context())
            {
                String? imagePath = context.Books.Where(o => o.Id == id).Select(o => o.photoPath).First();
                loadImage.ShowImage(picture, imagePath, 153, 203);
            }

            timer1.Interval = 100; // Thiết lập khoảng thời gian giữa mỗi lần Tick (100ms)
            timer1.Start(); // Khởi động timer
        }

        private void BookMostView_Load(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void LoadDate()
        {
            this.lb_author.Text = author;
            this.lb_bookName.Text = bookName;
            this.lb_index.Text = index;
            this.lb_status.Text = status.ToString();
            using (Context context1 = new Context())
                this.lb_reading.Text = context1.Books.Where(o => o.Id == id).Select(o => o.views).First().ToString();

            if (status == Status.borrowed)
                btn_borrow.Text = "Đăng ký";
            else
                btn_borrow.Text = "Mượn";

            using (Context context = new Context())
            {
                var rating = context.Feedbacks.Where(o => o.BookId == id).Select(o => o.rating).ToList();
                int count = rating.Count;
                float? sum = 0;
                rating.ForEach(rating =>
                {
                    sum += rating;
                });
                if (count > 0)
                    ratingStar.Value = (float)(sum / count);

            }
        }

        private void onClick(object sender, EventArgs e)
        {
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(new BookDetail(id));
        }

        private void btn_borrow_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                if (status == Status.borrowed)
                {
                    Register register = new Register();
                    register.BookId = id;
                    register.UserId = Singleton.getInstance.UserId;
                    register.Status = Status_borrow.Pending;
                    register.register_at = DateTime.Now;
                    context.Register.Add(register);
                    context.SaveChanges();
                    MessageBox.Show("Đăng ký thành công!");

                    Singleton.getInstance.RegisterHelper.registration_data.Add(new { register.BookId, register.register_at, register.Status });
                }
                else
                {

                }
            }
        }

        private void rating_click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                Feedback? feedback = context.Feedbacks
                                  .Where(o => o.UserId == Singleton.getInstance.UserId)
                                  .Where(o => o.BookId == id)
                                  .FirstOrDefault();

                if (feedback == null)
                {
                    // Nếu feedback không tồn tại, tạo một feedback mới
                    feedback = new Feedback
                    {
                        UserId = Singleton.getInstance.UserId,
                        BookId = id,
                        rating = ratingStar.Value, // Lấy giá trị từ RatingStar
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };
                    context.Feedbacks.Add(feedback);
                }
                else
                {
                    // Nếu feedback tồn tại, cập nhật giá trị rating
                    feedback.rating = ratingStar.Value;
                    feedback.updated_at = DateTime.Now;

                    context.Feedbacks.Update(feedback);
                }

                context.SaveChanges();
            }
        }

        private void OnVisible(object sender, EventArgs e)
        {
            using (Context context1 = new Context())
                this.lb_reading.Text = context1.Books.Where(o => o.Id == id).Select(o => o.views).First().ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
