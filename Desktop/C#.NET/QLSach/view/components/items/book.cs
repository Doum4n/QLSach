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

namespace QLSach.view.components.items
{
    public partial class book : UserControl
    {
        private int id;
        public book()
        {
            InitializeComponent();
        }


        public String Name
        {
            get { return lb_name_Book.Text; }
            set { lb_name_Book.Text = value; }
        }

        public String Author
        {
            get { return lb_name_Author.Text; }
            set { lb_name_Author.Text = value; }
        }

        public String Source
        {
            get { return lb_source.Text; }
            set { lb_source.Text = value; }
        }

        private void onClick(object sender, EventArgs e)
        {
            Singleton.getInstance.MainFrameHelper.Id = id;
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(new BookDetail());
        }

        public int Id { get { return id; } set { id = value; } }
    }
}
