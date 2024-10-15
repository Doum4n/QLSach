using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.view.components.items
{
    public partial class book : UserControl
    {
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

    }
}
