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
            //Singleton.getInstance.MainFrameHelper.Node = new Node(new DashBoard());
            //Singleton.getInstance.MainFrameHelper.Node.AddChild(State.DashBoard);
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
            //Node cur = new(Singleton.getInstance.State);
            ////StateOf(Singleton.getInstance.MainFrameHelper.Node.getCurrentNode().getLastChild().GetState());
            //addControl(cur.parent.GetState());
            //MessageBox.Show(cur.parent.GetState().ToString());
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            Node cur = Singleton.getInstance.State;
            if ( cur.parent != null)
            {
                cur.visited = true;
                addControl(cur.parent.getState());
                MessageBox.Show(cur.parent.getState().ToString());

                Singleton.getInstance.State = Singleton.getInstance.priviouState;

                Singleton.getInstance.MainFrameHelper.Node.DeleteNode( cur );
            }
        }

        private void addControl(UserControl control)
        {
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(control);
        }

        private void StateOf(State state)
        {
            switch (state)
            {
                case State.DashBoard:
                    {
                        addControl(Singleton.getInstance.Initilize.DashBoard);
                        break;
                    }
                case State.BookDetail:
                    {
                        addControl(Singleton.getInstance.Initilize.BookDetail);
                        break;
                    }
                case State.RecentUpdate:
                    {
                        addControl(Singleton.getInstance.Initilize.RecentUpdate);
                        break;
                    }
            }
        }
    }
}
