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
        public BookDetail()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            BookQuery query = new BookQuery();
            Book? book1 = query.getBook(Singleton.getInstance.MainFrameHelper.Id);
            Name.Text = book1?.name;

            //string imagePath = Path.Combine("resources", "images", "poster.png");
            String imagePath = ".\\resources\\images\\book.png";
            Singleton.getInstance.BookHelper.ShowMyImage(picture, imagePath, 223, 350);

            tb_pane_comment.RowCount = 0;
            //tb_pane_comment.size
        }

        private void BookDetail_Load(object sender, EventArgs e)
        {
            Node cur = Singleton.getInstance.State;
            Node node = new(this);
            cur.AddChild(node);

            Singleton.getInstance.State = node;

            var comments = Singleton.getInstance.Data.Comments.Where(o => o.BookId == Singleton.getInstance.MainFrameHelper.Id).ToList();
            comments.ForEach(o =>
            {
                if (o.parent_id.HasValue)
                {
                    MessageBox.Show(comments.Count.ToString());
                    comment comment1 = new comment();
                    comment1.Content = o.content;
                    comment1.subComment();
                    tb_pane_comment.RowCount++;
                    tb_pane_comment.SetRow(comment1, tb_pane_comment.RowCount);
                    tb_pane_comment.Controls.Add(comment1);
                }
                else
                {

                    //MessageBox.Show("Has " + comments.Count.ToString());
                    //o.childrents.ForEach(o =>
                    //{
                    comment comment = new comment();
                    comment.Content = o.content;
                    tb_pane_comment.RowCount++;
                    tb_pane_comment.SetRow(comment, tb_pane_comment.RowCount);
                    tb_pane_comment.Controls.Add(comment);
                    //});
                }
            });
            //Singleton.getInstance.MainFrameHelper.Node.getLastChild().AddChild(Singleton.getInstance.State);

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
    }
}
