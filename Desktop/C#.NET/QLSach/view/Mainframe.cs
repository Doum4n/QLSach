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
using QLSach.controllers;
using QLSach.view.components;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLSach.view
{
  
    public partial class Mainframe : Form
    {
        private bool isBookSelected = false;
        private bool isDigitalSelected = false;
        private GenreQuery query = new GenreQuery();
        private BookQuery bookQuery = new BookQuery();

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
            lb_name.Text = Singleton.getInstance.Username;
            foreach (var genre in query.getGenre_name_id())
            {
                Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button();
                btn.Text = genre.Value;
                btn.Dock = DockStyle.Top;
                btn.FillColor = Color.Chocolate;
                btn.Click += new EventHandler(onClick);
                btn.Name = genre.Key.ToString();
                pane_btnSach.Controls.Add(btn);
            }
        }

        private void onClick(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            if (btn != null)
                loadBookByGenre(int.Parse(btn.Name), btn.Text);
        }

        private void loadBookByGenre(int GenreId, string GenreName)
        {
            BookByGenre bookByGenre = new BookByGenre();
            bookByGenre.genreId = GenreId;
            bookByGenre.genreName = GenreName;
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(
               bookByGenre
            );
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
