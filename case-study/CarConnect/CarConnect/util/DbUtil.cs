using System;

using System.Data.SqlClient;

namespace CarConnect.util
{
    public class DbUtil
    {
        private static readonly string connectionString = "Data Source=RYZEN5\\SQLEXPRESS;Initial Catalog=CarConnect;Integrated Security=True";
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
