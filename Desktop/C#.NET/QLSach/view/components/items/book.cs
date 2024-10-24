using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSach.component;
using QLSach.components;
using QLSach.controllers;

namespace QLSach.view.components.items
{
    public partial class book : UserControl
    {
        private int id;
        private Bitmap MyImage;

        public book()
        {
            InitializeComponent();

            //string imagePath = Path.Combine("resources", "images", "poster.png");
            String imagePath = ".\\resources\\images\\book.png";
            //ImageQuery query = new ImageQuery();
            //String imagePath = query.GetPhoto(1).path;
            //ShowMyImage(imagePath, 128, 154);
            Singleton.getInstance.BookHelper.ShowMyImage(picture, imagePath, 128, 164);
        }

        public void ShowMyImage(String fileToDisplay, int xSize, int ySize)
        {
            // Sets up an image object to be displayed.
            if (MyImage != null)
            {
                MyImage.Dispose();
            }

            // Stretches the image to fit the pictureBox.
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            MyImage = new Bitmap(fileToDisplay);
            picture.ClientSize = new Size(xSize, ySize);
            picture.Image = (Image)MyImage;
        }


        public String Name
        {
            get { return lb_name_Book.Text; }
            set { lb_name_Book.Text = value; }
        }

        public String Author
        {
            get { return lb_name_Author.Text; }
            set { lb_name_Author.Text = value; }
        }

        public String Source
        {
            get { return lb_source.Text; }
            set { lb_source.Text = value; }
        }

        private void onClick(object sender, EventArgs e)
        {
            Singleton.getInstance.MainFrameHelper.Id = id;
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(new BookDetail());
        }

        public int Id { get { return id; } set { id = value; } }
    }
}
