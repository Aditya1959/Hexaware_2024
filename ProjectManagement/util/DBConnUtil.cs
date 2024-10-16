using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace ProjectManagementApp.util
{
    public class DBConnUtil
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = DBPropertyUtil.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
