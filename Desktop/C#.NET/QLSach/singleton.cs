using QLSach.dbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach
{
    internal class Singleton
    {
        private readonly Db db;
        private Guna.UI2.WinForms.Guna2Panel panel;

        private static Singleton? instance;
        private static readonly object lockObj = new object();
        public Singleton()
        {
            db = new Db();
        }

        public static Singleton getInstance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }

        public Db Data { get { return db; } }
        public Panel MainPane
        {
            get { return panel; }
            set { panel = (Guna.UI2.WinForms.Guna2Panel)value; }
        }
    }
}
