using QLSach.component;
using QLSach.controllers;

namespace QLSach.view.components.items
{
    public partial class book : UserControl
    {
        private int id;

        public book(int id)
        {
            this.id = id;
            InitializeComponent();
            ImageQuery query = new ImageQuery();
            String? imagePath = query.GetPhoto(id);
            Singleton.getInstance.LoadImg.ShowMyImage(picture, imagePath, 153, 203);
        }

        private void onClick(object sender, EventArgs e)
        {
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Clear();
            Singleton.getInstance.MainFrameHelper.MainPane.Controls.Add(new BookDetail(id));
        }

    }
}
