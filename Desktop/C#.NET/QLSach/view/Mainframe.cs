using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using QLSach.component;

namespace QLSach.view
{
  
    public partial class Mainframe : Form
    {

        private bool isBookSelected = false;
        private bool isDigitalSelected = false;

        int count = 1;

        public Mainframe()
        {
            InitializeComponent();
            Singleton.getInstance.MainFrameHelper.ActivePathChanged += OnActivated;

        }

        private void OnActivated(string newValue)
        {
            lb_path.Text = newValue;
        }


        private void btn_book_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.MainFrameHelper.MainPane = Pane_conten;
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(
                    Singleton.getInstance.Initilize.DashBoard
                    //new DashBoard()
                );

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


        private void btn_digitalBook_Click(object sender, EventArgs e)
        {
            isDigitalSelected = !isDigitalSelected;
            pane_btnDigitalBook.Visible = isDigitalSelected;
        }

        private void btn_redo_Click(object sender, EventArgs e)
        {
            Node cur = Singleton.getInstance.State;
            if (cur != null && cur.getVisitedNode() != null)
            {
                addControl(cur.getVisitedNode().getState());
                Singleton.getInstance.State = cur.getVisitedNode();
            }
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            Node cur = Singleton.getInstance.State;
            Node pre = cur.parent;
            if ( cur.parent != null)
            {
                if (cur != pre)
                {
                    addControl(pre.getState());
                    Singleton.getInstance.State = pre;
                }

                //Singleton.getInstance.MainFrameHelper.Node.DeleteNode( cur );
            }
        }

        private void addControl(UserControl control)
        {
            if (control != null)
            {
                Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
                Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(control);
            }
        }
    }
}
