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
        public delegate void ActivePathChangedHandler(String newValue);
        public event ActivePathChangedHandler ActivePathChanged;

        //temp
        private int _id;
        //public delegate void ActiveIdChangedHandler(int newId);
        //public event ActiveIdChangedHandler ActiveIdChanged;

        //private Stack<State> states;
        private Node root;

        public MainFrameHelper() {
            //states = new Stack<State>();
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
                    OnPathChanged(_path);
                }
            }
        }

        protected virtual void OnPathChanged(String newValue)
        {
            ActivePathChanged?.Invoke(newValue);
        }

        //protected virtual void OnIdChanged(int newId)
        //{
        //    ActiveIdChanged?.Invoke(newId);
        //}

        public int Id { get { return _id; } set { _id = value; } }

        //public Stack<State> States {  get { return states; } }

        public Node Node
        {
            get { return root; }
            set { root = value; }
        }

    }

    public delegate void TreeVisitor(UserControl nodeData);

    public class Node
    {
        private UserControl data;
        private LinkedList<Node> children;
        public Node parent;
        private Node current;
        public bool visited { get; set; } = false;

        public Node(UserControl data)
        {
            this.data = data;
            children = new LinkedList<Node>();
            parent = null;

        }

        public void AddChild(Node child)
        {
            child.parent = this;
            children.AddLast(child);

            Singleton.getInstance.priviouState = this;
           
        }

        public Node GetChild(int i)
        {
            foreach (Node n in children)
                if (--i == 0)
                    return n;
            return null;
        }

        public void Traverse(Node node, TreeVisitor visitor)
        {
            visitor(node.data);
            foreach (Node kid in node.children)
                Traverse(kid, visitor);
        }

        public LinkedList<Node> getChildren()
        {
            return children;
        }

        public UserControl getState()
        {
            return data;
        }

        public Node getLastChild()
        {
            return children.Last();
        }

        public void DeleteNode(Node node)
        {
            if (node == null) return;
            children.Remove(node);
            Traverse(node, delegate (UserControl userControl)
            {
                children.Remove(node);
            });
        }
    }
}
