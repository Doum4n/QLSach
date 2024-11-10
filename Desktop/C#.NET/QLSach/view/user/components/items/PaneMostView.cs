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
    public partial class PaneMostView : UserControl
    {
        public PaneMostView()
        {
            InitializeComponent();
        }

        private void PaneMostView_Load(object sender, EventArgs e)
        {
            tbLayoutPanel.Controls.Clear();

            BookQuery query = new BookQuery();
            int i = 1;
            foreach (var item in query.getMostViewBooks())
            {
                BookMostView bookMostView = new BookMostView();
                bookMostView.bookName = item.name;
                bookMostView.author = query.getBookAuthor(item.author_id);
                bookMostView.index = $"#{i++}";
                bookMostView.views = $"Lượt xem: {item.views}";
                bookMostView.id = item.Id;
                bookMostView.status = item.status;
                tbLayoutPanel.SetRow(bookMostView, tbLayoutPanel.RowCount++);
                tbLayoutPanel.Controls.Add(bookMostView);
            }
        }

        private void btn_thisWeek_Click(object sender, EventArgs e)
        {

        }

        private void btn_thisYear_Click(object sender, EventArgs e)
        {

        }

        private void btn_thisMonth_Click(object sender, EventArgs e)
        {

        }
    }
}
