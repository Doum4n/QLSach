using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.view
{
    public class CustomPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, this.Width, this.Height);
                this.Region = new Region(path);
            }
        }
    }
}
