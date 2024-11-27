namespace QLSach.components
{
    public class loadImage
    {
        public static void ShowImage(PictureBox picture, string? fileToDisplay, int xSize, int ySize)
        {
            Bitmap MyImage;
            if (fileToDisplay != "")
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
