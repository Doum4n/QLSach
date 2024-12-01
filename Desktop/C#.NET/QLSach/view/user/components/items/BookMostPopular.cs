using QLSach.component;
using QLSach.components;
using QLSach.database;
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
            using (Context context = new Context())
            {
                String? imagePath = context.Books.Where(o => o.Id == id).Select(o => o.photoPath).First();
                loadImage.ShowImage(picture, imagePath, 153, 203);
            }
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

            updateRating();
        }

        private void updateRating()
        {
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

                var book = context.Books.Where(o => o.Id == id).First();
                book.rating = ratingStar.Value;
                context.Books.Update(book);
                context.SaveChanges();
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {

            if (status == Status.borrowed)
            {
                using (var context = new Context())
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
            }
            else
            {

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

                updateRating();

                context.SaveChanges();
            }
        }
    }
}
