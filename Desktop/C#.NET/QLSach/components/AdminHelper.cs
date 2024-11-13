using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.components
{
    public class AdminHelper
    {

        public bool isPaneAdd {  get; set; } = false;
        public bool isPaneModify {  get; set; } = false;
        public BindingSource book_data { get; set; }
        public Guna.UI2.WinForms.Guna2Panel mainPane { get; set; }
        public AdminHelper()
        {
            book_data = new BindingSource();
        }
    }
}
