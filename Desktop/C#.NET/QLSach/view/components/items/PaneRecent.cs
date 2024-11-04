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
                rs.Genre = genre.name;
                //MessageBox.Show($"Genre: {genre.id}");
                //Singleton.getInstance.BookHelper.genreId = genre.id;
                rs.GenreId = genre.id;
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
            recentUpdate rc = new recentUpdate();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(rc);
        }
    }
}
