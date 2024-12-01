using MoreLinq;
using QLSach.component;
using QLSach.database;
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
            using (var context = new Context())
            {
                book_amount.Text = context.Books.Count().ToString();
                users_amount.Text = context.Users.Count().ToString();
                Availabel.Text = context.Books.Where(o => o.remaining > 0).ToList().Count().ToString();
                borrowed.Text = context.Books.Where(o => o.remaining < 1).ToList().Count().ToString();
                registed_books.Text = context.Register.Where(o => o.Status == database.models.Status_borrow.Pending).ToList().Count().ToString();
                borrowed.Text = context.Register.Where(o => o.Status == database.models.Status_borrow.Pending).ToList().Count().ToString();
                new_users_amount.Text = context.Users.Where(o => o.create_at >= DateOnly.FromDateTime(DateTime.Now.AddMonths(-1))).Count().ToString();
            
                int return_on_time = context.Register.Where(o => o.Status == database.models.Status_borrow.Completed).Where(o => o.return_at <= o.expected_at).Count();
                int late_payment = context.Register.Where(o => o.Status == database.models.Status_borrow.Completed).Where(o => o.return_at > o.expected_at).Count();
                int returns = context.Register.Where(o => o.Status == database.models.Status_borrow.Pending).Count();
                double return_rate = Math.Round(((return_on_time * 1.0 / returns * 1.0) * 100), 2);
            
                lb_return_rate.Text = return_rate.ToString();
                genre.Text = context.Genre.GroupBy(o => o.id).Count().ToString();
                category.Text = context.Categories.GroupBy(o => o.Id).Count().ToString();

                lb_overdueBooks.Text = context.Register.Where(o => o.return_at > o.expected_at).Count().ToString();
                lb_returnedBooks.Text = context.Register.Where(o => o.Status == database.models.Status_borrow.Completed).Count().ToString();

                var genres = context.Genre.Select(o => o.name).ToList();
                foreach (var genre in genres)
                {
                    Label label = new Label();
                    label.Text = genre;
                    label.Height = 30;
                    label.Dock = DockStyle.Top;
                    pane_genres.Controls.Add(label);
                }

                var categories = context.Categories.Select(o => o.Name).Take(10).ToList();
                foreach (var category in categories)
                {
                    Label label = new Label();
                    label.Text = category;
                    label.Height = 30;
                    label.Dock = DockStyle.Top;
                    pane_categories.Controls.Add(label);
                }

                var books = context.Register
                         .GroupBy(o => o.BookId)
                         .Select(g => new
                         {
                             BookId = g.Key,
                             Count = g.Count()
                         })
                         .Join(
                             context.Books,
                             register => register.BookId,
                             book => book.Id,
                             (register, book) => new
                             {
                                 Name = book.name,
                             }
                         )
                         .Take(10).ToList();

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
}
