using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSach.view.user.components.items
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            Progress_Bar.Style = ProgressBarStyle.Marquee; // Hiển thị kiểu chạy liên tục
            Progress_Bar.Value += 1;
        }
    }
}
