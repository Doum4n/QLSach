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
    public partial class comment : UserControl
    {
        public comment()
        {
            InitializeComponent();

            // Tạo một instance của CustomPictureBox
            CustomPictureBox customPictureBox = new CustomPictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(10, 10),
                BackColor = Color.Blue, // Màu nền cho PictureBox
                Image = Image.FromFile(".\\resources\\images\\book.png"), // Đường dẫn tới hình ảnh
                SizeMode = PictureBoxSizeMode.StretchImage // Cách hiển thị hình ảnh
            };

            avatar.Controls.Add(customPictureBox);
        }
    }
}
