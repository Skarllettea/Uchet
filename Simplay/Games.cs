using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplay
{
    class Games
    {
        MySqlConnectionStringBuilder ConnectionStr;
        MySqlConnection connection;
        public void CreateStrConnection()
        {
            ConnectionStr = new MySqlConnectionStringBuilder();
            ConnectionStr.Server = "localhost";
            ConnectionStr.Port = 3306;
            ConnectionStr.UserID = "root";
            ConnectionStr.Password = "root";
            ConnectionStr.Database = "SimPlay";
        } 
    }
}
