using Confluent.Kafka;
using QLSach.component;
using QLSach.database;
using QLSach.database.query;
using QLSach.view.user;
using QLSach.view.user.components.items;
using System.Data;

namespace QLSach.view
{

    public partial class Mainframe : Form
    {
        private bool isBookSelected = false;
        private bool isDigitalSelected = false;
        private GenreQuery query = new GenreQuery();
        private BookQuery bookQuery = new BookQuery();
        private AuthorQuery authorQuery = new AuthorQuery();

        private bool isContent = false;
        private bool isCategory = false;

        int count = 1;

        public Mainframe()
        {
            InitializeComponent();
            component.Node node = new component.Node(new DashBoard());
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
            pane_genre.Visible = isBookSelected;
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
                    //e.SuppressKeyPress = true;
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
                pane_genre.Controls.Add(btn);
            }

            using (var context = new Context())
            {
                foreach (var category in context.Categories.ToList())
                {
                    Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button();
                    btn.Text = category.Name;
                    btn.Dock = DockStyle.Top;
                    btn.FillColor = Color.Chocolate;
                    btn.Click += new EventHandler(onCategoryActive);
                    btn.Name = category.Id.ToString();
                    pane_category.Controls.Add(btn);
                }
            }

            pane_category.Visible = isCategory;

            Singleton.getInstance.RegisterHelper.registration_data = new BindingSource();

            ReadMessagesFromPartition(0);

            btn_look_up.Dock = DockStyle.Top;

            pane_nofitication.Visible = isContent;
        }

        private void onCategoryActive(object? sender, EventArgs e)
        {
            
        }

        public string ExtractMessage(string input)
        {
            int colonIndex = input.IndexOf("::");

            if (colonIndex >= 0)
            {
                return input[(colonIndex + 2)..].Trim();
            }

            return input;
        }

        public string ExtractMessageTime(string input)
        {
            int colonIndex = input.IndexOf("::");

            if (colonIndex >= 0)
            {
                return input[..(colonIndex)].Trim();
            }

            return input;
        }

        /*
            test message kafka
            */
        public void ReadMessagesFromPartition(int partition)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                GroupId = "my-group",
                ClientId = Singleton.getInstance.UserId.ToString(),
                EnableAutoCommit = false,
                BrokerAddressFamily = BrokerAddressFamily.V4,
            };

            using var consumer = new ConsumerBuilder<int, string>(config).Build();

            var topicPartition = new TopicPartition("my-topic", new Partition(partition));
            consumer.Assign(new[] { topicPartition });

            try
            {
                while (true)
                {
                    var consumeResult = consumer.Consume(TimeSpan.FromSeconds(1));
                    if (consumeResult != null)
                    {
                        int userId = consumeResult.Message.Key;
                        MessageBox.Show(userId.ToString() + ":" + consumeResult.Message.Key.ToString());
                        if (userId == Singleton.getInstance.UserId)
                        {
                            RichTextBox textBox = new RichTextBox();
                            Label label = new Label();
                            label.Text = ExtractMessageTime(consumeResult.Message.Value);
                            label.Dock = DockStyle.Top;

                            textBox.Text = ExtractMessage(consumeResult.Message.Value);
                            textBox.Dock = DockStyle.Top;
                            pane_nofitication.Controls.Add(textBox);
                            pane_nofitication.Controls.Add(label);
                        }

                        //consumer.Commit(consumeResult);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation canceled.");
            }
            finally
            {
                consumer.Close();
            }
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

        private void btn_redo_Click(object sender, EventArgs e)
        {
            component.Node cur = Singleton.getInstance.State;
            if (cur != null && cur.getVisitedNode() != null)
            {
                addControl(cur.getVisitedNode().getState());
                Singleton.getInstance.State = cur.getVisitedNode();
            }
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            component.Node cur = Singleton.getInstance.State;
            component.Node pre = cur.parent;
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

        private void lb_nofitication_Click(object sender, EventArgs e)
        {
            isContent = !isContent;
            pane_nofitication.Visible = isContent;
        }

        private void tb_noftitication_Click(object sender, EventArgs e)
        {
            isContent = !isContent;
            pane_nofitication.Visible = isContent;
        }

        private void btn_category_Click(object sender, EventArgs e)
        {
            isCategory = !isCategory;
            pane_category.Visible = isCategory;
        }
    }
}
