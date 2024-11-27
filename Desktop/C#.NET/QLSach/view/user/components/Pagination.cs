using QLSach.database.query;
using QLSach.dbContext.models;
using QLSach.view.components.items;

namespace QLSach.view.components
{
    // 2 rows, each row has 4 book(item)
    public class Pagination
    {
        public int currentIndex { get; set; } = 0;
        private TableLayoutPanel tablePane;
        public List<Book> books { get; set; }
        private BookQuery bookQuery = new BookQuery();
        private int colCount;
        private int rowCount;
        private int pageSize;
        private int curCol = 0;
        private int curRow = 0;

        public Pagination(TableLayoutPanel tablePane, int rowCount, int colCount, int pageSize)
        {
            this.tablePane = tablePane;
            this.rowCount = rowCount;
            this.colCount = colCount;
            this.pageSize = pageSize;
            books = new List<Book>();

            tablePane.ColumnCount = colCount;
            tablePane.RowCount = rowCount;
        }
        public void setData(BookRecent bookItem)
        {
            if (curCol == colCount)
            {
                curCol = 0;
                curRow++;
            }

            if (curRow == rowCount)
            {
                curRow = 0;
            }

            tablePane.SetCellPosition(bookItem, new TableLayoutPanelCellPosition(curCol, curRow));
            tablePane.Controls.Add(bookItem);
            curCol++;
        }

        public void LoadData()
        {
            //when pageSize > column count
            int offset = 0;
            int lastIndex = (int)Math.Floor(books.Count / (pageSize * 1.0)) - 1;
            //for last page
            if (currentIndex == lastIndex)
            {
                int remainingBooks = books.Count % pageSize;
                if (remainingBooks > 0)
                {
                    offset = pageSize - remainingBooks;
                }
            }

            for (int i = pageSize * currentIndex; i < (pageSize * currentIndex + pageSize) - offset; i++)
            {
                if (i < books.Count())
                {
                    if (!books[i].Id.Equals(null))
                    {
                        BookRecent book1 = new BookRecent(books[i].Id);
                        setData(book1);
                    }
                }

            }
        }

        public void btn_first_Click()
        {
            currentIndex = 0;
            tablePane.Controls.Clear();
            LoadData();
        }

        public void btn_next_Click()
        {
            int lastIndex = (int)Math.Floor(books.Count / (pageSize * 1.0)) - 1;
            if (lastIndex < 1)
            {
                lastIndex = 0;
            }
            if (currentIndex < lastIndex)
            {
                currentIndex++;

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
            currentIndex = (int)Math.Floor(books.Count / (pageSize * 1.0)) - 1;
            // when currentIndex = lastIndex
            if (currentIndex < 1)
            {
                currentIndex = 0;
            }
            tablePane.Controls.Clear();

            LoadData();
        }
    }
}
