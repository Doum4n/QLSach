using QLSach.dbContext.models;
using QLSach.view.components.items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.view.components
{
    // 2 rows, each row has 4 book(item)
    public class Pagination
    {
        public int currentIndex { get; set; } = 0;
        private TableLayoutPanel tablePane;
        public List<Book> books {  get; set; }
        private controllers.BookQuery bookQuery = new controllers.BookQuery();
        private int colCount;
        private int rowCount;
        private int pageSize;

        public Pagination(TableLayoutPanel tablePane, int rowCount, int colCount, int pageSize)
        {
            this.tablePane = tablePane;
            this.rowCount = rowCount;
            this.colCount = colCount;
            this.pageSize = pageSize;
            books = new List<Book>();
        }
        public void setData(book bookItem)
        {
            if (tablePane.ColumnCount == colCount)
            {
                tablePane.ColumnCount = 0;
                tablePane.RowCount++;
            }

            if (tablePane.RowCount == rowCount)
            {
                tablePane.RowCount = 0;
            }


            tablePane.SetCellPosition(bookItem,
                new TableLayoutPanelCellPosition(
                    tablePane.ColumnCount,
                    tablePane.RowCount
                    )
                );

            tablePane.ColumnCount += 1;
            tablePane.Controls.Add(bookItem);
        }

        public void LoadData()
        {

            List<Book> Books = books;
            int offset = 0;
            int lastIndex = (int)Math.Floor(bookQuery.getBooks().Count / (pageSize * 1.0)) - 1;
            if (currentIndex == lastIndex)
            {
                int count = Books.Count();
                while (count % pageSize != 0)
                {
                    count++;
                    offset++;
                }
            }
            
            int prev_pageSize = pageSize;
            int prev_colCount = colCount;

            while (pageSize > books.Count())
            {
                pageSize--;
                colCount--;                              
                offset = 0;
            }


            for (int i = pageSize * currentIndex; i < (pageSize * currentIndex + pageSize) - offset; i++)
            {
                //MessageBox.Show(i.ToString());
                if (!Books[i].Id.Equals(null))
                {
                    book book1 = new book();
                    //Singleton.getInstance.MainFrameHelper.Id = Books[i].id;
                    book1.Id = Books[i].Id;
                    //book1.Name = Books[i].name;
                    //book1.Author = bookQuery.getBookAuthor(Books[i].Id);
                    //book1.Source = "Internet";
                    setData(book1);
                }
            }

            pageSize = prev_pageSize;
            colCount = prev_colCount;
        }

        public void btn_first_Click()
        {
            currentIndex = 0;
            tablePane.Controls.Clear();
            LoadData();

        }

        public void btn_next_Click()
        {
            int lastIndex = (int)Math.Floor(bookQuery.getBooks().Count / (pageSize * 1.0)) - 1;
            if (currentIndex < lastIndex)
            {
                currentIndex += 1;

                tablePane.Controls.Clear();
                LoadData();
            }
        }

        public void btn_previous_Click()
        {
            if (currentIndex > 0)
            {
                currentIndex -= 1;

                tablePane.Controls.Clear();
                LoadData();
            }
        }

        public void btn_last_Click()
        {
            currentIndex = (int)Math.Floor(bookQuery.getBooks().Count / (pageSize * 1.0)) - 1;
            tablePane.Controls.Clear();
            LoadData();
        }
    }
}
