using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Jenga;
using QLSach.component;
using QLSach.controllers;
using QLSach.view.components;
using QLSach.view.user;
using QLSach.view.user.components.items;
using ServiceStack;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLSach.view
{

    public partial class Mainframe : Form
    {
        private bool isBookSelected = false;
        private bool isDigitalSelected = false;
        private GenreQuery query = new GenreQuery();
        private BookQuery bookQuery = new BookQuery();
        private AuthorQuery authorQuery = new AuthorQuery();

        int count = 1;

        public Mainframe()
        {
            InitializeComponent();
            Node node = new Node(new DashBoard());
            Singleton.getInstance.MainFrameHelper.Node = node;
            Singleton.getInstance.State = node;
            Singleton.getInstance.MainFrameHelper.ActivePathChanged += OnActivated;
        }

        private void OnActivated(string newValue)
        {
            lb_path.Text = newValue;
        }


        private void btn_book_Click(object sender, EventArgs e)
        {
            LoadDashBoard();

            isBookSelected = !isBookSelected;
            pane_btnSach.Visible = isBookSelected;
        }

        private void LoadDashBoard()
        {
            Singleton.getInstance.MainFrameHelper.MainPane = Pane_conten;
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(
                 new DashBoard()
            );
        }

        private void Mainframe_Load(object sender, EventArgs e)
        {
            LoadDashBoard();

            tb_search.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            Dictionary<int, string> booksName = new Dictionary<int, string>();
            bookQuery.getBooks().ForEach(book =>
            {
                booksName.Add(book.Id, book.name);
            });

            Dictionary<int, string> authorsName = new Dictionary<int, string>();
            authorQuery.getAuthors().ForEach(author =>
            {
                authorsName.Add(author.Id, author.name);
            });

            collection.AddRange(bookQuery.getBooks().Select(o => o.name).ToArray());
            collection.AddRange(authorQuery.getAuthorName().ToArray());
            tb_search.AutoCompleteCustomSource = collection;
            tb_search.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string selectedSuggestion = tb_search.Text;
                    Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();

                    if (booksName.ContainsValue(selectedSuggestion))
                    {
                        Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(new BookDetail(booksName.First(o => o.Value == selectedSuggestion).Key));
                    }
                    if (authorsName.ContainsValue(selectedSuggestion))
                    {
                        SearchPane search = new SearchPane(
                            selectedSuggestion,
                            authorsName.First(o => o.Value == selectedSuggestion).Key
                        );
                        Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(search);
                    }
                    e.SuppressKeyPress = true;
                }
            };

            lb_name.Text = Singleton.getInstance.Username;
            foreach (var genre in query.getGenre_name_id())
            {
                Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button();
                btn.Text = genre.Value;
                btn.Dock = DockStyle.Top;
                btn.FillColor = Color.Chocolate;
                btn.Click += new EventHandler(onClick);
                btn.Name = genre.Key.ToString();
                pane_btnSach.Controls.Add(btn);
            }

            Singleton.getInstance.RegisterHelper.registration_data = new BindingSource();
        }

        private void onClick(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            if (btn != null)
                loadBookByGenre(int.Parse(btn.Name), btn.Text);
        }

        private void loadBookByGenre(int GenreId, string GenreName)
        {
            BookByGenre bookByGenre = new BookByGenre();
            bookByGenre.genreId = GenreId;
            bookByGenre.genreName = GenreName;
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(
               bookByGenre
            );
        }

        private void toggle()
        {
            isBookSelected = !isBookSelected;
        }

        //private void btn_digitalBook_Click(object sender, EventArgs e)
        //{
        //    isDigitalSelected = !isDigitalSelected;
        //    pane_btnDigitalBook.Visible = isDigitalSelected;
        //}

        private void btn_redo_Click(object sender, EventArgs e)
        {
            Node cur = Singleton.getInstance.State;
            if (cur != null && cur.getVisitedNode() != null)
            {
                addControl(cur.getVisitedNode().getState());
                Singleton.getInstance.State = cur.getVisitedNode();
            }
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            Node cur = Singleton.getInstance.State;
            Node pre = cur.parent;
            if (cur.parent != null)
            {
                if (cur != pre)
                {
                    addControl(pre.getState());
                    Singleton.getInstance.State = pre;
                }
            }
        }

        private void addControl(UserControl control)
        {
            if (control != null)
            {
                Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
                Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(control);
            }
        }

        private void menu_item_borowed_Click(object sender, EventArgs e)
        {
            BorrowedBooks borrowed = new BorrowedBooks();
            borrowed.UserId = 9;
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(borrowed);
        }

        private void menu_item_registered_Click(object sender, EventArgs e)
        {
            RegistedBooks registed = new RegistedBooks();
            registed.UserId = 9;
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(registed);
        }

        private void btn_look_up_Click(object sender, EventArgs e)
        {

        }

        private void Pane_conten_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
