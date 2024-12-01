using QLSach.component;
using QLSach.components;
using QLSach.database;
using QLSach.database.models;
using QLSach.database.query;
using QLSach.dbContext.models;
using QLSach.view.components;
using QLSach.view.components.items;
using System.Data;

namespace QLSach.view
{
    public partial class BookDetail : UserControl
    {
        BookQuery query = new BookQuery();
        private Pagination pagination;
        Book? book = new Book();
        private int id;
        public BookDetail(int id)
        {
            this.id = id;
            InitializeComponent();
        }


        private void BookDetail_Load(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                //ImageQuery imageQuery = new ImageQuery();
                book = query.getBook(id);
                NameBook.Text = book?.name;
                author.Text = query.getBookAuthor(book.Id);
                genre.Text = query.getBookGenre(book.Id);
                publication_year.Text = book.public_at.ToString();
                description.Text = book.description;
                status.Text = book.remaining > 0 ? Status.available.ToString() : Status.borrowed.ToString();
                lb_remaining.Text = book.remaining.ToString();


                loadImage.ShowImage(picture, book.photoPath, 223, 350);

                tb_pane_comment.RowCount = 0;

                Node cur = Singleton.getInstance.State;
                Node node = new(new BookDetail(id));
                cur.AddChild(node);

                Singleton.getInstance.State = node;

                // Comments
                var comments = context.Feedbacks.Where(o => o.BookId == id).Where(o => o.comment != null).ToList();
                comments.ForEach(cmt =>
                {
                        comment comment = new comment();
                        comment.Content = cmt.comment;
                        comment.Name = context.Users.Where(o => o.Id == cmt.UserId).Select(o => o.Name).First();
                        tb_pane_comment.RowCount++;
                        tb_pane_comment.SetRow(comment, tb_pane_comment.RowCount);
                        tb_pane_comment.Controls.Add(comment);
                });

                var rating = context.Feedbacks.Where(o => o.BookId == id).Select(o => o.rating).ToList();
                int count = rating.Count;
                float? sum = 0;
                rating.ForEach(rating => {
                    sum += rating;
                });
                if(count > 0)
                    RatingStar.Value = (float)(sum / count);

                //if(count > 0)
                //    book.rating = sum / count;
                //context.Books.Update(book);


                if (book.remaining > 0)
                {
                    btn.Text = "Mượn";
                }
                else
                {
                    btn.Text = "Đăng ký";
                }

                book.views = book.views + 1;
                context.Books.Update(book);
                context.SaveChanges();

                pagination = new(tbLayoutPane_book, 1, 4, 4);
                pagination.books = context.Books.Where(o => o.genre_id == book.genre_id).Take(10).ToList(); 
                pagination.LoadData();

            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                Feedback? feedback = context.Feedbacks
                    .Where(o => o.UserId == Singleton.getInstance.UserId)
                    .Where(o => o.BookId == id)
                    .FirstOrDefault();

                if (feedback == null)
                {
                    feedback = new Feedback();
                    feedback.UserId = Singleton.getInstance.UserId;
                    feedback.BookId = id;
                    feedback.rating = RatingStar.Value;
                    feedback.comment = textBox_comment.Text;
                    context.Feedbacks.Add(feedback);

                    comment comment = new comment();
                    comment.Content = textBox_comment.Text;
                    tb_pane_comment.RowCount++;
                    tb_pane_comment.SetRow(comment, tb_pane_comment.RowCount);
                    tb_pane_comment.Controls.Add(comment);
                }
                else
                {
                    feedback.comment = textBox_comment.Text;
                    context.Feedbacks.Update(feedback);
                    comment comment = new comment();
                    comment.Content = textBox_comment.Text;
                    tb_pane_comment.RowCount++;
                    tb_pane_comment.SetRow(comment, tb_pane_comment.RowCount);
                    tb_pane_comment.Controls.Add(comment);
                }

                context.SaveChanges();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                if (status.Text == Status.borrowed.ToString())
                {
                    Register register = new Register();
                    register.BookId = book.Id;
                    register.UserId = Singleton.getInstance.UserId;
                    register.Status = Status_borrow.Pending;
                    register.register_at = DateTime.Now;
                    context.Register.Add(register);
                    context.SaveChanges();
                    MessageBox.Show("Đăng ký thành công!");

                    Singleton.getInstance.RegisterHelper.registration_data.Add(new { register.BookId, register.register_at, register.Status });
                }
            }
        }

        private void RatingStar_click(object sender, EventArgs e)
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
                        rating = RatingStar.Value, // Lấy giá trị từ RatingStar
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };
                    context.Feedbacks.Add(feedback);

                }
                else
                {
                    // Nếu feedback tồn tại, cập nhật giá trị rating
                    feedback.rating = RatingStar.Value;
                    feedback.updated_at = DateTime.Now;

                    context.Feedbacks.Update(feedback);
                }

                var book = context.Books.Where(o => o.Id == id).First();
                book.rating = RatingStar.Value;
                context.Books.Update(book);

                context.SaveChanges();
            }
        }
    }
}
