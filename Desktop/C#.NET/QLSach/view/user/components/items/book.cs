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
using QLSach.components;
using QLSach.controllers;

namespace QLSach.view.components.items
{
    public partial class book : UserControl
    {
        private int id;

        public book()
        {
            InitializeComponent();
            String imagePath = ".\\resources\\images\\book.png";
            Singleton.getInstance.LoadImg.ShowMyImage(picture, imagePath, 153, 203);
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
