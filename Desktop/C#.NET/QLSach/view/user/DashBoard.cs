using QLSach.controllers;
using QLSach.view.components.items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSach.controllers;
using QLSach.database;
using QLSach.component;
using QLSach.dbContext.models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLSach.view
{
    public partial class DashBoard : UserControl
    {
        Node node;

        private controllers.BookQuery dashBoard = new controllers.BookQuery();
        private int currentIndex = 0;

        public DashBoard()
        {
            InitializeComponent();
            Singleton.getInstance.MainFrameHelper.Path = "Trang chủ";
            node = new Node(this);
            Singleton.getInstance.MainFrameHelper.Node = node;
        }

        private void Init()
        {

        }
        private void DashBoard_Load(object sender, EventArgs e)
        {
            Singleton.getInstance.State = node;
            Singleton.getInstance.MainFrameHelper.Node.AddChild(node);
        }

        private void btn_newlyUpdate_Click(object sender, EventArgs e)
        {
            pane.Controls.Clear();
            pane.Controls.Add(Singleton.getInstance.Initilize.PaneRecent);
        }
        

        private void btn_popula_Click(object sender, EventArgs e)
        {
            pane.Controls.Clear();
            pane.Controls.Add(Singleton.getInstance.Initilize.PanePopular);
        }

        private void btn_mostView_Click(object sender, EventArgs e)
        {
            pane.Controls.Clear();
            pane.Controls.Add(Singleton.getInstance.Initilize.PaneMostView);
        }
    }
}
