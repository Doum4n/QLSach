using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.components
{
    public class loadImage
    {
        public int genreId {  get; set; }
        public void ShowMyImage(PictureBox picture, string? fileToDisplay, int xSize, int ySize)
        {
            Bitmap MyImage;
            if (fileToDisplay != null) 
            {
                // Tải hình ảnh và gán vào PictureBox hiện tại
                MyImage = new Bitmap(fileToDisplay);
            }
            else
            {
                MyImage = new Bitmap(".\\resources\\images\\book.png");
            }

            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.ClientSize = new Size(xSize, ySize);
            picture.Image = MyImage;
        }
    }

}
