using QLSach.component;
using QLSach.controllers;
using QLSach.database.models;
using QLSach.dbContext.models;
using QLSach.view.components.items;
using System.Data;

namespace QLSach.view
{
    public partial class BookDetail : UserControl
    {
        BookQuery query = new BookQuery();
        Book? book = new Book();
        private int id;
        public BookDetail(int id)
        {
            this.id = id;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {

        }

        private void BookDetail_Load(object sender, EventArgs e)
        {
            ImageQuery imageQuery = new ImageQuery();
            book = query.getBook(id);
            Name.Text = book?.name;
            author.Text = query.getBookAuthor(book.Id);
            genre.Text = query.getBookGenre(book.Id);
            publication_year.Text = book.year_public.ToString();
            description.Text = book.description;
            status.Text = book.remaining > 0 ? Status.available.ToString() : Status.borrowed.ToString();
            lb_remaining.Text = book.remaining.ToString();

            String imagePath = imageQuery.GetPhoto(id);
            Singleton.getInstance.LoadImg.ShowMyImage(picture, imagePath, 223, 350);

            tb_pane_comment.RowCount = 0;

            Node cur = Singleton.getInstance.State;
            Node node = new(new BookDetail(id));
            cur.AddChild(node);

            Singleton.getInstance.State = node;

            var comments = Singleton.getInstance.Data.Comments.Where(o => o.BookId == Singleton.getInstance.MainFrameHelper.Id).ToList();
            comments.ForEach(o =>
            {
                if (o.parent_id.HasValue)
                {
                    comment comment1 = new comment();
                    comment1.Content = o.content;
                    comment1.subComment();
                    tb_pane_comment.RowCount++;
                    tb_pane_comment.SetRow(comment1, tb_pane_comment.RowCount);
                    tb_pane_comment.Controls.Add(comment1);
                }
                else
                {
                    comment comment = new comment();
                    comment.Content = o.content;
                    tb_pane_comment.RowCount++;
                    tb_pane_comment.SetRow(comment, tb_pane_comment.RowCount);
                    tb_pane_comment.Controls.Add(comment);
                }
            });

            if (book.remaining > 0)
            {
                btn.Text = "Mượn";
            }
            else
            {
                btn.Text = "Đăng ký";
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.Data.Comments.Add(
                new Comment(textBox_comment.Text,
                            1,
                            Singleton.getInstance.MainFrameHelper.Id)
            );

            Singleton.getInstance.Data.SaveChanges();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (status.Text == Status.borrowed.ToString())
            {
                Register register = new Register();
                register.BookId = book.Id;
                register.UserId = Singleton.getInstance.UserId;
                register.Status = Status_borrow.Pending;
                register.register_at = DateTime.Now;
                Singleton.getInstance.Data.Register.Add(register);
                Singleton.getInstance.Data.SaveChanges();
                MessageBox.Show("Đăng ký thành công!");

                Singleton.getInstance.RegisterHelper.registration_data.Add(new { register.BookId, register.register_at, register.Status });
            }
        }
    }
}
