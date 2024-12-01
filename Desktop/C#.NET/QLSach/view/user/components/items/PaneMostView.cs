using QLSach.database;
using QLSach.database.query;
using QLSach.view.user.components.items;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            int i = 1;
            using (Context context = new Context()) {
                foreach (var item in context.Books.OrderByDescending(o => o.views).Where(o => o.created_at >= DateTime.Now.AddDays(-7)).Take(10).ToList())
                {
                    BookMostView bookMostView = new BookMostView(item.Id);
                    bookMostView.bookName = item.name;
                    bookMostView.author = context.Authors.Where(o => o.Id == item.author_id).Select(o => o.name).First();
                    bookMostView.index = $"#{i++}";
                    bookMostView.views = $"Lượt xem: {item.views}";
                    bookMostView.status = item.status;
                    tbLayoutPanel.SetRow(bookMostView, tbLayoutPanel.RowCount++);
                    tbLayoutPanel.Controls.Add(bookMostView);
                }
            }
        }

        private void btn_thisWeek_Click(object sender, EventArgs e)
        {
            tbLayoutPanel.Controls.Clear();
            int i = 1;
            using (Context context = new Context())
            {
                foreach (var item in context.Books.OrderBy(o => o.views).Where(o => o.created_at >= DateTime.Now.AddDays(-7)).Take(10).ToList())
                {
                    BookMostView bookMostView = new BookMostView(item.Id);
                    bookMostView.bookName = item.name;
                    bookMostView.author = context.Authors.Where(o => o.Id == item.author_id).Select(o => o.name).First();
                    bookMostView.index = $"#{i++}";
                    bookMostView.views = $"Lượt xem: {item.views}";
                    bookMostView.status = item.status;
                    tbLayoutPanel.SetRow(bookMostView, tbLayoutPanel.RowCount++);
                    tbLayoutPanel.Controls.Add(bookMostView);
                }
            }
        }

        private void btn_thisYear_Click(object sender, EventArgs e)
        {
            tbLayoutPanel.Controls.Clear();
            int i = 1;
            using (Context context = new Context())
            {
                foreach (var item in context.Books.OrderBy(o => o.views).Where(o => o.created_at >= DateTime.Now.AddYears(-1)).Take(10).ToList())
                {
                    BookMostView bookMostView = new BookMostView(item.Id);
                    bookMostView.bookName = item.name;
                    bookMostView.author = context.Authors.Where(o => o.Id == item.author_id).Select(o => o.name).First();
                    bookMostView.index = $"#{i++}";
                    bookMostView.views = $"Lượt xem: {item.views}";
                    bookMostView.status = item.status;
                    tbLayoutPanel.SetRow(bookMostView, tbLayoutPanel.RowCount++);
                    tbLayoutPanel.Controls.Add(bookMostView);
                }
            }
        }

        private void btn_thisMonth_Click(object sender, EventArgs e)
        {
            tbLayoutPanel.Controls.Clear();
            int i = 1;
            using (Context context = new Context())
            {
                foreach (var item in context.Books.OrderBy(o => o.views).Where(o => o.created_at >= DateTime.Now.AddMonths(-1)).Take(10).ToList())
                {
                    BookMostView bookMostView = new BookMostView(item.Id);
                    bookMostView.bookName = item.name;
                    bookMostView.author = context.Authors.Where(o => o.Id == item.author_id).Select(o => o.name).First();
                    bookMostView.index = $"#{i++}";
                    bookMostView.views = $"Lượt xem: {item.views}";
                    bookMostView.status = item.status;
                    tbLayoutPanel.SetRow(bookMostView, tbLayoutPanel.RowCount++);
                    tbLayoutPanel.Controls.Add(bookMostView);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
