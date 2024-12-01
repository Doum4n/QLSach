using MySqlConnector;
using QLSach.components;
using QLSach.Components;
using QLSach.database;
using QLSach.database.models;
using System.Data;

namespace QLSach.component
{
    internal class Singleton
    {
        private static Singleton? instance;
        private static readonly object lockObj = new object();
        //database
        private readonly Context db;
        public DataSet DataSet { get; private set; }
        //Mainframe
        private readonly MainFrameHelper mainFrameHelper;
        //Intilize From
        private readonly FormInitilize initilize;

        public loadImage LoadImg { get; }

        public Node State { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public Role Role { get; set; }

        public readonly string connectionString = "Server=localhost;Database=qlsach;User ID=root;Password=pw;";
        //public MySqlConnection connection;


        public RegisterHelper RegisterHelper { get; set; }
        public AdminHelper AdminHelper { get; set; }
        public CategoryManagerHelper CategoryManagerHelper { get; set; }

        public Singleton()
        {
            //connection = new MySqlConnection(connectionString);
            DataSet = new DataSet();
            db = new();
            mainFrameHelper = new();
            initilize = new();
            LoadImg = new();
            RegisterHelper = new RegisterHelper();
            AdminHelper = new AdminHelper();
            CategoryManagerHelper = new CategoryManagerHelper();
        }

        public static Singleton getInstance
        {
            get
            {
                lock (lockObj)
                {
                    instance ??= new();
                    return instance;
                }
            }
        }

        public Context CreateContext()
        {
            return new Context();
        }

        //public Context Data { get { return CreateContext(); } }
        public MainFrameHelper MainFrameHelper { get { return mainFrameHelper; } }
        public FormInitilize Initilize { get { return initilize; } }

    }

}
