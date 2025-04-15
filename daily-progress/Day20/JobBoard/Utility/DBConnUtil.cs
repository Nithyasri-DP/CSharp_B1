using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace JobBoard.Utility
{
    public class DBConnUtil
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=RYZEN5\\SQLEXPRESS;Initial Catalog=CareerHub;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
