using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.components
{
    public class AdminHelper
    {
        public BindingSource book_data { get; set; }

        public AdminHelper()
        {
            book_data = new BindingSource();
        }
    }
}
