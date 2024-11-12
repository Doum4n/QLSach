using QLSach.component;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLSach.view.components.items
{
    public partial class PaneRecent : UserControl
    {
        private GenreQuery query = new GenreQuery();

        public PaneRecent()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            foreach (var genre in query.getGenre())
            {
                RecentUpdateByGenre rs = new RecentUpdateByGenre();
                rs.GenreId = genre.id;
                rs.Genre = genre.name;
                tbLayoutPanel.SetRow(rs, tbLayoutPanel.RowCount++);
                tbLayoutPanel.Controls.Add(rs);
            }
        }

        private void PaneRecent_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void more_newlyBook_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(new recentUpdate());
        }
    }
}
