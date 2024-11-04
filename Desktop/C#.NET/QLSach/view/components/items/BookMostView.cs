using QLSach.component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.view.components.items
{
    public partial class BookMostView : UserControl
    {
        public string bookName { get; set; }
        public string author { get; set; }
        public int id { get; set; }
        public string index { get; set; }
        public string views {  get; set; }
        public BookMostView()
        {
            InitializeComponent();
            String imagePath = ".\\resources\\images\\book.png";
            Singleton.getInstance.BookHelper.ShowMyImage(picture, imagePath, 153, 203);
        }

        private void BookMostView_Load(object sender, EventArgs e)
        {
            this.lb_author.Text = author;
            this.lb_bookName.Text = bookName;
            this.lb_index.Text = index;
            this.lb_reading.Text = views.ToString();
        }

        private void btn_wantToRead_Click(object sender, EventArgs e)
        {

        }

        private void onClick(object sender, EventArgs e)
        {
            Singleton.getInstance.MainFrameHelper.Id = id;
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(new BookDetail());
        }
    }
}
