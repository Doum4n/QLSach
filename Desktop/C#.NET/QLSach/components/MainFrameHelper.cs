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

        private Node root;

        public MainFrameHelper() {
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

        public int Id { get { return _id; } set { _id = value; } }

        public Node Node { get; set; }

    }

    public delegate void TreeVisitor(Node nodeData);

    public class Node
    {
        private UserControl data;
        private LinkedList<Node> children;
        public Node parent;
        public bool isVisit { get; set; }

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
            Visit(child);
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
            visitor(node);
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

        public void DeleteNode(Node node)
        {
            if (node == null) return;
            children.Remove(node);
            Traverse(node, delegate (Node node)
            {
                children.Remove(node);
            });
            MessageBox.Show(children.Count.ToString());
        }

        public Node? getVisitedNode()
        {
            foreach (var item in this.children)
            {
                if (item.isVisit)
                {
                    return item;
                }
            }
            return null;
        }

        public void Visit(Node child)
        {
            foreach (var item in this.children)
            {
                item.isVisit = false;
            }
            child.isVisit = true;
        }
    }
}
