using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.view
{
    public partial class Mainframe : Form
    {
        
        private bool isSelected = false;
        public Mainframe()
        {
            InitializeComponent();
        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            Pane_conten.Controls.Add(new DashBoard());

            pane_btnSach.Visible = isSelected;

            toggle();
        }

        private void Mainframe_Load(object sender, EventArgs e)
        {
            
        }

        private void toggle()
        {
            isSelected = !isSelected;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void btn_digitalBook_Click(object sender, EventArgs e)
        {
            pane_btnDigitalBook.Visible = isSelected;

            toggle();
        }
    }
}
