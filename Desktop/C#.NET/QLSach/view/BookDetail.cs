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

            pane_comment.Controls.Add(new comment());
        }

        private void BookDetail_Load(object sender, EventArgs e)
        {
            Node cur = Singleton.getInstance.State;
            Node node = new(this);
            cur.AddChild(node);

            Singleton.getInstance.State = node;
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
