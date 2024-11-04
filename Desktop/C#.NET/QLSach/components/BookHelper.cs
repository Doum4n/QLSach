using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.components
{
    public class BookHelper
    {
        public int genreId {  get; set; }
        public void ShowMyImage(PictureBox picture, string fileToDisplay, int xSize, int ySize)
        {

            try
            {
                // Tải hình ảnh và gán vào PictureBox hiện tại
                Bitmap MyImage = new Bitmap(fileToDisplay);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.ClientSize = new Size(xSize, ySize);
                picture.Image = MyImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
    }

}
