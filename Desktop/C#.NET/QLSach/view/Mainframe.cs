using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSach.component;

namespace QLSach.view
{
    public partial class Mainframe : Form
    {

        private bool isBookSelected = false;
        private bool isDigitalSelected = false;
        public Mainframe()
        {
            InitializeComponent();
            Singleton.getInstance.MainFrameHelper.ActiveChanged += OnActivated;
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
            int count = Singleton.getInstance.MainFrameHelper.States.Count - 1;

            if (count > 0)
            {
                --count;
            }
            switch (Singleton.getInstance.MainFrameHelper.States.ElementAt(count))
            {
                case State.RecentUpdate:
                    {
                        Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
                        Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(
                            Singleton.getInstance.Initilize.RecentUpdate
                        );

                        break;
                    }
            }
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            int count = 1;

            if(count < Singleton.getInstance.MainFrameHelper.States.Count - 1)
            {
                ++count;
            }
            switch (Singleton.getInstance.MainFrameHelper.States.ElementAt(count))
            {
                case State.DashBoard:
                    {
                        Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
                        Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(
                            Singleton.getInstance.Initilize.DashBoard
                        );

                        break;
                    }
            }
        }
    }
}
