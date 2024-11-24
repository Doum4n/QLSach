using MoreLinq;
using QLSach.component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.view.admin
{
    public partial class Statistacs : UserControl
    {
        public Statistacs()
        {
            InitializeComponent();
        }

        private void Statistacs_Load(object sender, EventArgs e)
        {
            book_amount.Text = Singleton.getInstance.Data.Books.Count().ToString();
            users_amount.Text = Singleton.getInstance.Data.Users.Count().ToString();
            Availabel.Text = Singleton.getInstance.Data.Books.Where(o => o.remaining > 0).ToList().Count().ToString();
            borrowed.Text = Singleton.getInstance.Data.Books.Where(o => o.remaining < 1).ToList().Count().ToString();
            registed_books.Text = Singleton.getInstance.Data.Register.Where(o => o.Status == database.models.Status_borrow.Pending).ToList().Count().ToString();
            borrowed.Text = Singleton.getInstance.Data.Register.Where(o => o.Status == database.models.Status_borrow.Pending).ToList().Count().ToString();
            new_users_amount.Text = Singleton.getInstance.Data.Users.Where(o => o.create_at >= DateOnly.FromDateTime(DateTime.Now.AddMonths(-1))).Count().ToString();
            int pay_on_time = Singleton.getInstance.Data.Register.Where(o => o.Status == database.models.Status_borrow.Completed).Where(o => o.return_at <= o.expected_at).Count();
            int late_payment = Singleton.getInstance.Data.Register.Where(o => o.Status == database.models.Status_borrow.Completed).Where(o => o.return_at > o.expected_at).Count();
            int returns = Singleton.getInstance.Data.Register.Where(o => o.Status == database.models.Status_borrow.Pending).Count();
            float return_rate = (pay_on_time / returns) * 100;
            lb_return_rate.Text = return_rate.ToString();
            genre.Text = Singleton.getInstance.Data.Genre.GroupBy(o => o.id).Count().ToString();
            category.Text = Singleton.getInstance.Data.Categories.GroupBy(o => o.Id).Count().ToString();

            var genres = Singleton.getInstance.Data.Genre.Select(o => o.name).ToList();
            foreach (var genre in genres)
            {
                Label label = new Label();
                label.Text = genre;
                label.Height = 30;
                label.Dock = DockStyle.Top;
                pane_genres.Controls.Add(label);
            }

            var categories = Singleton.getInstance.Data.Categories.Select(o => o.Name).ToList();
            foreach (var category in categories)
            {
                Label label = new Label();
                label.Text = category;
                label.Height = 30;
                label.Dock = DockStyle.Top;
                pane_categories.Controls.Add(label);
            }

            var books = Singleton.getInstance.Data.Register
                .GroupBy(o => o.BookId)
                .Select(g => new
                {
                    BookId = g.Key,
                    Count = g.Count()
                })
                .Join(
                    Singleton.getInstance.Data.Books,
                    register => register.BookId,
                    book => book.Id,
                    (grouped, book) => new
                    {
                        Name = book.name,
                    }
                )
                .ToList();

            foreach (var book in books)
            {
                Label label = new Label();
                label.Text = book.Name;
                label.Height = 30;
                label.Dock = DockStyle.Top;
                pane_books.Controls.Add(label);
            }
        }
    }
}
