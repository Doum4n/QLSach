using QLSach.controllers;
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
    public partial class PanePopular : UserControl
    {
        public PanePopular()
        {
            InitializeComponent();
        }

        private void PanePopular_Load(object sender, EventArgs e)
        {
            tbLayoutPanel.Controls.Clear();

            BookQuery query = new BookQuery();
            int i = 1;
            foreach (var item in query.getMostViewBooks())
            {
                BookMostPopular popular = new();
                popular.bookName = item.name;
                popular.author = query.getBookAuthor(item.author_id);
                popular.index = $"#{i++}";
                popular.info = item.description;
                popular.id = item.Id;
                popular.status = item.status;
                tbLayoutPanel.SetRow(popular, tbLayoutPanel.RowCount++);
                tbLayoutPanel.Controls.Add(popular);
            }
        }
    }
}
