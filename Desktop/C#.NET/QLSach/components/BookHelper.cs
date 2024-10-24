using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.components
{
    public class BookHelper
    {

        // Nhận PictureBox từ bên ngoài và gán hình ảnh cho nó
        public void ShowMyImage(PictureBox picture, string fileToDisplay, int xSize, int ySize)
        {
            //// Nếu MyImage đã tồn tại, hủy tài nguyên
            //if (MyImage != null)
            //{
            //    MyImage.Dispose();
            //}

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
