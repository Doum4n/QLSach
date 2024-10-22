using QLSach.component;
using QLSach.controllers;
using QLSach.dbContext.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.view
{
    public partial class BookDetail : UserControl
    {
        public BookDetail()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            //if(Singleton.getInstance.MainFrameHelper.States.Last() != State.BookDetail)

            BookQuery query = new BookQuery();
            Book? book1 = query.getBook(Singleton.getInstance.MainFrameHelper.Id);
            Name.Text = book1?.name;
        }

        private void BookDetail_Load(object sender, EventArgs e)
        {
            Singleton.getInstance.State = new(this);
            Singleton.getInstance.MainFrameHelper.Node.getLastChild().AddChild(Singleton.getInstance.State);

        }
    }
}
