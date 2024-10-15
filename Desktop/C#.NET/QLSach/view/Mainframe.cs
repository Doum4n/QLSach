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
        
        private bool isBookSelected = false;
        private bool isDigitalSelected = false;
        public Mainframe()
        {
            InitializeComponent();
        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.MainPane = Pane_conten;
            Singleton.getInstance.MainPane.Controls.Add(new DashBoard());

            isBookSelected = !isBookSelected;
            pane_btnSach.Visible = isBookSelected;
        }

        private void Mainframe_Load(object sender, EventArgs e)
        {
            
        }

        private void toggle()
        {
            isBookSelected = !isBookSelected;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void btn_digitalBook_Click(object sender, EventArgs e)
        {
            isDigitalSelected = !isDigitalSelected;
            pane_btnDigitalBook.Visible = isDigitalSelected;
        }
    }
}
