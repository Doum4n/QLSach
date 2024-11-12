using Guna.UI2.WinForms.Suite;
using QLSach.component;
using QLSach.controllers;
using QLSach.database.models;
using QLSach.dbContext.models;
using QLSach.view.components.items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.view
{
    public partial class BookDetail : UserControl
    {
        BookQuery query = new BookQuery();
        Book? bookQuery = new Book();
        public BookDetail()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            bookQuery = query.getBook(Singleton.getInstance.MainFrameHelper.Id);
            Name.Text = bookQuery?.name;
            author.Text = query.getBookAuthor(bookQuery.Id);
            genre.Text = query.getBookGenre(bookQuery.Id);
            publication_year.Text = bookQuery.year_public.ToString();
            description.Text = bookQuery.description;
            status.Text = bookQuery.remaining > 0 ? Status.available.ToString() : Status.borrowed.ToString();
            lb_remaining.Text = bookQuery.remaining.ToString();

            String imagePath = ".\\resources\\images\\book.png";
            Singleton.getInstance.LoadImg.ShowMyImage(picture, imagePath, 223, 350);

            tb_pane_comment.RowCount = 0;
        }

        private void BookDetail_Load(object sender, EventArgs e)
        {
            bookQuery = query.getBook(Singleton.getInstance.MainFrameHelper.Id);

            Node cur = Singleton.getInstance.State;
            Node node = new(this);
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

            if (bookQuery.remaining > 0)
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
            if(status.Text == Status.borrowed.ToString())
            {
                Register register = new Register();
                register.BookId = bookQuery.Id;
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
