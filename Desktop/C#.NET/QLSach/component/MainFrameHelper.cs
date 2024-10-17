using QLSach.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.component
{
    public class MainFrameHelper
    {
        //view/Mainframe
        private Guna.UI2.WinForms.Guna2Panel panel;
        private String _path;
        public delegate void ActiveChangedHandler(String newValue);
        public event ActiveChangedHandler ActiveChanged;

        private Stack<State> states;

        public MainFrameHelper() {
            states = new Stack<State>();
        }

        public Panel MainPane
        {
            get { return panel; }
            set { panel = (Guna.UI2.WinForms.Guna2Panel)value; }
        }

        public String Path
        {
            get { return _path; }
            set
            {
                if (value != _path)
                {
                    _path = value;
                    OnActiveChanged(_path);
                }
            }
        }

        protected virtual void OnActiveChanged(String newValue)
        {
            ActiveChanged?.Invoke(newValue);
        }

        public Stack<State> States {  get { return states; } }
    }
}
