using QLSach.component;
using QLSach.database;
using QLSach.database.models;
using QLSach.dbContext.models;
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
        public string views { get; set; }
        public Status status { get; set; }
        public BookMostView()
        {
            InitializeComponent();
            String imagePath = ".\\resources\\images\\book.png";
            Singleton.getInstance.LoadImg.ShowMyImage(picture, imagePath, 153, 203);
        }

        private void BookMostView_Load(object sender, EventArgs e)
        {
            this.lb_author.Text = author;
            this.lb_bookName.Text = bookName;
            this.lb_index.Text = index;
            this.lb_reading.Text = views.ToString();
            this.lb_status.Text = status.ToString();

            if (status == Status.borrowed)
                btn_borrow.Text = "Đăng ký";
            else
                btn_borrow.Text = "Mượn";
        }

        private void onClick(object sender, EventArgs e)
        {
            Singleton.getInstance.MainFrameHelper.Id = id;
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(new BookDetail());
        }

        private void btn_borrow_Click(object sender, EventArgs e)
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

                Singleton.getInstance.RegisterHelper.registration_data.Add(new {register.BookId, register.register_at, register.Status});
            }
            else
            {

            }        
        }
    }
}
