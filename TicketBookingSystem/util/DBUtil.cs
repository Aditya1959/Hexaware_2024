using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.util
{
    public static class DBUtil
    {
        public static SqlConnection GetDBConn()
        {
            // Replace with your actual connection string
            string connectionString = "your_connection_string_here";
            return new SqlConnection(connectionString);
        }
    }
}
