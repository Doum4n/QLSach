using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach
{
    public abstract class DBConnection
    {
        private readonly string connection;
        public DBConnection()
        {
            connection = "SERVER = localhost; DATABASE = myDatabase; UID = root; PASSWORD = pw;";
        }

        /*public MySqlConnection getConnection()
        {
            return new MySqlConnection(connection);
        }*/
    }
}
