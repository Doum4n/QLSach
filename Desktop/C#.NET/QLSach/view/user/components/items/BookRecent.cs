using QLSach.component;
using QLSach.components;
using QLSach.database;
using QLSach.database.query;

namespace QLSach.view.components.items
{
    public partial class BookRecent : UserControl
    {
        private int id;

        public BookRecent(int id)
        {
            this.id = id;
            InitializeComponent();
            using (Context context = new Context())
            {
                String? imagePath = context.Books.Where(o => o.Id == id).Select(o => o.photoPath).First();
                loadImage.ShowImage(picture, imagePath, 153, 203);
            }
        }

        private void onClick(object sender, EventArgs e)
        {
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(new BookDetail(id));
        }

    }
}
