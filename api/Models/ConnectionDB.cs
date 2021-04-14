using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EasyHealthApi.Models
{
    public class ConnectionDB
    {
        public static MySqlConnection connection()
        {
            string connetionString = "server=localhost;port=3306;database=;username=root;password=123";
            MySqlConnection connection = new MySqlConnection(connetionString);

            return connection;
        }
    }
}