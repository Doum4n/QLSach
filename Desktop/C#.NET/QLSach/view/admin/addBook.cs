using QLSach.component;
using QLSach.components;
using QLSach.database;
using QLSach.database.models;
using QLSach.database.query;
using QLSach.dbContext.models;
using System.Data;

namespace QLSach.view.admin
{
    public partial class addBook : Form
    {
        private string filePath = "";
        private AuthorQuery authorQuery = new AuthorQuery();
        public addBook()
        {
            InitializeComponent();
        }

        private void onClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                loadImage.ShowImage(pictureBook, filePath, 162, 240);
            }
            //ofd.ShowDialog();
        }

        private void btn_post_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                Book book = new Book();
                book.Id = context.Books.Count() + 1;
                book.author_id = Convert.ToInt32(combobox_author_name.SelectedValue);
                book.name = tb_book_name.Text;
                book.description = rtb_description.Text;
                book.public_at = DateOnly.FromDateTime(date_picker.Value);
                int genre_id = context.Genre.Where(o => o.name == combo_box_genre.Text).Select(o => o.id).FirstOrDefault();
                book.genre_id = genre_id;
                book.quantity = byte.Parse(tb_quantity.Text);
                book.remaining = byte.Parse(tb_quantity.Text);
                book.photoPath = filePath;

                DataRow newRow = Singleton.getInstance.DataSet.Tables["Books"].NewRow();
                newRow["Id"] = book.Id;
                newRow["name"] = book.name;
                newRow["description"] = book.description;
                newRow["author_id"] = book.author_id;
                newRow["public_at"] = book.public_at;
                newRow["genre_id"] = book.genre_id;
                newRow["quantity"] = book.quantity;
                newRow["remaining"] = book.remaining;
                newRow["photoPath"] = book.photoPath;
                newRow["rating"] = 0;
                newRow["views"] = 0;
                newRow["created_at"] = book.created_at;
                newRow["updated_at"] = book.updated_at;
                newRow["status"] = book.status;

                Singleton.getInstance.DataSet.Tables["Books"].Rows.Add(newRow);

                MessageBox.Show("Thêm sách thành công");
            }
        }

        private void addBook_Load(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                combo_box_genre.DataSource = context.Genre.Select(o => o.name).ToList();
                combobox_author_name.DataSource = context.Authors.Select(o => new { o.Id, o.name }).ToList();
                combobox_author_name.DisplayMember = "name";
                combobox_author_name.ValueMember = "id";
            }
        }
    }
}
